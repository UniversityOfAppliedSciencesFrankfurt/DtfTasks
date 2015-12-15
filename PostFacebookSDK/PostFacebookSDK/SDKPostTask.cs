using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using System.Net;
using System.IO;
using Facebook;

namespace PostFacebookSDK
{
    /// <summary>
    /// Póst on facebook wall using facebook C# sdk
    /// </summary>
    public class SDKPostTask : TaskActivity<Tuple<string,string>, string>
    {
        protected override string Execute(TaskContext context, Tuple<string, string> input)
        {
            var outPut = string.Empty;

            // Created facebook client for posting on facebook wall

            var facebookClient = new FacebookClient(input.Item2);
            facebookClient.Post("me/feed", new { message = input.Item1 });
            return outPut;
        }        
    }
}
