using Microsoft.EntityFrameworkCore.Metadata.Builders; // Вызов фунуционала Entity Framework

namespace Data;  

public class Form // Класс объекта формы обратной связи (В качестве ячее для БД могут использоваться только свойства)
{
    public long Id { get; set; } // ID формы обратной связи - Первичный клюя
    public long UserId { get; set; } // iD пользователя, заполнившего форму - Вторичный ключ для связи с пользователем
    public User User { get; set;} // Привязка объекта пользователя к форме.
    public int FormProblemId { get; set; } // ID возможной проблемы - Вторичный ключ для связи с возможными проблемами для формы
    public FormProblem FormProblem { get; set; } // Привязка объекта проблемы
    public string FormText { get; set; } // Текст формы
}

public class FormMap  // Разметка сущности формы обратной связи
{
    public FormMap(EntityTypeBuilder<Form> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id); //Установка первичного ключа
        entityTypeBuilder.Property(e => e.FormText).IsRequired();
        entityTypeBuilder   //  Прописывание отношений ОДИН КО МНОГИМ между одним пользователем и заполненными им формами 
            .HasOne(e => e.User)
            .WithMany(e => e.FormsList)
            .HasForeignKey(e => e.UserId);  // Установка вторичного ключа - ID пользователя
        entityTypeBuilder //  Прописывание отношений ОДИН КО МНОГИМ между одной проблемой и содержащими ее описание формами
            .HasOne(e => e.FormProblem)
            .WithMany(e => e.FormsList)
            .HasForeignKey(e => e.FormProblemId); // Установка вторичного ключа - ID проблемы
    }
}