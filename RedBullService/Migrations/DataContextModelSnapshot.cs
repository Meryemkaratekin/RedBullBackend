﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedbullService.Data;

#nullable disable

namespace RedBullService.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RedbullService.Models.Atleths", b =>
                {
                    b.Property<int>("atlet_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("atlet_id"), 1L, 1);

                    b.Property<string>("adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("kategori_id")
                        .HasColumnType("int");

                    b.Property<string>("resim_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("atlet_id");

                    b.ToTable("Atleths");
                });

            modelBuilder.Entity("RedbullService.Models.Basket", b =>
                {
                    b.Property<int>("urunId")
                        .HasColumnType("int");

                    b.Property<int?>("BasketurunId")
                        .HasColumnType("int");

                    b.Property<int>("kullaniciId")
                        .HasColumnType("int");

                    b.Property<int>("tutar")
                        .HasColumnType("int");

                    b.HasKey("urunId");

                    b.HasIndex("BasketurunId");

                    b.HasIndex("kullaniciId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("RedbullService.Models.Categories", b =>
                {
                    b.Property<int>("urunId")
                        .HasColumnType("int");

                    b.Property<int>("kategoriId")
                        .HasColumnType("int");

                    b.HasKey("urunId", "kategoriId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RedBullService.Models.Products", b =>
                {
                    b.Property<int>("urunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("urunId"), 1L, 1);

                    b.Property<int?>("BasketurunId")
                        .HasColumnType("int");

                    b.Property<string>("aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resimUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("urunAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("urunId");

                    b.HasIndex("BasketurunId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RedbullService.Models.User", b =>
                {
                    b.Property<int>("kullanici_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("kullanici_id"), 1L, 1);

                    b.Property<int?>("BasketurunId")
                        .HasColumnType("int");

                    b.Property<string>("kullanici_adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("kullanici_id");

                    b.HasIndex("BasketurunId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RedbullService.Models.Basket", b =>
                {
                    b.HasOne("RedbullService.Models.Basket", null)
                        .WithMany("baskets")
                        .HasForeignKey("BasketurunId");

                    b.HasOne("RedbullService.Models.User", "User")
                        .WithMany("baskets")
                        .HasForeignKey("kullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedBullService.Models.Products", "Product")
                        .WithMany("Baskets")
                        .HasForeignKey("urunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RedbullService.Models.Categories", b =>
                {
                    b.HasOne("RedBullService.Models.Products", "Product")
                        .WithMany("Categories")
                        .HasForeignKey("urunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RedBullService.Models.Products", b =>
                {
                    b.HasOne("RedbullService.Models.Basket", null)
                        .WithMany("Products")
                        .HasForeignKey("BasketurunId");
                });

            modelBuilder.Entity("RedbullService.Models.User", b =>
                {
                    b.HasOne("RedbullService.Models.Basket", null)
                        .WithMany("users")
                        .HasForeignKey("BasketurunId");
                });

            modelBuilder.Entity("RedbullService.Models.Basket", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("baskets");

                    b.Navigation("users");
                });

            modelBuilder.Entity("RedBullService.Models.Products", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("RedbullService.Models.User", b =>
                {
                    b.Navigation("baskets");
                });
#pragma warning restore 612, 618
        }
    }
}
