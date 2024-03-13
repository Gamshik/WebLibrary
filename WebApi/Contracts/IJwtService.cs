using Entities;

namespace Contracts
{
    public interface IJwtService
    {
        Jwt? CreateJwtToken();
    }
}
