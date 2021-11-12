using Microsoft.AspNetCore.Mvc;
using ShareImageProject.Models;
using SimpleImageGallery.Data;
using SimpleImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareImageProject.Controllers
{
    public class GalleryController : Controller
    {
        //Private field
        private readonly AnImage _imgService;

        //Constructor
        public GalleryController(AnImage imgService)
        {
            _imgService = imgService;
        }

        //Going to use dependency injection to inject the service into the controller 
        public IActionResult Index()
        {
            var imageList = _imgService.GetAll();
            
            var model = new GalleryIndexModel
            {
                Images = imageList,
                SearchQuery = ""
            };

            return View(model);
        }
    }
}
