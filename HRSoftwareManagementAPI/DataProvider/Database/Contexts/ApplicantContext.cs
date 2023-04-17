using DataProvider.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataProvider.Database.Contexts;

public class ApplicantContext : DbContext
{
    public ApplicantContext(DbContextOptions<ApplicantContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetSection("DatabaseConfiguration:ConnectionString").Value;
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicantModel>()
            .ToTable("Applicant")
            .HasOne(a => a.Company)
            .WithMany(c => c.Applicants);
    }

    public DbSet<ApplicantModel> ApplicantsDbSet => Set<ApplicantModel>();
}