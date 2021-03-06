using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Xy.Pis.Domain.Mapping
{
    public class TmpWordDetailMap : EntityTypeConfiguration<TmpWordDetail>
    {
        public TmpWordDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.UseType)
                .HasMaxLength(50);

            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.F1)
                .HasMaxLength(100);

            this.Property(t => t.F2)
                .HasMaxLength(100);

            this.Property(t => t.F3)
                .HasMaxLength(100);

            this.Property(t => t.F4)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TmpWordDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UseType).HasColumnName("UseType");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.LsOpenType).HasColumnName("LsOpenType");
            this.Property(t => t.OperID).HasColumnName("OperID");
            this.Property(t => t.OperTime).HasColumnName("OperTime");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.OrderBy).HasColumnName("OrderBy");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.F1).HasColumnName("F1");
            this.Property(t => t.F2).HasColumnName("F2");
            this.Property(t => t.F3).HasColumnName("F3");
            this.Property(t => t.F4).HasColumnName("F4");

            // Relationships
            this.HasOptional(t => t.BsLocation)
                .WithMany(t => t.TmpWordDetails)
                .HasForeignKey(d => d.LocationId);
            this.HasOptional(t => t.BsUser)
                .WithMany(t => t.TmpWordDetails)
                .HasForeignKey(d => d.OperID);

        }
    }
}
