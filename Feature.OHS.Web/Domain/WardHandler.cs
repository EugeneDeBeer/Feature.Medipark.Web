using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Feature.OHS.Web.ViewModels.Lists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Settings;
using Microsoft.Extensions.Options;

namespace Feature.OHS.Web.Domain
{
    public class WardHandler : IWard
    {
        private readonly IAPIIntegration _integration;
        private readonly IntegrationSettings _integrationSettings;

        public WardHandler(IAPIIntegration integration, IOptions<IntegrationSettings> integrationOptions)
        {
            _integration = integration;
            _integrationSettings = integrationOptions.Value;

        }

       public dynamic CreateBed(BedViewModel bed)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Ward/Create/bed", bed, _integrationSettings.HospitalWardsApiUrl, true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<BedViewModel>(response.Message);
                if (dynamicResponse != null)
                {

                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public dynamic CreateRoom(RoomViewModel room)
        {
            room.EventDescription = "room";
            room.StatusDescription = "Created";
            var response = _integration.ResponseFromAPIPost("", "v1/ward/create/room", room,_integrationSettings.HospitalWardsApiUrl , true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<WardViewModel>(response.Message);
                if (dynamicResponse != null)
                {

                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public  dynamic CreateWard(WardViewModel ward)
        {
            ward.EventShortDescription = "ward";
            ward.EventDescription = "Created";
            var response = _integration.ResponseFromAPIPost("", "v1/Ward/create", ward, _integrationSettings.HospitalWardsApiUrl, true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<WardViewModel>(response.Message);
                if (dynamicResponse != null)
                {

                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public dynamic EditBed(BedViewModel bed)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Ward/edit/bed", bed, _integrationSettings.HospitalWardsApiUrl, true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<BedViewModel>(response.Message);
                if (dynamicResponse != null)
                {

                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public dynamic EditRoom(RoomViewModel room)
        {
            room.EventDescription = "room";
            room.StatusDescription = "Updated";
            var response = _integration.ResponseFromAPIPost("", "v1/ward/modify/room", room, _integrationSettings.HospitalWardsApiUrl, true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<WardViewModel>(response.Message);
                if (dynamicResponse != null)
                {

                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public dynamic EditWard(WardViewModel ward)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Ward/edit", ward, _integrationSettings.HospitalWardsApiUrl, true);

            if (response != null)
         
   {
                var dynamicResponse = JsonConvert.DeserializeObject<WardViewModel>(response.Message);
                if (dynamicResponse != null)
                {

                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public List<WardListViewModel> GetWardList(int HospitalId)
        {
            var response = _integration.ResponseFromAPIGet("", $"get/roomlist/{HospitalId}", _integrationSettings.HospitalWardsApiUrl,null);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<List<WardListViewModel>>(response.Message);
                if (dynamicResponse != null)
                {

                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }

        }

        public List<RoomListViewModel> GetRoomList(int wardId)
        {
            var response = _integration.ResponseFromAPIGet("", $"get/roomlist/{wardId}", _integrationSettings.HospitalWardsApiUrl, null);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<List<RoomListViewModel>>(response.Message);
                if (dynamicResponse != null)
                {

                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }

        }
    }
}
