using DICourse.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DICourse.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LifeTimeMiddleWare
    {
        private readonly RequestDelegate _next;

        public LifeTimeMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext httpContext, ScopedService scopedService, SingletonService singletonService, TransientService transientService)
        {
            httpContext.Items.Add("TransientService", "Transient Guid From MiddleWare= " + transientService.GetGuid());
            httpContext.Items.Add("ScopedService", "Scoped Guid From MiddleWare= " + scopedService.GetGuid());
            httpContext.Items.Add("SingletonService", "Singleton Guid From MiddleWare= " + singletonService.GetGuid());

            await _next(httpContext);
        }
    }
}
