using Data;
using WebApplication1.DTO.FormDTO; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO.UserDTO; // Вызов функционала EntityFramework

namespace Repository.FormRepository; // Методы, логика и содержимое репозитория форм в БД

public class FormRepository(ApplicationContext context) : IFormRepository // Логика взаимодействий с репозиторием форм
{
    private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<Form> _forms = context.Set<Form>(); // Получение списка форм из БД

    public FormDTO Get(long id) // Получение одного форм из БД
    {
        var form = _forms.Include(form=>form.User).SingleOrDefault(f => f.Id == id); // Нахождение формы по его ID в общем списке
        if (form == null) return null; // Если формы не существует
        var user = new UserDTO()
        {
            Id = form.User.Id,
            Login = form.User.Email,
            Password = "Hiidden"

        }; // Заполнение данных о пользователе
        
        
        return new FormDTO  // Создание и вывод объекта длч передачи данных найденной формы 
        {
            Id = form.Id,
            UserId  = form.UserId,
            FormProblemId = form.FormProblemId,
            FormText = form.FormText,
            User = user
        };  // Присваивание объекту для передачи данных всех свойств искомой формы
    }
    
    public List<FormDTO> GetForms()  // Получение всех форм из БД
    {
        var forms = _forms.ToList(); // Создание общего списка форм, содержащихся в БД
        List<FormDTO> lforms = new List<FormDTO>(); // Создание списка объектов для транспортировки данных всех форм из БД

        foreach (var form in forms) //  Циклическое заполнение объектов для транспортировки
        {
            lforms.Add(new FormDTO
            {
                Id = form.Id,
                UserId = form.UserId,
                FormProblemId = form.FormProblemId,
                FormText = form.FormText
            }); // Заполнение объектов для транспортировки
        }
        return lforms; // Вывод списка форм пользователю
    }


    public void Insert(CreateFormDTO dto)  // Вставка новой формы через объект для транспортировки в БД
    {
        Form form = new Form() // Создание новой формы в БД
        {
            UserId = dto.UserId,
            FormProblemId = dto.FormProblemId,
            FormText = dto.FormText
        }; // Присваивание ей всех свойств, введенных пользователем из объекта для транспортировки
        _forms.Add(form); // Добавление новой формы в общий список форм в БД
        context.SaveChanges(); // Сохранение изменений, внесенных в БД
    }

    public void Update(UpdateFormDTO dto) // Обновление информации о каком-либо авторе из БД
    {
        var form = _forms.SingleOrDefault(a => a.Id == dto.Id); // Нахождение искомой формы в общем списке форм из БД
        if (form == null) return; // Если искомой формы не существует

        form.UserId = dto.UserId;
        form.FormProblemId = dto.FormProblemId;
        form.FormText = dto.FormText;
        // Присваивание искомой форме свойств, введенных пользователем, через объект для трванспортировки

        _forms.Update(form); // Внесение изменений в общий список форм в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }
    
    public void Delete(long id) // Удаление формы ищ БД по указанному ID
    {
        var form = _forms.SingleOrDefault(a => a.Id == id);  // Нахождение указанной формы в общем списке форм из БД
        if (form == null) return; // Если искомого формы не существует
        _forms.Remove(form); // Удаление формы из общего списка форм в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }

    public void SaveChanges() // Сохранение внесенных изменений в БД
    {
        context.SaveChanges();  // Сохранение внесенных изменений в БД
    }
}