using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;

namespace Restabook.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHubContext<NotificationHub> _hubContext;

        public ContactController(AppDbContext context, UserManager<AppUser> userManager, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
           _userManager = userManager;
            _hubContext = hubContext;
           
        }

      

        public IActionResult Index()
        {


            Contact contact = _context.Contacts.FirstOrDefault();
               
           
            return View(contact);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Message(ContactMessage message1)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Contact contact = await _context.Contacts.Include(x => x.ContactMessages).FirstOrDefaultAsync(x => x.Id == message1.ContactId);

            if (contact == null)
                return NotFound();


            ContactMessage contactMessage = new ContactMessage
            {
                CreatedDate = DateTime.Now,
                ModifiedDate  = DateTime.Now,
                Email = message1.Email,
                PhoneNumber=message1.PhoneNumber,
                FullName = message1.FullName,
                ContactId = message1.ContactId,
                Subject = message1.Subject,
                Message = message1.Message
            };

            contact.ContactMessages.Add(contactMessage);

            await _context.SaveChangesAsync();
            List<string> adminConIds = _context.Users.Where(u => !u.IsMember).Select(x => x.ConnectionId).ToList();
            await _hubContext.Clients.Clients(adminConIds).SendAsync("MessageSent", user.FullName, message1.Message.Substring(0,10), message1.CreatedDate.ToString("dd.MMMM.yyyy"));

            return RedirectToAction("index");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Subscribe(Subscriber subscriber)
        {
            if (subscriber.Email != null)
            {
                Subscriber sub = new Subscriber();
                if (!await _context.Subscribers.AnyAsync(x => x.Email == subscriber.Email))
                {


                    sub.CreatedDate = DateTime.UtcNow;
                    sub.ModifiedDate = DateTime.UtcNow;
                    sub.Email = subscriber.Email;


                }



                _context.Subscribers.Add(sub);

                await _context.SaveChangesAsync();
            }
           
           
           


            return RedirectToAction("index");
        }
    }
}
