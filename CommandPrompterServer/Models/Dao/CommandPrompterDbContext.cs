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

        /// <summary>
        /// Plateform Table
        /// </summary>
        public DbSet<Plateform> Plateforms { get; set; }

        /// <summary>
        /// Command Table
        /// </summary>
        public DbSet<Command> Commands { get; set; }

        /// <summary>
        /// CommandParameter Table
        /// </summary>
        public DbSet<CommandParameter> CommandParameters { get; set; }

        /// <summary>
        /// CommandChain Table
        /// </summary>
        public DbSet<CommandChain> CommandChains { get; set; }

        /// <summary>
        /// ChainedCommand Table
        /// </summary>
        public DbSet<ChainedCommand> ChainedCommands { get; set; }

        /// <summary>
        /// ChainedCommandParameter Table
        /// </summary>
        public DbSet<ChainedCommandParameter> ChainedCommandParameters { get; set; }

        #endregion DbSets
        /// <summary>
        /// Does nothing.
        /// </summary>
        public CommandPrompterDbContext()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GlobalConfiguration.ConnectionString, (builder) =>
            {
                builder.EnableRetryOnFailure();
            });

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
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

            base.OnModelCreating(builder);
        }
    }
}
