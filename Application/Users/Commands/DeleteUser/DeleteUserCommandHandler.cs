using Application.Dtos;
using Application.Interfaces;
using Application.Utilities;
using MediatR;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler(IUserRepository repository) : IRequestHandler<DeleteUserCommand, Result<UserDto>>
    {
        private readonly IUserRepository _repository = repository;

        public async Task<Result<UserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (!await _repository.DeleteAsync(request.Id))
                return Result<UserDto>.Failure("User not found.");

            return Result<UserDto>.Success();
        }
    }
}
