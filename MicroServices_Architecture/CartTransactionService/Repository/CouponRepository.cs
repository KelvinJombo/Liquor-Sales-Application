using System.Net.Http;
using CartTransactionService.Models.Dtos;
using CartTransactionServices.Models.Dtos;
using Newtonsoft.Json;

namespace CartTransactionService.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _httpClient;

        public CouponRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CouponDto> GetCoupon(string couponName)
        {
            var response = await _httpClient.GetAsync($"/api/coupon/{couponName}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(resp.Result));
            }
            return new CouponDto();
        }
    }
}