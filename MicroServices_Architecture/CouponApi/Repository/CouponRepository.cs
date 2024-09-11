using AutoMapper;
using CouponApi.Data;
using CouponApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CouponApi.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CouponDbContext _dbContext;
        private readonly IMapper _mapper;
        public CouponRepository(CouponDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CouponDto> GetCouponByCode(string couponCode)
        {
             var couponFromDb = await _dbContext.Coupons.FirstOrDefaultAsync(x => x.CouponCode == couponCode);
             return _mapper.Map<CouponDto>(couponFromDb);
        }
    }
}