using Data;
using WebApplication1.DTO.CountryDTO; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO.CityDTO; // Вызов функционала EntityFramework

namespace Repository.CountryRepository; // Методы, логика и содержимое репозитория стран в БД

public class CountryRepository(ApplicationContext context) : ICountryRepository // Логика взаимодействий с репозиторием стран
{
    private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<Country> _countries = context.Set<Country>(); // Получение списка стран из БД
    
    public CountryDTO Get(int id) // Получение одной страны из БД
    {
        var country = _countries
            .Include(c => c.CitiesList) // Обращение к списку городов страны (Вывод списка через запрос)
            .SingleOrDefault(c => c.Id == id); // Нахождение страны по ее ID в общем списке
        
        if (country == null) return null; // Если страны не существует

        var Cities = new List<CityDTO>();
        foreach (var city in country.CitiesList)
        {
            Cities.Add(new CityDTO()
            {
                Id = city.Id,
                CityName = city.CityName,
                CityDescription = city.CityDescription
            });
        }
        return new CountryDTO  // Создание и вывод объекта длч передачи данных найденной страны  
        
        {
            Id = country.Id,
            CountryName = country.CountryName,
            CountryDescription = country.CountryDescription,
            CitiesList = Cities,
        };  // Присваивание объекту для передачи данных всех свойств искомого автора
    }
    
    public CountryDTO GetByName(string CountryName) // Получение одной страны по имени из БД
    {
        var country = _countries
            .Include(c => c.CitiesList) // Обращение к списку городов страгы (Вывод списка через запрос)
            .SingleOrDefault(c => c.CountryName == CountryName); // Нахождение автора по его ID в общем списке
        
        if (country == null) return null; // Если страны не существует

        var Cities = new List<CityDTO>();
        foreach (var city in country.CitiesList)
        {
            Cities.Add(new CityDTO()
            {
                Id = city.Id,
                CityName = city.CityName,
                CityDescription = city.CityDescription
            });
        }
        return new CountryDTO  // Создание и вывод объекта длч передачи данных найденной страны
            
        {
            Id = country.Id,
            CountryName = country.CountryName,
            CountryDescription = country.CountryDescription,
            CitiesList = Cities,
        };  // Присваивание объекту для передачи данных всех свойств искомой страны
    }
    
    
    
    public List<CountryDTO> GetCountries()  // Получение всех стран из БД
    {
        var countries = _countries.ToList(); // Создание общего списка стран, содержащихся в БД
        List<CountryDTO> lcountries = new List<CountryDTO>(); // Создание списка объектов для транспортировки данных всех стран из БД
        foreach (var country in countries) //  Циклическое заполнение объектов для транспортировки
        {
            lcountries.Add(new CountryDTO
            {
                Id = country.Id,
                CountryName = country.CountryName,
                CountryDescription = country.CountryDescription
                
            }); // Заполнение объектов для транспортировки
        }
        
        
        return lcountries; // Вывод списка стран пользователю
    }


    public void Insert(CreateCountryDTO dto)  // Вставка новой страны через объект для транспортировки в БД
    {
        Country country = new Country // Создание новой страны в БД
        {
            CountryName = dto.CountryName,
            CountryDescription = dto.CountryDescription,
        }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
        _countries.Add(country); // Добавление новой страны в общий список стран в БД
        context.SaveChanges(); // Сохранение изменений, внесенных в БД
    }

    public void Update(UpdateCountryDTO dto) // Обновление информации о какой-либо стране из БД
    {
        var country = _countries.SingleOrDefault(a => a.Id == dto.Id); // Нахождение искомой страны а в общем списке стран из БД
        if (country == null) return; // Если искомой страны не существует
        
        country.CountryName = dto.CountryName;
        country.CountryDescription = dto.CountryDescription;
        // Присваивание искомой стране свойств, введенных пользователем, через объект для трванспортировки

        _countries.Update(country); // Внесение изменений в общий список стран в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }
    
    public void Delete(int id) // Удаление страны ищ БД по указанному ID
    {
        var country = _countries.SingleOrDefault(a => a.Id == id);  // Нахождение указанной страны в общем списке стран из БД
        if (country == null) return; // Если искомого страны не существует
        _countries.Remove(country); // Удаление страны из общего списка стран в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }

    public void SaveChanges() // Сохранение внесенных изменений в БД
    {
        context.SaveChanges();  // Сохранение внесенных изменений в БД
    }
}