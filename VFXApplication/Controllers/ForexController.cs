using Microsoft.AspNetCore.Mvc;
using VFXFinancial.Services;
using Microsoft.AspNetCore.Authorization;

namespace VFXFinancial.Controllers
{
    [Authorize]
    public class ForexController : Controller
    {
        private readonly IForexRequestService _forexRequestService;

        public ForexController(IForexRequestService forexRequestService)
        {
            _forexRequestService = forexRequestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //
        // Url: /Forex/GetDailyPrices
        [HttpGet]
        public async Task<JsonResult> GetDailyPrices(string from_symbol, string to_symbol)
        {
            var forexRequestModel = await _forexRequestService.GetDailyPrices(from_symbol, to_symbol);
            return Json(forexRequestModel);
        }
    }
}
