using BzsHomePage.Data;
using BzsHomePage.Db.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BzsHomePage.Db;

public static class ServiceExtension
{
    public static void AddDatabase(this IServiceCollection sc)
    {
        sc.AddSingleton<DbFactory>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<DbOptions>>();
            return new DbFactory(options);
        });
        sc.AddSingleton<HomePageCurd>();
    }

    public static void UseDatabase(this IServiceProvider sp)
    {
        var dbFactory = sp.GetRequiredService<DbFactory>();
        dbFactory.EnsureCreateDb();

    }
}