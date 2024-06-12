using WebApplication1.DTO.CityDTO;  // Установка связи с объектами для транспортировки
using Repository.CityRepository; // Установка связи с репозиторием 

namespace Service.CityService;  // Бизнес логика взаимодействия с репозиторием (а через него и с содержимым БД)

public class CityService(ICityRepository cityRepository) : ICityService
{
    private ICityRepository _cityRepository = cityRepository; // создание "ссылки" для обращения в репозиторий из сервиса

    public CityDTO GetCity(int id) // Метод получения города из репозитория
    {
        return _cityRepository.Get(id); // Отработка по запросу сервиса метода нахождения города из репозитория
    }

    public CityDTO GetCityByName(string CityName) // Метод получения города из репозитория по его имени
    {
        return _cityRepository.GetByName(CityName); // Отработка по запросу сервиса метода нахождения города по имени из репозитория
    }
    
    public List<CityDTO> GetCities()  // Метод получсения всех городов из репозитория
    {
        return _cityRepository.GetCities(); // Отработка по запросу сервиса метода получения всех городов из репозитория
    }

    public void InsertCity(CreateCityDTO dto) // Метод создания нового города в репозитории
    {
        _cityRepository.Insert(dto);  // Отработка по запросу сервиса метода вставки нового города из репозитория
    }

    public void UpdateCity(UpdateCityDTO dto)  //  Метод обновления города из репозитория
    {
        _cityRepository.Update(dto); // Отработка по запросу сервиса метода обноаления информации о городе из репозитория
    }

    public void DeleteCity(int id)  // Метод удаления города из репозитория
    {
        _cityRepository.Delete(id);  // Отработка по запросу сервиса метода удаления города из репозитория
    }
}