namespace Data
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    public interface IPeopleContext : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        public DbSet<People> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
