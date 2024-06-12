using WebApplication1.DTO.CityDTO; // Связь с объектами для передачи данных извне в репозиторий

namespace Repository.CityRepository; // Установка связи с самим репозиторием 

public interface ICityRepository  // Интерфейс репозитория книг, содержащий описание всех необходимых для реализации в нем методов
{
    CityDTO Get(int id); // Описание метода для получение одного города из БД
    CityDTO GetByName(string CityName); // Описание метода для получение однго города из БД
    List<CityDTO> GetCities(); // Описание метода для получение всех городов из БД
    void Insert(CreateCityDTO dto); // Описание метода вставки нового города в БД
    void Update(UpdateCityDTO dto); // Описание метода обновления информации о городе в БД
    void Delete(int id);  // Описание метода удаления городп по указанному ID
    void SaveChanges();  // Описание метода сохранения изменений в БД
}