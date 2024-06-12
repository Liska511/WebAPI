using Data;
using WebApplication1.DTO.HotelDTO; // Установка связи с объектами для транспортировки
using WebApplication1.DTO.RoomDTO;
using Microsoft.EntityFrameworkCore;  // Вызов функционала EntityFramework

namespace Repository.HotelRepository; // Методы, логика и содержимое репозитория авторов в БД

public class HotelRepository(ApplicationContext context) : IHotelRepository // Логика взаимодействий с репозиторием отелей
{
    private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<Hotel> _hotels = context.Set<Hotel>(); // Получение списка отелей из БД

    public HotelDTO Get(long id) // Получение одного автора из БД
    {
        var hotel = _hotels.Include(hotel=>hotel.RoomsList).SingleOrDefault(f => f.Id == id); // Нахождение отеля по его ID в общем списке
        if (hotel == null) return null; // Если автора не существует
        
        var romms = new List<RoomDTO>();
        foreach (var room in hotel.RoomsList)
        {
            romms.Add(new RoomDTO()
            {
                Id = room.Id,
                RoomName = room.RoomName,
                RoomDescription = room.RoomDescription
            }); 
        } // Заполнение списка комнат отеля
        
        
        return new HotelDTO  // Создание и вывод объекта для передачи данных найденного отеля  
        
        {
            Id = hotel.Id,
            HotelName = hotel.HotelName,
            HotelDescription = hotel.HotelDescription,
            RoomsList = romms,
        };  // Присваивание объекту для передачи данных всех свойств искомого отеля
    }
    
    
    public HotelDTO GetByName(string HotelName) // Получение одного отеля по имени из БД
    {
        var hotel = _hotels.Include(hotel=>hotel.RoomsList).SingleOrDefault(f => f.HotelName == HotelName); // Нахождение отеля по его ID в общем списке
        if (hotel == null) return null; // Если отеля не существует
        
        var romms = new List<RoomDTO>();
        foreach (var room in hotel.RoomsList)
        {
            romms.Add(new RoomDTO()
            {
                Id = room.Id,
                RoomName = room.RoomName,
                RoomDescription = room.RoomDescription
            });
        } // Заполнение списка комнат отеля
        
        return new HotelDTO  // Создание и вывод объекта длч передачи данных найденного отеля  
        
        {
            Id = hotel.Id,
            HotelName = hotel.HotelName,
            HotelDescription = hotel.HotelDescription,
            RoomsList = romms,
        };  // Присваивание объекту для передачи данных всех свойств искомого отеля
    }
    
    
    public List<HotelDTO> GetHotels()  // Получение всех отелей из БД
    {
        var hotels = _hotels.ToList(); // Создание общего списка отелей, содержащихся в БД
        List<HotelDTO> lhotels = new List<HotelDTO>(); // Создание списка объектов для транспортировки данных всех отелей из БД

        foreach (var hotel in hotels) //  Циклическое заполнение объектов для транспортировки
        {
            lhotels.Add(new HotelDTO
            {
                Id = hotel.Id,
                CityId = hotel.CityId,
                HotelName = hotel.HotelName,
                HotelDescription = hotel.HotelDescription
            }); // Заполнение объектов для транспортировки
        }
        return lhotels; // Вывод списка отелей пользователю
    }


    public void Insert(CreateHotelDTO dto)  // Вставка нового отеля через объект для транспортировки в БД
    {
        Hotel hotel = new Hotel() // Создание нового отеля в БД
        {
            CityId = dto.CityId,
            HotelName = dto.HotelName,
            HotelDescription  = dto. HotelDescription 
        }; // Присваивание ему всех свойств, введенных пользователем из объекта для транспортировки
        _hotels.Add(hotel); // Добавление нового отеля в общий список отеля в БД
        context.SaveChanges(); // Сохранение изменений, внесенных в БД
    }

    public void Update(UpdateHotelDTO dto) // Обновление информации о каком-либо авторе из БД
    {
        var hotel = _hotels.SingleOrDefault(a => a.Id == dto.Id); // Нахождение искомого отеля в общем списке отелей из БД
        if (hotel == null) return; // Если искомого отеля не существует

        hotel.CityId = dto.CityId;
        hotel.HotelName = dto.HotelName;
        hotel.HotelDescription = dto.HotelDescription;
        // Присваивание искомому отелю свойств, введенных пользователем, через объект для трванспортировки

        _hotels.Update(hotel); // Внесение изменений в общий список отеля в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }
    
    public void Delete(long id) // Удаление отеля из БД по указанному ID
    {
        var hotel = _hotels.SingleOrDefault(a => a.Id == id);  // Нахождение указанного отеля в общем списке отелей из БД
        if (hotel == null) return; // Если искомого отеля не существует
        _hotels.Remove(hotel); // Удаление отеля из общего списка отеля в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }

    public void SaveChanges() // Сохранение внесенных изменений в БД
    {
        context.SaveChanges();  // Сохранение внесенных изменений в БД
    }
}