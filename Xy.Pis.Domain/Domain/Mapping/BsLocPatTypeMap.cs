using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Xy.Pis.Domain.Mapping
{
    public class BsLocPatTypeMap : EntityTypeConfiguration<BsLocPatType>
    {
        public BsLocPatTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.F1)
                .HasMaxLength(100);

            this.Property(t => t.F2)
                .HasMaxLength(100);

            this.Property(t => t.F3)
                .HasMaxLength(100);

            this.Property(t => t.F4)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("BsLocPatType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.PatTypeId).HasColumnName("PatTypeId");
            this.Property(t => t.F1).HasColumnName("F1");
            this.Property(t => t.F2).HasColumnName("F2");
            this.Property(t => t.F3).HasColumnName("F3");
            this.Property(t => t.F4).HasColumnName("F4");

            // Relationships
            this.HasRequired(t => t.BsLocation)
                .WithMany(t => t.BsLocPatTypes)
                .HasForeignKey(d => d.LocationId);
            this.HasRequired(t => t.BsPatType)
                .WithMany(t => t.BsLocPatTypes)
                .HasForeignKey(d => d.PatTypeId);

        }
    }
}
