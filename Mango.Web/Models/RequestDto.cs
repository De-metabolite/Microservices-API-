using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using Mango.Web.Models.HttpActions;

namespace Mango.Web.Models
{
    public class RequestDto
        {
       
        public  SD.Method ApiType { get; set; } =    SD.Method.GET;
        public  string? Url { get; set; }
        public  object? Data { get; set; } 
        public string? AccessToken {  get; set; }
       }


}
