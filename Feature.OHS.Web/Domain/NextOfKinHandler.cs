using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Medipark.Login.Interfaces;
using System;
using System.Linq;

namespace Feature.OHS.Web.Domain
{
    public class NextOfKinHandler : INextOfKinHandler
    {
        private IRepository _repository;

        public NextOfKinHandler(IRepository repository)
        {
            _repository = repository;
        }

        public PatientPayloadViewModel CreateNextOfKin(PatientPayloadViewModel nextOfKin, int id)
        {
            
            if (nextOfKin != null)
            {
                var nok = new Nextofkin
                {
                    FirstName = nextOfKin.NokName,
                    LastName = nextOfKin.NokSurname,
                    Email = nextOfKin.NokEmail,
                    Cellphone = nextOfKin.Cellphone,
                    PatientId = id,
                    Telephone = nextOfKin.Telephone,
                    Relation = nextOfKin.NokRelationship
                };
                _repository.AddEntity(nok);
                _repository.Save();
                return nextOfKin;
            }
            else
            {
                return null;
            }
        }

        public NextOfKinViewModel GetNextOfKinByPatientId(int PatientId)
        {
            var query = _repository.Search<Nextofkin>(x => x.PatientId == PatientId).FirstOrDefault(); // need to find the best way to search and return result. This will be modified base on the new table structure to be implemented
            if (query == null)
            {
                return null;
            }

            return MapperHelper.Map<NextOfKinViewModel, Nextofkin>(new NextOfKinViewModel(), query);
        }

    
        public bool UpdateNextOfKin(PatientPayloadViewModel nextOfKin)
        {
            try
            {
                var _nok = new Nextofkin();
                _nok = MapperHelper.Map<Nextofkin, PatientPayloadViewModel>(_nok, nextOfKin);
                _repository.UpdateEntity(_nok);
                _repository.Save();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
    }
}