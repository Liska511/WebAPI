namespace WebApplication1.DTO.FormDTO;

public class CreateFormDTO
{
    
    public long UserId { get; set; } // iD пользователя, заполнившего форму - Вторичный ключ для связи с пользователеV
    public int FormProblemId { get; set; } // ID возможной проблемы - Вторичный ключ для связи с возможными проблемами для формы
    public string FormText { get; set; } // Текст формы
}