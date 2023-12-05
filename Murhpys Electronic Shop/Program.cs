using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Murhpys_Electronic_Shop.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EmailsDatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EmailsDatabaseContext") ?? throw new InvalidOperationException("Connection string 'EmailsDatabaseContext' not found.")));
builder.Services.AddDbContext<Murhpys_Electronic_ShopContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Murhpys_Electronic_ShopContext") ?? throw new InvalidOperationException("Connection string 'Murhpys_Electronic_ShopContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

