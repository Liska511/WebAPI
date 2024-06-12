namespace WebApplication1.DTO.UserDTO;

public class UserDTO
{
    public long Id { get; set; } // ID пользователя  (Первичный ключ)
    public string Login { get; set; } // Логин пользователя
    
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LasttName { get; set; }
    public string Password { get; set; } // Пароль пользователя
    

}