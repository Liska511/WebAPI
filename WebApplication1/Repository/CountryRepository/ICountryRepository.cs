using WebApplication1.DTO.CountryDTO; // Связь с объектами для передачи данных извне в репозиторий

namespace Repository.CountryRepository; // Установка связи с самим репозиторием 

public interface ICountryRepository  // Интерфейс репозитория книг, содержащий описание всех необходимых для реализации в нем методов
{
    CountryDTO Get(int id); // Описание метода для получение одной страны из БД
    
    CountryDTO GetByName(string CountryName); // Описание метода для получение одной страны по имени из БД
    List<CountryDTO> GetCountries(); // Описание метода для получение всех стран из БД
    void Insert(CreateCountryDTO dto); // Описание метода вставки новой страны в БД
    void Update(UpdateCountryDTO dto); // Описание метода обновления информации о стране в БД
    void Delete(int id);  // Описание метода удаления страны по указанному ID
    void SaveChanges();  // Описание метода сохранения изменений в БД
}