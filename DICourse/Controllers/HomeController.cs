using DICourse.Models;
using DICourse.Services;
using DICourse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DICourse.Controllers
{
    public class HomeController : Controller
    {
        private ISMSService _sMSService;
        private KavrnegarViewModel _kavrnegarViewModel;
        private PasargadBankViewModel _pasargadBankViewModel;

        public HomeController(ISMSService sMSService, IOptions<KavrnegarViewModel> kavenegarOptions, IOptions<PasargadBankViewModel> pasargadBannkOptions)
        {
            _sMSService = sMSService;
            _kavrnegarViewModel = kavenegarOptions.Value;
            _pasargadBankViewModel = pasargadBannkOptions.Value;
        }

        public IActionResult Index()
        {
            var result = new IndexViewModel();

            result.SMSStatus = _sMSService.SendSMS();

            ViewBag.status = result.SMSStatus;

            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Kavenegar = _kavrnegarViewModel.Api;
            ViewBag.Pasargad = _pasargadBankViewModel.TerminalId;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
