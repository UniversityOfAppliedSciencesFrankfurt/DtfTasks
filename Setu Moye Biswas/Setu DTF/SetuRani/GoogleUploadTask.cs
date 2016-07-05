using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Daimto.Drive.api;
using Google.Apis.Drive.v2.Data;


namespace SetuRani
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
