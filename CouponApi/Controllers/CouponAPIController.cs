using CouponApi.Data;
using CouponApi.Models;
using CouponApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CouponApi.Controllers
{
    [Route("api/CouponAPI")]
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
        public ResponseDto Get() 
        {
            try
            {
                IEnumerable<Coupon> objlist = _db.Coupons.ToList();
                _response.Result = objlist;
              
            }catch(Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get([FromRoute] int id)
        {
            try
            {
                Coupon objlist = _db.Coupons.First(u=>u.CouponId==id);
                _response.Result= objlist;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

    }
}
