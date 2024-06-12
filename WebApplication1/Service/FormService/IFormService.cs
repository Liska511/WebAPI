using WebApplication1.DTO.FormDTO; // Установка связи с объектами для транспортировки

namespace Service.FormService; // Интерфейс сервиса с описаним методов из него

public interface IFormService // Интерфейс сервиса с описаним методов из него
{
    FormDTO GetForm(long id); // Описание метода получения формы из репозитория 
    List<FormDTO> GetForms(); // Описание метода получения всех форм из репозитория
    void InsertForm(CreateFormDTO dto);  // Описание метода вставки формы в репозитория
    void UpdateForm(UpdateFormDTO dto);  // Описание метода обновления информации о форме в репозитория
    void DeleteForm(long id); // Описание метода  удаления формы из репозитория по заданному пользователем ID
}