using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactsCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly Eradb002Context _context;

        public ContactController(Eradb002Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllContacts")]
        public async Task<IActionResult> ContactsList()
        {
            List<Contact> contacts = await _context.Contacts.OrderByDescending(c => c.ContactId).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, contacts);
        }

        [HttpPost]
        [Route("AddContact")]
        public async Task<IActionResult> AddContact([FromBody] Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("EditContact")]
        public async Task<IActionResult> EditContact([FromBody] Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        [Route("DeleteContact/{id:int}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            Contact contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
