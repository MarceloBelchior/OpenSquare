using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSquare
{
    public class Authorize : AuthorizeAttribute
    {
        public Authorize() : base()
        {

        }
        
    }
    public class AppSettings
    {
        public string Auth0Domain { get; set; }
        public string Auth0ClientId { get; set; }
        public string Auth0ClientSecret { get; set; }
        public string Auth0CertificateData { get; set; }
    }
}
