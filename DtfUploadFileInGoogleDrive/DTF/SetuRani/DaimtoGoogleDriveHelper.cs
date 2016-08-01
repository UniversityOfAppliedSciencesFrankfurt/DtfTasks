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
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;

namespace Daenet.Integration
{
    public class DaimtoGoogleDriveHelper
    {

        /// <summary>
        /// Download a file
        /// Documentation: https://developers.google.com/drive/v2/reference/files/get
        /// </summary>
        /// <param name="_service">a Valid authenticated DriveService</param>
        /// <param name="_fileResource">File resource of the file to download</param>
        /// <param name="_saveTo">location of where to save the file including the file name to save it as.</param>
        /// <returns></returns>
       


        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        /// <summary>
        /// Uploads a file
        /// Documentation: https://developers.google.com/drive/v2/reference/files/insert
        /// </summary>
        /// <param name="_service">a Valid authenticated DriveService</param>
        /// <param name="_uploadFile">path to the file to upload</param>
        /// <param name="_parent">Collection of parent folders which contain this file. 
        ///                       Setting this field will put the file in all of the provided folders. root folder.</param>
        /// <returns>If upload succeeded returns the File resource of the uploaded file 
        ///          If the upload fails returns null</returns>
        public static File uploadFile(DriveService _service, string _uploadFile, string _parent) {
            
            if (System.IO.File.Exists(_uploadFile))
            {
                File body = new File();
                body.Title = System.IO.Path.GetFileName(_uploadFile);
                body.Description = "File uploaded by Diamto Drive Sample";
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
                                
                // File's content.
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, GetMimeType(_uploadFile));
                    //request.Convert = true;   // uncomment this line if you want files to be converted to Drive format
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return null;
                }
            }
            else {
                Console.WriteLine("File does not exist: " + _uploadFile);
                return null;
            }           
        
        }

        /// <summary>
        /// Updates a file
        /// Documentation: https://developers.google.com/drive/v2/reference/files/update
        /// </summary>
        /// <param name="_service">a Valid authenticated DriveService</param>
        /// <param name="_uploadFile">path to the file to upload</param>
        /// <param name="_parent">Collection of parent folders which contain this file. 
        ///                       Setting this field will put the file in all of the provided folders. root folder.</param>
        /// <param name="_fileId">the resource id for the file we would like to update</param>                      
        /// <returns>If upload succeeded returns the File resource of the uploaded file 
        ///          If the upload fails returns null</returns>
        public static File updateFile(DriveService _service, string _uploadFile, string _parent,string _fileId)
        {

            if (System.IO.File.Exists(_uploadFile))
            {
                File body = new File();
                body.Title = System.IO.Path.GetFileName(_uploadFile);
                body.Description = "File updated by Diamto Drive Sample";
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };

                // File's content.
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.UpdateMediaUpload request = _service.Files.Update(body, _fileId, stream, GetMimeType(_uploadFile));
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("File does not exist: " + _uploadFile);
                return null;
            }

        }


        /// <summary>
        /// Create a new Directory.
        /// Documentation: https://developers.google.com/drive/v2/reference/files/insert
        /// </summary>
        /// <param name="_service">a Valid authenticated DriveService</param>
        /// <param name="_title">The title of the file. Used to identify file or folder name.</param>
        /// <param name="_description">A short description of the file.</param>
        /// <param name="_parent">Collection of parent folders which contain this file. 
        ///                       Setting this field will put the file in all of the provided folders. root folder.</param>
        /// <returns></returns>
        public static File createDirectory(DriveService _service, string _title, string _description, string _parent) {

            File NewDirectory = null;

            // Create metaData for a new Directory
            File body = new File();
            body.Title = _title;
            body.Description = _description;
            body.MimeType = "application/vnd.google-apps.folder";            
            body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
            try
            {
                FilesResource.InsertRequest request = _service.Files.Insert(body);
                NewDirectory = request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return NewDirectory;
        }


        /// <summary>
        /// List all of the files and directories for the current user.  
        /// 
        /// Documentation: https://developers.google.com/drive/v2/reference/files/list
        /// Documentation Search: https://developers.google.com/drive/web/search-parameters
        /// </summary>
        /// <param name="service">a Valid authenticated DriveService</param>        
        /// <param name="search">if Search is null will return all files</param>        
        /// <returns></returns>
        public static IList<File> GetFiles(DriveService service, string search)
        {

            IList<File> Files = new List<File>();

            try
            {
                //List all of the files and directories for the current user.  
                // Documentation: https://developers.google.com/drive/v2/reference/files/list
                FilesResource.ListRequest list = service.Files.List();
                list.MaxResults = 1000;
                if (search != null)
                {
                    list.Q = search;
                }
                FileList filesFeed = list.Execute();

                //// Loop through until we arrive at an empty page
                while (filesFeed.Items != null)
                {
                    // Adding each item  to the list.
                    foreach (File item in filesFeed.Items)
                    {
                        Files.Add(item);
                    }

                    // We will know we are on the last page when the next page token is
                    // null.
                    // If this is the case, break.
                    if (filesFeed.NextPageToken == null)
                    {
                        break;
                    }

                    // Prepare the next page of results
                    list.PageToken = filesFeed.NextPageToken;

                    // Execute and process the next page request
                    filesFeed = list.Execute();
                }
            }
            catch (Exception ex) {
                // In the event there is an error with the request.
                Console.WriteLine(ex.Message);                            
            }
            return Files;
        }


    }
}
