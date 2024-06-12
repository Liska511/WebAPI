using WebApplication1.DTO.RoomDTO; // Связь с объектами для передачи данных извне в репозиторий

namespace Repository.RoomRepository; // Установка связи с самим репозиторием 

public interface IRoomRepository  // Интерфейс репозитория комнат, содержащий описание всех необходимых для реализации в нем методов
{
    RoomDTO Get(long id); // Описание метода для получение одной комнаты из БД
    List<RoomDTO> GetRooms(); // Описание метода для получение всех комнат из БД
    void Insert(CreateRoomDTO dto); // Описание метода вставки новой комнаты в БД
    void Update(UpdateRoomDTO dto); // Описание метода обновления информации о комнате в БД
    void Delete(long id);  // Описание метода удаления комнате по указанному ID
    void SaveChanges();  // Описание метода сохранения изменений в БД
}