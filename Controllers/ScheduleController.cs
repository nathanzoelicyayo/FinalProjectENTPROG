using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

using FinalProjectENTPROG.Data;
using FinalProjectENTPROG.Models;

namespace FinalProjectENTPROG.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (user.Type != UserTypes.Admin)
            {
                return RedirectToAction("Index", "Home");
            }
            var list = _context.Schedules.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Schedule record)
        {
            var schedule = new Schedule()
            {
                ScheduleID = record.ScheduleID,
                Admin = record.Admin,
                ScheduledUser = record.ScheduledUser,
                Location = record.Location,
                Date = record.Date,
                Slots = record.Slots
            };

            _context.Schedules.Add(schedule);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (user.Type != UserTypes.Admin)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var schedule = _context.Schedules.Where(i => i.ScheduleID == id).SingleOrDefault();
            if (schedule == null)
            {
                return RedirectToAction("Index");
            }

            return View(schedule);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Schedule record)
        {
            var schedule = _context.Schedules.Where(i => i.ScheduleID == id).SingleOrDefault();
            schedule.ScheduleID = record.ScheduleID;
            schedule.Admin = record.Admin;
            schedule.ScheduledUser = record.ScheduledUser;
            schedule.Location = record.Location;
            schedule.Date = record.Date;
            schedule.Slots = record.Slots;

            _context.Schedules.Update(schedule);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
