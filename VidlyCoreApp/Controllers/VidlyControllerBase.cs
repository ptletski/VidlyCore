using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VidlyCoreApp.Controllers
{
	public class VidlyControllerBase : Controller
    {
        public VidlyControllerBase()
        {
        }

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
