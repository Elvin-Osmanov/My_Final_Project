using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;

namespace Restabook.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ContactViewModel contactVM = new ContactViewModel
            {
                Contact = _context.Contacts.FirstOrDefault(),
                Setting= _context.Settings.FirstOrDefault()
            };
            return View(contactVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Message(ContactMessage message1)
        {
            Contact contact = await _context.Contacts.Include(x => x.ContactMessages).FirstOrDefaultAsync(x => x.Id == message1.ContactId);

            if (contact == null)
                return NotFound();


            ContactMessage contactMessage = new ContactMessage
            {
                CreatedDate = DateTime.UtcNow,
                ModifiedDate  = DateTime.UtcNow,
                Email = message1.Email,
                PhoneNumber=message1.PhoneNumber,
                FullName = message1.FullName,
                ContactId = message1.ContactId,
                Subject = message1.Subject,
                Message = message1.Message
            };

            contact.ContactMessages.Add(contactMessage);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
