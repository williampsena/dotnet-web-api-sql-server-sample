using CouponsApp.DTO;
using CouponsApp.Repo;
using Microsoft.AspNetCore.Mvc;

namespace CouponsApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CouponController : ControllerBase
{
    private readonly ILogger<CouponController> _logger;

    private readonly Repo.Coupons _repository;

    public CouponController(ILogger<CouponController> logger, Repo.Coupons repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public IEnumerable<Coupon> ListCoupons()
    {
        return _repository.ListValidCoupons();
    }

    [HttpGet("{id}")]
    public Coupon? GetCoupon(long id)
    {
        return _repository.Get(id);
    }

    [HttpPost]
    public async Task<ActionResult<Coupon>> Create([FromBody] CreateCoupon model)
    {
        var createdCoupon = await _repository.Create(model!);
        return CreatedAtAction(nameof(Create), createdCoupon);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateCoupon model)
    {
        var coupon = _repository.Get(id);

        if (coupon == null) return NotFound();

        var couponUpdates = model + coupon;
        var updatedCoupon = await _repository.Update(couponUpdates!);

        return Ok(updatedCoupon);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var coupon = _repository.Get(id);

        if (coupon == null) return NotFound();

        await _repository.Delete(coupon!);

        return NoContent();
    }
}
