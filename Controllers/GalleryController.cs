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
                    Url = "https://www.pexels.com/photo/beverage-breakfast-brewed-coffee-caffeine-374885/",
                    Created = DateTime.Now,
                    Tags = coffeeImageTags
                },

                new GalleryImage()
                {
                    Title = "Xbox One",
                    Url = "https://www.pexels.com/photo/white-xbox-one-console-and-game-controller-5626726/",
                    Created = DateTime.Now,
                    Tags = gamingConsoleImageTags
                },

                new GalleryImage()
                {
                    Title = "Playstation 4",
                    Url = "https://www.pexels.com/photo/white-and-black-sony-ps-4-game-controller-3945657/",
                    Created = DateTime.Now,
                    Tags = gamingConsoleImageTags
                }
            };
            
            var model = new GalleryIndexModel
            {
                Images = imageList,
                SearchQuery = ""
            };

            return View(model);
        }
    }
}
