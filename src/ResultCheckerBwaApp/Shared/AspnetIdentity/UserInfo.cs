using System;
using System.Collections.Generic;
using System.Text;

namespace ResultCheckerBwaApp.Shared.AspnetIdentity
{
    public class UserInfo
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        // public Dictionary<string, string> ExposedClaims { get; set; }
        public List<KeyValuePair<string, string>> ExposedClaims { get; set; }
        public List<KeyValuePair<string, string>> Claims { get; set; }

    }
}
