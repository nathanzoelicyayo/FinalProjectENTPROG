using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

using FinalProjectENTPROG.Data;
using FinalProjectENTPROG.Models;

using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace FinalProjectENTPROG.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public MailAddress from { get; set; }

        public ScheduleController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (User.Identity.IsAuthenticated)
            {
                if (user.Type != UserTypes.Admin)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
            
            var list = _context.Schedules.ToList();
            //ViewBag.userid = _userManager.GetUserId();
            return View(list);        
        }

        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (User.Identity.IsAuthenticated)
            {
                if (user.Type != UserTypes.Admin)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Schedule record)
        {
            string userid = _userManager.GetUserId(HttpContext.User);
            var schedule = new Schedule()
            {
                ScheduleID = record.ScheduleID,
                Admin = record.Admin,
                Id = userid,
                Location = record.Location,
                Municipality = record.Municipality,
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
            schedule.Admin = record.Admin = _userManager.GetUserId(HttpContext.User);
            schedule.Id = schedule.Id;
            schedule.Location = record.Location;
            schedule.Municipality = record.Municipality;
            schedule.Date = record.Date;
            schedule.Slots = record.Slots;

            _context.Schedules.Update(schedule);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Contact()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (user.Type != UserTypes.Admin)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact record)
        {

            var mail = new MailMessage();
            mail.From = new MailAddress("benildesample@gmail.com", "Vaccination Queueing Staff");
            mail.To.Add(new MailAddress(record.Email));

            mail.Subject = "Inquiry from" + record.ScheduledUser + " (" + record.Subject + ")";
            string message = "Good day " + record.ScheduledUser + "<br/><br/>" +
                "Here is your Vaccination Schedule details: <br/><br/>" +
                "Location: " + record.Municipality + ", " + record.Location + "<br/>" +
                "Date and Time: " + record.Date + " - " + record.Time + "<br/><br/>" +
                "See you!";
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("benildesample@gmail.com", "entprog2021"),
                EnableSsl = true
            };

            smtp.Send(mail);
            ViewBag.Message = "Schedule sent.";
            return View();
        }

        public IActionResult ListUsers()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (User.Identity.IsAuthenticated)
            {
                if (user.Type != UserTypes.Admin)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

            var users = _userManager.Users;
            return View(users);
        }
    }
}
