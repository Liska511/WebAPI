namespace WebApplication1.DTO.NotificationDTO;

public class CreateNotificationDTO
{
    public int NotificationTypeId { get; set; } // ID типа уведомления  (Внешний ключ к таблице типов уведомления)
    public int NotificationTemplateId { get; set;} // ID шаблона уведомления (Внешний ключ к таблице шаблонов уведомлений)
    public string NotificationDate { get; set;} // Дата отправки уведомления
    public long UserID { get; set;} // ID пользователя  (Внешний ключ к таблице пользователей)
    public string NotificationTitle { get; set;} // Заголовок уведомления
    public string NotificationText { get; set;} // Текст уведомления
    public int CountryID { get; set;}  // ID страны (Внешний ключ к таблице стран)
    public int CityID { get; set;} // ID города (Внешний ключ к таблице городов)
    public long HotelID { get; set;} // ID отеля (Внешний ключ к таблице отелей)
    public long RoomID { get; set;} // ID комнаты (Внешний ключ к таблице комнат)
}