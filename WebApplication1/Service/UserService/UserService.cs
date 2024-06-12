using WebApplication1.DTO.UserDTO;  // Установка связи с объектами для транспортировки
using Repository.UserRepository; // Установка связи с репозиторием 

namespace Service.UserService;  // Бизнес логика взаимодействия с репозиторием (а через него и с содержимым БД)

public class UserService(IUserRepository userRepository) : IUserService
{
    private IUserRepository _userRepository = userRepository; // создание "ссылки" для обращения в репозиторий из сервиса

    public UserDTO GetUser(long id) // Метод полукчения книги из репозитория
    {
        return _userRepository.Get(id); // Отработка по запросу сервиса метода нахождения книги из репозитория
    }

    public List<UserDTO> GetUsers()  // Метод получсения всех книг из репозитория
    {
        return _userRepository.GetUsers(); // Отработка по запросу сервиса метода получения всех книг из репозитория
    }

    public void InsertUser(CreateUserDTO dto) // Метод создания новой книги в репозитории
    {
        _userRepository.Insert(dto);  // Отработка по запросу сервиса метода вставки новой книги из репозитория
    }

    public void UpdateUser(UpdateUserDTO dto)  //  Метод обновления книги из репозитория
    {
        _userRepository.Update(dto); // Отработка по запросу сервиса метода обноаления информации о книге из репозитория
    }

    public void DeleteUser(long id)  // Метод удаления книги из репозитория
    {
        _userRepository.Delete(id);  // Отработка по запросу сервиса метода удаления книги из репозитория
    }
}