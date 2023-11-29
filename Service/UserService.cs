using Repository.Interfaces;
using Service.DTOs;
using Service.DTOs.Responses;
using Service.Interfaces;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserResponse> CreateAsync(UserRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> UpdateAsync(UserRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}