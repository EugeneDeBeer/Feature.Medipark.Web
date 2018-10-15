using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Domain
{
    public class AddressHandler : IAddressHandler
    {
        private readonly IRepository _repository;
        public AddressHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Address CreateAddress(Address address)
        {
            try
            {
                var results = _repository.AddEntity(address);
                _repository.Save();
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Address GetAddressById(int id)
        {

            var query = _repository.Search<Address>(c => c.PersonId == id).FirstOrDefault();
            if (query == null) return null;
            return query;
        }

        public bool UpdateAddress(Address address)
        {
            try
            {

                _repository.UpdateEntity(address);
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
