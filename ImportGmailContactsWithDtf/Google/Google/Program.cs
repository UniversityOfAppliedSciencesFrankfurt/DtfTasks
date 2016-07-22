//=======================================================================================
// Copyright © daenet GmbH Frankfurt am Main, University of Applied Sciences Frankfurt am Main
//
// LICENSED UNDER THE APACHE LICENSE, VERSION 2.0 (THE "LICENSE"); YOU MAY NOT USE THESE
// FILES EXCEPT IN COMPLIANCE WITH THE LICENSE. YOU MAY OBTAIN A COPY OF THE LICENSE AT
// http://www.apache.org/licenses/LICENSE-2.0
// UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING, SOFTWARE DISTRIBUTED UNDER THE
// LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED. SEE THE LICENSE FOR THE SPECIFIC LANGUAGE GOVERNING
// PERMISSIONS AND LIMITATIONS UNDER THE LICENSE.
//=======================================================================================

using System;
using Google.GData.Client;
using Google.Contacts;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using System.Threading;

namespace Daenet.Integration
{
    class Program
    {
        public static OAuth2Parameters MainFunction()
        {
            string App_Name = "Gapp";
            string clientId = "389629385836-pujhinaqlnnj257u18db5ifreklg8p44.apps.googleusercontent.com";
            
            string clientSecret = "Js4RrsmYoNRSftnRPM9wZgR-";
            OAuth2Parameters parameters = new OAuth2Parameters();

            string[] scopes = new string[] { "https://www.googleapis.com/auth/contacts.readonly" };
            // view your basic profile info.
            try
            {
                // Use the current Google .net client library to get the Oauth2 stuff.
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                } , scopes, App_Name , CancellationToken.None , new FileDataStore("test")).Result;

                // Translate the Oauth permissions to something the old client libray can read
                 //parameters = new OAuth2Parameters();
                parameters.AccessToken = credential.Token.AccessToken;
                parameters.RefreshToken = credential.Token.RefreshToken;
                //RunContactsSample(parameters);
                //Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }
            return parameters;

        }

        public static void RunContactsSample(OAuth2Parameters parameters)
        {
            try
            {
                RequestSettings settings = new RequestSettings("Google contacts", parameters);
                ContactsRequest cr = new ContactsRequest(settings);
                Feed<Contact> f = cr.GetContacts();


                Console.WriteLine("Gmail Contacts::");
                foreach (Contact c in f.Entries)
                {
                    
                    Console.WriteLine(c.Name.FullName);

                }
            }
            catch (Exception a)
            {
                Console.WriteLine("A Google Apps error occurred.");
                Console.WriteLine();
            }
        }
    }
}
