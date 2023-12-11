using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace backend.DataModels
{
    public class Dbcontext:DbContext
    {
        public DbSet<User> Users{get; set;}
        public DbSet<Longread> longreads{get;set;}
        public DbSet<Commment> commments{get; set;}

        public Dbcontext(DbContextOptionsBuilder optionsBuilder):base(){
            
        }
    }
}