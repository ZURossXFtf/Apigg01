using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apigg01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly DataContext db;
        public FilmController(DataContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public IEnumerable<Film> GetHalls()
        {
            return db.Films.ToList();
        }
        [HttpPost]
        public void SaveFilm([FromBody] Film film)
        {
            db.Films.Add(film);
            db.SaveChanges();
        }
        [HttpPut]
        public async Task<ActionResult<Film>> Put(Film film)
        {
            if (film == null)
            {
                return BadRequest();
            }
            if (!db.Films.Any(x => x.IdFilm == film.IdFilm))
            {
                return NotFound();
            }
            db.Update(film);
            await db.SaveChangesAsync();
            return Ok(film);
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            db.Films.Remove(db.Films.Where(p => p.IdFilm == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}