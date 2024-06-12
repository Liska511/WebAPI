using WebApplication1.DTO.HotelDTO; // Связь с объектами для передачи данных извне в репозиторий

namespace Repository.HotelRepository; // Установка связи с самим репозиторием 

public interface IHotelRepository  // Интерфейс репозитория отелей, содержащий описание всех необходимых для реализации в нем методов
{
    HotelDTO Get(long id); // Описание метода для получение одного отеля из БД
    
    HotelDTO GetByName(string HotelName); // Описание метода для получение одного отеля по имени из БД
    List<HotelDTO> GetHotels(); // Описание метода для получение всех отелей из БД
    void Insert(CreateHotelDTO dto); // Описание метода вставки нового отеля в БД
    void Update(UpdateHotelDTO dto); // Описание метода обновления информации об отеле в БД
    void Delete(long id);  // Описание метода удаления ателя по указанному ID
    void SaveChanges();  // Описание метода сохранения изменений в БД
}