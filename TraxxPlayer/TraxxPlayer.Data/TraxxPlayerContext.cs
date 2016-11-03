using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraxxPlayer.Data.Models;

namespace TraxxPlayer.Data
{
    public class TraxxPlayerContext : DbContext
    {
        public DbSet<SoundCloudUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TraxxPlayer.db");
        }
    }
}
