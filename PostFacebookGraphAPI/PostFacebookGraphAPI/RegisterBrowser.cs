using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostFacebookGraphAPI
{
    class RegisterBrowser
    {
        /// <summary>
        /// This is a object of Browser form, is a web browser where facebook login page will be loaded.
        /// After giving user's cradentials, in navigated link will be access token
        /// </summary>
        Browser browser = new Browser();

        // Will have access token
        public string Access_Token { get; set; }
        public string Link { get; set; }
        public RegisterBrowser(string link)
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
            browser.GetWebBroser.Navigate(Link);
        }
    }
}
