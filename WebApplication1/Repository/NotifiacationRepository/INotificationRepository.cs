using WebApplication1.DTO.NotificationDTO; // Связь с объектами для передачи данных извне в репозиторий

namespace Repository.NotificationRepository; // Установка связи с самим репозиторием 

public interface INotificationRepository  // Интерфейс репозитория уведомлений, содержащий описание всех необходимых для реализации в нем методов
{
    NotificationDTO Get(long id); // Описание метода для получение одного уведомления из БД
    List<NotificationDTO> GetNotifications(); // Описание метода для получение всех уведомлений из БД
    List<NotificationDTO> GetNotificationsByCity(string Citysearch);  // Описание метода для получение всех уведомлений для города из БД
    
    List<NotificationDTO> GetNotificationsByCountry(string Countrysearch); // Описание метода для получение всех уведомлений для страны из БД
    List<NotificationDTO> GetNotificationsByHotel(string Hotelsearch); // Описание метода для получение всех уведомлений для отеля из БД
    List<NotificationDTO> GetNotificationsByRomm(string Roomsearch);  // Описание метода для получение всех уведомлений для комнаты из БД
    List<NotificationDTO> GetNotificationsByUser(string Usersearch); // Описание метода для получение всех уведомлений для пользователя из БД
    void Insert(CreateNotificationDTO dto); // Описание метода вставки нового уведомления в БД
    void Update(UpdateNotificationDTO dto); // Описание метода обновления информации об уведомлений в БД
    void Delete(long id);  // Описание метода удаления уведомления по указанному ID
    void SaveChanges();  // Описание метода сохранения изменений в БД
}