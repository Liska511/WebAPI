using Data;
using Microsoft.EntityFrameworkCore; // Вызов функционала EntityFramework
using WebApplication1.DTO.CityDTO; // Установка связи с объектами для транспортировки
using WebApplication1.DTO.CountryDTO;
using WebApplication1.DTO.HotelDTO;
using WebApplication1.DTO.RoomDTO;
using WebApplication1.DTO.UserDTO;
using WebApplication1.DTO.NotificationDTO; 

namespace Repository.NotificationRepository; // Методы, логика и содержимое репозитория уведомлений в БД

public class NotificationRepository(ApplicationContext context) : INotificationRepository // Логика взаимодействий с репозиторием уведомлений
{
    private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<Notification> _notifications = context.Set<Notification>(); // Получение списка уведомлений из БД

    public NotificationDTO Get(long id) // Получение одного уведомления из БД
    {
        var notification = _notifications
            .Include(notification=>notification.User)
            .Include(notification=>notification.Hotel)
            .Include(notification=>notification.City)
            .Include(notification=>notification.Room)
            .Include(notification=>notification.Country)
            .SingleOrDefault(f => f.Id == id); // Нахождение уведомления по его ID в общем списке
        if (notification == null) return null; // Если уведомления не существует

        var user = new UserDTO()
        {
            Id = notification.User.Id,
            Login = notification.User.Email,
            Password = "Hiidden"
        }; // Заролнение информации о пользователе в уведомлении
        
        var country = new CountryDTO()
        {
            Id = notification.Country.Id,
            CountryName = notification.Country.CountryName,
            CountryDescription = notification.Country.CountryDescription,
        }; // Заролнение информации о стране в уведомлении
        
        var city = new CityDTO()
        {
            Id = notification.City.Id,
            CityName = notification.City.CityName,
            CityDescription  = notification.City.CityDescription,
        }; // Заролнение информации о городе в уведомлении
        
        var hotel = new HotelDTO()
        {
            Id = notification.Hotel.Id,
            HotelName  = notification.Hotel.HotelName,
            HotelDescription = notification.Hotel.HotelDescription,
        }; // Заролнение информации о городе в уведомлении
        
        var roon = new RoomDTO()
        {
            Id = notification.Room.Id,
            RoomName  = notification.Room.RoomName,
            RoomDescription= notification.Room.RoomDescription,
        };  // Заролнение информации о комнате в уведомлении
        
        return new NotificationDTO  // Создание и вывод объекта длч передачи данных найденного автора  
        {
            Id = notification.Id,
            NotificationTypeId  = notification.NotificationTypeId,
            NotificationTemplateId = notification.NotificationTemplateId,
            NotificationDate = notification.NotificationDate,
            UserID = notification.UserID,
            NotificationTitle = notification.NotificationTitle,
            NotificationText = notification.NotificationText,
            CountryID = notification.CountryID,
            CityID = notification.CityID,
            HotelID = notification.HotelID,
            RoomID = notification.RoomID,
            User = user,
            Country = country,
            City = city,
            Hotel = hotel,
            Room = roon
        };  // Присваивание объекту для передачи данных всех свойств искомого уведомления
    }
    
    public List<NotificationDTO> GetNotifications()  // Получение всех уведомлений из БД
    {
        var notifications = _notifications.ToList(); // Создание общего списка уведомлений, содержащихся в БД
        List<NotificationDTO> lnotifications = new List<NotificationDTO>(); // Создание списка объектов для транспортировки данных всех уведомлений из БД

        foreach (var notification in notifications) //  Циклическое заполнение объектов для транспортировки
        {
                lnotifications.Add(new NotificationDTO
                {
                    Id = notification.Id,
                    NotificationTypeId = notification.NotificationTypeId,
                    NotificationTemplateId = notification.NotificationTemplateId,
                    NotificationDate = notification.NotificationDate,
                    UserID = notification.UserID,
                    NotificationTitle = notification.NotificationTitle,
                    NotificationText = notification.NotificationText,
                    CountryID = notification.CountryID,
                    CityID = notification.CityID,
                    HotelID = notification.HotelID,
                    RoomID = notification.RoomID
                }); // Заполнение объектов для транспортировки
            }
        

        return lnotifications; // Вывод списка уведомлений пользователю
    }
    
