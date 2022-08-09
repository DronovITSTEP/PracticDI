using Microsoft.EntityFrameworkCore;

using PracticDI.Data;
using PracticDI.Repositories;
using PracticDI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(option =>
{ option.Conventions.AddPageRoute("/view", ""); });

builder.Services.AddTransient<IRepository, Repository>();

builder.Services.AddDbContext<DBPersonContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DBPersonContext")));

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
