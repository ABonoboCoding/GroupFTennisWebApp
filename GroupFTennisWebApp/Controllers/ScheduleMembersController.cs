using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GroupFTennisWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupFTennisWebApp.Data;
using GroupFTennisWebApp.Models;

namespace GroupFTennisWebApp.Controllers
{
    public class ScheduleMembersController : Controller
    {
        private readonly GroupFTennisWebAppContext _context;
        private readonly UserManager<GroupFTennisWebAppUser> _userManager;



        public ScheduleMembersController(GroupFTennisWebAppContext context, UserManager<GroupFTennisWebAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: ScheduleMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScheduleMembers.ToListAsync());
        }
   
        // GET: ScheduleMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleMembers = await _context.ScheduleMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scheduleMembers == null)
            {
                return NotFound();
            }

            return View(scheduleMembers);
        }

        // GET: ScheduleMembers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScheduleMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScheduleId,MemberEmail")] ScheduleMembers scheduleMembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleMembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleMembers);
        }

        // GET: ScheduleMembers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleMembers = await _context.ScheduleMembers.FindAsync(id);
            if (scheduleMembers == null)
            {
                return NotFound();
            }
            return View(scheduleMembers);
        }

        // POST: ScheduleMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ScheduleId,MemberEmail")] ScheduleMembers scheduleMembers)
        {
            if (id != scheduleMembers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleMembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleMembersExists(scheduleMembers.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleMembers);
        }

        // GET: ScheduleMembers/Delete/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleMembers = await _context.ScheduleMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scheduleMembers == null)
            {
                return NotFound();
            }

            return View(scheduleMembers);
        }

        // POST: ScheduleMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduleMembers = await _context.ScheduleMembers.FindAsync(id);
            _context.ScheduleMembers.Remove(scheduleMembers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
     
        private bool ScheduleMembersExists(int id)
        {
            return _context.ScheduleMembers.Any(e => e.Id == id);
        }


    }
}
