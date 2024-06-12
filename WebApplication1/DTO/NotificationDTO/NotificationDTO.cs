namespace WebApplication1.DTO.NotificationDTO;

public class NotificationDTO
{
    public long Id { get; set; } // ID уведомления  (Первичный ключ)
    public int NotificationTypeId { get; set; } // ID типа уведомления  (Внешний ключ к таблице типов уведомления)
    public NotificationTypeDTO.NotificationTypeDTO NotificationType { get; set;} // Приаязка типа уведомления к уведомлению
    public int NotificationTemplateId { get; set;} // ID шаблона уведомления (Внешний ключ к таблице шаблонов уведомлений)
    public NotificationTemplateDTO.NotificationTemplateDTO NotificationTemplate { get; set;} // Привязка шаблона уведомления к уведомлению
    public string NotificationDate { get; set;} // Дата отправки уведомления
    public long UserID { get; set;} // ID пользователя  (Внешний ключ к таблице пользователей)
    public UserDTO.UserDTO User  { get; set;} // Привязка объекта пользователя к уведомлению
    public string NotificationTitle { get; set;} // Заголовок уведомления
    public string NotificationText { get; set;} // Текст уведомления
    public int CountryID { get; set;}  // ID страны (Внешний ключ к таблице стран)
    public CountryDTO.CountryDTO Country { get; set;} // Привязка страны к уведомлению
    public int CityID { get; set;} // ID города (Внешний ключ к таблице городов)
    public CityDTO.CityDTO City { get; set;} // Привязка объекта города к увежлмлению
    public long HotelID { get; set;} // ID отеля (Внешний ключ к таблице отелей)
    public HotelDTO.HotelDTO Hotel { get; set;} // Привязка объекта отеля к уведомлению
    public long RoomID { get; set;} // ID комнаты (Внешний ключ к таблице комнат)
    public RoomDTO.RoomDTO Room { get; set;} // Привязка объекта комнаты к уведомлению

}