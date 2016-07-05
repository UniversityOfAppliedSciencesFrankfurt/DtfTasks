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
using DropboxRestAPI;
using System.IO;

namespace DaenetIntegration
{

   

    class UploadTask :TaskActivity<string,Task<string>>
    {
        protected override async Task<string> Execute(TaskContext context, string input)
        {
            Console.WriteLine("AuthToke {0}", input);
            var options = new Options();
            options.AccessToken = input;
            var client = new Client(options);
            var rootFolder = await client.Core.Metadata.MetadataAsync("/", list: true);
            foreach (var folder in rootFolder.contents)
            {
                Console.WriteLine(" -> {0}: {1} (Id: {2})",
                    folder.is_dir ? "Folder" : "File", folder.Name, folder.path);
            }
            string filename = "test.jpg";
            string path = Environment.CurrentDirectory + @"\"+filename;
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                Console.WriteLine(stream.Length);
                var uploadedFile = await client.Core.Metadata.FilesPutAsync(stream, rootFolder.path + "/"+filename,null,true);
                Console.WriteLine("File Uploaded");
            }
            
           
            return "Test";

        }
    }
}
