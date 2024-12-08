using System.Net;
using Microsoft.EntityFrameworkCore;
using MovieList.API.Middleware;
using MovieList.Common;
using MovieList.Common.Helpers;
using MovieList.DAL.Repositories;
using MovieList.SAL.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// Load Environment Variables
EnvironmentVariables.LoadEnvironments();

var builder = WebApplication.CreateBuilder(args);

// Configuration Validation
string jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
if (string.IsNullOrEmpty(jwtSecret))
{
    throw new ArgumentNullException("JWT_SECRET", "JWT_SECRET environment variable is not set.");
}

// Add Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<MovieList.DAL.DbContext>(options =>
    options.UseNpgsql(ConnectionStringHelper.GetConnectionString()));

// Services 
builder.Services.AddScoped<MovieService>(); 
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ListService>();
builder.Services.AddScoped<ExternalMovieApiService>();

// Http Client
builder.Services.AddHttpClient<IExternalMovieApiService, ExternalMovieApiService>();

// Repositories
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IListRepository, ListRepository>();

// Controllers 
builder.Services.AddControllers();  

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); 
    });
});

// JWT Authentication 
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };
    });

// Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// CORS 
app.UseCors("AllowSpecificOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware
string devMode = Environment.GetEnvironmentVariable("DEV_MODE") ?? "false";
if (devMode.ToLower() != "true")
{
    app.UseMiddleware<TokenMiddleware>(jwtSecret);
}

// Authentication
app.UseAuthentication();
app.UseAuthorization();

// Controllers
app.MapControllers(); 

app.Run();
