using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Xy.Pis.Domain.Mapping
{
    public class BsBaseMap : EntityTypeConfiguration<BsBase>
    {
        public BsBaseMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.Type, t.Code, t.Name, t.PyCode, t.WbCode, t.OrderBy, t.IsActive, t.IconIndex });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PyCode)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.WbCode)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.OrderBy)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.F1)
                .HasMaxLength(100);

            this.Property(t => t.F2)
                .HasMaxLength(100);

            this.Property(t => t.F3)
                .HasMaxLength(100);

            this.Property(t => t.F4)
                .HasMaxLength(100);

            this.Property(t => t.IconIndex)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("BsBase");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PyCode).HasColumnName("PyCode");
            this.Property(t => t.WbCode).HasColumnName("WbCode");
            this.Property(t => t.OrderBy).HasColumnName("OrderBy");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.F1).HasColumnName("F1");
            this.Property(t => t.F2).HasColumnName("F2");
            this.Property(t => t.F3).HasColumnName("F3");
            this.Property(t => t.F4).HasColumnName("F4");
            this.Property(t => t.IconIndex).HasColumnName("IconIndex");
        }
    }
}
