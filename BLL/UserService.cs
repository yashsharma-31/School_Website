using School.Api.DMOs;
using School.Api.DTOs;
using School.Api.Interfaces;

namespace School.Api.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var usr = await _userRepository.GetByIdAsync(id);
            if (usr == null)
                return null;
            return new UserDto
            {
                FullName = usr.Name,
                Email = usr.Email
            };
        }
    }
}
