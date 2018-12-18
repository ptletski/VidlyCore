using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VidlyCoreApp.Controllers
{
    public class AppBaseController : Controller
    {
        private readonly ILogger _logger;
        private string _message;

        public AppBaseController(ILogger logger) : base()
        {
            _logger = logger;
        }

        protected ILogger Logger { get => _logger; }
        protected string Message { get => _message; set => _message = value; }

        protected void SetCookie(string key, string value)
        {
            CookieOptions option = new CookieOptions()
            {
                Expires = DateTime.Now.AddHours(1),
                IsEssential = true
            };

            Response.Cookies.Append(key, value, option);
        }

        protected string GetCookie(string cookieKey)
        {
            return Request.Cookies[cookieKey];
        }

        protected void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
