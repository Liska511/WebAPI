using WebApplication1.DTO.NotificationTypeDTO; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using Service.NotificationTypeService;  // Установка связи с сервисом типов

namespace WebApplication1.Controllers;  // Контроллеры, передающие запрос в сервис типов

[ApiController]
[Route("NotificationTypes")] // Путь для запроса в Swagger
public class NotificationTypesController(INotificationTypeService NotificationTypeService) : Controller // Контроллеры, передающие запрос в сервис типов
{
    [HttpGet]  // Тип автора
    public JsonResult GetNotificationTypes()   // Запрос на получение данных обо всех типах в БД
    {
        var notificationTypes = NotificationTypeService.GetNotificationTypes(); // создание списка типов на основе данных, полученных из сервиса
        return Json(notificationTypes);  // Возвращение списка типов в файл Json
    }
    
    [Route("{id}")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetNotificationType(int id)  // Запрос на получение информации об определенном типн из БД
    {
        var notificationType = NotificationTypeService.GetNotificationType(id);  // Нахождение типа через обращение в сервис авторов
        if(notificationType == null) return NotFound("Тип уведомления не найден"); // Если такого типа не существует
        return Json(notificationType); // Вывод информации о типе
    }
    
    [Route("create")]  // Путь для запроса в Swagger
    [HttpPost]  // Тип запроса
    public JsonResult CreateNotificationTemplate(CreateNotificationTypeDTO dto) // Запрос на создание типа в БД
    {
        NotificationTypeService.InsertNotificationType(dto); // Обращение к функции создания типа в сервисе типов
        return Json("New Notification Type has been created");  // Уведомление пользователя о создании типа
    }
    
    [Route("update")] // Путь для запроса в Swagger
    [HttpPatch] // Тип запроса
    public JsonResult UpdateNotificationTemplate(UpdateNotificationTypeDTO dto) // Запрос на обновление информации о типе в БД
    {
        NotificationTypeService.UpdateNotificationType(dto);  // Обращение к функции обновления информации  о типе в сервисе типав
        return Json("Notification Type has been updated");
    }
    
    [Route("delete/{id}")] // Путь для запроса в Swagger
    [HttpDelete] // Тип запроса
    public JsonResult DeleteNotificationTemplate(int id)  // Запрос на удаление типа из БД
    {
        NotificationTypeService.DeleteNotificationType(id); // Обращение к функциии удаления типа в сервисе типов
        return Json("Notification Type has been deleted");
    }
}