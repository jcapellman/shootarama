using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using shootarama.DB;

namespace shootarama.UWP.Migrations
{
    [DbContext(typeof(DBManager))]
    partial class DBManagerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("shootarama.DB.Tables.Games", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("LastSaveDate");

                    b.Property<DateTime>("Modified");

                    b.HasKey("ID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("shootarama.DB.Tables.LocationNames", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("LocationNames");
                });

            modelBuilder.Entity("shootarama.DB.Tables.PlayerNames", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("Modified");

                    b.HasKey("ID");

                    b.ToTable("PlayerNames");
                });

            modelBuilder.Entity("shootarama.DB.Tables.Players", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("Age");

                    b.Property<int>("Clutch");

                    b.Property<DateTime>("Created");

                    b.Property<int>("Defense");

                    b.Property<int>("Experience");

                    b.Property<string>("FirstName");

                    b.Property<int>("GameID");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("Offense");

                    b.Property<int>("Salary");

                    b.Property<int>("TeamID");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("shootarama.DB.Tables.TeamNames", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("TeamNames");
                });

            modelBuilder.Entity("shootarama.DB.Tables.Teams", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created");

                    b.Property<int>("GameID");

                    b.Property<string>("Location");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Teams");
                });
        }
    }
}
