using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework

namespace Data;

public class City  // Класс объекта города  (В качестве ячеек для БД могут использоваться только свойства)
{
    public int Id { get; set; } // ID города  (Первичный ключ)
    public int CountryId { get; set; } // ID страны города  (Вторичный ключ к таблице стран )
    public Country Country { get; set;} // Привязка страны к городу
    public string CityName { get; set;} // Имя города
    public string CityDescription { get; set;} // Олисание города
    public List<Hotel> HotelsList { get; set; } = [];  // Струтура списка отелей в одном городе. Необходим для организации связи ОДИН КО МНОГИМ города и отелей в нем
    public List<Notification> NotificationsList { get; set; } = [];  // Струтура списка уведомлений с этим городом. Необходим для организации связи ОДИН КО МНОГИМ города и уведомлений
}

public class CityMap  // Разметка сущности класса города для Entity Framework. В данном случае для классп города City
{
    public CityMap(EntityTypeBuilder<City> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);  // Установка первичного ключа - ID города
        entityTypeBuilder.Property(e => e.CityName).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder.Property(e => e.CityDescription).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder    // Прописывание отношений ОДИН КО МНОГИМ между городом и уведомлениями
            .HasMany(e => e.HotelsList)   
            .WithOne(e => e.City); 
        entityTypeBuilder    // Прописывание отношений ОДИН КО МНОГИМ между городом и уведомлениями
            .HasMany(e => e.NotificationsList)   
            .WithOne(e => e.City); 
        entityTypeBuilder //  Прописывание отношений ОДИН КО МНОГИМ между одной страной и городами
            .HasOne(e => e.Country)
            .WithMany(e => e.CitiesList)
            .HasForeignKey(e => e.CountryId); // Установка вторичного ключа - ID страны
       
    }
}