    public List<NotificationDTO> GetNotificationsByCity(string Citysearch)  // Получение всех уведомлений для города из БД
    {
        var notifications = _notifications.Where(_notifications => _notifications.City.CityName == Citysearch).ToList(); // Создание общего списка уведомлений для города, содержащихся в БД
        List<NotificationDTO> lnotifications = new List<NotificationDTO>(); // Создание списка объектов для транспортировки данных всех уведомлений города из БД

        foreach (var notification in notifications) //  Циклическое заполнение объектов для транспортировки
        {
            lnotifications.Add(new NotificationDTO
            {
                Id = notification.Id,
                NotificationTypeId = notification.NotificationTypeId,
                NotificationTemplateId = notification.NotificationTemplateId,
                NotificationDate = notification.NotificationDate,
                UserID = notification.UserID,
                NotificationTitle = notification.NotificationTitle,
                NotificationText = notification.NotificationText,
                CountryID = notification.CountryID,
                CityID = notification.CityID,
                HotelID = notification.HotelID,
                RoomID = notification.RoomID
            }); // Заполнение объектов для транспортировки
        }
        

        return lnotifications; // Вывод списка уведомлений для города пользователю
    }

    
    public List<NotificationDTO> GetNotificationsByCountry(string Countrysearch)  // Получение всех уведомлений страны из БД
    {
        var notifications = _notifications.Where(_notifications => _notifications.Country.CountryName == Countrysearch).ToList(); // Создание общего списка уведомлений для страны, содержащихся в БД
        List<NotificationDTO> lnotifications = new List<NotificationDTO>(); // Создание списка объектов для транспортировки данных всех уведомлений для страны из БД

        foreach (var notification in notifications) //  Циклическое заполнение объектов для транспортировки
        {
            lnotifications.Add(new NotificationDTO
            {
                Id = notification.Id,
                NotificationTypeId = notification.NotificationTypeId,
                NotificationTemplateId = notification.NotificationTemplateId,
                NotificationDate = notification.NotificationDate,
                UserID = notification.UserID,
                NotificationTitle = notification.NotificationTitle,
                NotificationText = notification.NotificationText,
                CountryID = notification.CountryID,
                CityID = notification.CityID,
                HotelID = notification.HotelID,
                RoomID = notification.RoomID
            }); // Заполнение объектов для транспортировки
        }
        

        return lnotifications; // Вывод списка авторов пользователю
    }

    public List<NotificationDTO> GetNotificationsByHotel(string Hotelsearch)  // Получение всех уведомлений для отеля из БД
    {
        var notifications = _notifications.Where(_notifications => _notifications.Hotel.HotelName == Hotelsearch).ToList(); // Создание общего списка уведомлений для отеля, содержащихся в БД
        List<NotificationDTO> lnotifications = new List<NotificationDTO>(); // Создание списка объектов для транспортировки данных всех уведомлений для отеля из БД

        foreach (var notification in notifications) //  Циклическое заполнение объектов для транспортировки
        {
            lnotifications.Add(new NotificationDTO
            {
                Id = notification.Id,
                NotificationTypeId = notification.NotificationTypeId,
                NotificationTemplateId = notification.NotificationTemplateId,
                NotificationDate = notification.NotificationDate,
                UserID = notification.UserID,
                NotificationTitle = notification.NotificationTitle,
                NotificationText = notification.NotificationText,
                CountryID = notification.CountryID,
                CityID = notification.CityID,
                HotelID = notification.HotelID,
                RoomID = notification.RoomID
            }); // Заполнение объектов для транспортировки
        }
        

        return lnotifications; // Вывод списка авторов пользователю
    }
    
