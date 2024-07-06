using Decorator_Pattern_Advance.Decorators;
using Decorator_Pattern_Advance.Interfaces;
using Decorator_Pattern_Advance.Policies;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddScoped<IFileService, FileService>()
    .Decorate<IFileService>((inner) => new ReportExceptionDecorator (inner, new ReportExceptionPolicy()))
    .Decorate<IFileService, RenameFileDecorator>()
    .Decorate<IFileService, ResizeFileDecorator>();

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
