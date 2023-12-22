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
    public class TicketController : ControllerBase
    {
        private readonly DataContext db;
        public TicketController(DataContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public IEnumerable<Ticket> GetTickets()
        {
            return db.Tickets.ToList();
        }
        [HttpPost]
        public void SaveTicket([FromBody] Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
        }
        [HttpPut]
        public async Task<ActionResult<Ticket>> Put(Ticket ticket) 
        {
            if(ticket == null)
            {
                return BadRequest();
            }
            if(!db.Tickets.Any(x =>x.IdTicket == ticket.IdTicket))
            {
                return NotFound();
            }
            db.Update(ticket);
            await db.SaveChangesAsync();
            return Ok(ticket);
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            db.Tickets.Remove(db.Tickets.Where(p => p.IdTicket == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}