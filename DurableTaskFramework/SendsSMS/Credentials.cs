using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendsSMS
{
    public class Credentials
    {
        #region Public Properties
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string SMSTo { get; set; }
        public string MBody { get; set; }
        #endregion
    }
}
