using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;

namespace API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ContactsController : ControllerBase
   {
      private readonly ApplicationDbContext _context;

      public ContactsController(ApplicationDbContext context)
      {
         _context = context;
      }

      // GET: api/Contacts
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Contact>>> GetContact()
      {
         return await _context.Contact.ToListAsync().ConfigureAwait(false);
      }

      // GET: api/Contacts/5
      [HttpGet("{id}")]
      public async Task<ActionResult<Contact>> GetContact(int id)
      {
         var contact = await _context.Contact.FindAsync(id).ConfigureAwait(false);

         if (contact == null)
         {
            return NotFound();
         }

         return contact;
      }

      // PUT: api/Contacts/5
      // To protect from overposting attacks, enable the specific properties you want to bind to, for
      // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      [HttpPut("{id}")]
      public async Task<IActionResult> PutContact(int id, Contact contact)
      {
         if (contact != null && id != contact.Id)
         {
            return BadRequest();
         }

         _context.Entry(contact).State = EntityState.Modified;

         try
         {
            await _context.SaveChangesAsync().ConfigureAwait(false);
         }
         catch (DbUpdateConcurrencyException)
         {
            if (!ContactExists(id))
            {
               return NotFound();
            }
            else
            {
               throw;
            }
         }

         return NoContent();
      }

      // POST: api/Contacts
      // To protect from overposting attacks, enable the specific properties you want to bind to, for
      // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      [HttpPost]
      public async Task<ActionResult<Contact>> PostContact(Contact contact)
      {
         if (contact == null) return BadRequest();
         _context.Contact.Add(contact);
         await _context.SaveChangesAsync().ConfigureAwait(false);

         return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
      }

      // DELETE: api/Contacts/5
      [HttpDelete("{id}")]
      public async Task<ActionResult<Contact>> DeleteContact(int id)
      {
         var contact = await _context.Contact.FindAsync(id);
         if (contact == null)
         {
            return NotFound();
         }

         _context.Contact.Remove(contact);
         await _context.SaveChangesAsync().ConfigureAwait(false);

         return contact;
      }

      private bool ContactExists(int id)
      {
         return _context.Contact.Any(e => e.Id == id);
      }
   }
}
