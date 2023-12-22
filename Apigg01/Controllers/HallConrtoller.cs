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
    public class HallController : ControllerBase
    {
        private readonly DataContext db;
        public HallController(DataContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public IEnumerable<Hall> GetHalls()
        {
            return db.Halls.ToList();
        }
        [HttpPost]
        public void SaveHall([FromBody] Hall hall)
        {
            db.Halls.Add(hall);
            db.SaveChanges();
        }
        [HttpPut]
        public async Task<ActionResult<Hall>> Put(Hall hall)
        {
            if (hall == null)
            {
                return BadRequest();
            }
            if (!db.Halls.Any(x => x.IdHall == hall.IdHall))
            {
                return NotFound();
            }
            db.Update(hall);
            await db.SaveChangesAsync();
            return Ok(hall);
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            db.Halls.Remove(db.Halls.Where(p => p.IdHall == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}