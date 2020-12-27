using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Managers
{
    public interface IUserManager : IBaseManager<User>
    {
        List<User> GetAllActivatedUsers();

        void ActivateUser(string id);

        void DeactivateUser(string id);

        void UpdateLastLoginTime(string id);

        User ValidateUserInfo(string username, string password);
    }
}
