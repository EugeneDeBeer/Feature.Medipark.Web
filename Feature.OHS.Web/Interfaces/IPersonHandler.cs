using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IPersonHandler
    {
        PersonViewModel CreatePerson(PersonViewModel patient);

        bool UpdatePerson(PersonViewModel person);
        Person GetPerson(string idNumber);
        IEnumerable<Person> People { get; }
    }
}
