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
    public class FriendHandler : IFriendHandler
    {
        public readonly IRepository _repository;

        public FriendHandler(IRepository repository)
        {
            _repository = repository;
        }

        public FriendViewModel CreateFriend(FriendViewModel friend)
        {
            try
            {
                var _friend = new Friend();
                _friend = MapperHelper.Map<Friend, FriendViewModel>(_friend, friend);

                var query = _repository.AddEntity(_friend);
                _repository.Save();

                return MapperHelper.Map<FriendViewModel, Friend>(friend, query);
            }
            catch(Exception ex) { throw; }
        }

        public bool UpdateFriend(PatientPayloadViewModel friend)
        {
            try
            {
                var _friend = new Friend();
                var newFriend = MapperHelper.Map<Friend, PatientPayloadViewModel>(_friend, friend);
                var query = _repository.UpdateEntity<Friend>(newFriend);
                _repository.Save();

                return true;
            }catch(Exception ex) { return false; }
        }

        public Friend GetFriend(int id)
        {
            try
            {
                return _repository.Search<Friend>(f => f.FriendId == id).FirstOrDefault();
            }catch(Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Friend> GetFriends()
        {
            try
            {
                //var results = _repository.Search<Friend>(f => f.FriendId > 0).ToList();

                //var friends = results.Select(f => {
                //    var person = _repository.Search<Person>(a => a.PersonId == f.PersonId).FirstOrDefault();

                //    return new Friend
                //    {
                //        FriendId = person.PersonId,
                //        PatientId = 
                //    }
                //});

                return _repository.Search<Friend>(f => f.FriendId > 0);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
