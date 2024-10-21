using CSMWebsite2024.Contracts.Infrastructure;
using CSMWebsite2024.Contracts.Posts;
using CSMWebsite2024.EntityFramework;
using CSMWebsite2024.MySql.Infrastructure;
using CSMWebsite2024.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<DefaultDbContext>(
			dbContextOptions => dbContextOptions
			   .UseMySql(builder.Configuration.GetConnectionString("DefaultConnectionString"),
				   ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnectionString")),
					  mySqlOptions =>
					  {
						  mySqlOptions.EnableRetryOnFailure(
							maxRetryCount: 10,
							maxRetryDelay: TimeSpan.FromSeconds(30),
							errorNumbersToAdd: null);
						  mySqlOptions.MigrationsAssembly(typeof(Program).Namespace);
					  })
			   .LogTo(Console.WriteLine, LogLevel.Information)
			   .EnableSensitiveDataLogging()
			   .EnableDetailedErrors()
);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IPostService), typeof(PostService));


// Add services to the container.
builder.Services.AddRazorPages();

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
