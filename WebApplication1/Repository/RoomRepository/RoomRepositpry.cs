using Data;
using WebApplication1.DTO.RoomDTO; // Установка связи с объектами для транспортировки
using Microsoft.EntityFrameworkCore;  // Вызов функционала EntityFramework

namespace Repository.RoomRepository; // Методы, логика и содержимое репозитория комнат в БД

public class RoomRepository(ApplicationContext context) : IRoomRepository // Логика взаимодействий с репозиторием комнат
{
    private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<Room> _rooms = context.Set<Room>(); // Получение списка комнат из БД

    public RoomDTO Get(long id) // Получение одной комнаты из БД
    {
        var room = _rooms.SingleOrDefault(f => f.Id == id); // Нахождение комнаты по его ID в общем списке
        if (room == null) return null; // Если комнаты не существует
        return new RoomDTO  // Создание и вывод объекта длч передачи данных найденной комнаты  
        {
            Id = room.Id,
            HotelId  = room.HotelId,
            RoomName = room.RoomName,
            RoomDescription = room.RoomDescription
        };  // Присваивание объекту для передачи данных всех свойств искомой комнаты
    }
    
    public List<RoomDTO> GetRooms()  // Получение всех комнат из БД
    {
        var rooms = _rooms.ToList(); // Создание общего списка комнаты, содержащихся в БД
        List<RoomDTO> lrooms = new List<RoomDTO>(); // Создание списка объектов для транспортировки данных всех комнаты из БД

        foreach (var room in rooms) //  Циклическое заполнение объектов для транспортировки
        {
            lrooms.Add(new RoomDTO
            {
                Id = room.Id,
                HotelId  = room.HotelId,
                RoomName = room.RoomName,
                RoomDescription = room.RoomDescription,
            }); // Заполнение объектов для транспортировки
        }
        return lrooms; // Вывод списка комнаты пользователю
    }


    public void Insert(CreateRoomDTO dto)  // Вставка новой комнаты через объект для транспортировки в БД
    {
        Room room = new Room() // Создание новой комнаты в БД
        {
            HotelId  = dto.HotelId,
            RoomName = dto.RoomName,
            RoomDescription = dto.RoomDescription
        }; // Присваивание ей всех свойств, введенных пользователем из объекта для транспортировки
        _rooms.Add(room); // Добавление новой комнаты в общий список комнат в БД
        context.SaveChanges(); // Сохранение изменений, внесенных в БД
    }

    public void Update(UpdateRoomDTO dto) // Обновление информации о какой-либо комнате из БД
    {
        var room = _rooms.SingleOrDefault(a => a.Id == dto.Id); // Нахождение искомой комнаты в общем списке комнат из БД
        if (room == null) return; // Если искомой комнаты не существует
        
        room.HotelId = dto.HotelId;
        room.RoomName = dto.RoomName;
        room.RoomDescription = dto.RoomDescription;
        // Присваивание искомой комнате свойств, введенных пользователем, через объект для трванспортировки

        _rooms.Update(room); // Внесение изменений в общий список авторов в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }
    
    public void Delete(long id) // Удаление комнаты из БД по указанному ID
    {
        var room = _rooms.SingleOrDefault(a => a.Id == id);  // Нахождение указанной комнаты в общем списке комнат из БД
        if (room == null) return; // Если искомой комнаты не существует
        _rooms.Remove(room); // Удаление комнаты из общего списка комнат в БД
        context.SaveChanges(); // Сохранение внесенных изменений в БД
    }

    public void SaveChanges() // Сохранение внесенных изменений в БД
    {
        context.SaveChanges();  // Сохранение внесенных изменений в БД
    }
}