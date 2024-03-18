using System;
using Microsoft.AspNetCore.Mvc;

namespace VFXApplication.Services.RedirecAuthenticatedUsers
{
        public class RedirectAttribute : TypeFilterAttribute
        {
            public RedirectAttribute() : base(typeof(RedirectFilter))
            {
            }
        }
}

