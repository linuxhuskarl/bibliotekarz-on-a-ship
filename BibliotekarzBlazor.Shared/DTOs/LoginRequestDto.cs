using System.ComponentModel.DataAnnotations;

namespace BibliotekarzBlazor.Shared.DTOs;

public class LoginRequestDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}