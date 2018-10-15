using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Feature.OHS.Web.Interfaces;
using System;
using System.Linq;

namespace Feature.OHS.Web.Domain
{
    public class DoctorHandler : IDocterHandler
    {
        private readonly IRepository _repository;

        public DoctorHandler(IRepository repository)
        {
            _repository = repository;
        }

        public StaffPayloadViewModel CreateDoctor(StaffPayloadViewModel doctor)
        {
            var _doctor = new Doctor();
            var existing = _repository.Find<Doctor>(doctor.PersonId);
            if (existing == null || !existing.HPCNARegistrationNumber.Equals(""))
            {
                _doctor = MapperHelper.Map<Doctor, StaffPayloadViewModel>(_doctor, doctor);
                var query = _repository.AddEntity(_doctor);
                _repository.Save();
                return MapperHelper.Map<StaffPayloadViewModel, Doctor>(doctor, query);
            }
            return null;
        }

        public DoctorViewModel GetDoctorById(int id)
        {
            var query = _repository.Search<Doctor>(c => c.PersonId == id).FirstOrDefault();
            if (query == null) return null;
            return MapperHelper.Map<DoctorViewModel,Doctor>(new DoctorViewModel(),query);
        }

        public bool IsReferentialDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDoctor(StaffPayloadViewModel doctor)
        {
            var _doctor = new Doctor();
            try
            {
                _doctor = MapperHelper.Map<Doctor, StaffPayloadViewModel>(_doctor, doctor);
                _repository.UpdateEntity(_doctor);
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