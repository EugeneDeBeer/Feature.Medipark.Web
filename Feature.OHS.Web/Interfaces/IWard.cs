using Feature.OHS.Web.ViewModels;
using Feature.OHS.Web.ViewModels.Lists;
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
        dynamic CreateRoom(RoomViewModel room);
        List<WardListViewModel> GetWardList(int HospitalId);
        dynamic EditRoom(RoomViewModel room);
        dynamic EditWard(WardViewModel ward);
        dynamic EditBed(BedViewModel bed);
        List<RoomListViewModel> GetRoomList(int wardId);
    }
}
