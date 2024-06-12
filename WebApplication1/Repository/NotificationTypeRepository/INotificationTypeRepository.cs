using WebApplication1.DTO.NotificationTypeDTO; // Связь с объектами для передачи данных извне в репозиторий

namespace Repository.NotificationTypeRepository; // Установка связи с самим репозиторием 

public interface INotificationTypeRepository  // Интерфейс репозитория типов уведомлений, содержащий описание всех необходимых для реализации в нем методов
{
    NotificationTypeDTO Get(int id); // Описание метода для получение одного типа из БД
    List<NotificationTypeDTO> GetNotificationTypes(); // Описание метода для получение всех типов из БД
    void Insert(CreateNotificationTypeDTO dto); // Описание метода вставки новой типа в БД
    void Update(UpdateNotificationTypeDTO dto); // Описание метода обновления информации о типе в БД
    void Delete(int id);  // Описание метода удаления типа по указанному ID
    void SaveChanges();  // Описание метода сохранения изменений в БД
}