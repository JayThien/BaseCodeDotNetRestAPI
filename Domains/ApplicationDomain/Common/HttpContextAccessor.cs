using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Claims;

namespace ApplicationDomain.Common
{
    public static class HttpContextAccessorCustom
    {
        public static T GetValue<T>(IHttpContextAccessor context, string claimType)
        {
            if (context == null || string.IsNullOrEmpty(claimType))
            {
                return default(T);
            }
            var result = context.HttpContext.User.FindFirstValue(claimType);
            if (result == null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(result, typeof(T));

        }
    }
}
