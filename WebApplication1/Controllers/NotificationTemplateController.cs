using WebApplication1.DTO.NotificationTemplateDTO; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using Service.NotificationTemplateService;  // Установка связи с сервисом шаблонов

namespace WebApplication1.Controllers;  // Контроллеры, передающие запрос в сервис шаблонов

[ApiController]
[Route("NotificationTemplates")] // Путь для запроса в Swagger
public class NotificationTemplatesController(INotificationTemplateService NotificationTemplateService) : Controller // Контроллеры, передающие запрос в сервис шаблонов
{
    [HttpGet]  // Тип автора
    public JsonResult GetNotificationTemplates()   // Запрос на получение данных обо всех шаблонов в БД
    {
        var notificationTemplates = NotificationTemplateService.GetNotificationTemplates(); // создание списка шаблонов на основе данных, полученных из сервиса
        return Json(notificationTemplates);  // Возвращение списка шаблоновв в файл Json
    }
    
    [Route("{id}")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetNotificationTemplate(int id)  // Запрос на получение информации об определенном шаблоне из БД
    {
        var notificationTemplate = NotificationTemplateService.GetNotificationTemplate(id);  // Нахождение автора через обращение в сервис шаблонов
        if(notificationTemplate == null) return NotFound("Шаблон не найден"); // Если такого шаблона не существует
        return Json(notificationTemplate); // Вывод информации об авторе
    }
    
    [Route("create")]  // Путь для запроса в Swagger
    [HttpPost]  // Тип запроса
    public JsonResult CreateNotificationTemplate(CreateNotificationTemplateDTO dto) // Запрос на создание шаблона в БД
    {
        NotificationTemplateService.InsertNotificationTemplate(dto); // Обращение к функции создания шаблона в сервисе авторов
        return Json("New Notification Template has been created");  // Уведомление пользователя о создании шаблона
    }
    
    [Route("update")] // Путь для запроса в Swagger
    [HttpPatch] // Тип запроса
    public JsonResult UpdateNotificationTemplate(UpdateNotificationTemplateDTO dto) // Запрос на обновление информации о шаблоне в БД
    {
        NotificationTemplateService.UpdateNotificationTemplate(dto);  // Обращение к функции обновления информации  об авторе в сервисе шаблонов
        return Json("Notification Template has been updated");
    }
    
    [Route("delete/{id}")] // Путь для запроса в Swagger
    [HttpDelete] // Тип запроса
    public JsonResult DeleteNotificationTemplate(int id)  // Запрос на удаление автора из БД
    {
        NotificationTemplateService.DeleteNotificationTemplate(id); // Обращение к функциии удаления шаблона в сервисе шаблонов
        return Json("Notification Template has been deleted");
    }
}