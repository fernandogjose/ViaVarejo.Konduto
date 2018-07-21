using System;
using System.Net;

namespace ViaVarejo.Konduto.Domain.Exceptions {
    public class KondutoException : Exception {

        public HttpStatusCode HttpStatusCode { get; set; }

        public KondutoException (string message, HttpStatusCode httpStatusCode) : base (message) {
            HttpStatusCode = httpStatusCode;
        }
    }
}