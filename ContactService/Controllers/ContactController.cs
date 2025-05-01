using ContactService.Models.Data;
using ContactService.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAll")]
        public async Task<List<Contact>> GetAll()
        {
            return await _dbContext.Contacts.ToListAsync();
        }

        [HttpGet("Get{UUID}")]
        public async Task<Contact> GetById(Guid uuid)
        {
            return await _dbContext.Contacts.FirstOrDefaultAsync(x => x.UUID == uuid);
        }
        
        [HttpPost("Post")]
        public async Task<IActionResult> Create([FromBody] Contact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return Ok("Adding Record Successful");
            //return CreatedAtAction(nameof(GetById), new { id = contactInfo.UUID }, contactInfo);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();
            return Ok("Registration Updated");
        }

        [HttpDelete("Delete{UUID}")]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            var contactInfo = await GetById(uuid); 
            if (contactInfo is null) { return NotFound(); }
            _dbContext.Contacts.Remove(contactInfo);  
            await _dbContext.SaveChangesAsync();
            return Ok("Record Deleted");
        }

    }
}
