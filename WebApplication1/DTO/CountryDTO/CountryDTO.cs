namespace WebApplication1.DTO.CountryDTO;

public class CountryDTO
{
    public int Id { get; set; } // ID страны  (Первичный ключ)
    public string CountryName { get; set;} // Имя страны
    public string CountryDescription { get; set;} // Описание страны
    public List<CityDTO.CityDTO> CitiesList { get; set; } = [];  // Струтура списка городов одной страны. Необходим для организации связи ОДИН КО МНОГИМ между страной и городами 
    
    public List<NotificationDTO.NotificationDTO> NotificationsList { get; set; } = [];  // Струтура списка уведомлений с этой страной. Необходим для организации связи ОДИН КО МНОГИМ страны и уведомлений

}