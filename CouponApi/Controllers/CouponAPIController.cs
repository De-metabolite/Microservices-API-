using CouponApi.Data;
using CouponApi.Models;
using CouponApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CouponApi.Controllers
{
    [Route("api/couponapi")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ResponseDto _response;
        public CouponAPIController(AppDbContext db)
        {
           _db=db; 
            _response=new ResponseDto();
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> Get() 
        {
            try
            {
                IEnumerable<Coupon> objlist = await _db.Coupons.ToListAsync();
                _response.Result = objlist;
              
            }catch(Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return Ok(_response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ResponseDto>> Get([FromRoute] int id)
        {
            try
            {
                Coupon objlist = await _db.Coupons.FindAsync(id);
                var dto = new CouponDto(objlist);
                _response.Result= dto;
                _response.Message = "List of Available coupons";
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return Ok(_response);
        }
        [HttpGet]
        [Route("GetByCode{code}")]
        public async Task<ActionResult<ResponseDto>> Get([FromRoute] string code)
        {
            try
            {
                var objlist = await _db.Coupons.FirstOrDefaultAsync(u => u.CouponCode.ToLower() == code.ToLower());
                var dto = new CouponDto(objlist);
                _response.Result = dto;
                _response.Message = "List of Available coupons";
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return Ok(_response);
        }
        [HttpPost("CreateCoupon")]
        
        public async Task<ActionResult <ResponseDto>> Post([FromBody] CreateDto dto)
        {
            try
            {
                
                Coupon obj = new Coupon
                {
                  
                    CouponCode = dto.CouponCode,
                    DiscountAmount = dto.DiscountAmount,
                    MinAmount = dto.MinAmount,
                };
                 _db.Coupons.Add(obj);
               await _db.SaveChangesAsync();
                
                
                _response.Result = dto;
                _response.Message = "Coupon Created Successfully";
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return Ok(_response);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ResponseDto>> Put([FromRoute] int id)
        {
            try
            {
                var obj = await _db.Coupons.FindAsync(id);

                _db.Coupons.Remove(obj);
                await  _db.SaveChangesAsync();


               
                _response.Message = $"The Coupon with an Id {id} has been deleted Successfully";
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return Ok(_response);
        }

    }
}
