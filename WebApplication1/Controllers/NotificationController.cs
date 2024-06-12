using WebApplication1.DTO.NotificationDTO; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using Service.NotificationService;  // Установка связи с сервисом уведомление

namespace WebApplication1.Controllers;  // Контроллеры, передающие запрос в сервис уведомлений

[ApiController]
[Route("Notifications")] // Путь для запроса в Swagger
public class NotificationController(INotificationService NotificationService) : Controller // Контроллеры, передающие запрос в сервис уведомлений
{
    [HttpGet]  // Тип запроса
    public JsonResult GetNotifications()   // Запрос на получение данных обо всех уведомлениях в БД
    {
        var notifications = NotificationService.GetNotifications(); // создание списка уведомленийв на основе данных, полученных из сервиса
        return Json(notifications);  // Возвращение списка уведомлений в файл Json
    }
    
    [Route("NotificationsByCity")] // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public JsonResult GetNotificationsByCity(string CitySearch)   // Запрос на получение данных обо всех уведомлениях города в БД
    {
        var notifications = NotificationService.GetNotificationsByCity(CitySearch); // создание списка уведомлений на основе данных, полученных из сервиса
        return Json(notifications);  // Возвращение списка уведомлений в файл Json
    }
    
    [Route("NotificationsByCountry")] // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public JsonResult GetNotificationsByCountry(string CountrySearch)   // Запрос на получение данных обо всех уведомлениях страны в БД
    {
        var notifications = NotificationService.GetNotificationsByCountry(CountrySearch); // создание списка уведомлений на основе данных, полученных из сервиса
        return Json(notifications);  // Возвращение списка уведомлений в файл Json
    }
    
    [Route("NotificationsByHotel")] // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public JsonResult GetNotificationsByHotel(string HotelSearch)   // Запрос на получение данных обо всех уведомлениях отеля в БД
    {
        var notifications = NotificationService.GetNotificationsByHotel(HotelSearch); // создание списка уведомлений на основе данных, полученных из сервиса
        return Json(notifications);  // Возвращение списка уведомлений в файл Json
    }
    [Route("NotificationsByUser")] // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public JsonResult GetNotificationsByUser(string UserSearch)   // Запрос на получение данных обо всех уведомлениях пользователя в БД
    {
        var notifications = NotificationService.GetNotificationsByUser(UserSearch); // создание списка уведомлений на основе данных, полученных из сервиса
        return Json(notifications);  // Возвращение списка уведомлений в файл Json
    }
    [Route("NotificationsByRoom")]
    [HttpGet]  // Тип запроса
    public JsonResult GetNotificationsByRoom(string RoomSearch)   // Запрос на получение данных обо всех уведомлениях комнаты в БД
    {
        var notifications = NotificationService.GetNotificationsByRoom(RoomSearch); // создание списка уведомлениях на основе данных, полученных из сервиса
        return Json(notifications);  // Возвращение списка уведомлениях в файл Json
    }
    
    [Route("{id}")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetNotification(long id)  // Запрос на получение информации об определенном уведомлении из БД
    {
        var notification = NotificationService.GetNotification(id);  // Нахождение уведомления через обращение в сервис авторов
        if(notification == null) return NotFound("Уведомленине не найдено"); // Если такого уведомления не существует
        return Json(notification); // Вывод информации об уведомлении
    }
    
    [Route("create")]  // Путь для запроса в Swagger
    [HttpPost]  // Тип запроса
    public JsonResult CreateNotification(CreateNotificationDTO dto) // Запрос на создание уведомления в БД
    {
        NotificationService.InsertNotification(dto); // Обращение к функции создания уведомления в сервисе уведомлений
        return Json("New Notification has been created");  // Уведомление пользователя о создании уведомления
    }
    
    [Route("update")] // Путь для запроса в Swagger
    [HttpPatch] // Тип запроса
    public JsonResult UpdateNotification(UpdateNotificationDTO dto) // Запрос на обновление информации об уведомлении в БД
    {
        NotificationService.UpdateNotification(dto);  // Обращение к функции обновления информации  об уведомлении в сервисе уведомления
        return Json("Notification has been updated");
    }
    
    [Route("delete/{id}")] // Путь для запроса в Swagger
    [HttpDelete] // Тип запроса
    public JsonResult DeleteNotification(long id)  // Запрос на удаление уведомлений из БД
    {
        NotificationService.DeleteNotification(id); // Обращение к функциии удаления уведомления в сервисе уведомлений
        return Json("Notification has been deleted");
    }
}