using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Storage;
using Newtonsoft.Json;
using VKCore.API.VKModels.Photo;
using VKCore.Util;

namespace VKCore.API.Core
{
    public enum UploadType
    {
        PhotoAlbumUpload,
        PhotoWallUpload,
        PhotoProfileUpload,
        PhotoMessageUpload,
        PhotoMarketAlbumUpload,
        PhotoMarketProductUpload
    }
    public class VKUploadRequest
    {

        class VKUploadServerAddress
        {
            public string upload_url { get; set; }
        }

        class VKUploadResponseData
        {
            public string server { get; set; }
            public string photo { get; set; }
            public string photos_list { get; set; }
            public string hash { get; set; }
            public string aid { get; set; }
            public long uid { get; set; }
            public long gid { get; set; }
            public string crop_data { get; set; }
            public string crop_hash { get; set; }
        }

     

        private UploadType _uploadType;
        private long _albumId;        
        private long _ownerId;
        private bool _is_main_photo;
        private long _groupId;
        protected VKUploadRequest()
        {
        }

        public static VKUploadRequest CreatePhotoAlbumUploadRequest(long albumId, long groupId = 0)
        {
            var uploadRequest = new VKUploadRequest();

            uploadRequest._uploadType = UploadType.PhotoAlbumUpload;
            uploadRequest._albumId = albumId;
            uploadRequest._groupId = groupId;

            return uploadRequest;   
        }

        public static VKUploadRequest CreatePhotoWallUploadRequest(long ownerId=0)
        {
            var uploadRequest = new VKUploadRequest();

            uploadRequest._uploadType = UploadType.PhotoWallUpload;
            uploadRequest._ownerId = ownerId;

            return uploadRequest;
        }

        public static VKUploadRequest CreatePhotoProfileUploadRequest(long ownerId)
        {
            var uploadRequest = new VKUploadRequest();

            uploadRequest._uploadType = UploadType.PhotoProfileUpload;
            uploadRequest._ownerId = ownerId;

            return uploadRequest;
        }

        public static VKUploadRequest CreatePhotoMessageUploadRequest()
        {
            var uploadRequest = new VKUploadRequest();

            uploadRequest._uploadType = UploadType.PhotoMessageUpload;

            return uploadRequest;
        }
        public static VKUploadRequest PhotoMarketCategoryAlbumRequest(long group_id)
        {
            var uploadRequest = new VKUploadRequest();

            uploadRequest._uploadType = UploadType.PhotoMarketAlbumUpload;
            uploadRequest._ownerId = group_id;
            return uploadRequest;
        }
        public static VKUploadRequest PhotoMarketProductUploadRequest(long group_id,bool is_main)
        {
            var uploadRequest = new VKUploadRequest();

            uploadRequest._uploadType = UploadType.PhotoMarketProductUpload;
            uploadRequest._ownerId = group_id;
            uploadRequest._is_main_photo = is_main;
            return uploadRequest;
        }

        public void Dispatch(
            StorageFile photoStream,
            Action<bool> progressCallback,
            Action<VKBackendResult<PhotoClass>> callback)
        {
            switch (_uploadType)
            {
                case UploadType.PhotoAlbumUpload: 
                    DispatchPhotoAlbumUpload(photoStream, progressCallback, callback);
                    break;
                case UploadType.PhotoMessageUpload:
                    DispatchPhotoMessageUpload(photoStream, progressCallback, callback);
                    break;
                case UploadType.PhotoProfileUpload:
                    DispatchPhotoProfileUpload(photoStream, progressCallback, callback);
                    break;
                case UploadType.PhotoWallUpload:
                    DispatchPhotoWallUpload(photoStream, progressCallback, callback);
                    break;
                case UploadType.PhotoMarketAlbumUpload:
                    DispatchPhotoMarketAlbumUpload(photoStream, progressCallback, callback);
                    break;
                case UploadType.PhotoMarketProductUpload:
                    DispatchPhotoMarketProductUpload(photoStream, progressCallback, callback);
                    break;
            }
        }

        private void DispatchPhotoWallUpload(StorageFile photoStream, Action<bool> progressCallback, Action<VKBackendResult<PhotoClass>> callback)
        {
            var parameters = new Dictionary<string, string>();
            if (_ownerId != 0)
            {
                string paramName = _ownerId < 0 ? "group_id" : "user_id";

                parameters[paramName] = Math.Abs(_ownerId).ToString();
            }

            UploadPhoto(photoStream,
                "photos.getWallUploadServer",
                parameters,
                "photos.saveWallPhoto",
                true,
                callback,
                progressCallback);
        }

        private void DispatchPhotoProfileUpload(StorageFile photoStream, Action<bool> progressCallback, Action<VKBackendResult<PhotoClass>> callback)
        {
            var parameters = new Dictionary<string, string>();

            UploadPhoto(photoStream,
              "photos.getProfileUploadServer",
              parameters,
              "photos.saveProfilePhoto",
              false,
              callback,
              progressCallback);           
        }

