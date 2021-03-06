﻿namespace VKCore.API.Core
{
    public class VKBackendResult<T>
    {
        public VKResultCode ResultCode { get; set; }

        public string ResultString { get; set; }

        public T Data { get; set; }

        public VKError Error { get; set; }
    }
}
