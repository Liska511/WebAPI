using WebApplication1.DTO.NotificationTypeDTO;  // Установка связи с объектами для транспортировки
using Repository.NotificationTypeRepository; // Установка связи с репозиторием 

namespace Service.NotificationTypeService;  // Бизнес логика взаимодействия с репозиторием (а через него и с содержимым БД)

public class NotificationTypeService(INotificationTypeRepository notificationtypeRepository) : INotificationTypeService
{
    private INotificationTypeRepository _notificationtypeRepository = notificationtypeRepository; // создание "ссылки" для обращения в репозиторий из сервиса

    public NotificationTypeDTO GetNotificationType(int id) // Метод получения типа из репозитория
    {
        return _notificationtypeRepository.Get(id); // Отработка по запросу сервиса метода нахождения типа из репозитория
    }

    public List<NotificationTypeDTO> GetNotificationTypes()  // Метод получения всех типов из репозитория
    {
        return _notificationtypeRepository.GetNotificationTypes(); // Отработка по запросу сервиса метода получения всех типов из репозитория
    }

    public void InsertNotificationType(CreateNotificationTypeDTO dto) // Метод создания нового типа в репозитории
    {
        _notificationtypeRepository.Insert(dto);  // Отработка по запросу сервиса метода вставки нового типа из репозитория
    }

    public void UpdateNotificationType(UpdateNotificationTypeDTO dto)  //  Метод обновления типа из репозитория
    {
        _notificationtypeRepository.Update(dto); // Отработка по запросу сервиса метода обноаления информации о типе из репозитория
    }

    public void DeleteNotificationType(int id)  // Метод удаления типа из репозитория
    {
        _notificationtypeRepository.Delete(id);  // Отработка по запросу сервиса метода удаления типа из репозитория
    }
}