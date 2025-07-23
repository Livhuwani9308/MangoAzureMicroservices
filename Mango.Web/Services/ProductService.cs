using Mango.Web.Models;
using Mango.Web.Services.IService;
using Mango.Web.Utilities;

namespace Mango.Web.Services
{
    public class ProductService(IBaseService _baseService) : IProductService
    {
        public async Task<ResponseDto?> CreateProductsAsync(ProductDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = $"{SD.ProductAPIBase}/api/product/create",
                Data = couponDto
            });
        }

        public async Task<ResponseDto?> DeleteProductsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = $"{SD.ProductAPIBase}/api/product/delete/{id}"
            });
        }

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.ProductAPIBase}/api/product/list"
            });
        }

        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.ProductAPIBase}/api/product/getbyid/{id}"
            });
        }

        public async Task<ResponseDto?> UpdateProductsAsync(ProductDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Url = $"{SD.ProductAPIBase}/api/product/update",
                Data = couponDto
            });
        }
    }
}
