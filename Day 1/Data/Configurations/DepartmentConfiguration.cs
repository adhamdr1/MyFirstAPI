namespace Day_1.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.Name)
                .HasColumnName("DepartmentName")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Loc)
                .HasColumnName("Location")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.ToTable("Departments");
        }
    }
}
