using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestWrapper.Entities.Concrete;

namespace RestWrapper.DataAccess.Concrete.EntityFramework.Configurations
{
    public class RequestEntityConfiguration : IEntityTypeConfiguration<RequestDAO>
    {
        public void Configure(EntityTypeBuilder<RequestDAO> builder)
        {
            builder.ToTable("Requests");

            builder.Property(p => p.CallId).HasColumnName("ParentId");
            builder.Property(p => p.InsertDate).HasColumnType("timestamp").IsRequired();
            builder.Property(p => p.Value).HasColumnType("clob").IsRequired();
            builder.HasOne(o => o.Call).WithMany(m => m.Requests).IsRequired();
        }
    }
}
