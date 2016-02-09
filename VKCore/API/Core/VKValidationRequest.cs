namespace VKCore.API.Core
{
    class VKValidationRequest
    {
        public string ValidationUri { get; set; }
    }

    class VKValidationResponse
    {
        public bool IsSucceeded { get; set; }
    }
}
