namespace WebApplication1.DTO.UserDTO;

public class UpdateUserDTO
{
        public long Id { get; set; }
        public string Login { get; set; } // Логин пользователя
        public string Password { get; set; } // Пароль пользователя
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LasttName { get; set; }
}