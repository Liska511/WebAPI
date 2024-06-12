using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework

namespace Data;

public class NotificationType  // Класс объекта типа уведомлений  (В качестве ячее для БД могут использоваться только свойства)
{
    public int Id { get; set; } // ID типа  (Первичный ключ)
    public string NotificationTypeName { get; set;} // Имя типа
    public string NotificationTypeDescription { get; set;} // Описание типа
  
    
    public List<Notification> NotificationsList { get; set; } = [];  // Струтура списка уведомлений с этим типом. Необходим для организации связи ОДИН КО МНОГИМ типа и уведомлений
}

public class NotificationTypeMap  // Разметка сущности класса автора для Entity Framework. В данном случае для классп Author
{
    public NotificationTypeMap(EntityTypeBuilder<NotificationType> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);  // Установка первичного ключа - ID типа
        entityTypeBuilder.Property(e => e.NotificationTypeName).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder.Property(e => e.NotificationTypeDescription).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder    // Прописывание отношений МНОГИЕ К ОДНОМУ между уведомлениями и типом
            .HasMany(e => e.NotificationsList)   
            .WithOne(e => e.NotificationType); 
    }
}