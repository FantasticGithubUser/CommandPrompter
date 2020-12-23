﻿using Microsoft.EntityFrameworkCore;
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
        protected IConfiguration _configuration { get; set; }

        public CommandPrompterDbContext()
        {
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
