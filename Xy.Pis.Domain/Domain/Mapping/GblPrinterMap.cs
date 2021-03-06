using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Xy.Pis.Domain.Mapping
{
    public class GblPrinterMap : EntityTypeConfiguration<GblPrinter>
    {
        public GblPrinterMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Hostname)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ReportName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PrinterName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.F1)
                .HasMaxLength(100);

            this.Property(t => t.F2)
                .HasMaxLength(100);

            this.Property(t => t.F3)
                .HasMaxLength(100);

            this.Property(t => t.F4)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("GblPrinter");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Hostname).HasColumnName("Hostname");
            this.Property(t => t.ReportName).HasColumnName("ReportName");
            this.Property(t => t.PrinterName).HasColumnName("PrinterName");
            this.Property(t => t.F1).HasColumnName("F1");
            this.Property(t => t.F2).HasColumnName("F2");
            this.Property(t => t.F3).HasColumnName("F3");
            this.Property(t => t.F4).HasColumnName("F4");
        }
    }
}
