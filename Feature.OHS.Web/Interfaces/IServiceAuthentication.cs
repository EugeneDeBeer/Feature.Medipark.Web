using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IServiveAuthentication
    {
        string GenerateToken(string issuer, string audience, TimeSpan expirationMinutes);
    }
}
