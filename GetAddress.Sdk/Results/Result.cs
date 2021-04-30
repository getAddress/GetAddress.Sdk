using Newtonsoft.Json;
using System.Net;

namespace GetAddress.Sdk
{
    public  class Result<S>
    {
        public HttpStatusCode StatusCode { get; }

        public bool IsSuccess { get; }

        public S Success { get; set; }

        public Failed Failed { get; set; }

        public bool TryGetSuccess(out S success)
        {
            success = Success;
            return IsSuccess;
        }

        public bool TryGetFailed(out Failed failed)
        {
            failed = Failed;
            return IsSuccess;
        }

        public Result(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public Result(S success, HttpStatusCode statusCode) :this(statusCode)
        {
            Success = success;
            IsSuccess = true;
        }
        public Result(Failed failed, HttpStatusCode statusCode) : this(statusCode)
        {
            Failed = failed ?? throw new System.ArgumentNullException(nameof(failed));
            IsSuccess = false;
        }
    }

    public class Failed
    {
        [JsonProperty("Message")]
        public string Message { get; set; }

    }

    

}
