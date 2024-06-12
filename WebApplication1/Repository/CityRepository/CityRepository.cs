using Data;
using WebApplication1.DTO.CityDTO; // Установка связи с объектами для транспортировки
using WebApplication1.DTO.HotelDTO;
using Microsoft.EntityFrameworkCore;  // Вызов функционала EntityFramework

namespace Repository.CityRepository; // Методы, логика и содержимое репозитория городов в БД

public class CityRepository(ApplicationContext context) : ICityRepository // Логика взаимодействий с репозиторием городов
{
    private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<City> _cities = context.Set<City>(); // Получение списка городов из БД

    public CityDTO Get(int id) // Получение одного города из БД
    {
        var city = _cities.Include(city => city.HotelsList).SingleOrDefault(city => city.Id == id); // Нахождение города по его ID в общем списке
        if (city == null) return null; // Если города не существует

        var hotels = new List<HotelDTO>();
        foreach (var hotel in city.HotelsList)
        {
            hotels.Add(new HotelDTO()
            {
                Id = hotel.Id,
                HotelName = hotel.HotelName,
                HotelDescription = hotel.HotelDescription
            });
        }
        return new CityDTO  // Создание и вывод объекта длч передачи данных найденного города 
        
        {
            Id = city.Id,
            CityName = city.CityName,
            CityDescription = city.CityDescription,
            HotelsList = hotels,
        };  // Присваивание объекту для передачи данных всех свойств искомого города
    }
        
    public CityDTO GetByName(string CityName) // Получение одного городa по имени из БД
    {
        var city = _cities.Include(city => city.HotelsList).SingleOrDefault(city => city.CityName == CityName); // Нахождение городаа по его имени в общем списке
        if (city == null) return null; // Если города не существует

        var hotels = new List<HotelDTO>();
        foreach (var hotel in city.HotelsList)
        {
            hotels.Add(new HotelDTO()
            {
                Id = hotel.Id,
                HotelName = hotel.HotelName,
                HotelDescription = hotel.HotelDescription
            }); // Заполнение списка отелей в данном городе
        }
        return new CityDTO  // Создание и вывод объекта длч передачи данных найденного города  
        
        {
            Id = city.Id,
            CityName = city.CityName,
            CityDescription = city.CityDescription,
            HotelsList = hotels,
        };  // Присваивание объекту для передачи данных всех свойств искомого города
    }
    
    public List<CityDTO> GetCities()  // Получение всех городов из БД
    {
        var cities = _cities.ToList(); // Создание общего списка городов, содержащихся в БД
        List<CityDTO> lcities = new List<CityDTO>(); // Создание списка объектов для транспортировки данных всех городов из БД

        foreach (var city in cities) //  Циклическое заполнение объектов для транспортировки
        {
            lcities.Add(new CityDTO
            {
                Id = city.Id,
                CityName = city.CityName,
                CountryId = city.CountryId,
                CityDescription = city.CityDescription
            }); // Заполнение объектов для транспортировки
        }
        return lcities; // Вывод списка городов пользователю
    }


    public void Insert(CreateCityDTO dto)  // Вставка нового города через объект для транспортировки в БД
    {
        City city = new City // Создание нового города в БД
        {   CountryId = dto.CountryId,
            CityName = dto.CityName,
            CityDescription = dto.CityDescription,
        }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
        _cities.Add(city); // Добавление нового автора в общий список городов в БД
        context.SaveChanges(); // Сохранение изменений, внесенных в БД
    }

    public void Update(UpdateCityDTO dto) // Обновление информации о каком-либо авторе из БД
    {
        var city = _cities.SingleOrDefault(a => a.Id == dto.Id); // Нахождение искомого города в общем списке городов из БД
        if (city == null) return; // Если искомого города не существует
        city.CountryId = dto.CountryId;
        city.CityName = dto.CityName;
        city.CityDescription = dto.CityDescription;
        // Присваивание искомому городу свойств, введенных пользователем, через объект для трванспортировки

        _cities.Update(city); // Внесение изменений в общий список городов в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }
    
    public void Delete(int id) // Удаление автора ищ БД по указанному ID
    {
        var city = _cities.SingleOrDefault(a => a.Id == id);  // Нахождение указанного автора в общем списке городов из БД
        if (city == null) return; // Если искомого городов не существует
        _cities.Remove(city); // Удаление города из общего списка городов в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }

    public void SaveChanges() // Сохранение внесенных изменений в БД
    {
        context.SaveChanges();  // Сохранение внесенных изменений в БД
    }
}