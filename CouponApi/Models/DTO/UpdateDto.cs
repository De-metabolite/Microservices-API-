namespace CouponApi.Models.DTO
{
    public record UpdateDto
        (
            int CouponId,
            string CouponCode,
            double DiscountAmount,
            int MinAmount

        );
    
}
