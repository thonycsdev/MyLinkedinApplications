using AutoMapper;
using Domain.Entities;
using Repository.Interfaces;
using Service.DTOs;
using Service.DTOs.Responses;
using Service.Interfaces;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserResponse> CreateAsync(UserRequest entity)
        {
            var user = _mapper.Map<User>(entity);
            try
            {
                await _userRepository.Create(user);
                return _mapper.Map<UserResponse>(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _userRepository.Delete(id);
                return;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetValues();
                return _mapper.Map<IEnumerable<UserResponse>>(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);
                return _mapper.Map<UserResponse>(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserResponse> UpdateAsync(UserRequest entity, int id)
        {
            try
            {
                var userToUpdate = await _userRepository.GetById(id);
                userToUpdate!.Email = entity.Email;
                userToUpdate!.Name = entity.Name;
                await _userRepository.Update(userToUpdate);
                return _mapper.Map<UserResponse>(userToUpdate);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}