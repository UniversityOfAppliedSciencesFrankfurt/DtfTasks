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
using DTFTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Daenet.Integration
{

   

    class BrowserManager
    {
        /// <summary>
        /// This is a object of Browser form, is a web browser where facebook login page will be loaded.
        /// After giving user's cradentials, in navigated link will be access token
        /// </summary>
        BrowserForm browser = new BrowserForm();

        // Will have access token
        public string Access_Token { get; set; }
        public string Link { get; set; }
        public BrowserManager(string link)
        {
            this.Link = link;
            browser.Load += new EventHandler(this.LinkNavigate);
            browser.ShowDialog();
        }

        /// <summary>
        /// That will display facebook login page in browser form and will collect access token by using Navigated 
        /// Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void LinkNavigate(object sender, EventArgs ev)
        {
            browser.webBrowser.Navigated += (b, e) =>
            {
                var navigatedUrl = e.Url.OriginalString;
                if (navigatedUrl.Contains("code="))
                {
                    browser.Hide();
                    
                    this.Access_Token = navigatedUrl.Substring(navigatedUrl.LastIndexOf("?") + 6);
                    //this.Access_Token = System.Web.HttpUtility.ParseQueryString(navigatedUrl).Get("access_token");
                    
                }
            };
            browser.webBrowser.Navigate(Link);
        }
    }
}
