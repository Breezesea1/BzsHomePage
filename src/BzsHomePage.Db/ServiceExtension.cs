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
}