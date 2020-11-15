using HangmanAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.DbContexts
{
    public class AppIndentityDbContext : IdentityDbContext<User>
    {
        public AppIndentityDbContext(DbContextOptions<AppIndentityDbContext> options)
            : base(options)
        {
        }
        public DbSet<Score> Scores { get; set; }

        
    }
}
