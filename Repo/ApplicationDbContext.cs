
using Microsoft.EntityFrameworkCore;

namespace CouponsApp.Repo;

public class ApplicationDbContext : DbContext
{
    public required DbSet<Coupon> Coupon { get; set; }

    public required IConfiguration Configuration { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}