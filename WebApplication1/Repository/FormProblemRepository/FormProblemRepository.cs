using Data;
using WebApplication1.DTO.FormProblemDTO; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;  // Вызов функционала EntityFramework

namespace Repository.FormProblemRepository; // Методы, логика и содержимое репозитория авторов в БД

public class FormProblemRepository(ApplicationContext context) : IFormProblemRepository // Логика взаимодействий с репозиторием проблемы
{
    private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<FormProblem> _formproblems = context.Set<FormProblem>(); // Получение списка проблем из БД

    public FormProblemDTO Get(int id) // Получение одной формы из БД
    {
        var formproblem = _formproblems.SingleOrDefault(f => f.Id == id); // Нахождение проблемы по ее ID в общем списке
        if (formproblem == null) return null; // Если проблемы не существует
        return new FormProblemDTO  // Создание и вывод объекта для передачи данных найденной проблемы
        {
            Id = formproblem.Id,
            ProblemName  = formproblem.ProblemName,
            ProblemSimpleDescription = formproblem.ProblemSimpleDescription,
        };  // Присваивание объекту для передачи данных всех свойств искомой проблемы
    }
    
    public List<FormProblemDTO> GetFormProblems()  // Получение всех проблем из БД
    {
        var formproblems = _formproblems.ToList(); // Создание общего списка проблем, содержащихся в БД
        List<FormProblemDTO> lformproblems = new List<FormProblemDTO>(); // Создание списка объектов для транспортировки данных всех проблем из БД

        foreach (var formproblem in formproblems) //  Циклическое заполнение объектов для транспортировки
        {
            lformproblems.Add(new FormProblemDTO
            {
                Id = formproblem.Id,
                ProblemName = formproblem.ProblemName,
                ProblemSimpleDescription = formproblem.ProblemSimpleDescription
            }); // Заполнение объектов для транспортировки
        }
        return lformproblems; // Вывод списка проблем пользователю
    }


    public void Insert(CreateFormProblemDTO dto)  // Вставка новой проблемы через объект для транспортировки в БД
    {
        FormProblem formproblem = new FormProblem() // Создание новой проблемы в БД
        {
            ProblemName = dto.ProblemName,
            ProblemSimpleDescription = dto.ProblemSimpleDescription,
        }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
        _formproblems.Add(formproblem); // Добавление нового автора в общий список авторов в БД
        context.SaveChanges(); // Сохранение изменений, внесенных в БД
    }

    public void Update(UpdateFormProblemDTO dto) // Обновление информации о какой-либо проблеме из БД
    {
        var formproblem = _formproblems.SingleOrDefault(a => a.Id == dto.Id); // Нахождение искомой проблемы в общем списке проблем из БД
        if (formproblem == null) return; // Если искомой проблемы не существует

        formproblem.ProblemName = dto.ProblemName;
        formproblem.ProblemSimpleDescription = dto.ProblemSimpleDescription;
        // Присваивание искомой проблеме свойств, введенных пользователем, через объект для трванспортировки

        _formproblems.Update(formproblem); // Внесение изменений в общий список проблем в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }
    
    public void Delete(int id) // Удаление проблемы ищ БД по указанному ID
    {
        var formproblem= _formproblems.SingleOrDefault(a => a.Id == id);  // Нахождение указанной проблемы в общем списке проблем из БД
        if (formproblem == null) return; // Если искомой ароблемы не существует
        _formproblems.Remove(formproblem); // Удаление проблемы из общего списка проблем в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }

    public void SaveChanges() // Сохранение внесенных изменений в БД
    {
        context.SaveChanges();  // Сохранение внесенных изменений в БД
    }
}