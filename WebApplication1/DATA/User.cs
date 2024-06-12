using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Data;

public class User : IdentityUser<long>  // Класс объекта автора  (В качестве ячее для БД могут использоваться только свойства)
{


    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } 
   
   
    public List<Form> FormsList { get; set; } = [];  // Струтура списка авторов одной книги. Необходим для организации связи МНОГИЕ КО МНОГИМ через смежную таблицу BookAuthor
    public List<Notification> NotificationsList { get; set; } = []; 
    
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    
}

