using WebApplication1.DTO.NotificationTemplateDTO; // Установка связи с объектами для транспортировки

namespace Service.NotificationTemplateService; // Интерфейс сервиса с описаним методов из него

public interface INotificationTemplateService // Интерфейс сервиса с описаним методов из него
{
    NotificationTemplateDTO GetNotificationTemplate(int id); // Описание метода получения шаблона из репозитория 
    List<NotificationTemplateDTO> GetNotificationTemplates(); // Описание метода получения всех шаблонов из репозитория
    void InsertNotificationTemplate(CreateNotificationTemplateDTO dto);  // Описание метода вставки шаблона в репозитория
    void UpdateNotificationTemplate(UpdateNotificationTemplateDTO dto);  // Описание метода обновления информации о шаблоне в репозитория
    void DeleteNotificationTemplate(int id); // Описание метода  удаления шаблона из репозитория по заданному пользователем ID
}