using System.ComponentModel.DataAnnotations;

namespace BarbershopApi.Models;

public class Barber
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
}
