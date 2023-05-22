using Microsoft.EntityFrameworkCore;
using WeatherDataWebManager.Models;

namespace WeatherDataWebManager.Data
{
    public class ApplicationContext:DbContext
    {
        public DbSet<WeatherDataFileModel> WeatherDataFilesModels { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
