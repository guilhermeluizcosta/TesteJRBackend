using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
namespace apiToDo.Models
{
    public class LoginView
    {      
        [Required]
        [SwaggerSchema(Description ="Usar: admin")]
        public string Username { get; set; }
        [Required]
        [SwaggerSchema(Description ="Usar:1234")]
        public string Password { get; set; }
    }
}
