namespace WebApplication1.DTO.FormDTO;

public class FormDTO
{
    public long Id { get; set; } // ID формы обратной связи - Первичный клюя
    public long UserId { get; set; } // iD пользователя, заполнившего форму - Вторичный ключ для связи с пользователем
    public UserDTO.UserDTO User { get; set;} // Привязка объекта пользователя к форме.
    public int FormProblemId { get; set; } // ID возможной проблемы - Вторичный ключ для связи с возможными проблемами для формы
    public FormProblemDTO.FormProblemDTO FormProblem { get; set; } // Привязка объекта проблемы
    public string FormText { get; set; } // Текст формы
}