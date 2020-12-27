using CommandPrompterServer.Helpers;
using CommandPrompterServer.Managers;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public class UserServiceImpl : IUserService
    {
        private IUserManager _userManager { get; set; }

        public void ActivateUser(string id)
        {
            _userManager.ActivateUser(id);
        }

        public User AddNewUser(User user)
        {
            return _userManager.AddNewEntity(user);
        }

        public void DeactivateUser(string id)
        {
            _userManager.DeactivateUser(id);
        }

        public User DeleteUser(string id)
        {
            return _userManager.DeleteEntity(id);
        }

        public List<User> GetAllActivatedUsers()
        {
            return _userManager.GetAllActivatedUsers();
        }

        public List<User> GetAllUsers()
        {
            return _userManager.GetAllEntities();
        }

        public void UpdateLastLoginTime(string id)
        {
            _userManager.UpdateLastLoginTime(id);
        }

        public User UpdateUser(User user)
        {
            return _userManager.UpdateEntity(user);
        }

        public User ValidateUser(string username, string password)
        {
            var user = _userManager.ValidateUserInfo(username, password);
            if(user != null)
                _userManager.UpdateLastLoginTime(user.Id);
            return user;
        }

    }
}
