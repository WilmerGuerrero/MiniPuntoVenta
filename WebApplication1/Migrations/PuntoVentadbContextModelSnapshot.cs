﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Services;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(PuntoVentadbContext))]
    partial class PuntoVentadbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApplication1.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("WebApplication1.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("WebApplication1.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<int>("InventarioID")
                        .HasColumnType("int")
                        .HasColumnName("InventarioID");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre");

                    b.Property<int?>("PuntoVentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PuntoVentaId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("WebApplication1.Models.ProductoFacturado", b =>
                {
                    b.Property<int>("FacturaId")
                        .HasColumnType("int")
                        .HasColumnName("Facturaid");

                    b.Property<int>("productoId")
                        .HasColumnType("int")
                        .HasColumnName("Productoid");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("Clienteid");

                    b.HasKey("FacturaId", "productoId", "ClienteId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("productoId");

                    b.ToTable("procesoFactura");
                });

            modelBuilder.Entity("WebApplication1.Models.PuntoVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("Stock");

                    b.HasKey("Id");

                    b.ToTable("PuntoVenta");
                });

            modelBuilder.Entity("WebApplication1.Models.Producto", b =>
                {
                    b.HasOne("WebApplication1.Models.PuntoVenta", "PuntoVenta")
                        .WithMany("Productos")
                        .HasForeignKey("PuntoVentaId");

                    b.Navigation("PuntoVenta");
                });

            modelBuilder.Entity("WebApplication1.Models.ProductoFacturado", b =>
                {
                    b.HasOne("WebApplication1.Models.Cliente", "cliente")
                        .WithMany("facturacion")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Factura", "factura")
                        .WithMany("facturacion")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Producto", "producto")
                        .WithMany("facturacion")
                        .HasForeignKey("productoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("factura");

                    b.Navigation("producto");
                });

            modelBuilder.Entity("WebApplication1.Models.Cliente", b =>
                {
                    b.Navigation("facturacion");
                });

            modelBuilder.Entity("WebApplication1.Models.Factura", b =>
                {
                    b.Navigation("facturacion");
                });

            modelBuilder.Entity("WebApplication1.Models.Producto", b =>
                {
                    b.Navigation("facturacion");
                });

            modelBuilder.Entity("WebApplication1.Models.PuntoVenta", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
