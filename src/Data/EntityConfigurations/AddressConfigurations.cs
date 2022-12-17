namespace Data.EntityConfigurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => new { e.AddressId });
            builder.Property(p => p.AddressId).ValueGeneratedOnAdd();
            builder.Property(e => e.PersonId).IsRequired();
            builder.Property(e => e.Description).IsRequired();
        }
    }
}
