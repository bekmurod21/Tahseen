using Microsoft.EntityFrameworkCore;
using Tahseen.Api.Middlewares;
using Tahseen.Data.DbContexts;
using Tahseen.Data.IRepositories;
using Tahseen.Data.Repositories;
using Tahseen.Service.Interfaces.IUsersService;
using Tahseen.Service.Mappings;
using Tahseen.Service.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Database Configuration
builder.Services.AddDbContext<AppDbContext>(option 
    => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserCartService, UserCartService>();
builder.Services.AddScoped<IWishlistService, WishlistService>();

// MiddleWares

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LoggerMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
