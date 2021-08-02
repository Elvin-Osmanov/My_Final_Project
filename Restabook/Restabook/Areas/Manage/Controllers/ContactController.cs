using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;

namespace Restabook.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
    [Area("Manage")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            ContactViewModel contactVM = new ContactViewModel
            {
                Contact = await _context.Contacts.FirstOrDefaultAsync()
            };
            return View(contactVM);
        }





        public async Task<IActionResult> Edit(int id)
        {
            Contact contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            Contact existCon = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == contact.Id);

            if (existCon == null)
                return NotFound();

            existCon.Address = contact.Address;
            existCon.Phone = contact.Phone;
            existCon.SupportEmail = contact.SupportEmail;

            existCon.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }



        public async Task<IActionResult> Message(int contactId)
        {
            List<ContactMessage> contactMessages = await _context.ContactMessages.Where(x => x.ContactId == contactId).ToListAsync();

            return View(contactMessages);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            ContactMessage message = await _context.ContactMessages.FirstOrDefaultAsync(x => x.Id == id);
            Contact contact = await _context.Contacts.Include(x => x.ContactMessages).FirstOrDefaultAsync(x => x.Id == message.ContactId);


            if (message == null)
                return NotFound();

            _context.ContactMessages.Remove(message);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
