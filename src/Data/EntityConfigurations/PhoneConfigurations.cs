namespace Data.EntityConfigurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class PhoneConfigurations : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(e => new { e.PhoneId });
            builder.Property(p => p.PhoneId).ValueGeneratedOnAdd();
            builder.Property(e => e.PersonId).IsRequired();
            builder.Property(e => e.PhoneNumber).IsRequired();
        }
    }
}
