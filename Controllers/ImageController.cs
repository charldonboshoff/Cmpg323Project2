using ImageGallery.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShareImageProject.Models;
using SimpleImageGallery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShareImageProject.Controllers
{
    public class ImageController : Controller
    {
        private IConfiguration _configuration;
        private AnImage anImageService;
        private string AzureStorageConnectionString { get; }

        public ImageController(IConfiguration configuratn, AnImage imageService)
        {
            _configuration = configuratn;
            anImageService = imageService;
            AzureStorageConnectionString = _configuration["AzureStorageConnectionString"];
        }

        public IActionResult Upload()
        {
            var model = new UploadImageModel();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewImage(IFormFile aFile, string tags, string title)
        {
            var container = anImageService.BlobContainer(AzureStorageConnectionString, "images");
            var content = ContentDispositionHeaderValue.Parse(aFile.ContentDisposition);
            var fileName = content.FileName.Trim('"');

            //Get a reference to a block blob
            var blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.UploadFromStreamAsync(aFile.OpenReadStream());
            await anImageService.SetImage(title, tags, blockBlob.Uri);

            return RedirectToAction("Index", "Gallery");
        }
    }
}
