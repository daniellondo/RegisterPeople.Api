namespace Data.EntityConfigurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class EmailConfigurations : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(e => new { e.EmailId });
            builder.Property(p => p.EmailId).ValueGeneratedOnAdd();
            builder.Property(e => e.PersonId).IsRequired();
            builder.Property(e => e.EmailAddress).IsRequired();
        }
    }
}
