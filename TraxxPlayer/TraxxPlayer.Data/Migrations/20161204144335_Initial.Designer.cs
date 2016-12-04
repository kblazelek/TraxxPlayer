using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TraxxPlayer.Data;

namespace TraxxPlayer.Data.Migrations
{
    [DbContext(typeof(TraxxPlayerContext))]
    [Migration("20161204144335_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

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

            modelBuilder.Entity("TraxxPlayer.Data.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("isDefault");

                    b.Property<string>("username");

                    b.HasKey("id");

                    b.ToTable("Users");
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
        }
    }
}
