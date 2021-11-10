using Microsoft.AspNetCore.Mvc;
using ShareImageProject.Models;
using SimpleImageGallery.Data.Models;
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
            var coffeeImageTags = new List<ImageTag>();
            var gamingConsoleImageTags = new List<ImageTag>();

            var tagOne = new ImageTag()
            { 
                Description = "Coffee freak",
                Id = 0
            };

            var tagTwo = new ImageTag()
            {
                Description = "Xbox user",
                Id = 1
            };

            var tagThree = new ImageTag()
            {
                Description = "Playstation user",
                Id = 2
            };

            coffeeImageTags.Add(tagOne);
            gamingConsoleImageTags.AddRange(new List<ImageTag> { tagTwo, tagThree});

            var imageList = new List<GalleryImage>()
            {
                new GalleryImage()
                {
                    Title = "Coffee",
                    Url = "",
                    Created = DateTime.Now,
                    Tags = coffeeImageTags
                },

                new GalleryImage()
                {
                    Title = "Xbox One",
                    Url = "",
                    Created = DateTime.Now,
                    Tags = gamingConsoleImageTags
                },

                new GalleryImage()
                {
                    Title = "Playstation 4",
                    Url = "",
                    Created = DateTime.Now,
                    Tags = gamingConsoleImageTags
                }
            };
            
            var model = new GalleryIndexModel
            {
                Images = imageList
            };

            return View(model);
        }
    }
}
