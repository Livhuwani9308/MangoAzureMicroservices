using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResponseDto = Mango.Services.CouponAPI.Models.Dto.ResponseDto;

namespace Mango.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    [Authorize]
    public class CouponAPIController(AppDbContext _db, IMapper _mapper) : ControllerBase
    {
        [HttpGet("list")]
        public ResponseDto GetList()
        {
            try
            {
                List<Coupon> res = _db.Coupons.ToList();

                return new ResponseDto()
                {
                    Result = _mapper.Map<List<CouponDto>>(res),
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

        [HttpGet("getbyid/{id:int}")]
        public ResponseDto GetById(int id)
        {
            try
            {
                Coupon res = _db.Coupons.First(c => c.CouponId == id);

                return new ResponseDto()
                {
                    Result = _mapper.Map<CouponDto>(res),
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

        [HttpGet("getbycode/{code}")]
        public ResponseDto GetById(string code)
        {
            try
            {
                Coupon res = _db.Coupons.First(c => c.CouponCode == code);

                return new ResponseDto()
                {
                    Result = _mapper.Map<CouponDto>(res),
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
        public ResponseDto Create([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);

                _db.Coupons.Add(obj);
                _db.SaveChanges();

                return new ResponseDto()
                {
                    Result = _mapper.Map<CouponDto>(obj),
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
        public ResponseDto Update([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);

                _db.Coupons.Update(obj);
                _db.SaveChanges();

                return new ResponseDto()
                {
                    Result = _mapper.Map<CouponDto>(obj),
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
                Coupon obj = _db.Coupons.First(c => c.CouponId == id);
                _db.Coupons.Remove(obj);
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
