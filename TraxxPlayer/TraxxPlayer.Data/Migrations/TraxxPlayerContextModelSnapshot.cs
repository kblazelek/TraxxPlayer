using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TraxxPlayer.Data;

namespace TraxxPlayer.Data.Migrations
{
    [DbContext(typeof(TraxxPlayerContext))]
    partial class TraxxPlayerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("TraxxPlayer.Data.Models.Like", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("TrackID");

                    b.Property<int>("UserID");

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("TraxxPlayer.Data.Models.Log", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Message");

                    b.Property<int>("MessageType");

                    b.Property<string>("Source");

                    b.Property<int?>("UserID");

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("TraxxPlayer.Data.Models.Playlist", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Name");

                    b.Property<int>("UserID");

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("TraxxPlayer.Data.Models.PlaylistTrack", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlaylistID");

                    b.Property<int>("TrackID");

                    b.Property<int>("TrackOrder");

                    b.HasKey("id");

                    b.HasIndex("PlaylistID");

                    b.ToTable("PlaylistTracks");
                });

            modelBuilder.Entity("TraxxPlayer.Data.Models.TrackHistory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("TrackID");

                    b.Property<int>("UserID");

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("TracksHistory");
                });

            modelBuilder.Entity("TraxxPlayer.Data.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("isDefault");

                    b.Property<string>("username");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TraxxPlayer.Data.Models.Like", b =>
                {
                    b.HasOne("TraxxPlayer.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TraxxPlayer.Data.Models.Log", b =>
                {
                    b.HasOne("TraxxPlayer.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("TraxxPlayer.Data.Models.Playlist", b =>
                {
                    b.HasOne("TraxxPlayer.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TraxxPlayer.Data.Models.PlaylistTrack", b =>
                {
                    b.HasOne("TraxxPlayer.Data.Models.Playlist", "Playlist")
                        .WithMany()
                        .HasForeignKey("PlaylistID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TraxxPlayer.Data.Models.TrackHistory", b =>
                {
                    b.HasOne("TraxxPlayer.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
