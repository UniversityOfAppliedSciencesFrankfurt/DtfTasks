using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenManager
{
    class Program
    {



        private static string sessionCookie = string.Empty;
        private static CookieContainer cc = new CookieContainer(2);
        private static HttpWebResponse wResp;
        private static HttpWebRequest wr;

        private enum linkedin
        {
            GetAllGroups,
            PostMessage,
            Invite,
            
        }



        static void Main(string[] args)
        {
            try
            {
                const string CLIENT_ID = "77a2p4ojrc8e7h";
                const string CLIENT_SECRET = "CUOk0TrIfLjiLUvQ";
                const string REDIR_URL = "http://linkedin.de";
            }

