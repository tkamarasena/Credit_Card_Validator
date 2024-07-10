namespace UI
{
    public class Startup
    {
        /*public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Serve default files (index.html, css files and js) and static files
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Set up endpoint routing
            app.UseRouting();

            // Endpoint to redirect root URL to index.html
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/index.html");
                });
            });
        }*/


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Serve default files (index.html, css files and js) and static files
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Set up endpoint routing
            app.UseRouting();

            // Endpoint to redirect root URL to index.html
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/index.html");
                });
            });
        }
    }
}




