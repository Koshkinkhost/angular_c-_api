using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_for_angular.models
{
    public 
        class User
    {
        [Key]
        public int Id { get; set; }

        [Column("Login")]
        public string Login { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
