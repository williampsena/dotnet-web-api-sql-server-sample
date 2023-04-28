using CouponsApp.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    var connectionString = Environment.GetEnvironmentVariable("COUPON_DB_CONNECTION") ?? builder.Configuration["ConnectionStrings:CouponDb"];
    option.UseSqlServer(connectionString);
});

builder.Services.AddScoped<Coupons>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
