using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext with SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<ReaderRepository>();
builder.Services.AddScoped<BorrowingRepository>();
builder.Services.AddScoped<AppUserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();
app.MapControllerRoute(name: "books",pattern: "{controller=Book}/{action=Index}/{id?}").WithStaticAssets();
app.MapControllerRoute(name: "readers",pattern: "{controller=Reader}/{action=Index}/{id?}").WithStaticAssets();
app.MapControllerRoute(name: "borrowings",pattern: "{controller=Borrowing}/{action=Index}/{id?}").WithStaticAssets();


app.Run();
