using CommandPrompterServer.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Models.Dao
{
    /// <summary>
    /// The db context
    /// </summary>
    public class CommandPrompterDbContext : DbContext
    {
        #region DbSets
        /// <summary>
        /// Users table
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Plateform> Plateforms { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<CommandParameter> CommandParameters { get; set; }
        public DbSet<CommandChain> CommandChains { get; set; }
        public DbSet<ChainedCommand> ChainedCommands { get; set; }
        public DbSet<ChainedCommandParameter> ChainedCommandParameters { get; set; }

        #endregion DbSets
        public CommandPrompterDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GlobalConfiguration.ConnectionString, (builder) =>
            {
                builder.EnableRetryOnFailure();
            });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            /*
             Unfortunately EF Core currently (latest at this time v2.0) does not expose a good way to control the conventions globally.
             The default EF Core 2.0 convention is to use DeleteBehavior.Cascade for required and DeleteBehavior.ClientSetNull for optional relationships. What I can suggest as workaround is a typical metadata model loop at the end of the OnModelCreating override. In this case, locating all the already discovered relationships and modifying them accordingly:
             */
            var cascadeFKs = builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
