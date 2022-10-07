using System.Net;
using System;
namespace PMS_PatientApi.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public CustomException(HttpStatusCode status, string err) : base(err)
        {
            StatusCode = status;
        }

     
    }
}
