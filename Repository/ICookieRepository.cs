using CookieStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookieStore.Api.Repository
{
    public interface ICookieRepository
    {
        Task<List<CookieModel>> GetAllCookiesAsync();
        Task<CookieModel> GetCookieByIdAsync(int cookieId);

        Task<int> AddCookieAsync(CookieModel cookieModel);

        Task UpdateCookieAsync(int cookieId, CookieModel cookieModel);

        Task UpdateCookiePatchAsync(int cookieId, JsonPatchDocument cookieModel);

        Task DeleteCookieAsync(int cookieId);
    }
}
