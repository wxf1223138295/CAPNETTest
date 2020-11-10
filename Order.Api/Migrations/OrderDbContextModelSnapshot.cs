﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Order.Api.OrderDb;

namespace Order.Api.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Order.Api.Domain.Buyer", b =>
                {
                    b.Property<int>("BuyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("BuyId");

                    b.ToTable("Buyer");
                });

            modelBuilder.Entity("Order.Api.Domain.MainOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BuyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OrderName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderSumAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("PaymentDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PaymentState")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("MainOrder");
                });

            modelBuilder.Entity("Order.Api.Domain.OrderItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("MainOrderOrderId")
                        .HasColumnType("int");

                    b.Property<string>("OrderItemName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ItemId");

                    b.HasIndex("MainOrderOrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Order.Api.Domain.PaymentMethod", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<string>("CardHolderName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CardNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SecurityNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.HasIndex("BuyerId");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("Order.Api.Domain.MainOrder", b =>
                {
                    b.OwnsOne("Order.Api.Domain.Address", "Address", b1 =>
                        {
                            b1.Property<int>("MainOrderOrderId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("Country")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("State")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("Street")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.HasKey("MainOrderOrderId");

                            b1.ToTable("MainOrder");

                            b1.WithOwner()
                                .HasForeignKey("MainOrderOrderId");
                        });
                });

            modelBuilder.Entity("Order.Api.Domain.OrderItem", b =>
                {
                    b.HasOne("Order.Api.Domain.MainOrder", null)
                        .WithMany("Items")
                        .HasForeignKey("MainOrderOrderId");
                });

            modelBuilder.Entity("Order.Api.Domain.PaymentMethod", b =>
                {
                    b.HasOne("Order.Api.Domain.Buyer", null)
                        .WithMany("PaymentMethods")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
