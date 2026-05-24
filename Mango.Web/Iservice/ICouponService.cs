using Mango.Web.Models;
namespace Mango.Web.Iservice
{
    public interface ICouponService
    {
        Task<ResponseDto> GetByCouponCodeAsync(string CouponCode);
        Task<ResponseDto> GetAllCouponsAsync();
        Task<ResponseDto> GetCouponByIdAsync(int id);
        Task<ResponseDto> CreateCouponAsync(CouponDto coupon);
        Task<ResponseDto> UpdateCouponAsync(UpdateDto coupon);
        Task<ResponseDto> DeleteCouponAsync(int id);
    }
}
