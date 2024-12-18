using Application.Dtos;
using Application.Interfaces;
using Application.Utilities;
using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler(IUserRepository repository) : IRequestHandler<UpdateUserCommand, Result<UserDto>>
    {
        private readonly IUserRepository _repository = repository;

        public async Task<Result<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user is null)
                return Result<UserDto>.Failure("User not found.");

            if (string.IsNullOrEmpty(request.User.UserName) || string.IsNullOrEmpty(request.User.Password))
                return Result<UserDto>.Failure("Username or password cannot be empty.");

            if (await _repository.UserExists(request.User.UserName))
                return Result<UserDto>.Failure("Username already exists in database");

            user.UserName = request.User.UserName;
            user.Password = request.User.Password;

            await _repository.UpdateAsync(user);

            return Result<UserDto>.Success(request.User);
        }
    }
}
