using System.Net;

namespace Common.CommonUtility
{
    public class BadRequestResponse : ApiResponse
    {
        public BadRequestResponse()
            : base(400, HttpStatusCode.BadRequest.ToString())
        {
        }


        public BadRequestResponse(string message)
            : base(400, HttpStatusCode.BadRequest.ToString(), message)
        {
        }

    }
}
