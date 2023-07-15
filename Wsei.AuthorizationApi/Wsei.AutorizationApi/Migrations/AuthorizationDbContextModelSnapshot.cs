﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wsei.AutorizationApi.Contexts;

#nullable disable

namespace Wsei.AutorizationApi.Migrations
{
    [DbContext(typeof(AuthorizationDbContext))]
    partial class AuthorizationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Wsei.AutorizationApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAdmin = true,
                            PasswordHash = new byte[] { 136, 47, 51, 167, 227, 48, 160, 40, 148, 108, 21, 143, 104, 157, 211, 130, 40, 252, 145, 243, 212, 154, 199, 89, 206, 18, 31, 44, 36, 32, 134, 23, 104, 119, 89, 220, 184, 196, 139, 227, 129, 147, 244, 120, 168, 13, 119, 213, 218, 130, 161, 243, 111, 104, 204, 46, 68, 143, 92, 189, 253, 140, 220, 254 },
                            PasswordSalt = new byte[] { 83, 25, 162, 251, 95, 68, 29, 160, 42, 94, 109, 206, 170, 26, 106, 7, 222, 86, 74, 191, 167, 104, 239, 183, 73, 241, 186, 92, 114, 141, 249, 172, 127, 197, 65, 246, 103, 189, 199, 129, 41, 108, 50, 24, 140, 57, 99, 97, 216, 47, 31, 38, 1, 58, 94, 75, 205, 27, 93, 107, 197, 29, 116, 219, 157, 244, 248, 125, 25, 4, 155, 244, 190, 12, 23, 4, 78, 18, 41, 177, 79, 143, 147, 109, 66, 8, 112, 71, 102, 71, 12, 119, 178, 50, 210, 69, 83, 29, 24, 240, 146, 95, 75, 85, 105, 239, 160, 140, 98, 27, 78, 200, 214, 169, 82, 238, 204, 54, 189, 250, 155, 134, 70, 12, 156, 219, 34, 5 },
                            Username = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