    public List<NotificationDTO> GetNotificationsByRomm(string Roomsearch)  // Получение всех уведомлений для комнаты из БД
    {
        var notifications = _notifications.Where(_notifications => _notifications.Room.RoomName == Roomsearch).ToList(); // Создание общего списка уведомлений для комнаты, содержащихся в БД
        List<NotificationDTO> lnotifications = new List<NotificationDTO>(); // Создание списка объектов для транспортировки данных всех уведомлений для комнаты из БД

        foreach (var notification in notifications) //  Циклическое заполнение объектов для транспортировки
        {
            lnotifications.Add(new NotificationDTO
            {
                Id = notification.Id,
                NotificationTypeId = notification.NotificationTypeId,
                NotificationTemplateId = notification.NotificationTemplateId,
                NotificationDate = notification.NotificationDate,
                UserID = notification.UserID,
                NotificationTitle = notification.NotificationTitle,
                NotificationText = notification.NotificationText,
                CountryID = notification.CountryID,
                CityID = notification.CityID,
                HotelID = notification.HotelID,
                RoomID = notification.RoomID
            }); // Заполнение объектов для транспортировки
        }
        

        return lnotifications; // Вывод списка уведомлений для комнаты пользователю
    }
    
    public List<NotificationDTO> GetNotificationsByUser(string Usersearch)  // Получение всех уведомлений для пользователя из БД
    {
        var notifications = _notifications.Where(_notifications => _notifications.Room.RoomName == Usersearch).ToList(); // Создание общего списка уведомлений для пользователя, содержащихся в БД
        List<NotificationDTO> lnotifications = new List<NotificationDTO>(); // Создание списка объектов для транспортировки данных всех уведомлений для пользователя из БД

        foreach (var notification in notifications) //  Циклическое заполнение объектов для транспортировки
        {
            lnotifications.Add(new NotificationDTO
            {
                Id = notification.Id,
                NotificationTypeId = notification.NotificationTypeId,
                NotificationTemplateId = notification.NotificationTemplateId,
                NotificationDate = notification.NotificationDate,
                UserID = notification.UserID,
                NotificationTitle = notification.NotificationTitle,
                NotificationText = notification.NotificationText,
                CountryID = notification.CountryID,
                CityID = notification.CityID,
                HotelID = notification.HotelID,
                RoomID = notification.RoomID
            }); // Заполнение объектов для транспортировки
        }
        

        return lnotifications; // Вывод списка уведомлений для пользователя пользователю
    }

    public void Insert(CreateNotificationDTO dto)  // Вставка нового уведомлений через объект для транспортировки в БД
    {
        Notification notification = new Notification() // Создание уведомлений автора в БД
        {
            NotificationTypeId  = dto.NotificationTypeId,
            NotificationTemplateId = dto.NotificationTemplateId,
            NotificationDate = dto.NotificationDate,
            UserID = dto.UserID,
            NotificationTitle = dto.NotificationTitle,
            NotificationText = dto.NotificationText,
            CountryID = dto.CountryID,
            CityID = dto.CityID,
            HotelID = dto.HotelID,
            RoomID = dto.RoomID
        }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
        _notifications.Add(notification); // Добавление нового уведомлений в общий список уведомлений в БД
        context.SaveChanges(); // Сохранение изменений, внесенных в БД
    }

    public void Update(UpdateNotificationDTO dto) // Обновление информации о каком-либо уведомлений из БД
    {
        var notification = _notifications.SingleOrDefault(a => a.Id == dto.Id); // Нахождение искомого уведомления в общем списке уведомлений из БД
        if (notification == null) return; // Если искомого уведомления не существует

        notification.NotificationTypeId = dto.NotificationTypeId;
        notification.NotificationTemplateId = dto.NotificationTemplateId;
        notification.NotificationDate = dto.NotificationDate;
        notification.UserID = dto.UserID;
        notification.NotificationTitle = dto.NotificationTitle;
        notification.NotificationText = dto.NotificationText;
        notification.CountryID = dto.CountryID;
        notification.CityID = dto.CityID;
        notification.HotelID = dto.HotelID;
        notification.RoomID = dto.RoomID;
        // Присваивание искомому уведомлению свойств, введенных пользователем, через объект для трванспортировки

        _notifications.Update(notification); // Внесение изменений в общий список уведомлений в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }
    
    public void Delete(long id) // Удаление уведомленияа из БД по указанному ID
    {
        var notification = _notifications.SingleOrDefault(a => a.Id == id);  // Нахождение указанного уведомления в общем списке уведомлений из БД
        if (notification == null) return; // Если искомого уведомления не существует
        _notifications.Remove(notification); // Удаление уведомления из общего списка уведомлений в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }

    public void SaveChanges() // Сохранение внесенных изменений в БД
    {
        context.SaveChanges();  // Сохранение внесенных изменений в БД
    }
}

