using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.DTO.CityDTO; // Вызов фунуционала Entity Framework

namespace Data;

public class Country  // Класс объекта страны  (В качестве ячее для БД могут использоваться только свойства)
{
    public int Id { get; set; } // ID страны  (Первичный ключ)
    public string CountryName { get; set;} // Имя страны
    public string CountryDescription { get; set;} // Описание страны
    public List<City> CitiesList { get; set; } = [];  // Струтура списка городов одной страны. Необходим для организации связи ОДИН КО МНОГИМ между страной и городами 
    
    public List<Notification> NotificationsList { get; set; } = [];  // Струтура списка уведомлений с этой страной. Необходим для организации связи ОДИН КО МНОГИМ страны и уведомлений
}

public class CountryMap  // Разметка сущности класса страны для Entity Framework. В данном случае для классп Country
{
    public CountryMap(EntityTypeBuilder<Country> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);  // Установка первичного ключа - ID автора
        entityTypeBuilder.Property(e => e.CountryName).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder.Property(e => e.CountryDescription).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder    // Прописывание отношений ОДИН КО МНОГИМ между страной и уведомлениями
            .HasMany(e => e.NotificationsList)   
            .WithOne(e => e.Country); 
        entityTypeBuilder    // Прописывание отношений ОДИН КО МНОГИМ между страной и уведомлениями
            .HasMany(e => e.CitiesList)   
            .WithOne(e => e.Country);
    }
}