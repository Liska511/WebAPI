namespace WebApplication1.DTO.CityDTO;

public class CityDTO
{
    public int Id { get; set; } // ID города  (Первичный ключ)
    public int CountryId { get; set; } // ID страны города  (Вторичный ключ к таблице стран )
    public CountryDTO.CountryDTO Country { get; set;} // Привязка страны к городу
    public string CityName { get; set;} // Имя города
    public string CityDescription { get; set;} // Олисание города
    public List<HotelDTO.HotelDTO> HotelsList { get; set; } = [];  // Струтура списка отелей в одном городе. Необходим для организации связи ОДИН КО МНОГИМ города и отелей в нем
    public List<NotificationDTO.NotificationDTO> NotificationsList { get; set; } = [];  // Струтура списка уведомлений с этим городом. Необходим для организации связи ОДИН КО МНОГИМ города и уведомлений
}