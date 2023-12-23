using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace backend.DataModels
{
    public class Dbcontext:DbContext
    {
        public DbSet<User> Users{get; set;}
        public DbSet<Longread> Longreads{get;set;}
        public DbSet<Commment> Commments{get; set;}

        public Dbcontext(DbContextOptions optionsBuilder)
            :base(optionsBuilder){
            
        }
    }
}