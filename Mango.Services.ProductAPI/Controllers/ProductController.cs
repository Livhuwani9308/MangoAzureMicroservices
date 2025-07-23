using AutoMapper;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    //[Authorize]
    public class ProductAPIController(AppDbContext _db, IMapper _mapper) : ControllerBase
    {
        [HttpGet("list")]
        public ResponseDto GetList()
        {
            try
            {
                List<Product> res = _db.Products.ToList();

                return new ResponseDto()
                {
                    Result = _mapper.Map<List<ProductDto>>(res),
                    IsSuccess = true,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        [HttpGet("getbyid/{id}")]
        public ResponseDto GetById(int id)
        {
            try
            {
                Product res = _db.Products.First(c => c.ProductId == id);

                return new ResponseDto()
                {
                    Result = _mapper.Map<ProductDto>(res),
                    IsSuccess = true,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Create([FromBody] ProductDto ProductDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(ProductDto);

                _db.Products.Add(obj);
                _db.SaveChanges();

                return new ResponseDto()
                {
                    Result = _mapper.Map<ProductDto>(obj),
                    IsSuccess = true,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        [HttpPut("update")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Update([FromBody] ProductDto ProductDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(ProductDto);

                _db.Products.Update(obj);
                _db.SaveChanges();

                return new ResponseDto()
                {
                    Result = _mapper.Map<ProductDto>(obj),
                    IsSuccess = true,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product obj = _db.Products.First(c => c.ProductId == id);
                _db.Products.Remove(obj);
                _db.SaveChanges();

                return new ResponseDto()
                {
                    Result = null,
                    IsSuccess = true,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    Message = ex.Message,
                    Result = null
                };
            }
        }
    }
}
