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
        private readonly AnImage _imgSrv;

        //Constructor
        public GalleryController(AnImage imgService)
        {
            _imgSrv = imgService;
        }

        //Going to use dependency injection to inject the service into the controller 
        public IActionResult Index()
        {
            var imgList = _imgSrv.GetAll();
            
            var model = new GalleryIndexModel
            {
                Images = imgList,
                SearchQuery = ""
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var img = _imgSrv.GetId(id);

            var model = new DetailGalModel()
            {
                Id = img.Id,
                Title = img.Title,
                Created = img.Created,
                Url = img.Url,
                //Selecting a tag to its specific description and putting it into a list 
                Tags = img.Tags.Select(t => t.Description).ToList()
            };

            return View(model);
        }
    }
}
