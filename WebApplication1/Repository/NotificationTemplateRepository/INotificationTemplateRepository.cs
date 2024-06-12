using WebApplication1.DTO.NotificationTemplateDTO; // Связь с объектами для передачи данных извне в репозиторий

namespace Repository.NotificationTemplateRepository; // Установка связи с самим репозиторием 

public interface INotificationTemplateRepository  // Интерфейс репозитория шаблонов, содержащий описание всех необходимых для реализации в нем методов
{
    NotificationTemplateDTO Get(int id); // Описание метода для получение одного шаблона из БД
    List<NotificationTemplateDTO> GetNotificationTemplates(); // Описание метода для получение всех шаблонов из БД
    void Insert(CreateNotificationTemplateDTO dto); // Описание метода вставки нового шаблона в БД
    void Update(UpdateNotificationTemplateDTO dto); // Описание метода обновления информации о шаблоне в БД
    void Delete(int id);  // Описание метода удаления шаблона по указанному ID
    void SaveChanges();  // Описание метода сохранения изменений в БД
}