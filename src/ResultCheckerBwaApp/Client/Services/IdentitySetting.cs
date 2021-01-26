using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultCheckerBwaApp.Client.Services
{
    public interface IIdentitySetting
    {
        string Value { get;  }
    }

    public class AspnetIdentitySetting : IIdentitySetting
    {
        public string Value => "AspnetIdentity";
    }

    public class IdentityServerSetting : IIdentitySetting
    {
        public string Value => "IdentityServer";
    }
}
