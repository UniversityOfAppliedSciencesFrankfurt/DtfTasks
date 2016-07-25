using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statusupdate
{
    class Program
    {
        static void Main(string[] args)
        {
            if (HttpContext.Current.Session["AccessToken"] != null)
            {
                var authorization = new WebOAuthAuthorization(new TokenManager(), HttpContext.Current.Session["AccessToken"].ToString());
                LinkedInService service = new LinkedInService(authorization);
                service.CreateShare("My test comment", LinkedIn.ServiceEntities.VisibilityCode.ConnectionsOnly);
            }
        }
    }
}
