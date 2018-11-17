using Feature.OHS.Web.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
   public interface IAPIIntegration
    {
        APIResponse ResponseFromAPIPost<T>(string serviceName, string method, T passedObject, string apiUrl, bool authenticate) where T : class;
        APIResponse ResponseFromAPIPost<T>(string serviceName, string method, T passedObject, string apiUrl, bool authenticate, string Customtoken) where T : class;
        APIResponse ResponseFromAPIGet(string serviceName, string method, string apiUrl, string authHeader);
    }
}
