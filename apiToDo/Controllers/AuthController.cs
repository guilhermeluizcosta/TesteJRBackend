using apiToDo.Models;
using apiToDo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace apitoDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public ActionResult Login([FromQuery] LoginView login)
        {
            if (login.Username == "admin" && login.Password == "1234")
            {
                var token = TokenService.GenerateToken(new apiToDo.Models.Tarefas());

                return Ok(token);
            }

            return BadRequest("Usuário ou senha inválidos");
        }
    }



}

