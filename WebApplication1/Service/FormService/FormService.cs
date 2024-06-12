using WebApplication1.DTO.FormDTO;  // Установка связи с объектами для транспортировки
using Repository.FormRepository; // Установка связи с репозиторием 

namespace Service.FormService;  // Бизнес логика взаимодействия с репозиторием (а через него и с содержимым БД)

public class FormService(IFormRepository formRepository) : IFormService
{
    private IFormRepository _formRepository = formRepository; // создание "ссылки" для обращения в репозиторий из сервиса

    public FormDTO GetForm(long id) // Метод полукчения формы из репозитория
    {
        return _formRepository.Get(id); // Отработка по запросу сервиса метода нахождения формы из репозитория
    }

    public List<FormDTO> GetForms()  // Метод получсения всех форм из репозитория
    {
        return _formRepository.GetForms(); // Отработка по запросу сервиса метода получения всех форм из репозитория
    }

    public void InsertForm(CreateFormDTO dto) // Метод создания новой формы в репозитории
    {
        _formRepository.Insert(dto);  // Отработка по запросу сервиса метода вставки новой формы из репозитория
    }

    public void UpdateForm(UpdateFormDTO dto)  //  Метод обновления формы из репозитория
    {
        _formRepository.Update(dto); // Отработка по запросу сервиса метода обноаления информации о форме из репозитория
    }

    public void DeleteForm(long id)  // Метод удаления формы из репозитория
    {
        _formRepository.Delete(id);  // Отработка по запросу сервиса метода удаления формы из репозитория
    }
}