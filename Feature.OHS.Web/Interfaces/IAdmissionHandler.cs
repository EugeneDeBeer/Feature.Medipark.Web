﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.ViewModels;

namespace Feature.OHS.Web.Interfaces
{
    public interface IAdmissionHandler
    {
        AdmissionViewModel AddAdmission(AdmissionViewModel admission);
    }
}
