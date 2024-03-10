using AutoMapper;
using Domain.Classes.DTOs.UserDTOs;
using Domain.Classes.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Classes.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IUserEntitiesValidationService _validator;
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IJwtService jwtService, IUserEntitiesValidationService validator, ILoggerService loggerService, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _validator = validator;
            _loggerService = loggerService;
            _mapper = mapper;
        }
        public async Task<Jwt?> AuthorizationAsync(UserAuthorizeDto user, CancellationToken cancellationToken = default)
        {
            var foundUser = await _userRepository.FindByEmailAsync(user.Email, cancellationToken);

            if (foundUser == null)
            {
                _loggerService.LogInfo($"User with email - {user.Email}, is not exist!");
                return null;
            }

            var isPasswordCorrect = await _userRepository.CheckPasswordAsync(foundUser, user.Password, cancellationToken);

            if (!isPasswordCorrect)
            {
                _loggerService.LogInfo($"User with email - {user.Email}, entered incorrect password!");
                return null;
            }

            return _jwtService.CreateJwtToken();
        }

        public async Task<Result> RegistrationAsync(UserRegistrationDto user, CancellationToken cancellationToken = default)
        {
            var result = await _validator.UserRegistrationValidateAsync(user, cancellationToken);

            if (!result.IsSuccess)
            {
                _loggerService.LogInfo($"User entered incorrect data: {result.Message}");
                return result;
            }

            var identityUser = _mapper.Map<IdentityUser<int>>(user);

            var createIsSuccess = await _userRepository.CreateUserAsync(identityUser, user.Password);

            if (!createIsSuccess)
            {
                _loggerService.LogError($"An error occurred while creating a user!");
                return new Result { IsSuccess = false, StatusCode = 400, Message = "Entered incorrect data!" };
            }

            return new Result { IsSuccess = true, StatusCode = 201, Message = $"User with email - {user.Email} had been created!" };
        }
    }
}