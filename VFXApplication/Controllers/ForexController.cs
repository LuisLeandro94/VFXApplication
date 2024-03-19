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

        [HttpGet]
        public async Task<IActionResult> GetDailyPrices(string from_symbol, string to_symbol)
        {
            try
            {
                var forexRequestModel = await _forexRequestService.GetDailyPrices(from_symbol, to_symbol);
                return Json(forexRequestModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred while fetching daily prices: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
