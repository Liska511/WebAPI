using WebApplication1.DTO.HotelDTO; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using Service.HotelService;  // Установка связи с сервисом отелей

namespace WebApplication1.Controllers;  // Контроллеры, передающие запрос в сервис отелях

[ApiController]
[Route("Hotels")] // Путь для запроса в Swagger
public class HotelController(IHotelService HotelService) : Controller // Контроллеры, передающие запрос в сервис отелей
{
    [HttpGet]  // Тип автора
    public JsonResult GetHotels()   // Запрос на получение данных обо всех авторов в БД
    {
        var hotels = HotelService.GetHotels(); // создание списка отелей на основе данных, полученных из сервиса
        return Json(hotels);  // Возвращение списка отелей в файл Json
    }
    
    [Route("{id}")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetHotel(long id)  // Запрос на получение информации об определенном авторе из БД
    {
        var hotel = HotelService.GetHotel(id);  // Нахождение отеля через обращение в сервис отелей
        if(hotel == null) return NotFound("Отель не найден"); // Если такого отеля не существует
        return Json(hotel); // Вывод информации об отеле
    }
    
    [Route("GetByName")] // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetHotelByName(string HotelName)  // Запрос на получение информации об определенном отеле из БД
    {
        var hotel = HotelService.GetHotelByName(HotelName);  // Нахождение отеля через обращение в сервис отелей
        if(hotel == null) return NotFound("Отель не найден"); // Если такого отеля не существует
        return Json(hotel); // Вывод информации об отеле
    }
    
    [Route("create")]  // Путь для запроса в Swagger
    [HttpPost]  // Тип запроса
    public JsonResult CreateFormProblem(CreateHotelDTO dto) // Запрос на создание отеля в БД
    {
        HotelService.InsertHotel(dto); // Обращение к функции создания отеля в сервисе отелей
        return Json("New Hotel has been created");  // Уведомление пользователя о создании отеля
    }
    
    [Route("update")] // Путь для запроса в Swagger
    [HttpPatch] // Тип запроса
    public JsonResult UpdateHotel(UpdateHotelDTO dto) // Запрос на обновление информации об отеле в БД
    {
        HotelService.UpdateHotel(dto);  // Обращение к функции обновления информации  об отелк в сервисе отелей
        return Json("Hotel has been updated");
    }
    
    [Route("delete/{id}")] // Путь для запроса в Swagger
    [HttpDelete] // Тип запроса
    public JsonResult DeleteHotel(long id)  // Запрос на удаление отеля из БД
    {
        HotelService.DeleteHotel(id); // Обращение к функциии удаления автора в сервисе отелей
        return Json("Hotel has been deleted");
    }
}