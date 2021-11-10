using Microsoft.AspNetCore.Mvc;
using ShareImageProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareImageProject.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var model = new GalleryIndexModel
            {
            
            };
            return View(model);
        }
    }
}
