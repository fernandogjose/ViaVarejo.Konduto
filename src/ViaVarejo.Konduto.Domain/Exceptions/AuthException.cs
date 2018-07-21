using System;
using System.Net;

namespace ViaVarejo.Konduto.Domain.Exceptions {
    public class AuthException : Exception {

        public HttpStatusCode HttpStatusCode { get; set; }

        public AuthException (string message, HttpStatusCode httpStatusCode) : base (message) {
            HttpStatusCode = httpStatusCode;
        }
    }
}