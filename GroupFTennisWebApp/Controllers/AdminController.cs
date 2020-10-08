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

namespace AssignmentTwo.Controllers
{
    //Must be an admin to access any admin controller methods
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly GroupFTennisWebAppContext _context;
        private readonly UserManager<GroupFTennisWebAppUser> _userManager;
        



        public AdminController(GroupFTennisWebAppContext context, UserManager<GroupFTennisWebAppUser> userManager)
        {
            _userManager = userManager;
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Showallmember()
        {
            var user = _userManager.Users;
            return View(user);
        }

        // GET: Admin/Schedule
        public async Task<IActionResult> Schedule()
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
        public IActionResult Create()
        {
            IEnumerable<Coach> Coach = _context.Coach.ToList();

            GroupFTennisWebApp.ViewModels.CoachCreate viewModel = new GroupFTennisWebApp.ViewModels.CoachCreate
            {
                Coach = Coach
            };
            return View(viewModel);
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

            IEnumerable<Coach> Coach = _context.Coach.ToList();

            GroupFTennisWebApp.ViewModels.CoachCreate viewModel = new GroupFTennisWebApp.ViewModels.CoachCreate
            {
                Coach = Coach
            };
            return View(viewModel);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        private bool ScheduleExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: Schedules/Delete/5
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

        //Gets all users who have a role of "member" and lists them
        [HttpGet]
        public IActionResult ListMembers()
        {
            var members = _userManager.Users.Where(m => m.Role == "member");
            return View(members);
        }

        //Gets all users who have a role of "coach" and lists them
        [HttpGet]
        public IActionResult ListCoaches()
        {
            var coaches = _userManager.Users.Where(m => m.Role == "coach");
            return View(coaches);
        }
    }
}