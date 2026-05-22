namespace CouponApi.Models.DTO
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
        public CouponDto(Coupon data)
        {
            CouponId= data.CouponId;
            CouponCode= data.CouponCode;
            DiscountAmount= data.DiscountAmount;
            MinAmount = data.MinAmount;
        }
    }

}
