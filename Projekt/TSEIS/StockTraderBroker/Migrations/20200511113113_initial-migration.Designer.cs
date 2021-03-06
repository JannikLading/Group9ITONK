﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockTraderBroker.Database;

namespace StockTraderBroker.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200511113113_initial-migration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockTraderBroker.Models.StockTrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StockAmount")
                        .HasColumnType("int");

                    b.Property<int>("StockBuyerId")
                        .HasColumnType("int");

                    b.Property<double>("StockPrice")
                        .HasColumnType("float");

                    b.Property<int>("StockSellerId")
                        .HasColumnType("int");

                    b.Property<bool>("StockTransferComplete")
                        .HasColumnType("bit");

                    b.Property<double>("TaxAmount")
                        .HasColumnType("float");

                    b.Property<bool>("TransactionComplete")
                        .HasColumnType("bit");

                    b.Property<int>("TransferStockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StockTrades");
                });
#pragma warning restore 612, 618
        }
    }
}
