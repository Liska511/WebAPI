namespace WebApplication1.DTO.NotificationTemplateDTO;

public class NotificationTemplateDTO
{
    public int Id { get; set; } // ID шаблона  (Первичный ключ)
    public string NotificationTemplateName { get; set;} // Имя шаблона
    public string NotificationTemplateDescription { get; set;} // Описание шаблона
    public string NotificationTemplateFilePath { get; set;} // Путь к файлу шаблона
    public List<NotificationDTO.NotificationDTO> NotificationsList { get; set; } = [];   // Струтура списка уведомлений с этим отелем. Необходим для организации связи ОДИН КО МНОГИМ шаблона и уведомлений

}