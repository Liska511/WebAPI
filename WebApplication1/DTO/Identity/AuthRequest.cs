namespace WebApplication1.DTO.Identity;

public class AuthRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}