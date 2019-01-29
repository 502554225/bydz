﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bydz.Repositroy;

namespace bydz.Repositroy.Migrations
{
    [DbContext(typeof(context))]
    [Migration("20190129094103_table1")]
    partial class table1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("bydz.Models.Poker", b =>
                {
                    b.Property<string>("PokerId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Aggressivity");

                    b.Property<double>("Defenses");

                    b.Property<string>("PokerName")
                        .HasMaxLength(50);

                    b.Property<string>("action");

                    b.Property<int>("ascription");

                    b.Property<double>("crits");

                    b.Property<double>("evade");

                    b.Property<double>("hit");

                    b.Property<double>("indomitableness");

                    b.Property<int>("level");

                    b.Property<double>("life");

                    b.Property<int>("positionX");

                    b.Property<int>("positionY");

                    b.Property<int>("skill");

                    b.Property<int>("survival");

                    b.Property<double>("vigour");

                    b.HasKey("PokerId");

                    b.ToTable("Pokers");
                });

            modelBuilder.Entity("bydz.Repositroy.Models.array", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("PokerId");

                    b.Property<double>("Aggressivity");

                    b.Property<double>("Defenses");

                    b.Property<string>("PokerName")
                        .HasMaxLength(50);

                    b.Property<string>("action");

                    b.Property<int>("ascription");

                    b.Property<double>("crits");

                    b.Property<double>("evade");

                    b.Property<double>("hit");

                    b.Property<double>("indomitableness");

                    b.Property<int>("level");

                    b.Property<double>("life");

                    b.Property<int>("positionX");

                    b.Property<int>("positionY");

                    b.Property<int>("skill");

                    b.Property<int>("survival");

                    b.Property<double>("vigour");

                    b.HasKey("UserId", "PokerId");

                    b.ToTable("array");
                });

            modelBuilder.Entity("bydz.Repositroy.Models.myPoker", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("PokerId");

                    b.Property<double>("Aggressivity");

                    b.Property<double>("Defenses");

                    b.Property<string>("PokerName")
                        .HasMaxLength(50);

                    b.Property<string>("action");

                    b.Property<int>("ascription");

                    b.Property<double>("crits");

                    b.Property<double>("evade");

                    b.Property<double>("hit");

                    b.Property<double>("indomitableness");

                    b.Property<int>("level");

                    b.Property<double>("life");

                    b.Property<int>("positionX");

                    b.Property<int>("positionY");

                    b.Property<int>("skill");

                    b.Property<int>("survival");

                    b.Property<double>("vigour");

                    b.HasKey("UserId", "PokerId");

                    b.ToTable("myPokers");
                });
#pragma warning restore 612, 618
        }
    }
}
