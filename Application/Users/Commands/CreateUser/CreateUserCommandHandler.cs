using Application.Dtos;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand, Result<UserDto>>
    {
        private readonly IUserRepository _repository = repository;

        public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.UserExists(request.User.UserName))
                return Result<UserDto>.Failure("Username already exists in database.");

            var user = new User
            {
                UserName = request.User.UserName,
                Password = request.User.Password,
            };

            await _repository.AddAsync(user);

            return Result<UserDto>.Success(request.User);
        }
    }
}
