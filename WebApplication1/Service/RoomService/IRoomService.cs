using WebApplication1.DTO.RoomDTO; // Установка связи с объектами для транспортировки

namespace Service.RoomService; // Интерфейс сервиса с описаним методов из него

public interface IRoomService // Интерфейс сервиса с описаним методов из него
{
    RoomDTO GetRoom(long id); // Описание метода получения комнаты из репозитория 
    List<RoomDTO> GetRooms(); // Описание метода получения всех комнат из репозитория
    void InsertRoom(CreateRoomDTO dto);  // Описание метода вставки комнаты в репозитория
    void UpdateRoom(UpdateRoomDTO dto);  // Описание метода обновления информации о комнате в репозитория
    void DeleteRoom(long id); // Описание метода  удаления комнаты из репозитория по заданному пользователем ID
}