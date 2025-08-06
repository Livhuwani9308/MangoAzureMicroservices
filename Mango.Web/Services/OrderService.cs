using Mango.Web.Models;
using Mango.Web.Services.IService;
using Mango.Web.Utilities;

namespace Mango.Web.Services
{
    public class OrderService(IBaseService _baseService) : IOrderService
    {
        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = $"{SD.OrderAPIBase}/api/order/CreateOrder",
                Data = cartDto
            });
        }
    }
}
