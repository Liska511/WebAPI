using WebApplication1.DTO.FormProblemDTO; // Установка связи с объектами для транспортировки

namespace Service.FormProblemService; // Интерфейс сервиса с описаним методов из него

public interface IFormProblemService // Интерфейс сервиса с описаним методов из него
{
    FormProblemDTO GetFormProblem(int id); // Описание метода получения проблемы из репозитория 
    List<FormProblemDTO> GetFormProblems(); // Описание метода получения всех проблемы из репозитория
    void InsertFormProblem(CreateFormProblemDTO dto);  // Описание метода вставки проблемыы в репозитория
    void UpdateFormProblem(UpdateFormProblemDTO dto);  // Описание метода обновления информации о проблеме в репозитория
    void DeleteFormProblem(int id); // Описание метода  удаления проблемы из репозитория по заданному пользователем ID
}