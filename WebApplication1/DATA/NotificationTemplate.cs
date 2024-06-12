using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework

namespace Data;

public class NotificationTemplate  // Класс объекта шаблона уведомления  (В качестве ячее для БД могут использоваться только свойства)
{
    public int Id { get; set; } // ID шаблона  (Первичный ключ)
    public string NotificationTemplateName { get; set;} // Имя шаблона
    public string NotificationTemplateDescription { get; set;} // Описание шаблона
    public string NotificationTemplateFilePath { get; set;} // Путь к файлу шаблона
    public List<Notification> NotificationsList { get; set; } = [];   // Струтура списка уведомлений с этим отелем. Необходим для организации связи ОДИН КО МНОГИМ шаблона и уведомлений
}

public class NotificationTemplateMap  // Разметка сущности класса автора для Entity Framework. В данном случае для классп Author
{
    public NotificationTemplateMap(EntityTypeBuilder<NotificationTemplate> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);  // Установка первичного ключа - ID шаблона
        entityTypeBuilder.Property(e => e.NotificationTemplateName).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder.Property(e => e.NotificationTemplateDescription).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder.Property(e => e.NotificationTemplateFilePath).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder    // Прописывание отношений ОДИН КО МНОГИМ шаблона и уведомлений
            .HasMany(e => e.NotificationsList)   
            .WithOne(e => e.NotificationTemplate); 
    }
}