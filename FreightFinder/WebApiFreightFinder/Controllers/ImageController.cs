using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FreightFinder.Core.IServices;

namespace WebApiFreightFinder.Controllers
{
    [System.Web.Http.AllowAnonymous]
    public class ImageController : ApiController
    {
        private readonly IImageServices _imageServices;

        public ImageController(IImageServices imageServices)
        {
            _imageServices = imageServices;
        }
        public HttpResponseMessage Get(string url)
        {
            var byteArray = _imageServices.getImage(url);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(byteArray);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return result;
        }
    }
}
