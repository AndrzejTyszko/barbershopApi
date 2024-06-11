using System.ComponentModel.DataAnnotations;

namespace BarbershopApi.Models;

public class Customer
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }

    public bool IsConfirmed { get; set; } = false;
}
