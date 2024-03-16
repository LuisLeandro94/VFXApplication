using Microsoft.AspNetCore.Mvc;
using VFXFinancial.Services;

namespace VFXFinancial.Controllers
{
    public class ForexController: Controller
    {
        private readonly ForexRequestService _forexRequestService;

        public ForexController(ForexRequestService forexRequestService)
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
