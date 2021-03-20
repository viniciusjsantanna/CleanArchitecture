using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CleanArchitecture.Infrastructure.Mapping
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("TB_COURSE");
            builder.HasKey(e => e.Key);
            builder.Property(e => e.Key)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.Type)
                .HasConversion<string>()
                .HasColumnName("TYPE");

            builder.OwnsOne(
                    e => e.Name,
                    e =>
                    {
                        e.Property(e => e.name)
                            .HasColumnType("varchar(100)")
                            .HasColumnName("NAME");
                    });

            builder.Property<DateTime>(e => e.CreatedAt)
                .HasColumnName("CREATED_AT");
        }
    }
}
