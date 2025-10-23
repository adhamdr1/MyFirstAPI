namespace Day_1.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.Name)
                .HasColumnName("CourseName")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(a => a.Name)
                .IsUnique();

            builder.Property(a => a.Duration)
                .HasColumnName("Duration")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.Description)
                .HasColumnName("Descraption")
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsRequired();


            builder.ToTable("Courses");
        }
    }
}
