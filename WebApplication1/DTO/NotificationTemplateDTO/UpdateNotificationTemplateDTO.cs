namespace WebApplication1.DTO.NotificationTemplateDTO;

public class UpdateNotificationTemplateDTO
{
    public int Id { get; set; }
    public string NotificationTemplateName { get; set;} // Имя шаблона
    public string NotificationTemplateDescription { get; set;} // Описание шаблона
    public string NotificationTemplateFilePath { get; set;} // Путь к файлу шаблона
}