﻿// <auto-generated />
using System;
using CoronaNyScaper.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CoronaNyScaper.Migrations
{
    [DbContext(typeof(MetricDatabaseContext))]
    [Migration("20200325191718_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CoronaNyScaper.Model.NyDataEntity", b =>
                {
                    b.Property<DateTime>("last_updated")
                        .HasColumnName("last_updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("nassau")
                        .HasColumnName("nassau")
                        .HasColumnType("integer");

                    b.Property<DateTime>("newsday_last_updated")
                        .HasColumnName("newsday_last_updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("nyc")
                        .HasColumnName("nyc")
                        .HasColumnType("integer");

                    b.Property<int>("state")
                        .HasColumnName("state")
                        .HasColumnType("integer");

                    b.Property<int>("suffolk")
                        .HasColumnName("suffolk")
                        .HasColumnType("integer");

                    b.HasKey("last_updated");

                    b.ToTable("corona_ny");
                });
#pragma warning restore 612, 618
        }
    }
}
