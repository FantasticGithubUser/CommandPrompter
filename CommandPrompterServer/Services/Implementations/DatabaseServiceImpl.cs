using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CommandPrompterServer.Services
{
    public class DatabaseServiceImpl : IDatabaseService
    {
        private IConfiguration _configuration { get; set; }
        public void EnsureClearDatabase()
        {
            using (var context = new CommandPrompterDbContext(_configuration))
            {
                context.Database.EnsureDeleted();
            }
        }

        public void EnsureCreateDatabase()
        {
            using(var context = new CommandPrompterDbContext(_configuration))
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
