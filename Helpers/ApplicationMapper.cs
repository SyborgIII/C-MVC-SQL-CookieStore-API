using AutoMapper;
using CookieStore.Api.Data;
using CookieStore.Api.Models;
using System.Net;

namespace CookieStore.Api.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Cookies, CookieModel>().ReverseMap();
        }  
    }
}
