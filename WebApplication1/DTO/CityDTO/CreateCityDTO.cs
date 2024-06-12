namespace WebApplication1.DTO.CityDTO;

public class CreateCityDTO
{
    public int CountryId { get; set; } // ID страны города  (Вторичный ключ к таблице стран)
    public string CityName { get; set;} // Имя города
    public string CityDescription { get; set;} // Олисание города
    
}