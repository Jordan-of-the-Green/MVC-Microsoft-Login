using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Microsoft_Login.Models
{
    public class UserModel
    {
        [Key]
        public int id { get; set; }
        public string? UserName { get; internal set; }
    }
}

