﻿
using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;



namespace Voting.Client

{

    public class Startup

    {

        public Startup(IConfiguration configuration)

        {

            Configuration = configuration;

        }



        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)

        {

            services.AddHttpClient("VotingAPIClient", client =>

            {

                var baseAddress = Configuration["VotingAPIUrl"];

                if (string.IsNullOrWhiteSpace(baseAddress))

                {

                    throw new Exception("Missing required environment variable: VotingAPIUrl");

                }



                Console.WriteLine("Using VotingAPIUrl: " + baseAddress);

                client.BaseAddress = new Uri(baseAddress);

            });



            services.AddControllersWithViews();

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

        {

            if (env.IsDevelopment())

            {

                app.UseDeveloperExceptionPage();

            }

            else

            {

                app.UseExceptionHandler("/Home/Error");

            }

            app.UseStaticFiles();



            app.UseRouting();



            app.UseAuthorization();



            app.UseEndpoints(endpoints =>

            {

                endpoints.MapControllerRoute(

                    name: "default",

                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

        }

    }

}

