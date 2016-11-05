using Microsoft.EntityFrameworkCore;
using EXP.Models;
namespace EXP.Infrastructure
{
    public class ExpenseDB : DbContext
    {
        public virtual DbSet<Usuario> Usuarios {get;set;}

       public ExpenseDB(DbContextOptions<ExpenseDB> options)
            : base(options)
        { }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
                modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Nome).IsRequired();
                entity.Property(x => x.EMail).IsRequired();
                entity.Property(x => x.Senha).IsRequired();
            });

         }
        
    }

}