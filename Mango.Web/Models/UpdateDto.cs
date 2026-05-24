namespace Mango.Web.Models;

public record UpdateDto
    (
        int CouponId,
        string CouponCode,
        double DiscountAmount,
        int MinAmount

    );
