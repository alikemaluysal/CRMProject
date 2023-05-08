using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Domain.Entities;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<OfferStatus> OfferStatus { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<RequestStatus> RequestStatus { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
