// <auto-generated>
// ReSharper disable CheckNamespace
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable NotAccessedVariable
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCast
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// ReSharper disable UsePatternMatching
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YodaClock.DataContext
{
    // Nap
    public class NapConfiguration : IEntityTypeConfiguration<Nap>
    {
        public void Configure(EntityTypeBuilder<Nap> builder)
        {
            builder.ToTable("Nap", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Nap").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.PlanId).HasColumnName(@"PlanId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Percentage).HasColumnName(@"Percentage").HasColumnType("decimal(18,2)").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Plan).WithMany(b => b.Naps).HasForeignKey(c => c.PlanId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Nap_Plan");
        }
    }

}
// </auto-generated>

