using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Medipark.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Domain
{
    public class QualificationHandler : IQualificationHandler
    {
        private readonly IRepository _repository;
        public QualificationHandler(IRepository repository)
        {
            _repository = repository;
        }
        public QualificationViewModel CreateQualification(QualificationViewModel qualification)
        {
            var _qualification = new Qualification();
            _qualification = MapperHelper.Map<Qualification, QualificationViewModel>(_qualification, qualification);
            var query = _repository.AddEntity(_qualification);
            _repository.Save();
            return MapperHelper.Map<QualificationViewModel, Qualification>(qualification, _qualification);
        }

        public QualificationViewModel GetQualificationById(int personId)
        {
            var query = _repository.Search<Qualification>(c => c.PersonId == personId).FirstOrDefault();
            return MapperHelper.Map<QualificationViewModel,Qualification>(new QualificationViewModel(),query);
        }

        public bool UpdateQualification(StaffPayloadViewModel staff)
        {
            try
            {
                var _qualification = new Qualification();
                _qualification = MapperHelper.Map<Qualification, StaffPayloadViewModel>(_qualification, staff);
                _repository.UpdateEntity(_qualification);
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
