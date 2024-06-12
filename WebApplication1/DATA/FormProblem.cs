using Microsoft.EntityFrameworkCore.Metadata.Builders;  // Вызов фунуционала Entity Framework

namespace Data;

public class FormProblem  // Класс объекта проблемы для формы (В качестве ячее для БД могут использоваться только свойства)
{
    public int Id { get; set; } // ID проблемы  (Первичный ключ)
    public string ProblemName { get; set;} // Название страны
    public string ProblemSimpleDescription { get; set;} // Описание проблемы автора
  
    
    public List<Form> FormsList { get; set; } = [];  // Струтура списка форм обратной связи с одной проблемой. Необходим для организации связи ОДИН КО МНОГИМ между проблемой и формами обратной связи
}

public class FormProblemMap  // Разметка сущности класса проблемы для Entity Framework. 
{
    public FormProblemMap(EntityTypeBuilder<FormProblem> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);  // Установка первичного ключа - ID проблемы
        entityTypeBuilder.Property(e => e.ProblemName).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder.Property(e => e.ProblemSimpleDescription).IsRequired(); // Обязательное Поле для БД
        entityTypeBuilder    // Прописывание отношений ОДИН КО МНОГИМ между проблемой и формами обратной связи
            .HasMany(e => e.FormsList)   
            .WithOne(e => e.FormProblem); 
    }
}