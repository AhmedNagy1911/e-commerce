using Core.Entites;

namespace Core.Interfaces;

public interface ICouponService
{
    Task<AppCoupon?> GetCouponFromPromoCode(string code);
}