using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nginx_project.models;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using mvc_for_angular.models;
namespace mvc_for_angular.Controllers
{
    public class UserController(nginx_project.models.AppContext db) : Controller
    {
       readonly nginx_project.models.AppContext db=db;
       
        // GET: UserController1
        public async Task<IActionResult> Index()
        {
            try
            {
                List<User> users = await db.users.ToListAsync();
                return Json(users);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Ошибка: {ex.Message}");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }
    }
}
