using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public interface IUserService : IBaseService<User>
    {
        List<User> GetAllActivatedUsers();

        User ValidateUser(string username, string password);

        void UpdateLastLoginTime(string id);

        void ActivateUser(string id);

        void DeactivateUser(string id);
    }
}
