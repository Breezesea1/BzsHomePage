using BzsHomePage.Data;
using BzsHomePage.Db;
using BzsHomePage.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Configurations
builder.Services.Configure<DbOptions>(builder.Configuration.GetRequiredSection("DbOptions"));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDatabase();


var app = builder.Build();
app.Services.UseDatabase();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();