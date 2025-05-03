using NSFASBudgetTracker.Core.Entities;

namespace NSFASBudgetTracker.Core.Interfaces;

public interface IUserRepository
{
  Task<AppUser> GetUserByUsernameAsync(string username);
    Task AddUserAsync(AppUser user);

}
