using E_commerce.Dal;
using Microsoft.EntityFrameworkCore;
namespace E_commerce.Server.Configurations;

public static class DataBaseConfiguration 
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {

        // 1 option
        //ConfigurationManager manager = new ConfigurationManager();
        //var connectionStr = manager.GetConnectionString("DatabaseConnection");
        // 2 option
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

        builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(connectionString));
    }
}
