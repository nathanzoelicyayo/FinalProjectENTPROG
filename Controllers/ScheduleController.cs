using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
