using WebApplication1.DTO.FormProblemDTO; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc;  // Вызов функционала ASPNet для создания проблем
using Service.FormProblemService;  // Установка связи с сервисом проблем

namespace WebApplication1.Controllers;  // Контроллеры, передающие запрос в сервис проблем

[ApiController]
[Route("FormProblems")] // Путь для запроса в Swagger
public class FormProblemController(IFormProblemService FormProblemService) : Controller // Контроллеры, передающие запрос в сервис проблем
{
    [HttpGet]  // Тип автора
    public JsonResult GetFormProblems()   // Запрос на получение данных обо всех проблемах в БД
    {
        var formproblems = FormProblemService.GetFormProblems(); // создание списка проблем на основе данных, полученных из сервиса проблем
        return Json(formproblems);  // Возвращение списка проблем в файл Json
    }
    
    [Route("{id}")]  // Путь для запроса в Swagger
    [HttpGet]  // Тип запроса
    public IActionResult GetFormProblem(int id)  // Запрос на получение информации об определенной проблеме из БД
    {
        var formproblem = FormProblemService.GetFormProblem(id);  // Нахождение проблем через обращение в сервис авторов
        if(formproblem == null) return NotFound("Проблема не найден"); // Если такой проблемы не существует
        return Json(formproblem); // Вывод информации об проблеме
    }
    
    [Route("create")]  // Путь для запроса в Swagger
    [HttpPost]  // Тип запроса
    public JsonResult CreateFormProblem(CreateFormProblemDTO dto) // Запрос на создание проблемы в БД
    {
        FormProblemService.InsertFormProblem(dto); // Обращение к функции создания проблемы в сервисе проблем
        return Json("New Problem has been created");  // Уведомление проблем о создании проблем
    }
    
    [Route("update")] // Путь для запроса в Swagger
    [HttpPatch] // Тип запроса
    public JsonResult UpdateAuthor(UpdateFormProblemDTO dto) // Запрос на обновление информации о проблеме в БД
    {
        FormProblemService.UpdateFormProblem(dto);  // Обращение к функции обновления информации  о проблеме в сервисе авторов
        return Json("Problem has been updated");
    }
    
    [Route("delete/{id}")] // Путь для запроса в Swagger
    [HttpDelete] // Тип запроса
    public JsonResult DeleteFormProblem(int id)  // Запрос на удаление проблемы из БД
    {
        FormProblemService.DeleteFormProblem(id); // Обращение к функциии удаления проблемы в сервисе проблем
        return Json("Problem has been deleted");
    }
}