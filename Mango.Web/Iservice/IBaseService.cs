using Mango.Web.Models;


namespace Mango.Web.Iservice
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto dto);
    }
}
