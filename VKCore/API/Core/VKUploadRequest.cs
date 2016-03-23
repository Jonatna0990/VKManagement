using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Storage;
using Newtonsoft.Json;
using VKCore.API.VKModels.Doc;
using VKCore.API.VKModels.Photo;
using VKCore.Util;

namespace VKCore.API.Core
{
    public class VKUploadServerAddress
    {
        public string upload_url { get; set; }
        public long video_id { get; set; }
        public long owner_id { get; set; }
        public string descriprion { get; set; }
        public string access_key { get; set; }
    }
    public enum UploadType
    {
        PhotoAlbumUpload,
        PhotoWallUpload,
        PhotoProfileUpload,
        PhotoMessageUpload,
        PhotoMarketAlbumUpload,
        PhotoMarketProductUpload,
        VideoProfileUpload,
        VideoWallUpload,
        VideoMessageUpload,
        DocProfileUpload,
        DocMessageUpload,
        DocWallUpload

    }
    public class VKUploadRequest
    {
    

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
            public string file { get; set; }
        }

     

        private UploadType _uploadType;
        private long _albumId;        
        private long _ownerId;
        private bool _is_main_photo;
        private long _groupId;
        private string privacy_view;
        private string privacy_comment;
        private int is_private;
        private int wallpost;
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
        public static VKUploadRequest CreatePhotoWallUploadRequest(long ownerId = 0)
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
        public static VKUploadRequest VideoProfileUploadRequest(long group_id, long album_id)
        {
            var uploadRequest = new VKUploadRequest();

            uploadRequest._uploadType = UploadType.PhotoMarketProductUpload;
            uploadRequest._ownerId = group_id;
            return uploadRequest;
        }
        public static VKUploadRequest VideoMessageUploadRequest()
        {
            var uploadRequest = new VKUploadRequest();

            uploadRequest._uploadType = UploadType.PhotoMarketProductUpload;
            uploadRequest.is_private = 1;
            return uploadRequest;
        }
        public static VKUploadRequest VideoWallUploadRequest(long group_id)
        {
            var uploadRequest = new VKUploadRequest();

            uploadRequest._uploadType = UploadType.PhotoMarketProductUpload;
            uploadRequest._ownerId = group_id;
            uploadRequest.wallpost = 1;
            return uploadRequest;
        }
        public static VKUploadRequest DocProfileUploadRequest(long group_id)
        {
            var uploadRequest = new VKUploadRequest();
            uploadRequest._uploadType = UploadType.DocProfileUpload;
            uploadRequest._ownerId = group_id;
            return uploadRequest;
        }
        public static VKUploadRequest DocWallUploadRequest(long group_id, bool is_main)
        {
            var uploadRequest = new VKUploadRequest();

            uploadRequest._uploadType = UploadType.DocWallUpload;
            uploadRequest._ownerId = group_id;
            uploadRequest._is_main_photo = is_main;
            return uploadRequest;
        }


        public void Dispatch(
            StorageFile photoStream,
            Action<bool> progressCallback,
            Action<VKBackendResult<PhotoClass>> callback, Action<VKBackendResult<DocClass>> doccallback=null)
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
                case UploadType.DocProfileUpload:
                    DispatchDocProfileUpload(photoStream, progressCallback, doccallback);
                    break;
                case UploadType.DocMessageUpload: DispatchDocProfileUpload(photoStream, progressCallback, doccallback);
                    break;
                case UploadType.DocWallUpload:
                    DispatchDocProfileUpload(photoStream, progressCallback, doccallback);
                    break;
            }
        }
        private void DispatchDocProfileUpload(StorageFile photoStream, Action<bool> progressCallback, Action<VKBackendResult<DocClass>> callback)
        {
            var parameters = new Dictionary<string, string>();
            if (_ownerId != 0)
            {
                parameters["group_id"] = _ownerId.ToString();
            }
            UploadDoc(photoStream,
              "docs.getUploadServer",
              parameters,
              "docs.save",
              callback,
              progressCallback);
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
                                    if (!string.IsNullOrWhiteSpace(uploadData.file))
                                    {
                                        parameters["file"] = uploadData.file;
                                    }
                                    if (!string.IsNullOrWhiteSpace(uploadData.crop_data))
                                    {
                                        parameters["crop_data"] = uploadData.crop_data;
                                    }
                                    if (!string.IsNullOrWhiteSpace(uploadData.crop_hash))
                                    {
                                        parameters["crop_hash"] = uploadData.crop_hash;
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

        private void UploadDoc(StorageFile photoStream,
      string getServerMethodName,
      Dictionary<string, string> parameters,
      string saveMethodName,
      Action<VKBackendResult<DocClass>> callback,
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
                                    if (!string.IsNullOrWhiteSpace(uploadData.file))
                                    {
                                        parameters["file"] = uploadData.file;
                                    }
                                   
                                  

                                    var saveWallPhotoVKParams = new VKRequestParameters(saveMethodName,
                                        parameters);

                                    var saveWallPhotoRequest = new VKRequest(saveWallPhotoVKParams);

                                    saveWallPhotoRequest.Dispatch(
                                        callback,
                                        (jsonStr) =>
                                        {
                                                var resp = JsonConvert.DeserializeObject<GenericRoot<List<DocClass>>>(jsonStr);
                                                return resp.response.First();
                                           
                                        });

                                }
                                else
                                {
                                    callback(new VKBackendResult<DocClass> { ResultCode = VKResultCode.UnknownError });
                                }
                            },
                            progressCallback);
                   }
                   else
                   {
                       callback(new VKBackendResult<DocClass> { ResultCode = res.ResultCode, Error = res.Error });
                   }
               });
        }
        private void UploadVideo(StorageFile photoStream,
     string getServerMethodName,
     Dictionary<string, string> parameters,
     string saveMethodName,
     Action<VKBackendResult<DocClass>> callback,
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
                                    if (!string.IsNullOrWhiteSpace(uploadData.file))
                                    {
                                        parameters["file"] = uploadData.file;
                                    }



                                    var saveWallPhotoVKParams = new VKRequestParameters(saveMethodName,
                                        parameters);

                                    var saveWallPhotoRequest = new VKRequest(saveWallPhotoVKParams);

                                    saveWallPhotoRequest.Dispatch(
                                        callback,
                                        (jsonStr) =>
                                        {
                                            var resp = JsonConvert.DeserializeObject<GenericRoot<List<DocClass>>>(jsonStr);
                                            return resp.response.First();

                                        });

                                }
                                else
                                {
                                    callback(new VKBackendResult<DocClass> { ResultCode = VKResultCode.UnknownError });
                                }
                            },
                            progressCallback);
                   }
                   else
                   {
                       callback(new VKBackendResult<DocClass> { ResultCode = res.ResultCode, Error = res.Error });
                   }
               });
        }

    }
}
