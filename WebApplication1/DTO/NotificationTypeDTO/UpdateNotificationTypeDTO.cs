namespace WebApplication1.DTO.NotificationTypeDTO;

public class UpdateNotificationTypeDTO
{
    public int Id { get; set; } // ID типа  (Первичный ключ)
    public string NotificationTypeName { get; set;} // Имя типа
    public string NotificationTypeDescription { get; set;} // Описание типа

}