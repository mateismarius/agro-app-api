using API.Errors;
using API.Extensions;
using API.Helpers;
using API.Middlewares;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.AppContext;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var services = builder.Services;
services.AddControllers();

//register AutoMapper
services.AddAutoMapper(typeof(MappingProfiles));
// get connection string and register application context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(connectionString));
services.AddIdentityCore<AppUser>(opt =>
{
    // add identity options here
})
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddSignInManager<SignInManager<AppUser>>();

  services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidateIssuer = true,
            ValidateAudience = false
        };
    });
  

services.AddAuthorization(); 

//register repositories
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddScoped<ITokenService, TokenService>();

//override the ApiController behaviour, add errors, if exists, to ApiValidationErrorResponse 
services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .SelectMany(x => x.Value.Errors)
            .Select(x => x.ErrorMessage).ToArray();

        var errorResponse = new ApiValidationErrorResponse
        {
            Errors = errors
        };
        return new BadRequestObjectResult(errorResponse);
    };
});

services.AddCors();
services.AddSwaggerDocumentation();

var app = builder.Build();

// migrate database when application starts
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
var identityContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await identityContext.Database.MigrateAsync();
}
catch (Exception ex)
{
    logger.LogError(ex, "Probleme in timpul migrarii datelor");
}

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseCors(options =>
{
    options.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    options.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:59105");
});
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseSwaggerDocumentation();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();