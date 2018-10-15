using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;


namespace Feature.OHS.Web.Domain
{
    public class StaffHandler : IStaffHandler
    {
        private IRepository _repository;
        private IQualificationHandler _qualificationHandler;
        private IDocterHandler _docterHandler;
        private INurseHandler _nurseHandler;
        private IPersonHandler _personHandler;
        private IContactHandler _contactHandler;
        private IAddressHandler _addressHandler;

        public StaffHandler(IRepository repository, IPersonHandler personHandler, IQualificationHandler qualificationHandler,
            IDocterHandler docterHandler, INurseHandler nurseHandler, IAddressHandler addressHandler, IContactHandler contactHandler)
        {
            _repository = repository;
            _docterHandler = docterHandler;
            _qualificationHandler = qualificationHandler;
            _nurseHandler = nurseHandler;
            _personHandler = personHandler;
            _addressHandler = addressHandler;
            _contactHandler = contactHandler;
        }

        public StaffPayloadViewModel CreateStaff(StaffPayloadViewModel staff)
        {
            var _contact = new Contact();
            var _address = new Address();
            var _staff = new Qualification();
            _staff = MapperHelper.Map<Qualification, StaffPayloadViewModel>(_staff, staff);
            _contact = MapperHelper.Map<Contact, StaffPayloadViewModel>(_contact, staff);
            _address = MapperHelper.Map<Address, StaffPayloadViewModel>(_address, staff);
            _contactHandler.CreateContact(_contact);
            _addressHandler.CreateAddress(_address);
            var query = _repository.AddEntity(_staff);
            _repository.Save();
            return MapperHelper.Map<StaffPayloadViewModel, Qualification>(staff, query);
        }

        public StaffPayloadViewModel GetStaffbyPersonId(string idNumber)
        {
            if (idNumber != null)
            {
                var _person = _personHandler.GetPerson(idNumber);
                var _doctor = _docterHandler.GetDoctorById(_person.PersonId);
                var _nurse = _nurseHandler.GetNurseById(_person.PersonId);
                var _qualification = _qualificationHandler.GetQualificationById(_person.PersonId);

                var staff = new StaffPayloadViewModel();
                if (_nurse == null)
                {
                    staff = MapperHelper.Map<StaffPayloadViewModel, DoctorViewModel>(staff, _doctor);
                }
                else if (_doctor == null)
                {
                    staff = MapperHelper.Map<StaffPayloadViewModel, NurseViewModel>(staff, _nurse);
                }

                if (staff != null)
                {
                    var payload = new StaffPayloadViewModel()
                    {
                        FirstName = _person.FirstName,
                        LastName = _person.LastName,
                        DateOfBirth = _person.DateOfBirth,
                        Country = _person.Country,
                        Ethnicity = _person.Ethnicity,
                        Email = _person.Email,
                        MaritalStatus = _person.MaritalStatus,
                        IdNumber = _person.IdNumber,
                        Initials = _person.Initials,
                        Religion = _person.Religion,
                        Title = _person.Title,
                        ResAddress1 = _person.ResAddress1,
                        ResAddress2 = _person.ResAddress2,
                        ResPostCode = _person.ResPostCode,
                        BusName = _person.BusName,
                        GenderId = _person.GenderId,
                        PassportNumber = _person.PassportNumber,
                        MiddleName = _person.MiddleName,
                        BusAddress = _person.BusAddress,
                        ResSurbub = _person.ResSurbub,
                        HomeTel = _person.HomeTel,
                        HPCNARegistrationNumber = staff.HPCNARegistrationNumber,
                        PracticeNumber = staff.PracticeNumber,
                        YearObtained = _qualification.YearObtained,
                        YearsInPractice = staff.YearsInPractice,
                        Institution = _qualification.Institution,
                        NurseId = staff.NurseId,
                        DoctorId = staff.DoctorId,
                        NameOfDegree = _qualification.NameOfDegree,
                        QualificationId = _qualification.QualificationId,
                        PersonId = _person.PersonId
                    };

                    return payload;
                }
            }
            return null;
        }
    }
}