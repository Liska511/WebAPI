using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework

namespace Data;

public class Hotel  // Класс объекта отеля  (В качестве ячее для БД могут использоваться только свойства)
{
    public long Id { get; set; } // ID отеля (Первичный ключ)
    public int CityId { get; set; } // ID города  (Внешний ключ для связи с городом)
    public City City { get; set;} // Приаязка объекта города
    public string HotelName { get; set;} // Имя отеля
    public string HotelDescription { get; set;} // Описание отеля
    public List<Room> RoomsList { get; set; } = [];  // Струтура списка комнат одного отеля. Необходим для организации связи ОДИН КО МНОГИМ между отелем и его комнатами
    public List<Notification> NotificationsList { get; set; } = [];  // Струтура списка уведомлений с этим отелем. Необходим для организации связи ОДИН КО МНОГИМ отеля и уведомлений
        
}

public class HotelMap  // Разметка сущности класса отеля для Entity Framework. 
{
    public HotelMap(EntityTypeBuilder<Hotel> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);  // Установка первичного ключа - ID отеля
        entityTypeBuilder.Property(e => e.HotelName).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder.Property(e => e.HotelDescription).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder    // Прописывание отношений МНОГИЕ К ОДНОМУ между уведомлениями и отелем
            .HasMany(e => e.NotificationsList)  
            .WithOne(e => e.Hotel); 
        entityTypeBuilder    // Прописывание отношений МНОГИЕ К ОДНОМУ между уведомлениями и отелем
            .HasMany(e => e.RoomsList)   
            .WithOne(e => e.Hotel); 
        entityTypeBuilder //  Прописывание отношений ОДИН КО МНОГИМ между одним городои и отелями
            .HasOne(e => e.City)
            .WithMany(e => e.HotelsList)
            .HasForeignKey(e => e.CityId); // Установка вторичного ключа - ID города
    }
}