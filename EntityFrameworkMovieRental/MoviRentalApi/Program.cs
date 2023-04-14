using MoviRentalApi;
using MovieRental.Domain;
using MovieRental.Domain.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITagRepository, TagRepository>();
builder.Services.AddTransient<ITagStorage, TagStorage>();

builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IMovieStorage, MovieStorage>();

builder.Services.AddTransient<IMovieTagRepository, MovieTagRepository>();
builder.Services.AddTransient<IMovieTagStorage, MovieTagStorage>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserStorage, UserStorage>();

builder.Services.AddTransient<IRentRepository, RentRepository>();
builder.Services.AddTransient<IRentStorage, RentStorage>();

builder.Services.AddTransient<ISellRepository, SellRepository>();
builder.Services.AddTransient<ISellStorage,  SellStorage>();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();
