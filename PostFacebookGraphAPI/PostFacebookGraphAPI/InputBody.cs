using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostFacebookGraphAPI
{
    class InputBody
    {
        /// <summary>
        /// Contains Access Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// That will contain message what will be post on facebook wall
        /// </summary>
        public string Message { get; set; }
    }
}
