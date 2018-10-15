using Feature.OHS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IContactHandler
    {
        Contact CreateContact(Contact contactViewModel);
        Contact GetContactById(int id);
        bool UpdateContact(Contact cmv);
    }
}
