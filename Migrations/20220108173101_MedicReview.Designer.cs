// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetPet.Data;

namespace VetPet.Migrations
{
    [DbContext(typeof(VetPetContext))]
    [Migration("20220108173101_MedicReview")]
    partial class MedicReview
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VetPet.Models.MedicReview", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProgramareID")
                        .HasColumnType("int");

                    b.Property<int>("ReviewID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProgramareID");

                    b.HasIndex("ReviewID");

                    b.ToTable("MedicReview");
                });

            modelBuilder.Entity("VetPet.Models.Programare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_programarii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nume_doctor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume_insotitor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume_pacient")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Programare");
                });

            modelBuilder.Entity("VetPet.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nume_medic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reviewmedic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("VetPet.Models.MedicReview", b =>
                {
                    b.HasOne("VetPet.Models.Programare", "Programare")
                        .WithMany("MedicReviews")
                        .HasForeignKey("ProgramareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetPet.Models.Review", "Review")
                        .WithMany("MedicReviews")
                        .HasForeignKey("ReviewID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Programare");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("VetPet.Models.Programare", b =>
                {
                    b.Navigation("MedicReviews");
                });

            modelBuilder.Entity("VetPet.Models.Review", b =>
                {
                    b.Navigation("MedicReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
