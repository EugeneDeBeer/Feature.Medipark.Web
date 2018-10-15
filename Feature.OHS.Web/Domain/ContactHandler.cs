using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Medipark.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Domain
{
    public class ContactHandler : IContactHandler
    {
        private readonly IRepository _repository; 

        public ContactHandler(IRepository repository )
        {
            _repository = repository;
        }

        public Contact CreateContact(Contact contact)
        {
            try
            {
            var  results  =  _repository.AddEntity(contact);
                _repository.Save();
                return results;
            }
            catch (Exception)
            {

                throw;
            }
            
           
        }

        public Contact GetContactById(int id)
        {
            var query = _repository.Search<Contact>(c => c.PersonId == id).FirstOrDefault();
            if (query == null) return null;
            return query;
        }

        public bool UpdateContact(Contact contact)
        {
            try
            {
               
                _repository.UpdateEntity(contact);
                _repository.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
