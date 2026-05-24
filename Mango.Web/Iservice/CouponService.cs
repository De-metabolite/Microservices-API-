
using Mango.Web.Models;
using Mango.Web.Models.HttpActions;

namespace Mango.Web.Iservice
{
    public class CouponService:ICouponService
    {

        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> GetByCouponCodeAsync(string CouponCode) 
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType=SD.Method.GET,
                Url= SD.CouponAPIBase+ "/api/coupon/GetByCode"+ CouponCode
            });

        }
        public async Task<ResponseDto> GetAllCouponsAsync() 
        {

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.Method.GET,
                Url = SD.CouponAPIBase + "/api/couponapi/"
            });
        }
        public async Task<ResponseDto> GetCouponByIdAsync(int id) 
        {

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.Method.GET,
                Url = SD.CouponAPIBase + "/api/coupon/"+ id
            });
        }
        public async Task<ResponseDto> CreateCouponAsync(CouponDto coupon) 
        {

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.Method.POST,
                Data=coupon,
                Url = SD.CouponAPIBase + "/api/coupon/"
            });
        }
        public async Task<ResponseDto> UpdateCouponAsync(UpdateDto coupon) 
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.Method.PUT,
                Url = SD.CouponAPIBase + "/api/coupon/"
            });
        }
        
        public async Task<ResponseDto> DeleteCouponAsync(int id)
        {

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.Method.DELETE,
                Url = SD.CouponAPIBase + "/api/coupon/" + id
            });

        }
    }
}
