using WebApplication1.DTO.RoomDTO;  // Установка связи с объектами для транспортировки
using Repository.RoomRepository; // Установка связи с репозиторием 

namespace Service.RoomService;  // Бизнес логика взаимодействия с репозиторием (а через него и с содержимым БД)

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    private IRoomRepository _roomRepository = roomRepository; // создание "ссылки" для обращения в репозиторий из сервиса

    public RoomDTO GetRoom(long id) // Метод получения комнаты из репозитория
    {
        return _roomRepository.Get(id); // Отработка по запросу сервиса метода нахождения комнаты из репозитория
    }

    public List<RoomDTO> GetRooms()  // Метод получсения всех комнат из репозитория
    {
        return _roomRepository.GetRooms(); // Отработка по запросу сервиса метода получения всех комнат из репозитория
    }

    public void InsertRoom(CreateRoomDTO dto) // Метод создания новой комнаты в репозитории
    {
        _roomRepository.Insert(dto);  // Отработка по запросу сервиса метода вставки новой комнаты из репозитория
    }

    public void UpdateRoom(UpdateRoomDTO dto)  //  Метод обновления комнаты из репозитория
    {
        _roomRepository.Update(dto); // Отработка по запросу сервиса метода обноаления информации о комнаты из репозитория
    }

    public void DeleteRoom(long id)  // Метод удаления комнаты из репозитория
    {
        _roomRepository.Delete(id);  // Отработка по запросу сервиса метода удаления комнаты из репозитория
    }
}