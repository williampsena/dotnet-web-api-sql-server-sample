using System.ComponentModel.DataAnnotations;

namespace CouponsApp.DTO;

public class CreateCoupon
{
    [Required]
    public required String Code { get; set; }
    [Required]
    public required String Description { get; set; }

    public DateTime? ExpiredAt { get; set; }

    public bool Active { get; set; }

    public static implicit operator Coupon?(CreateCoupon model)
    {
        if (model == null) throw new NullReferenceException("CreateCoupon can't be null");

        return new Coupon()
        {
            Code = model.Code,
            Description = model.Description,
            ExpiredAt = model.ExpiredAt,
            Active = model.Active
        };
    }

}
public class UpdateCoupon
{
    [Required]
    public required String Description { get; set; }

    public DateTime? ExpiredAt { get; set; }

    public bool Active { get; set; }

    public static Coupon? operator +(UpdateCoupon model, Coupon coupon)
    {
        if (coupon == null) throw new NullReferenceException("Coupon can't be null");
        if (model == null) throw new NullReferenceException("UpdateCoupon can't be null");

        return new Coupon()
        {
            Code = coupon.Code,
            Description = model.Description,
            ExpiredAt = model.ExpiredAt,
            Active = model.Active
        };
    }

}