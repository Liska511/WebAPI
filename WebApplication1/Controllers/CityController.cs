using WebApplication1.DTO.CityDTO; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using Service.CityService;  // Установка связи с сервисом городов

namespace WebApplication1.Controllers;  // Контроллеры, передающие запрос в сервис городов

[ApiController]
[Route("Cities")] // Путь для запроса в Swagger
public class CityController(ICityService CityService) : Controller // Контроллеры, передающие запрос в сервис городов
{
    [HttpGet]  // Тип автора
    public JsonResult GetCities()   // Запрос на получение данных обо всех городах в БД
    {
        var cities = CityService.GetCities(); // создание списка городов на основе данных, полученных из сервиса
        return Json(cities);  // Возвращение списка городов в файл Json
    }
    
    [Route("{id}")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetCity(int id)  // Запрос на получение информации об определенном городе из БД
    {
        var city = CityService.GetCity(id);  // Нахождение города через обращение в сервис городов
        if(city == null) return NotFound("Город не найден"); // Если такого города не существует
        return Json(city); // Вывод информации о городе
    }
    
    
    [Route("GetByName")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetCityByName(string CityName)  // Запрос на получение информации об определенном городе из БД
    {
        var city = CityService.GetCityByName(CityName);  // Нахождение города через обращение в сервис городов
        if(city == null) return NotFound("Город не найден"); // Если такого города не существует
        return Json(city); // Вывод информации о городе
    }
    
    [Route("create")]  // Путь для запроса в Swagger
    [HttpPost]  // Тип запроса
    public JsonResult CreateCity(CreateCityDTO dto) // Запрос на создание города в БД
    {
        CityService.InsertCity(dto); // Обращение к функции создания города в сервисе городов
        return Json("New City has been created");  // Уведомление пользователя о создании города
    }
    
    
    
    
    
    [Route("update")] // Путь для запроса в Swagger
    [HttpPatch] // Тип запроса
    public JsonResult UpdateCity(UpdateCityDTO dto) // Запрос на обновление информации об городе в БД
    {
        CityService.UpdateCity(dto);  // Обращение к функции обновления информации  о городе в сервисе авторов
        return Json("City has been updated");
    }
    
    [Route("delete/{id}")] // Путь для запроса в Swagger
    [HttpDelete] // Тип запроса
    public JsonResult DeleteCity(int id)  // Запрос на удаление города из БД
    {
        CityService.DeleteCity(id); // Обращение к функциии удаления города в сервисе городов
        return Json("City has been deleted");
    }
}