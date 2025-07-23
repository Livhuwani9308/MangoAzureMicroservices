
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ResponseDto res = new()
                {
                    IsSuccess = false,
                    Message = errorMessage
                };
                return BadRequest(res);
            }

            ResponseDto response = new()
            {
                IsSuccess = true,
                Message = "Successfully registered."
            };
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                ResponseDto res = new()
                {
                    IsSuccess = false,
                    Message = "Username or password is incorrect",
                };
                return BadRequest(res);
            }

            ResponseDto response = new()
            {
                IsSuccess = true,
                Message = "Successful login",
                Result = loginResponse
            };
            return Ok(response);
        }


        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                ResponseDto res = new()
                {
                    Message = "Error encountered",
                };
                return BadRequest(res);
            }

            ResponseDto response = new()
            {
                IsSuccess = true,
                Message = "Role assigned succesfully"
            };
            return Ok(response);
        }
    }
}