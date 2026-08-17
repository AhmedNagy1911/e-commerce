using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class AddressDto
{
    [Required]
    public required string Line1 { get; set; } = string.Empty;
    [Required]
    public string? Line2 { get; set; }
    [Required]
    public required string City { get; set; } = string.Empty;
    [Required]
    public required string State { get; set; } = string.Empty;
    [Required]
    public required string PostalCode { get; set; } = string.Empty;
    [Required]
    public required string Country { get; set; } = string.Empty;
}
