using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Medipark.Login.Interfaces;

namespace Feature.OHS.Web.Domain
{
    public class PersonHandler : IPersonHandler
    {
        private readonly IRepository _repository;

        public IEnumerable<Person> People { get =>_repository.All<Person>();}

        public PersonHandler(IRepository repository)
        {
            _repository = repository;
        }
        public PersonViewModel CreatePerson(PersonViewModel person)
        {
            var _person = new Person();
            _person = MapperHelper.Map<Person, PersonViewModel>(_person, person);

            //var validatePerson = _repository.Search<Person>(c => c.PersonId.Equals(_person.PersonId)).FirstOrDefault();
            var validatePerson = _repository.Search<Person>(c => c.PersonId == _person.PersonId).FirstOrDefault();
            if (validatePerson == null)
            {
                var query = _repository.AddEntity(_person);
                _repository.Save();
                return MapperHelper.Map<PersonViewModel, Person>(person, query);
            }
            return null;
        }


        public bool UpdatePerson(PersonViewModel person)
        {
            try
            {
                //var _friend = GetFriend(friend.FriendId);
                //if (_friend == null) return false;

                var _person = new Person();

                var newPerson = MapperHelper.Map<Person, PersonViewModel>(_person, person);

                var query = _repository.UpdateEntity<Person>(newPerson);
                _repository.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Person GetPerson(string idNumber)
        {
            try
            {
                return _repository.Search<Person>(f => f.IdNumber == idNumber).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}