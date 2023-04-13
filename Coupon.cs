using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponsApp;

public class Coupon
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public bool Active { get; set; }

    [Required]
    public required String Code { get; set; }

    [Required]
    public required String Description { get; set; }

    public required DateTime? ExpiredAt { get; set; }
}
