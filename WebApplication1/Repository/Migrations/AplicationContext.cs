using Data;
using Microsoft.EntityFrameworkCore; // Вызов функционала Entity Framework
using Microsoft.AspNetCore.Identity; // Вызов функционала ASP .NET Core Identity
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Модели ASP .Net Identity для пользователя и ролей

namespace Repository;



public class  ApplicationContext : IdentityDbContext<User, IdentityRole<long>, long> 
{  
    
    public ApplicationContext (DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) // Создание моделей в БД на основе сущностей и классов из Data
    {
        base.OnModelCreating(modelBuilder);
        new CityMap(modelBuilder.Entity<City>()); // Создание модели города в БД
        new CountryMap(modelBuilder.Entity<Country>());  // Создание модели страны в БД
        new FormMap(modelBuilder.Entity<Form>()); // Создание модели формы обратной связи в БД
        new FormProblemMap(modelBuilder.Entity<FormProblem>()); // Создание моделИ проблемыв в БД
        new HotelMap(modelBuilder.Entity<Hotel>()); // Создание модели отеля в БД
        new NotificationMap(modelBuilder.Entity<Notification>()); // Создание модели уведомления в БД
        new NotificationTemplateMap(modelBuilder.Entity<NotificationTemplate>()); // Создание модели шаблона уведомлений в БД
        new NotificationTypeMap(modelBuilder.Entity<NotificationType>()); // Создание модели типа уведомлений в БД
        new RoomMap(modelBuilder.Entity<Room>()); // Создание модели комнаты в БД

    }
}