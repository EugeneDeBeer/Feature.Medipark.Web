using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class NursesController : Controller
    {
        private readonly INurseHandler nurseHandler;

        public NursesController(INurseHandler nurseHandler)
        {
            this.nurseHandler = nurseHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string GetNurses()
        {
            try
            {
                var patients = nurseHandler.GetNurses();

                return patients;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}