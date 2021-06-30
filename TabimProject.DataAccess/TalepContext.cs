
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProject.Model;

namespace TabimProject.DataAccess
{
    public class TalepContext : DbContext
    {
        //public TalepContext() : base("name=TalepConnStr")
        //{
        //    var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        //}

        public TalepContext(DbContextOptions<TalepContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Talep> Taleps { get; set; }

       
    }
}
