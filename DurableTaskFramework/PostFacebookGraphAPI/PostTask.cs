using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using System.Net;
using System.IO;
namespace PostFacebookGraphAPI
{
    /// <summary>
    /// Post on facebook wall using Graph API
    /// </summary>
   public class PostTask : TaskActivity<Tuple<string,string>, string>
    {
        /// <summary>
        /// This will collect access token from AccessTokenTask and will post messge on facebook wall using this access token
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input">Provides static methods for creating tuple objects. It is work like a dictionary or list 
        /// but not a dictonary and list</param>
        /// <returns>If there any error that will return otherwise it will return null</returns>
        protected override string Execute(TaskContext context, Tuple<string, string> input)
        {
            var outPut = string.Empty;
            //string postingUrl = @"https://graph.facebook.com/v2.3/me/feed?message=" + messageBody + "&access_token=" + token;
            string postUrl = string.Format("https://graph.facebook.com/v2.3/me/feed?message={0}&access_token={1}", input.Item1, input.Item2);
            try
            {
                // Created a Http Web Request for POST Method
                HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
                httpWebRequest.Method = "POST";
                using (HttpWebResponse webResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    
                    StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                    
                }
            }
            catch (Exception e)
            {
                outPut = e.ToString();
            }
            return outPut;
        }        
    }
}
