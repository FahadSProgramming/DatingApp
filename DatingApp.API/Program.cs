using DatingApp.Persistence;
using DatingApp.Application.Authentication;
using DatingApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DatingApp.Persistence.Data;
using DatingApp.Application.Users;
using System.Reflection;
using DatingApp.Core;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenServiceKey"]));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
//builder.Services.AddDbContext<DatingContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<DatingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLServerConnection")));
builder.Services.AddScoped<ITokenService>(provider => new TokenService(symmetricKey));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(typeof(DatingApp.Persistence.Helpers.AutoMapperProfiles).GetTypeInfo().Assembly);

builder.Services.AddIdentityCore<AppUser>(options => {
    options.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<AppRole>()
    .AddRoleManager<RoleManager<AppRole>>()
    .AddEntityFrameworkStores<DatingContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = symmetricKey,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithOrigins("http://localhost:4200"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DatingContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(userManager, roleManager);
} catch (Exception ex)
{
    var logger = services.GetService<ILogger>();
    logger.LogError(ex, "An error occurred during migration.");
}

app.Run();
