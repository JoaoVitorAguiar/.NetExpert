using DevFreela.Core.Entities.Users;

namespace DevFreela.Core.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
}
