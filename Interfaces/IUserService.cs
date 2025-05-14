using School.Api.DTOs;

namespace School.Api.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
    }
}