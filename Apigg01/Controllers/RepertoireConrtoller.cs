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
    public class RepertoireController : ControllerBase
    {
        private readonly DataContext db;
        public RepertoireController(DataContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public IEnumerable<Repertoire> GetTickets()
        {
            return db.Repertoires.ToList();
        }
        [HttpPut]
        public async Task<ActionResult<Repertoire>> Put(Repertoire repertoire)
        {
            if (repertoire == null)
            {
                return BadRequest();
            }
            if (!db.Repertoires.Any(x => x.IdRepertoire == repertoire.IdRepertoire))
            {
                return NotFound();
            }
            db.Update(repertoire);
            await db.SaveChangesAsync();
            return Ok(repertoire);
        }
        [HttpPut]
        public void UpdateRepertoire([FromBody] Repertoire repertoire)
        {
            db.Repertoires.Update(repertoire);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            db.Repertoires.Remove(db.Repertoires.Where(p => p.IdRepertoire == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}