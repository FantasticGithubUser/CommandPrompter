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
        private IConfiguration _configuration { get; set; }
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
        public CommandPrompterDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionString"], (builder) =>
            {
                builder.EnableRetryOnFailure();
            });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
