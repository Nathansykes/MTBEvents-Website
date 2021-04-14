using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTBEventProject.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace MTBEventProject.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CMSController : Controller
    {
        private readonly ILogger<CMSController> _logger;

        private readonly ApplicationDbContext _context;

        public CMSController(ILogger<CMSController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<MTBEvent> model = _context.MTBEvents.ToList();
            return View(model);
        }


        [HttpGet]
        public IActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEvent(MTBEventForm model)
        {
            MTBEvent newEvent = new MTBEvent
            {
                MTBEventTitle = model.MTBEventTitle,
                MTBEventLocation = model.MTBEventLocation,
                MTBEventDescription = model.MTBEventDescription,
                MTBEventWebsite= model.MTBEventWebsite,
                MTBEventDate= model.MTBEventDate,
                MTBEventGroup = model.MTBEventGroup,
            };
            _context.Add(newEvent);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

            
        }


        

        [HttpGet]
        public IActionResult UpdateEvent(int id)
        {
            MTBEvent model = _context.MTBEvents.Find(id);
            MTBEventForm formModel = new MTBEventForm
            {
                MTBEventID = model.MTBEventID,
                MTBEventTitle = model.MTBEventTitle,
                MTBEventLocation = model.MTBEventLocation,
                MTBEventDescription = model.MTBEventDescription,
                MTBEventWebsite = model.MTBEventWebsite,
                MTBEventDate = model.MTBEventDate,
                MTBEventGroup = model.MTBEventGroup,
            };

            return View(formModel);
        }

        [HttpPost]
        public IActionResult UpdateEvent(MTBEventForm model)
        {

            if (ModelState.IsValid)
            {
                MTBEvent editEvent = new MTBEvent
                {
                    MTBEventID = model.MTBEventID,
                    MTBEventTitle = model.MTBEventTitle,
                    MTBEventLocation = model.MTBEventLocation,
                    MTBEventDescription = model.MTBEventDescription,
                    MTBEventWebsite = model.MTBEventWebsite,
                    MTBEventDate = model.MTBEventDate,
                    MTBEventGroup = model.MTBEventGroup,
                };
                _context.MTBEvents.Update(editEvent); 

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }




        [HttpGet]
        public IActionResult DeleteEvent(int id)
        {
            MTBEvent model = _context.MTBEvents.Find(id);

            return View(model);
        }


        [HttpPost]
        public IActionResult DeleteEvent(MTBEvent model)
        {
            _context.MTBEvents.Remove(model);
            _context.SaveChanges();
                

            return RedirectToAction("Index");
        }


    }
}
