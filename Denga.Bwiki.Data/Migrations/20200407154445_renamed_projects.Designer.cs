﻿// <auto-generated />
using System;
using Denga.Bwiki.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Denga.Bwiki.Data.Migrations
{
    [DbContext(typeof(BwikiContext))]
    [Migration("20200407154445_renamed_projects")]
    partial class renamed_projects
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Denga.Bwiki.Data.Entities.PageContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HtmlContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageMetaDataId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PageMetaDataId");

                    b.ToTable("PageContents");
                });

            modelBuilder.Entity("Denga.Bwiki.Data.Entities.PageMetaData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LatestVersionId")
                        .HasColumnType("int");

                    b.Property<string>("UrlTitle")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LatestVersionId");

                    b.HasIndex("UrlTitle")
                        .IsUnique()
                        .HasFilter("[UrlTitle] IS NOT NULL");

                    b.ToTable("PageMetaDatas");
                });

            modelBuilder.Entity("Denga.Bwiki.Data.Entities.PageContent", b =>
                {
                    b.HasOne("Denga.Bwiki.Data.Entities.PageMetaData", "MetaData")
                        .WithMany("Versions")
                        .HasForeignKey("PageMetaDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Denga.Bwiki.Data.Entities.PageMetaData", b =>
                {
                    b.HasOne("Denga.Bwiki.Data.Entities.PageContent", "LatestVersion")
                        .WithMany()
                        .HasForeignKey("LatestVersionId");
                });
#pragma warning restore 612, 618
        }
    }
}
