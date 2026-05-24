using Mango.Web.Iservice;
using Microsoft.AspNetCore.Mvc;
using Mango.Web.Models;
using System.Text.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> list = new();
            ResponseDto response = await _couponService.GetAllCouponsAsync();
            if (response.Result != null && response.IsSuccess) 
            { 
                list = JsonSerializer.Deserialize<List<CouponDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
