using System;
using System.Net;

namespace ViaVarejo.Konduto.Domain.Exceptions {
    
    public class CustomException : Exception {

        public HttpStatusCode HttpStatusCode { get; set; }

        public CustomException (string message, HttpStatusCode httpStatusCode) : base (message) {
            HttpStatusCode = httpStatusCode;
        }
    }
}