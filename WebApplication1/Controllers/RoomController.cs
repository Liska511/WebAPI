using WebApplication1.DTO.RoomDTO; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using Service.RoomService;  // Установка связи с сервисом комнат

namespace WebApplication1.Controllers;  // Контроллеры, передающие запрос в сервис комнат

[ApiController]
[Route("Rooms")] // Путь для запроса в Swagger
public class RoomController(IRoomService RoomService) : Controller // Контроллеры, передающие запрос в сервис авторов
{
    [HttpGet]  // Тип автора
    public JsonResult GetRooms()   // Запрос на получение данных обо всех комнатах в БД
    {
        var rooms = RoomService.GetRooms(); // создание списка комнат на основе данных, полученных из сервиса
        return Json(rooms);  // Возвращение списка комнат в файл Json
    }
    
    [Route("{id}")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetRoom(long id)  // Запрос на получение информации об определенной комнате из БД
    {
        var room = RoomService.GetRoom(id);  // Нахождение комнаты через обращение в сервис комнат
        if(room == null) return NotFound("Комната не найдена"); // Если такой комнаты не существует
        return Json(room); // Вывод информации о комнате
    }
    
    [Route("create")]  // Путь для запроса в Swagger
    [HttpPost]  // Тип запроса
    public JsonResult CreateNotificationTemplate(CreateRoomDTO dto) // Запрос на создание комнаты в БД
    {
        RoomService.InsertRoom(dto); // Обращение к функции создания комнаты в сервисе комнаты
        return Json("New Room has been created");  // Уведомление пользователя о создании комнаты
    }
    
    [Route("update")] // Путь для запроса в Swagger
    [HttpPatch] // Тип запроса
    public JsonResult UpdateRoom(UpdateRoomDTO dto) // Запрос на обновление информации о комнате в БД
    {
        RoomService.UpdateRoom(dto);  // Обращение к функции обновления информации  о комнате в сервисе комнат
        return Json("Room has been updated");
    }
    
    [Route("delete/{id}")] // Путь для запроса в Swagger
    [HttpDelete] // Тип запроса
    public JsonResult DeleteRoom(long id)  // Запрос на удаление комнаты из БД
    {
        RoomService.DeleteRoom(id); // Обращение к функциии удаления комнаты в сервисе комнат
        return Json("Room has been deleted");
    }
}