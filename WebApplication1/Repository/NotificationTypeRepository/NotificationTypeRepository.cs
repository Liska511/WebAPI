using Data;
using WebApplication1.DTO.NotificationTypeDTO; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;  // Вызов функционала EntityFramework

namespace Repository.NotificationTypeRepository; // Методы, логика и содержимое репозитория авторов в БД

public class NotificationTypeRepository(ApplicationContext context) : INotificationTypeRepository // Логика взаимодействий с репозиторием типов уведомлений
{
    private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<NotificationType> _notificationtypes = context.Set<NotificationType>(); // Получение списка типов из БД

    public NotificationTypeDTO Get(int id) // Получение одного типа из БД
    {
        var notificationtype = _notificationtypes.SingleOrDefault(f => f.Id == id); // Нахождение типа по его ID в общем списке
        if (notificationtype == null) return null; // Если типа не существует
        return new NotificationTypeDTO  // Создание и вывод объекта длч передачи данных найденного типа  
        {
            Id = notificationtype.Id,
            NotificationTypeName  = notificationtype.NotificationTypeName,
            NotificationTypeDescription = notificationtype.NotificationTypeDescription,
        };  // Присваивание объекту для передачи данных всех свойств искомого типа
    }
    
    public List<NotificationTypeDTO> GetNotificationTypes()  // Получение всех типов из БД
    {
        var notificationtypes = _notificationtypes.ToList(); // Создание общего списка типов, содержащихся в БД
        List<NotificationTypeDTO> lnotificationtypes = new List<NotificationTypeDTO>(); // Создание списка объектов для транспортировки данных всех типов из БД

        foreach (var notificationtype in notificationtypes) //  Циклическое заполнение объектов для транспортировки
        {
            lnotificationtypes.Add(new NotificationTypeDTO
            {
                Id = notificationtype.Id,
                NotificationTypeName  = notificationtype.NotificationTypeName,
                NotificationTypeDescription = notificationtype.NotificationTypeDescription,
            }); // Заполнение объектов для транспортировки
        }
        return lnotificationtypes; // Вывод списка типов пользователю
    }


    public void Insert(CreateNotificationTypeDTO dto)  // Вставка нового типа через объект для транспортировки в БД
    {
        NotificationType notificationtype = new NotificationType() // Создание нового типа в БД
        {
            NotificationTypeName  = dto.NotificationTypeName,
            NotificationTypeDescription = dto.NotificationTypeDescription,
        }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
        _notificationtypes.Add(notificationtype); // Добавление нового типа в общий список типов в БД
        context.SaveChanges(); // Сохранение изменений, внесенных в БД
    }

    public void Update(UpdateNotificationTypeDTO dto) // Обновление информации о каком-либо типе из БД
    {
        var notificationtype = _notificationtypes.SingleOrDefault(a => a.Id == dto.Id); // Нахождение искомого типа в общем списке типов из БД
        if (notificationtype == null) return; // Если искомого типа не существует

        notificationtype.NotificationTypeName = dto.NotificationTypeName;
        notificationtype.NotificationTypeDescription = dto.NotificationTypeDescription;
        // Присваивание искомому типу свойств, введенных пользователем, через объект для трванспортировки

        _notificationtypes.Update(notificationtype); // Внесение изменений в общий список типов в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }
    
    public void Delete(int id) // Удаление автора ищ БД по указанному ID
    {
        var notificationtype = _notificationtypes.SingleOrDefault(a => a.Id == id);  // Нахождение указанного типа в общем списке типов из БД
        if (notificationtype == null) return; // Если искомого типа не существует
        _notificationtypes.Remove(notificationtype); // Удаление типа из общего списка типов в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }

    public void SaveChanges() // Сохранение внесенных изменений в БД
    {
        context.SaveChanges();  // Сохранение внесенных изменений в БД
    }
}