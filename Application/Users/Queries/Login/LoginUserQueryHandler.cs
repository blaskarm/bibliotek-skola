using Application.Interfaces;
using Application.Users.Queries.Login.Helpers;
using MediatR;

namespace Application.Users.Queries.Login
{
    public class LoginUserQueryHandler(TokenHelper tokenHelper, IUserRepository repository) : IRequestHandler<LoginUserQuery, string>
    {
        private readonly TokenHelper _tokenHelper = tokenHelper;
        private readonly IUserRepository _repository = repository;

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repository.LoginUser(request.User.UserName, request.User.Password);

                string token = _tokenHelper.GenerateJwtToken(user);

                return token;
            }
            catch (UnauthorizedAccessException e)
            {
                return e.Message;
            }
        }
    }
}
