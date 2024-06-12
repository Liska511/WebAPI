using WebApplication1.DTO.UserDTO; // Связь с объектами для передачи данных извне в репозиторий

namespace Repository.UserRepository; // Установка связи с самим репозиторием 

public interface IUserRepository  // Интерфейс репозитория книг, содержащий описание всех необходимых для реализации в нем методов
{
    UserDTO Get(long id); // Описание метода для получение одной книги из БД
    List<UserDTO> GetUsers(); // Описание метода для получение всех книг из БД
    void Insert(CreateUserDTO dto); // Описание метода вставки новой книги в БД
    void Update(UpdateUserDTO dto); // Описание метода обновления информации о книге в БД
    void Delete(long id);  // Описание метода удаления книги по указанному ID
    void SaveChanges();  // Описание метода сохранения изменений в БД
}