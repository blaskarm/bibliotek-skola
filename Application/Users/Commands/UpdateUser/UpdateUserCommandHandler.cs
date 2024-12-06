using Application.Interfaces;
using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler(IUserRepository repository) : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _repository = repository;

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user is null)
                return false;

            if (string.IsNullOrEmpty(request.User.UserName) || string.IsNullOrEmpty(request.User.Password))
                return false;

            if (await _repository.UserExists(request.User.UserName))
                return false;

            user.UserName = request.User.UserName;
            user.Password = request.User.Password;

            await _repository.UpdateAsync(user);

            return true;
        }
    }
}
