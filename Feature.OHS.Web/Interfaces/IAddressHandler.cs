using Feature.OHS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
   public interface IAddressHandler
    {
        Address CreateAddress(Address address);
        Address GetAddressById(int id);
        bool UpdateAddress(Address address);
    }
}
