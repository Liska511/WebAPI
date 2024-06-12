using WebApplication1.DTO.HotelDTO;  // Установка связи с объектами для транспортировки
using Repository.HotelRepository; // Установка связи с репозиторием 

namespace Service.HotelService;  // Бизнес логика взаимодействия с репозиторием (а через него и с содержимым БД)

public class HotelService(IHotelRepository hotelRepository) : IHotelService
{
    private IHotelRepository _hotelRepository = hotelRepository; // создание "ссылки" для обращения в репозиторий из сервиса

    public HotelDTO GetHotel(long id) // Метод получения отеля из репозитория
    {
        return _hotelRepository.Get(id); // Отработка по запросу сервиса метода нахождения отеля из репозитория
    }
    public HotelDTO GetHotelByName(string HotelName) // Метод полукчения отеля из репозитория
    {
        return _hotelRepository.GetByName(HotelName); // Отработка по запросу сервиса метода нахождения отеля из репозитория
    }
    public List<HotelDTO> GetHotels()  // Метод получсения всех отелей из репозитория
    {
        return _hotelRepository.GetHotels(); // Отработка по запросу сервиса метода получения всех отелей из репозитория
    }

    public void InsertHotel(CreateHotelDTO dto) // Метод создания новой отеля в репозитории
    {
        _hotelRepository.Insert(dto);  // Отработка по запросу сервиса метода вставки нового отеля из репозитория
    }

    public void UpdateHotel(UpdateHotelDTO dto)  //  Метод обновления отеля из репозитория
    {
        _hotelRepository.Update(dto); // Отработка по запросу сервиса метода обноаления информации об отеле из репозитория
    }

    public void DeleteHotel(long id)  // Метод удаления отеля из репозитория
    {
        _hotelRepository.Delete(id);  // Отработка по запросу сервиса метода удаления отеля из репозитория
    }
}