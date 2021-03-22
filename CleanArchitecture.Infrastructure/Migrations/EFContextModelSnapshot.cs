﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(EFContext))]
    partial class EFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Course", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TYPE");

                    b.HasKey("Key");

                    b.ToTable("TB_COURSE");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Course", b =>
                {
                    b.OwnsOne("CleanArchitecture.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CourseKey")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("name")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("NAME");

                            b1.HasKey("CourseKey");

                            b1.ToTable("TB_COURSE");

                            b1.WithOwner()
                                .HasForeignKey("CourseKey");
                        });

                    b.Navigation("Name");
                });
#pragma warning restore 612, 618
        }
    }
}