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
    public class CoachesController : Controller
    {
        private readonly GroupFTennisWebAppContext _context;
        private readonly UserManager<GroupFTennisWebAppUser> _userManager;



        public CoachesController(GroupFTennisWebAppContext context, UserManager<GroupFTennisWebAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;


        }

        // GET: Coaches
        //only an admin and member can view all coaches as per assignment request
        [Authorize(Roles = "Member, Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coach.ToListAsync());
        }


        [Authorize(Roles = "Admin, Coach, Member")]
        public ActionResult MyCoach()
        {

            var coach = _userManager.GetUserName(User);
            var myCoach = _context.Coach.Where(m => m.Email == coach);

            return View("Index", myCoach);

        }

        //Only an admin can view all schedules
        [Authorize(Roles = "Admin")]
        public ActionResult AllSchedule()
        {
            var schedules = _context.Schedule.ToList();

            return View("MySchedule", schedules);

        }

        //Only a coach can view their own schedule
        [Authorize(Roles = "Coach")]
        public ActionResult MySchedule()
        {
            // GET current User
            var coach = _userManager.GetUserName(User);
            // Query db to match all records with same CoachEmail
            var schedules = _context.Schedule.Where(m => m.CoachEmail == coach);
            return View("MySchedule", schedules);

        }

        public IActionResult Schedules(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = _context.ScheduleMembers
                .Where(m => m.ScheduleId == id);

            return View("Schedule", member);
        }

        [HttpGet]
        public IActionResult ListCoaches()
        {
            var coaches = _userManager.Users.Where(m => m.Role == "coach");
            return View(coaches);
        }


        // GET: Coaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // GET: Coaches/Create
        [Authorize(Roles = "Coach")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Coach")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Biography,PhotoUrl")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(coach);
        }

        // GET: Coaches/Edit/5
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coach.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }
            return View(coach);
        }

        // POST: Coaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Coach")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Biography,PhotoUrl")] Coach coach)
        {
            if (id != coach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachExists(coach.Id))
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
            return View(coach);
        }

        // GET: Coaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coach = await _context.Coach.FindAsync(id);
            _context.Coach.Remove(coach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoachExists(int id)
        {
            return _context.Coach.Any(e => e.Id == id);
        }

        //Gets all users who have a role of "coach" and lists them
        [HttpGet]
        public IActionResult CoachProfile()
        {
            var user = _userManager.GetUserName(User);

            var profile = _userManager.Users.Where(m => m.UserName == user);
            return View(profile);
        }
    }
}
