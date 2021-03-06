using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Xy.Pis.Domain.Mapping
{
    public class CkLabResultMap : EntityTypeConfiguration<CkLabResult>
    {
        public CkLabResultMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.LastResult)
                .HasMaxLength(100);

            this.Property(t => t.Result)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Unit)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Memo)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.F1)
                .HasMaxLength(100);

            this.Property(t => t.F2)
                .HasMaxLength(100);

            this.Property(t => t.F3)
                .HasMaxLength(100);

            this.Property(t => t.F4)
                .HasMaxLength(100);

            this.Property(t => t.TextRange)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("CkLabResult");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.LabId).HasColumnName("LabId");
            this.Property(t => t.TestId).HasColumnName("TestId");
            this.Property(t => t.LastResult).HasColumnName("LastResult");
            this.Property(t => t.Result).HasColumnName("Result");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.LsRefFlag).HasColumnName("LsRefFlag");
            this.Property(t => t.IsPanic).HasColumnName("IsPanic");
            this.Property(t => t.IsDalta).HasColumnName("IsDalta");
            this.Property(t => t.DalAbsolute).HasColumnName("DalAbsolute");
            this.Property(t => t.DalPercent).HasColumnName("DalPercent");
            this.Property(t => t.LowValue).HasColumnName("LowValue");
            this.Property(t => t.HighValue).HasColumnName("HighValue");
            this.Property(t => t.PanicLow).HasColumnName("PanicLow");
            this.Property(t => t.PanicHigh).HasColumnName("PanicHigh");
            this.Property(t => t.IsPass).HasColumnName("IsPass");
            this.Property(t => t.IsReport).HasColumnName("IsReport");
            this.Property(t => t.Memo).HasColumnName("Memo");
            this.Property(t => t.OperTime).HasColumnName("OperTime");
            this.Property(t => t.OperId).HasColumnName("OperId");
            this.Property(t => t.IsPrint).HasColumnName("IsPrint");
            this.Property(t => t.PrintTime).HasColumnName("PrintTime");
            this.Property(t => t.PrintOperId).HasColumnName("PrintOperId");
            this.Property(t => t.F1).HasColumnName("F1");
            this.Property(t => t.F2).HasColumnName("F2");
            this.Property(t => t.F3).HasColumnName("F3");
            this.Property(t => t.F4).HasColumnName("F4");
            this.Property(t => t.TextRange).HasColumnName("TextRange");

            // Relationships
            this.HasOptional(t => t.BsUser)
                .WithMany(t => t.CkLabResults)
                .HasForeignKey(d => d.PrintOperId);
            this.HasRequired(t => t.CkLab)
                .WithMany(t => t.CkLabResults)
                .HasForeignKey(d => d.LabId);

        }
    }
}
