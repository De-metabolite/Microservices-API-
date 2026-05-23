namespace CouponApi.Models.DTO
{
    public record CreateDto
        (
         string CouponCode,
         double DiscountAmount,
         int MinAmount
        );
    
}
