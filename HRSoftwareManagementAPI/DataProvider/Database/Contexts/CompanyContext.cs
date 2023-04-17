using DataProvider.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataProvider.Database.Contexts;

public class CompanyContext : DbContext
{
    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
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
        modelBuilder.Entity<CompanyModel>()
            .ToTable("Company")
            .HasMany<ApplicantModel>(c => c.Applicants)
            .WithOne(e => e.Company)
            .HasForeignKey(a => a.CompanyId)
            .HasPrincipalKey(c => c.Id);
    }

    public DbSet<CompanyModel> CompaniesDbSet => Set<CompanyModel>();
}