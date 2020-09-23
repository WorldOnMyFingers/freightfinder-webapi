﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using NSwag.AspNet.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApiFreightFinder.Startup))]

namespace WebApiFreightFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            // from https://github.com/NSwag/NSwag/wiki/Middlewares			
            var config = new HttpConfiguration();

            app.UseSwaggerUi(typeof(Startup).Assembly);
            app.UseWebApi(config);

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            // to serve static files, see: http://stackoverflow.com/a/36297940/445927
            string root = AppDomain.CurrentDomain.BaseDirectory;
            //var physicalFileSystem = new PhysicalFileSystem(Path.Combine(root, "wwwroot"));
            var physicalFileSystem = new PhysicalFileSystem(root);
            var options = new FileServerOptions
            {
                RequestPath = PathString.Empty,
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };
            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = false;
            app.UseFileServer(options);

        }
    }
}
