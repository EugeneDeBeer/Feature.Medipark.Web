using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IFriendHandler
    {
        FriendViewModel CreateFriend(FriendViewModel friend);

        bool UpdateFriend(PatientPayloadViewModel friend);//, string userId);

        IEnumerable<Friend> GetFriends();

        Friend GetFriend(int id);

        //  void StallFriend(Friend friend);
    }
}
