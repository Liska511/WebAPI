using WebApplication1.DTO.FormDTO; // Связь с объектами для передачи данных извне в репозиторий

namespace Repository.FormRepository; // Установка связи с самим репозиторием 

public interface IFormRepository  // Интерфейс репозитория форм, содержащий описание всех необходимых для реализации в нем методов
{
    FormDTO Get(long id); // Описание метода для получение одной формы из БД
    List<FormDTO> GetForms(); // Описание метода для получение всех форм из БД
    void Insert(CreateFormDTO dto); // Описание метода вставки новой формы в БД
    void Update(UpdateFormDTO dto); // Описание метода обновления информации о форме в БД
    void Delete(long id);  // Описание метода удаления формы по указанному ID
    void SaveChanges();  // Описание метода сохранения изменений в БД
}