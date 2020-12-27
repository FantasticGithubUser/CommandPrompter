using CommandPrompterServer.Helpers;
using CommandPrompterServer.Managers;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;

namespace CommandPrompterServer.Services
{
    public class UserServiceImpl : BaseServiceImpl<User>, IUserService
    {
        private IUserManager _userManager { get; set; }

        public void ActivateUser(string id)
        {
            _userManager.ActivateUser(id);
        }

        public override User AddNewEntity(User entity)
        {
            return _userManager.AddNewEntity(entity);
        }

        public void DeactivateUser(string id)
        {
            _userManager.DeactivateUser(id);
        }

        public List<User> GetAllActivatedUsers()
        {
            return _userManager.GetAllActivatedUsers();
        }

        public void UpdateLastLoginTime(string id)
        {
            _userManager.UpdateLastLoginTime(id);
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
