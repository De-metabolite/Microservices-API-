using Mango.Web.Models;
using Mango.Web.Models.HttpActions;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;


namespace Mango.Web.Iservice
{
    public class BaseService:IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto> SendAsync(RequestDto dto) 
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                RequestDto request = new();
                message.RequestUri = new Uri(request.Url);
                if (request.Data != null)
                {
                    message.Content = new StringContent(JsonSerializer.Serialize(request.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage? apiresponse = null;
                switch (request.ApiType)
                {
                    case SD.Method.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.Method.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.Method.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;

                }

                apiresponse = await client.SendAsync(message);

                switch (apiresponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "NotFound",
                        };

                    case System.Net.HttpStatusCode.Forbidden:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Forbiden"

                        };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Unauthorised"
                        };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "InternalServerError"
                        };
                    default:
                        var apicontent = await apiresponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonSerializer.Deserialize<ResponseDto>(apicontent);
                        return apiResponseDto;
                }
            }catch (Exception ex)
                {
                    return new()
                    {
                        IsSuccess = false,
                        Message = ex.Message.ToString()
                    };
                }   

        }
    }
}
