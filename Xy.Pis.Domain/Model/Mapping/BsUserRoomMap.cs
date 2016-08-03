using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Xy.Pis.Domain.Mapping
{
    public class BsUserRoomMap : EntityTypeConfiguration<BsUserRoom>
    {
        public BsUserRoomMap()
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
            this.ToTable("BsUserRoom");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OperId).HasColumnName("OperId");
            this.Property(t => t.RoomId).HasColumnName("RoomId");
            this.Property(t => t.F1).HasColumnName("F1");
            this.Property(t => t.F2).HasColumnName("F2");
            this.Property(t => t.F3).HasColumnName("F3");
            this.Property(t => t.F4).HasColumnName("F4");
            this.Property(t => t.IconIndex).HasColumnName("IconIndex");

            // Relationships
            this.HasRequired(t => t.BsRoom)
                .WithMany(t => t.BsUserRooms)
                .HasForeignKey(d => d.RoomId);
            this.HasRequired(t => t.BsUser)
                .WithMany(t => t.BsUserRooms)
                .HasForeignKey(d => d.OperId);

        }
    }
}
