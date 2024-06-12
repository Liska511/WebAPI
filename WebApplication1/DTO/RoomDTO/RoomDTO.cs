namespace WebApplication1.DTO.RoomDTO;

public class RoomDTO
{
    public long Id { get; set; } // ID комнаты  (Первичный ключ)
    public long HotelId { get; set; } // ID отеля  (Внешний ключ к таблице отелей)
    public HotelDTO.HotelDTO Hotel { get; set;} // Привязка объекта отеля к комнате
    public string RoomName { get; set;} // Номер комнаты
    public string RoomDescription { get; set;} // Описание комнаты
    public List<NotificationDTO.NotificationDTO> NotificationsList { get; set; } = [];  // Струтура списка уведомлений с этой комнатой. Необходим для организации связи ОДИН КО МНОГИМ комнаты и уведомлений

}