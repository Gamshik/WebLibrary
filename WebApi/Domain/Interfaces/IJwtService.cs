using Domain.Classes.Entities;

namespace Domain.Interfaces
{
    public interface IJwtService
    {
        Jwt CreateJwtToken();
    }
}
