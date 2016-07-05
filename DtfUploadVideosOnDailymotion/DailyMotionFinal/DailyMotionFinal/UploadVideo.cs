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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Daenet.Integration
{
   public class UploadVideo
    {

       public static UploadResponse GetFileUploadResponse(string fileToUpload, string accessToken, string uploadUrl)
        {
            var client = new WebClient();
            client.Headers.Add("Authorization", "OAuth " + accessToken);

            var responseBytes = client.UploadFile(uploadUrl, fileToUpload);

            var responseString = Encoding.UTF8.GetString(responseBytes);

            var response = JsonConvert.DeserializeObject<UploadResponse>(responseString);

            return response;
        }
        public static string GetFileUploadUrl(string accessToken)
        {
            var client = new WebClient();
            client.Headers.Add("Authorization", "OAuth " + accessToken);

            var urlResponse = client.DownloadString("https://api.dailymotion.com/file/upload");

            var response = JsonConvert.DeserializeObject<UploadRequestResponse>(urlResponse).upload_url;

            return response;
        }
        public static UploadedResponse PublishVideo(UploadResponse uploadResponse, string accessToken)
        {
            var request = WebRequest.Create("https://api.dailymotion.com/me/videos?url=" + HttpUtility.UrlEncode(uploadResponse.url));
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", "OAuth " + accessToken);

            var requestString = String.Format("title={0}&tags={1}&channel={2}&published={3}",
                HttpUtility.UrlEncode("some title"),
                HttpUtility.UrlEncode("tag1"),
                HttpUtility.UrlEncode("news"),
                HttpUtility.UrlEncode("true"));

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

            var uploadedResponse = JsonConvert.DeserializeObject<UploadedResponse>(responseString);
            return uploadedResponse;
        }
    }
}
