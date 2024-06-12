namespace WebApplication1.DTO.NotificationTypeDTO;

public class NotificationTypeDTO
{
    public int Id { get; set; } // ID типа  (Первичный ключ)
    public string NotificationTypeName { get; set;} // Имя типа
    public string NotificationTypeDescription { get; set;} // Описание типа
  
    
    public List<NotificationDTO.NotificationDTO> NotificationsList { get; set; } = [];  // Струтура списка уведомлений с этим типом. Необходим для организации связи ОДИН КО МНОГИМ типа и уведомлений

}