using CouponApi.Models.Dtos;
using CouponApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CouponApi.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        protected ResponseDto _response;
        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
            _response = new ResponseDto();
        }

        [HttpGet("{code}")]
        public async Task<object> GetDiscountForCode(string couponCode)
        {
            try
            {
                CouponDto couponDto = await _couponRepository.GetCouponByCode(couponCode);
                _response.Result = couponDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>{ex.ToString()};
            }
                return _response;

        }



    }
}