using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vicevært.Contract;
using Vicevært.Infrastructure.Database;
using Vicevært.Web.Infrastructure;
using Refit;
using Vicevært.BoligData.DataAccess;
using Vicevært.Infrastructure.Database.Account;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AccessConnection"),
        x => { x.MigrationsAssembly("Vicevært.Web"); }));
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
    options.AddPolicy("Vicevært", policy => policy.RequireClaim("Vicevært"));
    options.AddPolicy("Beboer", policy => policy.RequireClaim("Beboer"));
});

// Inject Identity
builder.Services.AddIdentity<User, IdentityRole>(
        options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireDigit = true;
            options.Password.RequireNonAlphanumeric = true;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.User.RequireUniqueEmail = true;

            options.SignIn.RequireConfirmedEmail = false;
        })
    .AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.LogoutPath = "/Account/Logout";
});


builder.Services.AddHttpClient<IRekvisitionService, RekvisitionServiceProxy>
        (client =>
        {
            client.BaseAddress =
                new Uri("https://localhost:7242");
        });
builder.Services.AddHttpClient<ILejemaalService, LejemaalServiceProxy>
    (client =>
    {
        client.BaseAddress =
            new Uri("https://localhost:7242");
    });

builder.Services.AddHttpClient<IBookingService, BookingServiceProxy>
    (client =>
    {
        client.BaseAddress =
            new Uri("https://localhost:7242");
    });

builder.Services.AddHttpClient<ITidsRegistreringService, TidsRegistreringServiceProxy>
    (client =>
    {
        client.BaseAddress =
        new Uri("https://localhost:7242/");
    });

builder.Services.AddRefitClient<IBoligData>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://boligdataapi.azurewebsites.net");
    c.DefaultRequestHeaders.Add("ApiKey", "87AE43F15C1C420DAA76ED9667B7E045");
}
);

builder.Services.AddDbContext<DatabaseContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext"),
        x => { x.MigrationsAssembly("Vicevært.Web"); }));
//options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext") ?? throw new InvalidOperationException("Connection string 'DatabaseContext' not found.")));
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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
