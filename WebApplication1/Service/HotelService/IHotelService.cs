using WebApplication1.DTO.HotelDTO; // Установка связи с объектами для транспортировки

namespace Service.HotelService; // Интерфейс сервиса с описаним методов из него

public interface IHotelService // Интерфейс сервиса с описаним методов из него
{
    HotelDTO GetHotel(long id); // Описание метода получения отеля из репозитория 
    
    HotelDTO GetHotelByName(string HotelName); // Описание метода получения отеля по имени из репозитория 
    List<HotelDTO> GetHotels(); // Описание метода получения всех отелей из репозитория
    void InsertHotel(CreateHotelDTO dto);  // Описание метода вставки отеля в репозитория
    void UpdateHotel(UpdateHotelDTO dto);  // Описание метода обновления информации об отеле в репозитория
    void DeleteHotel(long id); // Описание метода  удаления отеля из репозитория по заданному пользователем ID
}