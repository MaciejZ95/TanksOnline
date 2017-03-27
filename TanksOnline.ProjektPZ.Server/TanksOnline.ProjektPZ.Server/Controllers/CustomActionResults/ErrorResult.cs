using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TanksOnline.ProjektPZ.Server.Controllers.CustomActionResults
{
    public class ErrorResult : IHttpActionResult
    {
        private HttpRequestMessage Request { get; }
        private HttpStatusCode statusCode;
        private string message;

        public ErrorResult(HttpRequestMessage request, HttpStatusCode statusCode, string message)
        {
            this.Request = request;
            this.statusCode = statusCode;
            this.message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Request.CreateErrorResponse(statusCode, message));
        }
    }
}