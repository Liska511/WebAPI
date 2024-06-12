using WebApplication1.DTO.FormDTO; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания запросов
using Service.FormService;  // Установка связи с сервисом форм

namespace WebApplication1.Controllers;  // Контроллеры, передающие запрос в сервис форм

[ApiController]
[Route("Forms")] // Путь для запроса в Swagger
public class FormController(IFormService FormService) : Controller // Контроллеры, передающие запрос в сервис форм
{
    [HttpGet]  // Тип запроса
    public JsonResult GetForms()   // Запрос на получение данных обо всех формах в БД
    {
        var forms = FormService.GetForms(); // создание списка форм на основе данных, полученных из сервиса
        return Json(forms);  // Возвращение списка форм в файл Json
    }
    
    [Route("{id}")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetForm(long id)  // Запрос на получение информации об определенном форме из БД
    {
        var form = FormService.GetForm(id);  // Нахождение автора через обращение в сервис форм
        if(form == null) return NotFound("Форма обратной связи не найден"); // Если такой формы не существует
        return Json(form); // Вывод информации о форме
    }
    
    [Route("create")]  // Путь для запроса в Swagger
    [HttpPost]  // Тип запроса
    public JsonResult CreateForm(CreateFormDTO dto) // Запрос на создание формы в БД
    {
        FormService.InsertForm(dto); // Обращение к функции создания формы в сервисе форм
        return Json("New Form has been created");  // Уведомление пользователя о создании автора
    }
    
    [Route("update")] // Путь для запроса в Swagger
    [HttpPatch] // Тип запроса
    public JsonResult UpdateForm(UpdateFormDTO dto) // Запрос на обновление информации о форме в БД
    {
        FormService.UpdateForm(dto);  // Обращение к функции обновления информации  о форме в сервисе форм
        return Json("Form has been updated");
    }
    
    [Route("delete/{id}")] // Путь для запроса в Swagger
    [HttpDelete] // Тип запроса
    public JsonResult DeleteForm(long id)  // Запрос на удаление формы из БД
    {
        FormService.DeleteForm(id); // Обращение к функциии удаления автора в сервисе форм
        return Json("Form has been deleted");
    }
}