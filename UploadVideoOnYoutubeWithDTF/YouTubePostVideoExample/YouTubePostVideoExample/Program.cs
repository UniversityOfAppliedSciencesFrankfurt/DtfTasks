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



using Google.GData.Client;
using Google.GData.Extensions.Location;
using Google.GData.Extensions.MediaRss;
using Google.GData.YouTube;
using Google.YouTube;

namespace Daenet.Integration
{
    class Program
    {
        private static object request;

        static void Main(string[] args)
        {
            Video newVideo = new Video();
            newVideo.Title = "My Test Movie";
            newVideo.Tags.Add(new MediaCategory("Autos", YouTubeNameTable.CategorySchema));
            newVideo.Keywords = "cars, funny";
            newVideo.Description = "My description";
            newVideo.YouTubeEntry.Private = false;
            newVideo.Tags.Add(new MediaCategory("mydevtag, anotherdevtag",
              YouTubeNameTable.DeveloperTagSchema));

            newVideo.YouTubeEntry.Location = new GeoRssWhere(37, -122);
            // alternatively, you could just specify a descriptive string
            // newVideo.YouTubeEntry.setYouTubeExtension("location", "Mountain View, CA");

            newVideo.YouTubeEntry.MediaSource = new MediaFileSource("c:\\file.mov",
              "video/quicktime");
            Video createdVideo = request.Upload(newVideo);
        }
    }
}
