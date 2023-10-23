using AutoMapper;
using CookieStore.Api.Data;
using CookieStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.Api.Repository
{
    public class CookieRepository : ICookieRepository
    {
        private readonly CookieStoreContext context;
        private readonly IMapper mapper;

        public CookieRepository(CookieStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;   
        }
        public async Task<List<CookieModel>> GetAllCookiesAsync()
        {
            var records = await context.Cookies.ToListAsync();

            return mapper.Map<List<CookieModel>>(records); 
        }

        public async Task<CookieModel> GetCookieByIdAsync(int cookieId)
        {
            //var records = await context.Cookies.Where(x=> x.Id == cookieId).Select(x => new CookieModel()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    description = x.description
            //}).FirstOrDefaultAsync();
            //return records;

            var cookie = await context.Cookies.FindAsync(cookieId);
            return mapper.Map<CookieModel>(cookie); 
        }

        public async Task<int> AddCookieAsync(CookieModel cookieModel)
        {
            var cookie = new Cookies()
            {
                Name = cookieModel.Name,
                description = cookieModel.description
            };
            context.Cookies.Add(cookie);    
            await context.SaveChangesAsync();
            return cookie.Id;
        }

        public async Task UpdateCookieAsync(int cookieId, CookieModel cookieModel)
        {
            //var cookie = await context.Cookies.FindAsync(cookieId);
            //if (cookie != null)
            //{
            //    cookie.Name = cookieModel.Name; 
            //    cookie.description = cookieModel.description;   

            //    await context.SaveChangesAsync();
            //}

            var cookie = new Cookies()
            {
                Id= cookieId,
                Name = cookieModel.Name,
                description = cookieModel.description
            };
            context.Cookies.Update(cookie);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCookiePatchAsync(int cookieId, JsonPatchDocument cookieModel)
        {
            var cookeie = await context.Cookies.FindAsync(cookieId);
            if (cookeie != null) 
            {
                cookieModel.ApplyTo(cookeie);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteCookieAsync(int cookieId)
        {
            var cookie = new Cookies() { Id = cookieId};
            context.Cookies.Remove(cookie);
            await context.SaveChangesAsync();
        }

    }
}
