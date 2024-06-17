using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarbershopApi.Models;

public class Customer
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? PhoneNumber { get; set; }

    [Required]
    public DateTime? ReservationDate { get; set; }

    [Required]
    public int BarberId { get; set; }

    [ForeignKey("BarberId")]
    public Barber? Barber { get; set; }

    public bool IsConfirmed { get; set; } = false;
}
