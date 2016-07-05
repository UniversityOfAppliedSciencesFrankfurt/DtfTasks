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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
namespace Daenet.Integration
{
    class UploadVideoTask: TaskActivity<string,string> 
    {
        protected override string Execute(TaskContext context, string accessToken)
        {
            var fileToUpload = @"C:\Program Files\Common Files\Microsoft Shared\ink\en-US\delete.avi";
            var uploadUrl = UploadVideo.GetFileUploadUrl(accessToken);

            var response = UploadVideo.GetFileUploadResponse(fileToUpload, accessToken, uploadUrl);
            var uploadedResponse = UploadVideo.PublishVideo(response, accessToken);
            Console.WriteLine("File has been uploaded successfully!!");
            Console.WriteLine("Press any key to quit.");
            return null;

        }
    }
}
