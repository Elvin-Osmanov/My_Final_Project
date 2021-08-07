using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
    [Area("Manage")]
    public class TableController : Controller
    {
        private readonly AppDbContext _context;

        public TableController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Tables.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            TableViewModel tableViewModel = new TableViewModel
            {
                Tables = await _context.Tables.Skip((page - 1) * 5).Take(5).ToListAsync()
            };
            return View(tableViewModel);
        }

        public IActionResult Create()
        {

           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Table table)
        {
            if (!ModelState.IsValid)
                return View();


            table.CreatedDate = DateTime.UtcNow;
            table.ModifiedDate = DateTime.UtcNow;
            table.EndTime = table.StartTime.AddHours(2);

           
            int counterofmatches = 0;
            int counterofwatches = 0;
           
            foreach (var item in _context.Tables)
            {
                var time = item.StartTime.TimeOfDay;
                var end = item.EndTime.TimeOfDay;
                if (table.Date == item.Date)
                {
                    counterofmatches++;


                    //Number of tables that available for a day
                    if (counterofmatches == 35)
                    {
                        ModelState.AddModelError("Table", "No more tables for this span");
                        return View();
                    }


                    if ((table.StartTime.Hour == item.StartTime.Hour))
                    {
                        counterofwatches++;
                        if (counterofwatches == 5)
                        {
                            if (time <= table.StartTime.TimeOfDay && end <= table.EndTime.TimeOfDay)
                            {
                                ModelState.AddModelError("Table", "No more tables for this span");
                                return View();
                            }

                            
                        }

                    }
                }
                              
            }



            await _context.Tables.AddAsync(table);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Table table = await _context.Tables.FirstOrDefaultAsync(x => x.Id == id);

            if (table == null)
            {
                return NotFound();
            }
           
            return View(table);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Table table)
        {
            Table tableExist = await _context.Tables.FirstOrDefaultAsync(x => x.Id == table.Id);

            if (tableExist == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return View();


            int counterofmatches = 0;
            int counterofwatches = 0;

            foreach (var item in _context.Tables)
            {
                var time = item.StartTime.TimeOfDay;
              
                if (table.Date == item.Date)
                {
                    counterofmatches++;


                    //Number of tables that available for a day
                    if (counterofmatches == 35)
                    {
                        ModelState.AddModelError("Table", "No more tables for this span");
                        return View();
                    }


                    if ((table.StartTime.Hour == item.StartTime.Hour))
                    {
                        counterofwatches++;
                        if (counterofwatches == 5)
                        {
                            if (time <= table.StartTime.TimeOfDay)
                            {
                                ModelState.AddModelError("Table", "No more tables for this span");
                                return View();
                            }


                        }

                    }
                }

            }


            tableExist.Date = table.Date;
            tableExist.StartTime = table.StartTime;
            tableExist.EndTime = tableExist.StartTime.AddHours(2);
            tableExist.ModifiedDate = DateTime.UtcNow;


            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Table table = await _context.Tables.FirstOrDefaultAsync(x => x.Id == id);

            if (table == null)
            {
                return NotFound();
            }
          
            return View(table);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Table table = await _context.Tables.FirstOrDefaultAsync(x => x.Id == id);

            if (table == null)
            {
                return NotFound();
            }
           
            return View(table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Table table)
        {
            Table tableExist = await _context.Tables.FirstOrDefaultAsync(x => x.Id == table.Id);

            if (tableExist == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(tableExist);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Reservations(int id, int page = 1)
        {
            double totalCount = await _context.Tables.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;
            Table table = await _context.Tables.Include(x=>x.Reservation).FirstOrDefaultAsync(x => x.Id == id);


            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }
    }
}
