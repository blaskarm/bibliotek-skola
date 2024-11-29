using Application.Interfaces;
using Application.Users.Queries.Login.Helpers;
using MediatR;

namespace Application.Users.Queries.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IFakeDatabase _database;
        private readonly TokenHelper _tokenHelper;

        public LoginUserQueryHandler(IFakeDatabase database, TokenHelper tokenHelper)
        {
            _database = database;
            _tokenHelper = tokenHelper;
        }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = _database.Users.FirstOrDefault(user => user.UserName == request.User.UserName &&
                                                      user.Password == request.User.Password) ??
                                                      throw new UnauthorizedAccessException("Invalid username or password");

            string token = _tokenHelper.GenerateJwtToken(user);

            return Task.FromResult(token);
        }
    }
}
