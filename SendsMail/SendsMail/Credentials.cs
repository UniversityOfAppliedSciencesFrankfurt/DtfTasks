using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendsMail
{
    /// <summary>
    /// This class will have all of the credential of user.
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// That will contain smtp address for creating smtp client
        /// </summary>
        public string smtpAddress { get; set; }
        /// <summary>
        /// This public property will have the email address, from which mail will be sent.
        /// </summary>
        public string eMailFrom { get; set; }
        /// <summary>
        /// This is sender email password
        /// </summary>
        public string passWord { get; set; }
        /// <summary>
        /// Contails email address, to which have to send email
        /// </summary>
        public string eMailTo { get; set; }
        /// <summary>
        /// That will contains message 
        /// </summary>
        public string mBody { get; set; }
        /// <summary>
        /// This is the message subject
        /// </summary>
        public string eSubject { get; set; }
    }
}
