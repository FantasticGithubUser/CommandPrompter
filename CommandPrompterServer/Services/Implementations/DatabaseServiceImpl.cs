using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Services.Interfaces;

namespace CommandPrompterServer.Services
{
    public class DatabaseServiceImpl : IDatabaseService
    {
        public void EnsureClearDatabase()
        {
            using (var context = new CommandPrompterDbContext())
            {
                context.Database.EnsureDeleted();
            }
        }

        public void EnsureCreateDatabase()
        {
            using(var context = new CommandPrompterDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