        private void DispatchPhotoMessageUpload(StorageFile photoStream, Action<bool> progressCallback, Action<VKBackendResult<PhotoClass>> callback)
        {
            var parameters = new Dictionary<string, string>();

            UploadPhoto(photoStream,
               "photos.getMessagesUploadServer",
                parameters,
                "photos.saveMessagesPhoto",
                true,
                callback,
                progressCallback);            
        }

        private void DispatchPhotoAlbumUpload(StorageFile photoStream, Action<bool> progressCallback, Action<VKBackendResult<PhotoClass>> callback)
        {
            var parameters = new Dictionary<string, string>();

            parameters["album_id"] = _albumId.ToString();

            if (_groupId != 0)
            {
                parameters["group_id"] = _groupId.ToString();
            }
            UploadPhoto(photoStream,
               "photos.getUploadServer",
                parameters,
                "photos.save",
                true,
                callback,
                progressCallback);                  
        }
        private void DispatchPhotoMarketAlbumUpload(StorageFile photoStream, Action<bool> progressCallback, Action<VKBackendResult<PhotoClass>> callback)
        {
            var parameters = new Dictionary<string, string>();
            if (_ownerId != 0)
            {
                parameters.Add("group_id", Math.Abs(_ownerId).ToString());
            }
            UploadPhoto(photoStream,
               "photos.getMarketAlbumUploadServer",
                parameters,
                "photos.saveMarketAlbumPhoto",
                true,
                callback,
                progressCallback);
        }
        private void DispatchPhotoMarketProductUpload(StorageFile photoStream, Action<bool> progressCallback, Action<VKBackendResult<PhotoClass>> callback)
        {
            var parameters = new Dictionary<string, string>();
            if (_ownerId != 0)
            {
                parameters.Add("group_id", Math.Abs(_ownerId).ToString());
            }
            if (_is_main_photo)
            {
                parameters.Add("main_photo", "1");
            }
            UploadPhoto(photoStream,
               "photos.getMarketUploadServer",
                parameters,
                "photos.saveMarketPhoto",
                true,
                callback,
                progressCallback);
        }
        private void UploadPhoto(StorageFile photoStream,
         string getServerMethodName,
         Dictionary<string, string> parameters,
         string saveMethodName,
         bool saveReturnsList,
         Action<VKBackendResult<PhotoClass>> callback,
         Action<bool> progressCallback)
        {

            var vkParams = new VKRequestParameters(getServerMethodName,
               parameters);

            var getServerRequest = new VKRequest(vkParams);

            getServerRequest.Dispatch<VKUploadServerAddress>(
               (res) =>
               {
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {
                       var uploadUrl = res.Data.upload_url;
                       VKHttpRequestHelper.Upload(
                            uploadUrl,
                            photoStream,
                            (uploadRes) =>
                            {
                                if (uploadRes.IsSucceeded)
                                {
                                    var serverPhotoHashJson = uploadRes.Data;

                                    var uploadData = JsonConvert.DeserializeObject<VKUploadResponseData>(serverPhotoHashJson);

                                    if (!string.IsNullOrWhiteSpace(uploadData.server))
                                    {
                                        parameters["server"] = uploadData.server;
                                    }
                                    if (!string.IsNullOrWhiteSpace(uploadData.photos_list))
                                    {
                                        parameters["photos_list"] = uploadData.photos_list;
                                    }
                                    if (!string.IsNullOrWhiteSpace(uploadData.hash))
                                    {
                                        parameters["hash"] = uploadData.hash;
                                    }
                                    if (!string.IsNullOrWhiteSpace(uploadData.photo))
                                    {
                                        parameters["photo"] = uploadData.photo;
                                    }

                                    var saveWallPhotoVKParams = new VKRequestParameters(saveMethodName,
                                        parameters);

                                    var saveWallPhotoRequest = new VKRequest(saveWallPhotoVKParams);

                                    saveWallPhotoRequest.Dispatch(
                                        callback,
                                        (jsonStr) =>
                                        {
                                            if (saveReturnsList)
                                            {
                                                var resp = JsonConvert.DeserializeObject<GenericRoot<List<PhotoClass>>>(jsonStr);

                                                return resp.response.First();
                                            }
                                            else
                                            {
                                                var resp = JsonConvert.DeserializeObject<GenericRoot<PhotoClass>>(jsonStr);

                                                return resp.response;
                                            }
                                        });

                                }
                                else
                                {
                                    callback(new VKBackendResult<PhotoClass> { ResultCode = VKResultCode.UnknownError });
                                }
                            },
                            progressCallback);
                   }
                   else
                   {
                       callback(new VKBackendResult<PhotoClass> { ResultCode = res.ResultCode, Error = res.Error });
                   }
               });
        }
    }
}
