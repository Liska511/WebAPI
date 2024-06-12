using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework

namespace Data;

public class Notification  // Класс объекта уведомления  (В качестве ячее для БД могут использоваться только свойства)
{
    public long Id { get; set; } // ID уведомления  (Первичный ключ)
    public int NotificationTypeId { get; set; } // ID типа уведомления  (Внешний ключ к таблице типов уведомления)
    public NotificationType NotificationType { get; set;} // Приаязка типа уведомления к уведомлению
    public int NotificationTemplateId { get; set;} // ID шаблона уведомления (Внешний ключ к таблице шаблонов уведомлений)
    public NotificationTemplate NotificationTemplate { get; set;} // Привязка шаблона уведомления к уведомлению
    public string NotificationDate { get; set;} // Дата отправки уведомления
    public long UserID { get; set;} // ID пользователя  (Внешний ключ к таблице пользователей)
    public User User  { get; set;} // Привязка объекта пользователя к уведомлению
    public string NotificationTitle { get; set;} // Заголовок уведомления
    public string NotificationText { get; set;} // Текст уведомления
    public int CountryID { get; set;}  // ID страны (Внешний ключ к таблице стран)
    public Country Country { get; set;} // Привязка страны к уведомлению
    public int CityID { get; set;} // ID города (Внешний ключ к таблице городов)
    public City City { get; set;} // Привязка объекта города к увежлмлению
    public long HotelID { get; set;} // ID отеля (Внешний ключ к таблице отелей)
    public Hotel Hotel { get; set;} // Привязка объекта отеля к уведомлению
    public long RoomID { get; set;} // ID комнаты (Внешний ключ к таблице комнат)
    public Room Room { get; set;} // Привязка объекта комнаты к уведомлению


}

public class NotificationMap  // Разметка сущности класса автора для Entity Framework. В данном случае для классп Author
{
    public NotificationMap(EntityTypeBuilder<Notification> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);  // Установка первичного ключа - ID уведомления
        entityTypeBuilder.Property(e => e.NotificationDate).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder.Property(e => e.NotificationTitle).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder.Property(e => e.NotificationText).IsRequired(); // Обязательное Поле для БД    
        entityTypeBuilder //  Прописывание отношений ОДИН КО МНОГИМ между одним пользоователем и уведомлениями 
            .HasOne(e => e.User)
            .WithMany(e => e.NotificationsList)
            .HasForeignKey(e => e.UserID); // Установка внешнего ключа - ID пользователя
        entityTypeBuilder //  Прописывание отношений ОДИН КО МНОГИМ между страной и уведомлениями
            .HasOne(e => e.Country)
            .WithMany(e => e.NotificationsList)
            .HasForeignKey(e => e.CountryID); // Установка внешнего ключа - ID страны
        entityTypeBuilder //  Прописывание отношений ОДИН КО МНОГИМ между одним городом и уведомлениями
            .HasOne(e => e.City)
            .WithMany(e => e.NotificationsList)
            .HasForeignKey(e => e.CityID); // Установка внешнего ключа - ID города
        entityTypeBuilder //  Прописывание отношений ОДИН КО МНОГИМ между одним отелем и уведомлениями
            .HasOne(e => e.Hotel)
            .WithMany(e => e.NotificationsList)
            .HasForeignKey(e => e.HotelID); // Установка внешнего ключа - ID отеля
        entityTypeBuilder //  Прописывание отношений ОДИН КО МНОГИМ между одной комнатой и уведомленияит
            .HasOne(e => e.Room)
            .WithMany(e => e.NotificationsList)
            .HasForeignKey(e => e.RoomID); // Установка внешнего ключа - ID комнаты
    }
}