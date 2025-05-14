using School.Api.DMOs;

namespace School.Api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
    }
}