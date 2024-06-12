using Data;
using WebApplication1.DTO.UserDTO; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;  // Вызов функционала EntityFramework

namespace Repository.UserRepository; // Методы, логика и содержимое репозитория авторов в БД

public class UserRepository(ApplicationContext context) : IUserRepository // Логика взаимодействий с репозиторием авторов
{
    private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<User> _users = context.Set<User>(); // Получение списка авторов из БД

    public UserDTO Get(long id) // Получение одного автора из БД
    {
        var user = _users.SingleOrDefault(f => f.Id == id); // Нахождение автора по его ID в общем списке
        if (user == null) return null; // Если автора не существует
        return new UserDTO  // Создание и вывод объекта длч передачи данных найденного автора  
        {
            Id = user.Id,
            Login  = user.Email,
            Password = user.Email,
            FirstName = user.FirstName,
            MiddleName = user.MiddleName,
            LasttName = user.LastName,
      
        };  // Присваивание объекту для передачи данных всех свойств искомого автора
    }
    
    public List<UserDTO> GetUsers()  // Получение всех авторов из БД
    {
        var users = _users.ToList(); // Создание общего списка авторов, содержащихся в БД
        List<UserDTO> lusers = new List<UserDTO>(); // Создание списка объектов для транспортировки данных всех авторов из БД

        foreach (var user in users) //  Циклическое заполнение объектов для транспортировки
        {
            lusers.Add(new UserDTO
            {
                Id = user.Id,
                Login  = user.Email,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LasttName = user.LastName
             
            }); // Заполнение объектов для транспортировки
        }
        return lusers; // Вывод списка авторов пользователю
    }


    public void Insert(CreateUserDTO dto)  // Вставка нового автора через объект для транспортировки в БД
    {
        User user = new User() // Создание нового автора в БД
        {
            Email  = dto.Login,
            LastName = dto.LasttName,
            MiddleName = dto.MiddleName,
            FirstName = dto.FirstName
        
        }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
        _users.Add(user); // Добавление нового автора в общий список авторов в БД
        context.SaveChanges(); // Сохранение изменений, внесенных в БД
    }

    public void Update(UpdateUserDTO dto) // Обновление информации о каком-либо авторе из БД
    {
        var user = _users.SingleOrDefault(a => a.Id == dto.Id); // Нахождение искомого автора в общем списке авторов из БД
        if (user == null) return; // Если искомого автора не существует

        user.Email = dto.Login;
        user.LastName = dto.LasttName;
        user.MiddleName = dto.MiddleName; 
        user.FirstName = dto.FirstName;
        
    
        // Присваивание искомому автору свойств, введенных пользователем, через объект для трванспортировки

        _users.Update(user); // Внесение изменений в общий список авторов в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }
    
    public void Delete(long id) // Удаление автора ищ БД по указанному ID
    {
        var user = _users.SingleOrDefault(a => a.Id == id);  // Нахождение указанного автора в общем списке авторов из БД
        if (user == null) return; // Если искомого автора не существует
        _users.Remove(user); // Удаление автора из общего списка авторов в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }

    public void SaveChanges() // Сохранение внесенных изменений в БД
    {
        context.SaveChanges();  // Сохранение внесенных изменений в БД
    }
}