using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Feature.OHS.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Domain
{
    public class NurseHandler: INurseHandler
    {
        private readonly IRepository _repository;
        public NurseHandler(IRepository repository)
        {
            _repository = repository;
        }

        public StaffPayloadViewModel CreateNurse(StaffPayloadViewModel nurse)
        {
            var _nurse = new Nurse();
            var existing = _repository.Find<Nurse>(nurse.PersonId);
            if (existing == null)
            {
                _nurse = MapperHelper.Map<Nurse, StaffPayloadViewModel>(_nurse, nurse);
                var query = _repository.AddEntity(_nurse);
                _repository.Save();
                return MapperHelper.Map<StaffPayloadViewModel, Nurse>(nurse, query);
            }
            return null;
        }

        public NurseViewModel GetNurseById(int id) {

            var query = _repository.Search<Nurse>(x => x.PersonId == id).FirstOrDefault(); // need to find the best way to search and return result. This will be modified base on the new table structure to be implemented
            if (query == null)
            {
                return null;
            }
            return MapperHelper.Map<NurseViewModel, Nurse>(new NurseViewModel(), query);
        }

        public bool UpdateNurse(StaffPayloadViewModel nurse)
        {
            var _nurse = new Nurse();
            try
            {
                _nurse = MapperHelper.Map<Nurse, StaffPayloadViewModel>(_nurse, nurse);
                _repository.UpdateEntity(_nurse);
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
