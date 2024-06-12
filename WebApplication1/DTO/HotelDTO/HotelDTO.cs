namespace WebApplication1.DTO.HotelDTO;

public class HotelDTO
{
    public long Id { get; set; } // ID отеля (Первичный ключ)
    public int CityId { get; set; } // ID города  (Внешний ключ для связи с городом)
    public CityDTO.CityDTO City { get; set;} // Приаязка объекта города
    public string HotelName { get; set;} // Имя отеля
    public string HotelDescription { get; set;} // Описание отеля
    public List<RoomDTO.RoomDTO> RoomsList { get; set; } = [];  // Струтура списка комнат одного отеля. Необходим для организации связи ОДИН КО МНОГИМ между отелем и его комнатами
    public List<NotificationDTO.NotificationDTO> NotificationsList { get; set; } = [];  // Струтура списка уведомлений с этим отелем. Необходим для организации связи ОДИН КО МНОГИМ отеля и уведомлений

}