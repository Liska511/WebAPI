using WebApplication1.DTO.NotificationDTO; // Установка связи с объектами для транспортировки

namespace Service.NotificationService; // Интерфейс сервиса с описаним методов из него

public interface INotificationService // Интерфейс сервиса с описаним методов из него
{
    NotificationDTO GetNotification(long id); // Описание метода получения уведомления из репозитория 
    List<NotificationDTO> GetNotifications(); // Описание метода получения всех уведомлений из репозитория

    List<NotificationDTO> GetNotificationsByCity(string CitySearch); // Описание метода получения всех уведомлений для города из репозитория
    
    List<NotificationDTO> GetNotificationsByCountry(string CountrySearch); // Описание метода получения всех уведомлений для страны из репозитория
    List<NotificationDTO> GetNotificationsByHotel(string HotelSearch); // Описание метода получения всех уведомлений для отеля из репозитория
    List<NotificationDTO> GetNotificationsByUser(string UserSearch); // Описание метода получения всех уведомлений для пользователя из репозитория
    
    List<NotificationDTO> GetNotificationsByRoom(string RoomSearch); // Описание метода получения всех уведомлений для комнаты из репозитория
    void InsertNotification(CreateNotificationDTO dto);  // Описание метода вставки уведомления в репозитория
    void UpdateNotification(UpdateNotificationDTO dto);  // Описание метода обновления информации об уведомлении е в репозитория
    void DeleteNotification(long id); // Описание метода  удаления уведомления из репозитория по заданному пользователем ID
}