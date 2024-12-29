using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Repository.InterFaces;
using Service.MappingProfiles;
using Service.ServiceRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// //Config Database 
builder.Services.AddDbContext<AppDbContext>(Options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
    Options.UseSqlServer(connectionString);
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingMovie));
//builder.Services.AddAutoMapper(typeof(MappingCategory));

//Add IServiceRepository
builder.Services.AddScoped(typeof(IMovieService), (typeof(MovieService)));
builder.Services.AddScoped(typeof(ICategoryService<>), (typeof(CategoryService<>)));
builder.Services.AddScoped(typeof(ICinemaService), (typeof(CinemaService)));
builder.Services.AddScoped(typeof(IHallService), (typeof(HallService))); 
builder.Services.AddScoped(typeof(ICastService), (typeof(CastService)));
builder.Services.AddScoped(typeof(IScheduleService), (typeof(ScheduleService)));
builder.Services.AddScoped(typeof(IMovie_CastService), (typeof(Movie_CastService)));

//Pagination
builder.Services.AddScoped(typeof(IPagination<>), (typeof(Pagination<>)));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
