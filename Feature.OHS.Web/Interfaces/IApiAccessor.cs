using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IApiAccessor
    {
        HttpClient GetHttpClient();
    }
}
