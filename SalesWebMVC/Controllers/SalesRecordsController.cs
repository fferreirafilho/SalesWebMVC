using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using System;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers {
    public class SalesRecordsController : Controller {

        private readonly SalesRecordsService _salesRecordsService;

        public SalesRecordsController(SalesRecordsService salesRecordsService) {
            _salesRecordsService = salesRecordsService;
        }

        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate) {
            if (!minDate.HasValue) {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue) {
                maxDate = DateTime.Now;
            }
            var result = await _salesRecordsService.FindByDateAsync(minDate, maxDate);
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate) {
            if (!minDate.HasValue) {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue) {
                maxDate = DateTime.Now;
            }
            var result = await _salesRecordsService.FindByDateGroupingAsync(minDate, maxDate);
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            return View(result);
        }
    }
}
