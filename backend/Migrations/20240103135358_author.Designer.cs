﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.DataModels;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(Dbcontext))]
    [Migration("20240103135358_author")]
    partial class author
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend.DataModels.Commment", b =>
                {
                    b.Property<int>("Comment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("comment_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Comment_id"));

                    b.Property<int>("Autor_id")
                        .HasColumnType("integer");

                    b.Property<string>("Comment_text")
                        .HasColumnType("text")
                        .HasColumnName("comment_text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<int>("Longread_idcoment")
                        .HasColumnType("integer");

                    b.HasKey("Comment_id");

                    b.HasIndex("Autor_id");

                    b.HasIndex("Longread_idcoment");

                    b.ToTable("Commments");
                });

            modelBuilder.Entity("backend.DataModels.Longread", b =>
                {
                    b.Property<int>("Longread_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("longread_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Longread_id"));

                    b.Property<int>("Author_id")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<string>("Content_text")
                        .HasColumnType("text")
                        .HasColumnName("content_text");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Longread_id");

                    b.HasIndex("Author_id");

                    b.ToTable("Longreads");
                });

            modelBuilder.Entity("backend.DataModels.User", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("User_id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nickname");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("User_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backend.DataModels.Commment", b =>
                {
                    b.HasOne("backend.DataModels.User", "Author")
                        .WithMany()
                        .HasForeignKey("Autor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.DataModels.Longread", "Longreads")
                        .WithMany()
                        .HasForeignKey("Longread_idcoment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Longreads");
                });

            modelBuilder.Entity("backend.DataModels.Longread", b =>
                {
                    b.HasOne("backend.DataModels.User", "Author")
                        .WithMany()
                        .HasForeignKey("Author_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });
#pragma warning restore 612, 618
        }
    }
}
