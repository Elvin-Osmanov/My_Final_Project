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

        public async Task<IActionResult> Create()
        {

            ViewBag.Times = await _context.Times.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Table table)
        {
            if (!ModelState.IsValid)
                return View();

            var counterofmatches = 0;

            foreach (var item in _context.Tables)
            {
                if (table.Date == item.Date)
                {
                    if (counterofmatches == 5)
                    {
                        ModelState.AddModelError("Table", "No more tables for this span");
                        return View();
                    }
                    counterofmatches++;
                }
            }



            table.TimeTables = await _createProductTimes(table.TimeIds);
            table.CreatedDate = DateTime.UtcNow;
            table.ModifiedDate = DateTime.UtcNow;

            Table lastTable = await _context.Tables.OrderByDescending(x => x.No).FirstOrDefaultAsync();
            table.No = lastTable == null ? 101 : (lastTable.No + 1);

            var tt = _context.Tables.Include(x => x.TimeTables).ThenInclude(p => p.Time);




            await _context.Tables.AddAsync(table);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Table table = await _context.Tables.Include(x => x.TimeTables).FirstOrDefaultAsync(x => x.Id == id);

            if (table == null)
            {
                return NotFound();
            }
            ViewBag.Times = await _context.Times.ToListAsync();
            return View(table);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Table table)
        {
            Table tableExist = await _context.Tables.Include(x => x.TimeTables).FirstOrDefaultAsync(x => x.Id == table.Id);

            if (tableExist == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return View();

            var counterofmatches = 0;
            foreach (var item in _context.Tables)
            {
                if (item.Date == table.Date)
                {
                    if (counterofmatches == 5)
                    {
                        ModelState.AddModelError("Table", "No more tables for this span");
                        return View();
                    }
                    counterofmatches++;
                }
            }

            tableExist.TimeTables = await _getUpdatedProductTimesAsync(tableExist.TimeTables, table.TimeIds, table.Id);

            tableExist.Date = table.Date;

            tableExist.ModifiedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Table table = await _context.Tables.Include(x => x.TimeTables).ThenInclude(t => t.Time).FirstOrDefaultAsync(x => x.Id == id);

            if (table == null)
            {
                return NotFound();
            }
            ViewBag.Times = await _context.Times.ToListAsync();
            return View(table);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Table table = await _context.Tables.Include(x => x.TimeTables).ThenInclude(t => t.Time).FirstOrDefaultAsync(x => x.Id == id);

            if (table == null)
            {
                return NotFound();
            }
            ViewBag.Times = await _context.Times.ToListAsync();
            return View(table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Table table)
        {
            Table tableExist = await _context.Tables.Include(x => x.TimeTables).ThenInclude(t => t.Time).FirstOrDefaultAsync(x => x.Id == table.Id);

            if (tableExist == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(tableExist);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        private async Task<List<TimeTable>> _getUpdatedProductTimesAsync(List<TimeTable> timeTables, int[] timeIds, int tableId)
        {
            List<TimeTable> removableTimes = new List<TimeTable>();
            removableTimes.AddRange(timeTables);

            foreach (var timeId in timeIds)
            {
                TimeTable time = timeTables.FirstOrDefault(x => x.TimeId == timeId);

                if (time != null)
                {
                    removableTimes.Remove(time);
                }
                else
                {
                    if (!await _context.Times.AnyAsync(x => x.Id == timeId))
                    {
                        throw new Exception("Time not found!");
                    }

                    time = new TimeTable
                    {
                        TimeId = timeId,
                        TableId = tableId
                    };

                    timeTables.Add(time);
                }
            }

            timeTables = timeTables.Except(removableTimes).ToList();

            return timeTables;
        }
        private async Task<List<TimeTable>> _createProductTimes(int[] timeIds)
        {

            List<TimeTable> timeTables = new List<TimeTable>();
            foreach (var timeId in timeIds)
            {
                if (!await _context.Times.AnyAsync(x => x.Id == timeId))
                {
                    throw new Exception("Time not found!");
                }

                TimeTable timeTable = new TimeTable
                {
                    TimeId = timeId
                };

                timeTables.Add(timeTable);
            }

            return timeTables;
        }
    }
}
