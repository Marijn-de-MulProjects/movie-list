using MovieList.Common;
using MovieList.DAL.Repositories;
using MovieList.SAL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services 
builder.Services.AddScoped<MovieService>(); 
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ListService>();

// Repositories
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IListRepository, ListRepository>();

// Controllers 
builder.Services.AddControllers();  

// Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication
app.UseAuthentication();
app.UseAuthorization();

// Controllers
app.MapControllers(); 

app.Run();