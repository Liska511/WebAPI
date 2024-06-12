namespace WebApplication1.DTO.RoomDTO;

public class CreateRoomDTO
{
    public long HotelId { get; set; } // ID отеля  (Внешний ключ к таблице отелей)
    public string RoomName { get; set;} // Номер комнаты
    public string RoomDescription { get; set;} // Описание комнаты
}