using Data;
using WebApplication1.DTO.NotificationTemplateDTO; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;  // Вызов функционала EntityFramework

namespace Repository.NotificationTemplateRepository; // Методы, логика и содержимое репозитория шаблонов в БД

public class NotificationTemplateRepository(ApplicationContext context) : INotificationTemplateRepository // Логика взаимодействий с репозиторием шаблонов
{
    private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<NotificationTemplate> _notificationtemplates = context.Set<NotificationTemplate>(); // Получение списка шаблонов из БД

    public NotificationTemplateDTO Get(int id) // Получение одного автора из БД
    {
        var notificationtemplate = _notificationtemplates.SingleOrDefault(f => f.Id == id); // Нахождение шаблона по его ID в общем списке
        if (notificationtemplate == null) return null; // Если шаблона не существует
        return new NotificationTemplateDTO  // Создание и вывод объекта для передачи данных найденного шаблона  
        {
            Id = notificationtemplate.Id,
            NotificationTemplateName  = notificationtemplate.NotificationTemplateName,
            NotificationTemplateDescription = notificationtemplate.NotificationTemplateDescription,
            NotificationTemplateFilePath= notificationtemplate.NotificationTemplateFilePath
        };  // Присваивание объекту для передачи данных всех свойств искомого шаблона
    }
    
    public List<NotificationTemplateDTO> GetNotificationTemplates()  // Получение всех шаблонов из БД
    {
        var notificationtemplates = _notificationtemplates.ToList(); // Создание общего списка шаблонов, содержащихся в БД
        List<NotificationTemplateDTO> lnotificationtemplates = new List<NotificationTemplateDTO>(); // Создание списка объектов для транспортировки данных всех шаблонов из БД

        foreach (var notificationtemplate in notificationtemplates) //  Циклическое заполнение объектов для транспортировки
        {
            lnotificationtemplates.Add(new NotificationTemplateDTO
            {
                Id = notificationtemplate.Id,
                NotificationTemplateName  = notificationtemplate.NotificationTemplateName,
                NotificationTemplateDescription = notificationtemplate.NotificationTemplateDescription,
                NotificationTemplateFilePath= notificationtemplate.NotificationTemplateFilePath
            }); // Заполнение объектов для транспортировки
        }
        return lnotificationtemplates; // Вывод списка шаблонов пользователю
    }


    public void Insert(CreateNotificationTemplateDTO dto)  // Вставка нового шаблона через объект для транспортировки в БД
    {
        NotificationTemplate notificationtemplate = new NotificationTemplate() // Создание нового шаблона в БД
        {
            NotificationTemplateName  = dto.NotificationTemplateName,
            NotificationTemplateDescription = dto.NotificationTemplateDescription,
            NotificationTemplateFilePath= dto.NotificationTemplateFilePath
        }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
        _notificationtemplates.Add(notificationtemplate); // Добавление нового шаблона в общий список шаблонов в БД
        context.SaveChanges(); // Сохранение изменений, внесенных в БД
    }

    public void Update(UpdateNotificationTemplateDTO dto) // Обновление информации о каком-либо шаблоне из БД
    {
        var notificationtemplate = _notificationtemplates.SingleOrDefault(a => a.Id == dto.Id); // Нахождение искомого шаблона в общем списке шаблонов из БД
        if (notificationtemplate == null) return; // Если искомого шаблона не существует

        notificationtemplate.NotificationTemplateName = dto.NotificationTemplateName;
        notificationtemplate.NotificationTemplateDescription = dto.NotificationTemplateDescription;
        notificationtemplate.NotificationTemplateFilePath = dto.NotificationTemplateFilePath;
        // Присваивание искомому шаблону свойств, введенных пользователем, через объект для трванспортировки

        _notificationtemplates.Update(notificationtemplate); // Внесение изменений в общий список шаблонов в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }
    
    public void Delete(int id) // Удаление автора ищ БД по указанному ID
    {
        var notificationtemplate = _notificationtemplates.SingleOrDefault(a => a.Id == id);  // Нахождение указанного шаблона в общем списке авторов из БД
        if (notificationtemplate == null) return; // Если искомого шаблона не существует
        _notificationtemplates.Remove(notificationtemplate); // Удаление шаблона из общего списка авторов в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }

    public void SaveChanges() // Сохранение внесенных изменений в БД
    {
        context.SaveChanges();  // Сохранение внесенных изменений в БД
    }
}