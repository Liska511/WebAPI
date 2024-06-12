using WebApplication1.DTO.CountryDTO;  // Установка связи с объектами для транспортировки
using Repository.CountryRepository; // Установка связи с репозиторием 

namespace Service.CountryService;  // Бизнес логика взаимодействия с репозиторием (а через него и с содержимым БД)

public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    private ICountryRepository _countryRepository = countryRepository; // создание "ссылки" для обращения в репозиторий из сервиса

    public CountryDTO GetCountry(int id) // Метод получения страны из репозитория
    {
        return _countryRepository.Get(id); // Отработка по запросу сервиса метода нахождения страны из репозитория
    }
    
    
    public CountryDTO GetCountryByName(string CountryName) // Метод получения страны из репозитория
    {
        return _countryRepository.GetByName(CountryName); // Отработка по запросу сервиса метода нахождения страны по имени из репозитория 
    }

    public List<CountryDTO> GetCountries()  // Метод получения всех стран из репозитория
    {
        return _countryRepository.GetCountries(); // Отработка по запросу сервиса метода получения всех стран из репозитория
    }

    public void InsertCountry(CreateCountryDTO dto) // Метод создания новой страны в репозитории
    {
        _countryRepository.Insert(dto);  // Отработка по запросу сервиса метода вставки новой страны из репозитория
    }

    public void UpdateCountry(UpdateCountryDTO dto)  //  Метод обновления страны из репозитория
    {
        _countryRepository.Update(dto); // Отработка по запросу сервиса метода обноаления информации о стране из репозитория
    }

    public void DeleteCountry(int id)  // Метод удаления страны из репозитория
    {
        _countryRepository.Delete(id);  // Отработка по запросу сервиса метода удаления страны из репозитория
    }
}