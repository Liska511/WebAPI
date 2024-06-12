using WebApplication1.DTO.FormProblemDTO;  // Установка связи с объектами для транспортировки
using Repository.FormProblemRepository; // Установка связи с репозиторием 

namespace Service.FormProblemService;  // Бизнес логика взаимодействия с репозиторием (а через него и с содержимым БД)

public class FormProblemService(IFormProblemRepository formproblemRepository) : IFormProblemService
{
    private IFormProblemRepository _formproblemRepository = formproblemRepository; // создание "ссылки" для обращения в репозиторий из сервиса

    public FormProblemDTO GetFormProblem(int id) // Метод получения проблемы из репозитория
    {
        return _formproblemRepository.Get(id); // Отработка по запросу сервиса метода нахождения проблемы из репозитория
    }

    public List<FormProblemDTO> GetFormProblems()  // Метод получсения всех проблем из репозитория
    {
        return _formproblemRepository.GetFormProblems(); // Отработка по запросу сервиса метода получения всех проблем из репозитория
    }

    public void InsertFormProblem(CreateFormProblemDTO dto) // Метод создания новой проблемы в репозитории
    {
        _formproblemRepository.Insert(dto);  // Отработка по запросу сервиса метода вставки новой проблемы из репозитория
    }

    public void UpdateFormProblem(UpdateFormProblemDTO dto)  //  Метод обновления проблемы из репозитория
    {
        _formproblemRepository.Update(dto); // Отработка по запросу сервиса метода обноаления информации о проблемые из репозитория
    }

    public void DeleteFormProblem(int id)  // Метод удаления проблемы из репозитория
    {
        _formproblemRepository.Delete(id);  // Отработка по запросу сервиса метода удаления проблемы из репозитория
    }
}