namespace Day_1.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.FullName)
                .HasColumnName("FullName")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Address)
                .HasColumnName("Address")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(a => a.age)
                .HasColumnName("Age")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(a => a.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(a => a.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Students");
        }
    }
}
