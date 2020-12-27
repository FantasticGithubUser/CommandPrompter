using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public interface IUserService : IBaseService
    {
        List<User> GetAllUsers();

        List<User> GetAllActivatedUsers();
        User AddNewUser(User user);

        User UpdateUser(User user);

        User DeleteUser(string id);

        User ValidateUser(string username, string password);

        void UpdateLastLoginTime(string id);

        void ActivateUser(string id);

        void DeactivateUser(string id);
    }
}
