using DICourse.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DICourse.Controllers
{
    public class LifeTimeController : Controller
    {
        private readonly SingletonService _singletonService;
        private readonly ScopedService _scopedService;
        private readonly TransientService _transientService;

        public LifeTimeController(SingletonService singletonService, ScopedService scopedService, TransientService transientService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
        }

        public IActionResult Index()
        {
            var lifeTimeList = new List<string>();

            lifeTimeList.Add($"SigleTon Guid From Controller = {_singletonService.GetGuid()}");
            lifeTimeList.Add(HttpContext.Items["SingletonService"].ToString());
            lifeTimeList.Add("---------------------------------------------------");

            lifeTimeList.Add($"Transient Guid From Controller = {_transientService.GetGuid()}");
            lifeTimeList.Add(HttpContext.Items["TransientService"].ToString());
            lifeTimeList.Add("---------------------------------------------------");

            lifeTimeList.Add($"Scoped Guid From Controller = {_scopedService.GetGuid()}");
            lifeTimeList.Add(HttpContext.Items["ScopedService"].ToString());
            lifeTimeList.Add("---------------------------------------------------");

            ViewData["LifeTimeList"] = lifeTimeList;

            return View();
        }
    }
}
