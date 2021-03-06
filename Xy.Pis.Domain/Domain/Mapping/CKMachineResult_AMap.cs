using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Xy.Pis.Domain.Mapping
{
    public class CKMachineResult_AMap : EntityTypeConfiguration<CKMachineResult_A>
    {
        public CKMachineResult_AMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OperDate, t.ID, t.LabID, t.SampleNum, t.TestDate, t.MachineID, t.TestTypeID });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LabID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SampleNum)
                .IsRequired()
                .HasMaxLength(14);

            this.Property(t => t.MachineID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TestTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("CKMachineResult_A");
            this.Property(t => t.OperDate).HasColumnName("OperDate");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.LabID).HasColumnName("LabID");
            this.Property(t => t.SampleNum).HasColumnName("SampleNum");
            this.Property(t => t.TestDate).HasColumnName("TestDate");
            this.Property(t => t.MachineID).HasColumnName("MachineID");
            this.Property(t => t.TestTypeID).HasColumnName("TestTypeID");
        }
    }
}
