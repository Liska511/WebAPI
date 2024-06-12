using WebApplication1.DTO.CountryDTO; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using Service.CountryService;  // Установка связи с сервисом стран

namespace WebApplication1.Controllers;  // Контроллеры, передающие запрос в сервис стран

[ApiController]
[Route("Countries")] // Путь для запроса в Swagger
public class CountryController(ICountryService CountryService) : Controller // Контроллеры, передающие запрос в сервис стран
{
    [HttpGet]  // Тип страны
    public JsonResult GetCountries()   // Запрос на получение данных обо всех странах в БД
    {
        var countries = CountryService.GetCountries(); // создание списка стран на основе данных, полученных из сервиса
        return Json(countries);  // Возвращение списка стран в файл Json
    }
    
    [Route("{id}")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetCountry(int id)  // Запрос на получение информации об определенном стране из БД
    {
        var country = CountryService.GetCountry(id);  // Нахождение страны через обращение в сервис стран
        if(country == null) return NotFound("Страна не найден"); // Если такой страны не существует
        return Json(country); // Вывод информации о стране
    }
    
    [Route("GetByName")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetCountryByName(string CountryName)  // Запрос на получение информации об определенной стране из БД
    {
        var country = CountryService.GetCountryByName(CountryName);  // Нахождение страны через обращение в сервис стран
        if(country == null) return NotFound("Страна не найден"); // Если такой страны  не существует
        return Json(country); // Вывод информации о стране
    }
    
    [Route("create")]  // Путь для запроса в Swagger
    [HttpPost]  // Тип запроса
    public JsonResult CreateCountry(CreateCountryDTO dto) // Запрос на создание автора в БД
    {
        CountryService.InsertCountry(dto); // Обращение к функции создания страны в сервисе стран
        return Json("New Country has been created");  // Уведомление пользователя о создании страны
    }
    
    [Route("update")] // Путь для запроса в Swagger
    [HttpPatch] // Тип запроса
    public JsonResult UpdateCountry(UpdateCountryDTO dto) // Запрос на обновление информации об авторе в БД
    {
        CountryService.UpdateCountry(dto);  // Обращение к функции обновления информации  о стране в сервисе стран
        return Json("Country has been updated");
    }
    
    [Route("delete/{id}")] // Путь для запроса в Swagger
    [HttpDelete] // Тип запроса
    public JsonResult DeleteCountry(int id)  // Запрос на удаление страны из БД
    {
        CountryService.DeleteCountry(id); // Обращение к функциии удаления страны в сервисе стран
        return Json("Country has been deleted");
    }
}