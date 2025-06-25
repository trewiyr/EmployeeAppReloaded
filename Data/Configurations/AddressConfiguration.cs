using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(a=>a.Id);

            builder.Property(a => a.StreetNo)
               .IsRequired()
               .HasMaxLength(10);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(a => a.StreetName)
                .IsRequired()
                .HasMaxLength(30);

            //builder.Property(a => a.State)
                
            //    .HasMaxLength(30);

            builder.HasOne(a => a.Employee)
               .WithOne(e => e.Address)
               .HasForeignKey<Address>(a => a.EmployeeId) 
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
