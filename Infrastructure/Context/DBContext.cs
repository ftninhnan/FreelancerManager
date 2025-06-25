using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Information;

namespace Infrastructure.Context;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    public DbSet<Freelancer> Freelancers => Set<Freelancer>();
    public DbSet<Skillset> Skillsets => Set<Skillset>();
    public DbSet<Hobby> Hobbies => Set<Hobby>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Freelancer>()
            .HasMany(f => f.Skillsets)
            .WithOne()
            .HasForeignKey(s => s.FreelancerID);

        modelBuilder.Entity<Freelancer>()
            .HasMany(f => f.Hobbies)
            .WithOne()
            .HasForeignKey(h => h.FreelancerID);
    }
}
