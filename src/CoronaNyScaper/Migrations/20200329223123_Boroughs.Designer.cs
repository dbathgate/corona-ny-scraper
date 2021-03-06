﻿// <auto-generated />
using System;
using CoronaNyScaper.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CoronaNyScaper.Migrations
{
    [DbContext(typeof(MetricDatabaseContext))]
    [Migration("20200329223123_Boroughs")]
    partial class Boroughs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CoronaNyScaper.Model.NyBoroughDeathsEntity", b =>
                {
                    b.Property<DateTime>("LastUpdated")
                        .HasColumnName("last_updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Bronx")
                        .HasColumnName("bronx")
                        .HasColumnType("integer");

                    b.Property<int>("Brooklyn")
                        .HasColumnName("brooklyn")
                        .HasColumnType("integer");

                    b.Property<int>("Manhattan")
                        .HasColumnName("manhattan")
                        .HasColumnType("integer");

                    b.Property<int>("Queens")
                        .HasColumnName("queens")
                        .HasColumnType("integer");

                    b.Property<int>("Staten")
                        .HasColumnName("staten")
                        .HasColumnType("integer");

                    b.HasKey("LastUpdated");

                    b.ToTable("corona_borough_deaths");
                });

            modelBuilder.Entity("CoronaNyScaper.Model.NyBoroughEntity", b =>
                {
                    b.Property<DateTime>("LastUpdated")
                        .HasColumnName("last_updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Bronx")
                        .HasColumnName("bronx")
                        .HasColumnType("integer");

                    b.Property<int>("Brooklyn")
                        .HasColumnName("brooklyn")
                        .HasColumnType("integer");

                    b.Property<int>("Manhattan")
                        .HasColumnName("manhattan")
                        .HasColumnType("integer");

                    b.Property<int>("Queens")
                        .HasColumnName("queens")
                        .HasColumnType("integer");

                    b.Property<int>("Staten")
                        .HasColumnName("staten")
                        .HasColumnType("integer");

                    b.HasKey("LastUpdated");

                    b.ToTable("corona_boroughs");
                });

            modelBuilder.Entity("CoronaNyScaper.Model.NyBoroughHospitalizations", b =>
                {
                    b.Property<DateTime>("LastUpdated")
                        .HasColumnName("last_updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Bronx")
                        .HasColumnName("bronx")
                        .HasColumnType("integer");

                    b.Property<int>("Brooklyn")
                        .HasColumnName("brooklyn")
                        .HasColumnType("integer");

                    b.Property<int>("Manhattan")
                        .HasColumnName("manhattan")
                        .HasColumnType("integer");

                    b.Property<int>("Queens")
                        .HasColumnName("queens")
                        .HasColumnType("integer");

                    b.Property<int>("Staten")
                        .HasColumnName("staten")
                        .HasColumnType("integer");

                    b.HasKey("LastUpdated");

                    b.ToTable("corona_borough_hospitalizations");
                });

            modelBuilder.Entity("CoronaNyScaper.Model.NyDataEntity", b =>
                {
                    b.Property<DateTime>("LastUpdated")
                        .HasColumnName("last_updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Nassau")
                        .HasColumnName("nassau")
                        .HasColumnType("integer");

                    b.Property<int>("Nyc")
                        .HasColumnName("nyc")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnName("state")
                        .HasColumnType("integer");

                    b.Property<int>("Suffolk")
                        .HasColumnName("suffolk")
                        .HasColumnType("integer");

                    b.HasKey("LastUpdated");

                    b.ToTable("corona_ny");
                });
#pragma warning restore 612, 618
        }
    }
}
