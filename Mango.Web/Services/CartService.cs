using Mango.Web.Models;
using Mango.Web.Services.IService;
using Mango.Web.Utilities;

namespace Mango.Web.Services
{
    public class CartService(IBaseService _baseService) : ICartService
    {
        public async Task<ResponseDto?> ApplyCoupon(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = $"{SD.ShoppingCartAPIBase}/api/cart/ApplyCoupon",
                Data = cartDto
            });
        }

        public async Task<ResponseDto?> EmailCart(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = $"{SD.ShoppingCartAPIBase}/api/cart/EmailCartRequest",
                Data = cartDto
            });
        }

        public async Task<ResponseDto?> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.ShoppingCartAPIBase}/api/cart/GetCart/{userId}"
            });
        }

        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = $"{SD.ShoppingCartAPIBase}/api/cart/RemoveCart",
                Data = cartDetailsId
            });
        }

        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = $"{SD.ShoppingCartAPIBase}/api/cart/CartUpsert",
                Data = cartDto
            });
        }
    }
}
