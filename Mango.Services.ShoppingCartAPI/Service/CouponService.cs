using Mango.Services.ShoppingCartAPI.Models.Dto;
using Mango.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Service
{
    public class CouponService(IHttpClientFactory _httpClientFactory) : ICouponService
    {
        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var response = await client.GetAsync($"/api/coupon/getbycode/{couponCode}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (res != null && res.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(res.Result.ToString());
            }
            return new();
        }
    }
}