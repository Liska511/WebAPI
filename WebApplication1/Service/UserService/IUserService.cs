using WebApplication1.DTO.UserDTO; // Установка связи с объектами для транспортировки

namespace Service.UserService; // Интерфейс сервиса с описаним методов из него

public interface IUserService // Интерфейс сервиса с описаним методов из него
{
    UserDTO GetUser(long id); // Описание метода получения книги из репозитория 
    List<UserDTO> GetUsers(); // Описание метода получения всех книг из репозитория
    void InsertUser(CreateUserDTO dto);  // Описание метода вставки книги в репозитория
    void UpdateUser(UpdateUserDTO dto);  // Описание метода обновления информации о книге в репозитория
    void DeleteUser(long id); // Описание метода  удаления книги из репозитория по заданному пользователем ID
}