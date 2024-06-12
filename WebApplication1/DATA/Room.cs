using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework

namespace Data;

public class Room  // Класс объекта комнаты  (В качестве ячее для БД могут использоваться только свойства)
{
    public long Id { get; set; } // ID комнаты  (Первичный ключ)
    public long HotelId { get; set; } // ID отеля  (Внешний ключ к таблице отелей)
    public Hotel Hotel { get; set;} // Привязка объекта отеля к комнате
    public string RoomName { get; set;} // Номер комнаты
    public string RoomDescription { get; set;} // Описание комнаты
    public List<Notification> NotificationsList { get; set; } = [];  // Струтура списка уведомлений с этой комнатой. Необходим для организации связи ОДИН КО МНОГИМ комнаты и уведомлений
}

public class RoomMap  // Разметка сущности класса автора для Entity Framework. В данном случае для классп Author
{
    public RoomMap(EntityTypeBuilder<Room> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);  // Установка первичного ключа - ID комнаты
        entityTypeBuilder.Property(e => e.RoomName).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder.Property(e => e.RoomDescription).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder    // Прописывание отношений МНОГИЕ К ОДНОМУ между уведомлениями и комнатой
            .HasMany(e => e.NotificationsList)   
            .WithOne(e => e.Room); 
        entityTypeBuilder //  Прописывание отношений ОДИН КО МНОГИМ между одним отелем и его комнатами
            .HasOne(e => e.Hotel)
            .WithMany(e => e.RoomsList)
            .HasForeignKey(e => e.HotelId); // Установка внешнего ключа - ID отеля
    }
}