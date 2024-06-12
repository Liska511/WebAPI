namespace WebApplication1.DTO.FormProblemDTO;

public class FormProblemDTO
{
    public int Id { get; set; } // ID проблемы  (Первичный ключ)
    public string ProblemName { get; set;} // Название страны
    public string ProblemSimpleDescription { get; set;} // Описание проблемы автора
    public List<FormDTO.FormDTO> FormsList { get; set; } = [];  // Струтура списка форм обратной связи с одной проблемой. Необходим для организации связи ОДИН КО МНОГИМ между проблемой и формами обратной связи

}