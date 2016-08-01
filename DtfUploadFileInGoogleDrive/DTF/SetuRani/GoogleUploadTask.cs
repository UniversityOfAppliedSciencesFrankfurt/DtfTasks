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
using DurableTask;
using Google.Apis.Drive.v2.Data;


namespace Daenet.Integration
{
    class GoogleUploadTask:TaskActivity<string,string>
    {
        
        protected override string Execute(TaskContext context, string input)
        {
            // This is the ID of the directory 

            // Listing files with search.  
            // This searches for a directory with the name DiamtoSample
            string Q = "title = 'SETUDTF' and mimeType = 'application/vnd.google-apps.folder'";
            IList<File> _Files = DaimtoGoogleDriveHelper.GetFiles(Program.service, Q);

            foreach (File item in _Files)
            {
                Console.WriteLine(item.Title + " " + item.MimeType);
            }

            // If there isn't a directory with this name lets create one.
            if (_Files.Count == 0)
            {
                _Files.Add(DaimtoGoogleDriveHelper.createDirectory(Program.service, "SETUDTF", "SETUDTF", "root"));
            }

            // We should have a directory now because we either had it to begin with or we just created one.
            if (_Files.Count != 0)
            {

                // This is the ID of the directory 
                string directoryId = _Files[0].Id;
                var path = Environment.CurrentDirectory + @"\clc.jpg";
                
                //Upload a file
                File newFile = DaimtoGoogleDriveHelper.uploadFile(Program.service, path, directoryId);
                Console.WriteLine("File Uploaded: " + path);
            }

            return "Done";
        }

        
    }

}
