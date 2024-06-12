using WebApplication1.DTO.NotificationTypeDTO; // Установка связи с объектами для транспортировки

namespace Service.NotificationTypeService; // Интерфейс сервиса с описаним методов из него

public interface INotificationTypeService // Интерфейс сервиса с описаним методов из него
{
    NotificationTypeDTO GetNotificationType(int id); // Описание метода получения типа из репозитория 
    List<NotificationTypeDTO> GetNotificationTypes(); // Описание метода получения всех типов из репозитория
    void InsertNotificationType(CreateNotificationTypeDTO dto);  // Описание метода вставки типа в репозитория
    void UpdateNotificationType(UpdateNotificationTypeDTO dto);  // Описание метода обновления информации о типе в репозитория
    void DeleteNotificationType(int id); // Описание метода  удаления типа из репозитория по заданному пользователем ID
}