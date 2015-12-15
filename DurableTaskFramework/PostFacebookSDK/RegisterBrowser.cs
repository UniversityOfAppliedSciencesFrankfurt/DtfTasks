using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostFacebookSDK
{
    class RegisterBrowser
    {
        /// <summary>
        /// This is a object of Browser form, is a web browser where facebook login page will be loaded.
        /// After giving user's cradentials, in navigated link will be access token
        /// </summary>
        Browser browser = new Browser();
        public string Access_Token { get; set; }
        public string Link { get; set; }
        public RegisterBrowser(string link)
        {
            this.Link = link;
            browser.Load += new EventHandler(this.LinkNavigate);
            browser.ShowDialog();
        }

        private void LinkNavigate(object sender, EventArgs ev)
        {
            // Navigated Event Handler 
            browser.GetWebBroser.Navigated += (b, e) =>
            {
                var navigatedUrl = e.Url.Fragment;
                if (navigatedUrl.Contains("access_token") && navigatedUrl.Contains("#"))
                {
                    browser.Hide();
                    navigatedUrl = (new Regex("#")).Replace(navigatedUrl, "?", 1);
                    this.Access_Token = System.Web.HttpUtility.ParseQueryString(navigatedUrl).Get("access_token");
                    // Console.WriteLine(navigatedUrl);
                }
            };

            // For loading facebook login page in Browser form 
            browser.GetWebBroser.Navigate(Link);
        }
    }
}
