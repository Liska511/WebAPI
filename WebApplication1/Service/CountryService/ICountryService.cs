using WebApplication1.DTO.CountryDTO; // Установка связи с объектами для транспортировки

namespace Service.CountryService; // Интерфейс сервиса с описаним методов из него

public interface ICountryService // Интерфейс сервиса с описаним методов из него
{
    CountryDTO GetCountry(int id); // Описание метода получения страны из репозитория 
    
    CountryDTO GetCountryByName(string CountryName); // Описание метода получения страны по имени из репозитория 
    List<CountryDTO> GetCountries(); // Описание метода получения всех стран из репозитория
    void InsertCountry(CreateCountryDTO dto);  // Описание метода вставки страны в репозитория
    void UpdateCountry(UpdateCountryDTO dto);  // Описание метода обновления информации о стране в репозитория
    void DeleteCountry(int id); // Описание метода  удаления страны из репозитория по заданному пользователем ID
}