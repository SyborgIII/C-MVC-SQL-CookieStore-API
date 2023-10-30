using CookieStore.Api.Models;
using CookieStore.Api.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookiesController : ControllerBase
    {
        int test = 20;
        public readonly ICookieRepository cookieRepository;
        public CookiesController(ICookieRepository cookieRepository)
        {
            this.cookieRepository = cookieRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCookies()
        {
            var cookies = await cookieRepository.GetAllCookiesAsync();
            return Ok(cookies); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCookieById([FromRoute]int id)
        {
            var cookies = await cookieRepository.GetCookieByIdAsync(id);
            if(cookies == null) 
            {
                return NotFound();
            }
            return Ok(cookies);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewCookie([FromBody]CookieModel cookieModel)
        {
            var id = await cookieRepository.AddCookieAsync(cookieModel);
            return CreatedAtAction(nameof(GetCookieById), new { id = id, controller = "cookies" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCookie([FromBody] CookieModel cookieModel, [FromRoute] int id)
        {
            await cookieRepository.UpdateCookieAsync(id, cookieModel);  
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCookiePatch([FromBody] JsonPatchDocument cookieModel, [FromRoute] int id)
        {
            await cookieRepository.UpdateCookiePatchAsync(id, cookieModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookiePatch( [FromRoute] int id)
        {
            await cookieRepository.DeleteCookieAsync(id);
            return Ok();
        }
    }
}
