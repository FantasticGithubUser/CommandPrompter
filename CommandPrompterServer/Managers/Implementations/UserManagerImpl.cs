
using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;

namespace CommandPrompterServer.Managers
{
    public class UserManagerImpl : IUserManager
    {
        private CommandPrompterDbContext _context => DbContextHolder.Context;
        public User AddNewEntity(User entity)
        {
            _context.Users.Add(entity);
            return entity;
        }

        public User DeleteEntity(string id)
        {
            throw new System.NotImplementedException();
        }

        public User GetEneityByIdFilterOutDeleted(string id)
        {
            throw new System.NotImplementedException();
        }

        public User GetEntityById(string id)
        {
            throw new System.NotImplementedException();
        }

        public User UpdateEntity(User eneity)
        {
            throw new System.NotImplementedException();
        }
    }
}
