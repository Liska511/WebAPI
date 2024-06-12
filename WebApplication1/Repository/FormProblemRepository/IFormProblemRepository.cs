using WebApplication1.DTO.FormProblemDTO; // Связь с объектами для передачи данных извне в репозиторий

namespace Repository.FormProblemRepository; // Установка связи с самим репозиторием 

public interface IFormProblemRepository  // Интерфейс репозитория проблем, содержащий описание всех необходимых для реализации в нем методов
{
    FormProblemDTO Get(int id); // Описание метода для получение одной проблем из БД
    List<FormProblemDTO> GetFormProblems(); // Описание метода для получение всех проблем из БД
    void Insert(CreateFormProblemDTO dto); // Описание метода вставки новой проблемы в БД
    void Update(UpdateFormProblemDTO dto); // Описание метода обновления информации о проблеме в БД
    void Delete(int id);  // Описание метода удаления проблемы по указанному ID
    void SaveChanges();  // Описание метода сохранения изменений в БД
}