using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IWard
    {
        dynamic CreateWard(WardViewModel ward);
        dynamic CreateBed(BedViewModel bed);
        //dynamic CreateRoom()
        dynamic EditWard(WardViewModel ward);
        dynamic EditBed(BedViewModel bed);
    }
}
