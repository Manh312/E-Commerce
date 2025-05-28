using server.Entities;

namespace server.Helper
{
    public interface IJwtHelper
    {
        string GenerateJwtToken(User user);

    }
}
