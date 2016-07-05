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

using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Daenet.Integration
{
    public class AccessToken
    {

        public static string GetAccessToken()
        {
            var request = WebRequest.Create("https://api.dailymotion.com/oauth/token");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            var requestString = String.Format("grant_type=password&client_id={0}&client_secret={1}&username={2}&password={3}",
                HttpUtility.UrlEncode(SettingsProvider.Key),
                HttpUtility.UrlEncode(SettingsProvider.Secret),
                HttpUtility.UrlEncode(SettingsProvider.Username),
                HttpUtility.UrlEncode(SettingsProvider.Password));

            var requestBytes = Encoding.UTF8.GetBytes(requestString);

            var requestStream = request.GetRequestStream();

            requestStream.Write(requestBytes, 0, requestBytes.Length);

            var response = request.GetResponse();

            var responseStream = response.GetResponseStream();
            string responseString;
            using (var reader = new StreamReader(responseStream))
            {
                responseString = reader.ReadToEnd();
            }

            var oauthResponse = JsonConvert.DeserializeObject<OAuthResponse>(responseString);

            return oauthResponse.access_token;
        }

        public static void Authorize(string accessToken)
        {
            var authorizeUrl = String.Format("https://api.dailymotion.com/oauth/authorize?response_type=code&client_id={0}&scope=read+write+manage_videos+delete&redirect_uri={1}",
                HttpUtility.UrlEncode(SettingsProvider.Key),
                HttpUtility.UrlEncode(SettingsProvider.CallbackUrl));

           Console.WriteLine("We need permissions to upload. Press enter to open web browser.");
            Console.ReadLine();

            Process.Start(authorizeUrl);

            var client = new WebClient();
            client.Headers.Add("Authorization", "OAuth " + accessToken);
            
            Console.WriteLine("Press enter once you have authenticated and been redirected to your callback URL");
            Console.ReadLine();
        }
    }
}
