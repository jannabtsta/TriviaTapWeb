﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TriviaTapWeb;

#nullable disable

namespace TriviaTapWeb.Migrations
{
    [DbContext(typeof(TriviaDBContext))]
    partial class TriviaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TriviaTapWeb.Models.Option", b =>
                {
                    b.Property<int>("OptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("OptionID"));

                    b.Property<string>("Options")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("OptionID");

                    b.HasIndex("QuestionID");

                    b.ToTable("tb_option");
                });

            modelBuilder.Entity("TriviaTapWeb.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("QuestionID"));

                    b.Property<string>("QuestionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QuizID")
                        .HasColumnType("int");

                    b.HasKey("QuestionID");

                    b.HasIndex("QuizID");

                    b.ToTable("tb_question");
                });

            modelBuilder.Entity("TriviaTapWeb.Models.Quiz", b =>
                {
                    b.Property<int>("QuizID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("QuizID"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("QuizID");

                    b.ToTable("tb_quiz");
                });

            modelBuilder.Entity("TriviaTapWeb.Models.Option", b =>
                {
                    b.HasOne("TriviaTapWeb.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TriviaTapWeb.Models.Question", b =>
                {
                    b.HasOne("TriviaTapWeb.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("TriviaTapWeb.Models.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("TriviaTapWeb.Models.Quiz", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
