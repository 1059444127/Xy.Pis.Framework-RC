using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Xy.Pis.Domain.Mapping
{
    public class BsHouseMap : EntityTypeConfiguration<BsHouse>
    {
        public BsHouseMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.WbCode)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.PyCode)
                .IsRequired()
                .HasMaxLength(6);

            // Table & Column Mappings
            this.ToTable("BsHouse");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.WbCode).HasColumnName("WbCode");
            this.Property(t => t.PyCode).HasColumnName("PyCode");
            this.Property(t => t.OrderBy).HasColumnName("OrderBy");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IconIndex).HasColumnName("IconIndex");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.IsWz).HasColumnName("IsWz");
        }
    }
}
