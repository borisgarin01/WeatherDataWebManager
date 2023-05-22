namespace WeatherDataWebManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMvc(mvcOptions=> mvcOptions.EnableEndpointRouting=false);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.Environment.ContentRootPath = "C:\\WebSites\\WeatherDataWebManager\\WeatherDataWebManager\\Weather.Moscow.2010-2014\\Weather.Moscow.2010-2014\\";
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=WeatherDataModels}/{action=Index}");

            app.UseMvc();

            app.Run();
        }
    }
}