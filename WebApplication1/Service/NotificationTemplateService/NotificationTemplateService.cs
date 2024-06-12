using WebApplication1.DTO.NotificationTemplateDTO;  // Установка связи с объектами для транспортировки
using Repository.NotificationTemplateRepository; // Установка связи с репозиторием 

namespace Service.NotificationTemplateService;  // Бизнес логика взаимодействия с репозиторием (а через него и с содержимым БД)

public class NotificationTemplateService(INotificationTemplateRepository notificationtemplateRepository) : INotificationTemplateService
{
    private INotificationTemplateRepository _notificationtemplateRepository = notificationtemplateRepository; // создание "ссылки" для обращения в репозиторий из сервиса

    public NotificationTemplateDTO GetNotificationTemplate(int id) // Метод полукчения шаблона из репозитория
    {
        return _notificationtemplateRepository.Get(id); // Отработка по запросу сервиса метода нахождения шаблона из репозитория
    }

    public List<NotificationTemplateDTO> GetNotificationTemplates()  // Метод получсения всех шаблонов из репозитория
    {
        return _notificationtemplateRepository.GetNotificationTemplates(); // Отработка по запросу сервиса метода получения всех шаблонов из репозитория
    }

    public void InsertNotificationTemplate(CreateNotificationTemplateDTO dto) // Метод создания нового шаблона в репозитории
    {
        _notificationtemplateRepository.Insert(dto);  // Отработка по запросу сервиса метода вставки нового шаблона из репозитория
    }

    public void UpdateNotificationTemplate(UpdateNotificationTemplateDTO dto)  //  Метод обновления шаблона из репозитория
    {
        _notificationtemplateRepository.Update(dto); // Отработка по запросу сервиса метода обноаления информации о шаблоне из репозитория
    }

    public void DeleteNotificationTemplate(int id)  // Метод удаления шаблона из репозитория
    {
        _notificationtemplateRepository.Delete(id);  // Отработка по запросу сервиса метода удаления шаблона из репозитория
    }
}