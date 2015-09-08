using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;
using Serilog;
using Weblog.Repositories;

namespace weblog
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IRuntimeEnvironment runtime) {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            Configuration = new ConfigurationBuilder(".")
                .AddJsonFile("config.json")
                .Build();
        }

        public IConfiguration Configuration { get; private set; }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRepositories();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage();
            app.UseStaticFiles();
            app.UseMvc();

        }
    }
}
