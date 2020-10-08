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
    public class SchedulesController : Controller
    {
        private readonly GroupFTennisWebAppContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<GroupFTennisWebAppUser> _userManager;


        public SchedulesController(GroupFTennisWebAppContext context, UserManager<GroupFTennisWebAppUser> userManager, RoleManager <IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            this.roleManager = roleManager;


        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            return View(await _context.Schedule.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        //Only a member can view a schedule 
        [Authorize(Roles = "Member,Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Only an admin or member can create a schedule 
        [Authorize(Roles = "Admin, Member")]


        public async Task<IActionResult> Create([Bind("Id,When,Description,CoachEmail,Location")] Schedule schedule)
        {
         


            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Edit/5
      //  [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,When,Description,CoachEmail,Location")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
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
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        [Authorize(Roles = "Admin")]    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Enrol(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FirstOrDefaultAsync(m => m.Id == id);

            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        //Allows user to enrol into a schedule
        [HttpPost, ActionName("Enrol")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnrolConfirmed(int id, [Bind("ScheduleId")] ScheduleMembers member)
        {
            var newMember = await _context.Schedule.FindAsync(id);

            if (newMember.When < DateTime.Now)
            {
                ViewBag.errorMessage = "Sorry, You can't sign up to the event that has already happened.";
                return View("Views/Home/Error.cshtml", ViewBag.errorMessage);
            }

            if (newMember.When > DateTime.Now)
            {
                member.ScheduleId = newMember.Id;
                member.MemberEmail = _userManager.GetUserName(User);

                _context.Add(member);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return View(newMember);

        }


        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.Id == id);
        }
    }
}
