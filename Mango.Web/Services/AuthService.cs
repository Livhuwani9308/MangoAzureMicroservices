using Mango.Web.Models;
using Mango.Web.Services.IService;
using Mango.Web.Utilities;

namespace Mango.Web.Services
{
    public class AuthService(IBaseService _baseService) : IAuthService
    {
        public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = $"{SD.AuthAPIBase}/api/auth/AssignRole",
                Data = registrationRequestDto
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = $"{SD.AuthAPIBase}/api/auth/login",
                Data = loginRequestDto
            }, withBearer: false);
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = $"{SD.AuthAPIBase}/api/auth/register",
                Data = registrationRequestDto
            }, withBearer: false);
        }
    }
}
