using Newtonsoft.Json;
using System.Net;

namespace GetAddress.Sdk
{
    public  class Result<S>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; }

        public S Success { get; set; }

        public Failed Failed { get; set; }

        public Result(S success)
        {
            Success = success;
            IsSuccess = true;
        }
        public Result(Failed failed)
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
