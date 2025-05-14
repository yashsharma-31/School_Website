using School.Api.DMOs;
using School.Api.DTOs;

namespace School.Api.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(RequestDto request);
        Task<UserDto?> RegisterAsync(User request);
    }
}