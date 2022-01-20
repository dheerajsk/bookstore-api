using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ehealthcare.Api
{
    public class AuthUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccessToken { get; set; }
        public long ID { get; set; }
        public bool IsAdmin { get; set; }
    }
}
