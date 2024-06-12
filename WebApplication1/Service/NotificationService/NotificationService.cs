using WebApplication1.DTO.NotificationDTO;  // Установка связи с объектами для транспортировки
using Repository.NotificationRepository; // Установка связи с репозиторием 

namespace Service.NotificationService;  // Бизнес логика взаимодействия с репозиторием (а через него и с содержимым БД)

public class NotificationService(INotificationRepository notificationRepository) : INotificationService
{
    private INotificationRepository _notificationRepository = notificationRepository; // создание "ссылки" для обращения в репозиторий из сервиса

    public NotificationDTO GetNotification(long id) // Метод получения уведомления из репозитория
    {
        return _notificationRepository.Get(id); // Отработка по запросу сервиса метода нахождения уведомления из репозитория
    }

    public List<NotificationDTO> GetNotifications()  // Метод получсения всех уведомлений из репозитория
    {
        return _notificationRepository.GetNotifications(); // Отработка по запросу сервиса метода получения всех уведомлений из репозитория
    }
    
    public List<NotificationDTO> GetNotificationsByCity(string CitySearch)  // Метод получсения всех уведомлений для города из репозитория
    {
        return _notificationRepository.GetNotificationsByCity(CitySearch); // Отработка по запросу сервиса метода получения всех уведомлений для города из репозитория
    }
    
    public List<NotificationDTO> GetNotificationsByCountry(string CountrySearch)  // Метод получсения всех уведомлений для страны из репозитория
    {
        return _notificationRepository.GetNotificationsByCountry(CountrySearch); // Отработка по запросу сервиса метода получения всех уведомлений для страны из репозитория
    }
    public List<NotificationDTO> GetNotificationsByHotel(string HotelSearch)  // Метод получсения всех уведомлений для отеля из репозитория
    {
        return _notificationRepository.GetNotificationsByHotel(HotelSearch); // Отработка по запросу сервиса метода получения всех уведомлений для отеля из репозитория
    }
    public List<NotificationDTO> GetNotificationsByRoom(string RoomSearch)  // Метод получсения всех уведомлений для комнаты из репозитория
    {
        return _notificationRepository.GetNotificationsByRomm(RoomSearch); // Отработка по запросу сервиса метода получения всех уведомлений для комнаты из репозитория
    }
    
    public List<NotificationDTO> GetNotificationsByUser(string UserSearch)  // Метод получсения всех уведомлений для пользователя из репозитория
    {
        return _notificationRepository.GetNotificationsByUser(UserSearch); // Отработка по запросу сервиса метода получения всех уведомлений для пользователя из репозитория
    }

    public void InsertNotification(CreateNotificationDTO dto) // Метод создания нового уведомления в репозитории
    {
        _notificationRepository.Insert(dto);  // Отработка по запросу сервиса метода вставки нового уведомления из репозитория
    }

    public void UpdateNotification(UpdateNotificationDTO dto)  //  Метод обновления увкдомления из репозитория
    {
        _notificationRepository.Update(dto); // Отработка по запросу сервиса метода обноаления информации об уведомлении из репозитория
    }

    public void DeleteNotification(long id)  // Метод удаления уведомления из репозитория
    {
        _notificationRepository.Delete(id);  // Отработка по запросу сервиса метода удаления уведомления из репозитория
    }
}