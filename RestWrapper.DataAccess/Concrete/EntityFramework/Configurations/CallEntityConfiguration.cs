using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestWrapper.Entities.Concrete;

namespace RestWrapper.DataAccess.Concrete.EntityFramework.Configurations
{
    public class CallEntityConfiguration : IEntityTypeConfiguration<CallDAO>
    {
        public void Configure(EntityTypeBuilder<CallDAO> builder)
        {
            builder.ToTable("Calls");

            builder.Property(p => p.InsertDate).HasColumnType("timestamp").IsRequired();
        }
    }
}
