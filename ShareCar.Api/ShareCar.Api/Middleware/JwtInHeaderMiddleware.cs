﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ShareCar.Api.Middleware
{
    public class JwtInHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtInHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var authenticationCookieName = "token";
            var cookie = context.Request.Cookies[authenticationCookieName];
            if (cookie != null)
            {
                context.Request.Headers.Append("Authorization", "Bearer " + cookie);
            }

            await _next.Invoke(context);
        }
    }
}