using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MTBEventProject.Models;

namespace MTBEventProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult AllEvents()
        {
            MTBEvent a = _context.MTBEvents.FirstOrDefault();
            List<MTBEvent> model = _context.MTBEvents.ToList();

            

            return View(model.OrderBy(a => a.MTBEventDate));

        }

        public IActionResult EventDetails(int id)
        {
            MTBEvent model = _context.MTBEvents.Find(id);

            return View(model);
                

        }

        public IActionResult Search(String SearchString, String SearchField)

        {

            if (!string.IsNullOrEmpty(SearchString) || !string.IsNullOrEmpty(SearchField))
            {
                var events = from m in _context.MTBEvents
                             where m.MTBEventTitle.Contains(SearchString)
                             select m; 

                switch (SearchField)
                {

                    case "MTBEventLocation":
                        events = from m in _context.MTBEvents
                                 where m.MTBEventLocation.Contains(SearchString)
                                 select m;
                        break;

                    case "MTBEventGroup":
                        events = from m in _context.MTBEvents
                                 where m.MTBEventGroup.Contains(SearchString)
                                 select m;
                        break;

                    default:
                        events = from m in _context.MTBEvents
                                 where m.MTBEventTitle.Contains(SearchString)
                                 select m;
                        break;
                }

                

                List<MTBEvent> model = events.ToList();

                ViewData["SearchString"] = SearchString;
                ViewData["SearchField"] = SearchField;

                return View(model);

            }
            else
            {
                return View();
            }



        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
