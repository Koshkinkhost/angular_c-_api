using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using mvc_for_angular.models;
using System.Linq;
namespace nginx_project.models
{
    public class AppContext : DbContext
    {
       public DbSet<mvc_for_angular.models.User> users { get; set; }
      
        public void DeleteDatabase()
        {
            Database.EnsureDeleted();
        }
        public AppContext(DbContextOptions<AppContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Проверка, существует ли база данных
          

            // Проверка, есть ли уже данные
           

            // Если данных нет, добавляем начальные данные
            var users = new User[]
            {
                new User { Login = "user12", Password = "password1" },
                new User { Login = "user23", Password = "password2" }
            };
           
        }



    }
}
