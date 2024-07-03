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
        private readonly TransientService _transientService;

        public LifeTimeMiddleWare(RequestDelegate next, TransientService transientService)
        {
            _next = next;
            _transientService = transientService;
        }
        
        public async Task InvokeAsync(HttpContext httpContext, ScopedService scopedService, SingletonService singletonService)
        {
            httpContext.Items.Add("TransientService", "Transient Guid From MiddleWare= " + _transientService.GetGuid());
            httpContext.Items.Add("ScopedService", "Scoped Guid From MiddleWare= " + scopedService.GetGuid());
            httpContext.Items.Add("SingletonService", "Singleton Guid From MiddleWare= " + singletonService.GetGuid());

            await _next(httpContext);
        }
    }
}
