using CouponApi.Models.Dtos;

namespace CouponApi.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
        
    }
}