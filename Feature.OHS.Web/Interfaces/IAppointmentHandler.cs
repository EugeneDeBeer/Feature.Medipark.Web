using Feature.OHS.Web.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
   public interface IAppointmentHandler
    {
       IEnumerable<AppointmentViewModel> GetAppointments { get; }
       AppointmentViewModel GetAppointmentByIdNumber(string id);
       AppointmentViewModel Create(AppointmentViewModel appointmentViewModel);
       dynamic Update(AppointmentViewModel appointmentViewModel); 
    }
}
