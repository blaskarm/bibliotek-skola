using Application.Users.Queries.Login.Helpers;
using Infrastructure.Data;
using MediatR;

namespace Application.Users.Queries.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly FakeDatabase _database;
        private readonly TokenHelper _tokenHelper;

        public LoginUserQueryHandler(FakeDatabase database, TokenHelper tokenHelper)
        {
            _database = database;
            _tokenHelper = tokenHelper;
        }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = _database.Users.FirstOrDefault(user => user.UserName == request.user.UserName &&
                                                      user.Password == request.user.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            string token = _tokenHelper.GenerateJwtToken(user);

            return Task.FromResult(token);
        }
    }
}
