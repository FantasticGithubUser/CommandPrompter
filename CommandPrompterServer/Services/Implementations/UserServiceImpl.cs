using CommandPrompterServer.Helpers;
using CommandPrompterServer.Managers;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public class UserServiceImpl : IUserService
    {
        private IUserManager _userManager { get; set; }
        public User AddNewUser(User user)
        {
            return _userManager.AddNewEntity(user);
        }

        public List<User> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}
