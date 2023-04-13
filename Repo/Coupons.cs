namespace CouponsApp.Repo;

public class Coupons : IDisposable
{
    private readonly ApplicationDbContext db;
    private bool disposed;

    public Coupons(ApplicationDbContext db)
    {
        this.db = db;
    }


    public Coupon? Get(long id) =>
        db.Coupon.Where(c => c.Id == id).SingleOrDefault();


    public IEnumerable<Coupon> ListValidCoupons() =>
        db.Coupon.Where(c => c.Active).ToList();


    public async Task<Coupon> Create(Coupon coupon)
    {
        var createdCoupon = db.Coupon.Add(coupon).Entity;
        await db.SaveChangesAsync();

        return createdCoupon;
    }

    public async Task<Coupon> Update(Coupon coupon)
    {
        var updatedCoupon = db.Coupon.Update(coupon).Entity;
        await db.SaveChangesAsync();

        return updatedCoupon;
    }

    public async Task Delete(Coupon coupon)
    {
        db.Coupon.Remove(coupon);
        await db.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
            db.Dispose();

        disposed = true;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}