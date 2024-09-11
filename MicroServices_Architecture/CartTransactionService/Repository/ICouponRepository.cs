using CartTransactionService.Models.Dtos;

namespace CartTransactionService.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}