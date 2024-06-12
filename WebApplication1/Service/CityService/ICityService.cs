using WebApplication1.DTO.CityDTO; // Установка связи с объектами для транспортировки

namespace Service.CityService; // Интерфейс сервиса с описаним методов из него

public interface ICityService // Интерфейс сервиса с описаним методов из него
{
    CityDTO GetCity(int id); // Описание метода получения города из репозитория 
    
    CityDTO GetCityByName(string CityName);
    List<CityDTO> GetCities(); // Описание метода получения всех городов из репозитория
    void InsertCity(CreateCityDTO dto);  // Описание метода вставки города в репозитория
    void UpdateCity(UpdateCityDTO dto);  // Описание метода обновления информации о городе в репозитория
    void DeleteCity(int id); // Описание метода удаления города из репозитория по заданному пользователем ID
}