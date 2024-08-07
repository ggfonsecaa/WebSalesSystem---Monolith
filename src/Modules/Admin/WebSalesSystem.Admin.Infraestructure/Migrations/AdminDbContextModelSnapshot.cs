﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSalesSystem.Admin.Infraestructure.Data;

#nullable disable

namespace WebSalesSystem.Admin.Infraestructure.Migrations
{
    [DbContext(typeof(AdminDbContext))]
    partial class AdminDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebSalesSystem.Shared.Domain.Tenancy.Aggregates.SubTenantAggregate.SubTenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex("Name", "Email")
                        .IsUnique();

                    b.ToTable("SubTenants", (string)null);
                });

            modelBuilder.Entity("WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate.DbProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("DbProvider");
                });

            modelBuilder.Entity("WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("DbProviderId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<Guid>("Identifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("DbProviderId");

                    b.HasIndex("Name", "Email")
                        .IsUnique();

                    b.ToTable("Tenants", (string)null);
                });

            modelBuilder.Entity("WebSalesSystem.Shared.Domain.Tenancy.Aggregates.SubTenantAggregate.SubTenant", b =>
                {
                    b.HasOne("WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate.Tenant", "Tenant")
                        .WithMany("SubTenants")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate.Tenant", b =>
                {
                    b.HasOne("WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate.DbProvider", "DbProvider")
                        .WithMany()
                        .HasForeignKey("DbProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DbProvider");
                });

            modelBuilder.Entity("WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate.Tenant", b =>
                {
                    b.Navigation("SubTenants");
                });
#pragma warning restore 612, 618
        }
    }
}
