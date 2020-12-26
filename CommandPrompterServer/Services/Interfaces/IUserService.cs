using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public interface IUserService : IBaseService
    {
        List<User> GetAllUsers();

        User AddNewUser(User user);
    }
}
