using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TraxxPlayer.Data;

namespace TraxxPlayer.Data.Migrations
{
    [DbContext(typeof(TraxxPlayerContext))]
    [Migration("20161105165325_AddIsDefaultField")]
    partial class AddIsDefaultField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509");

            modelBuilder.Entity("TraxxPlayer.Data.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("avatar_url");

                    b.Property<string>("city");

                    b.Property<string>("country");

                    b.Property<string>("description");

                    b.Property<string>("discogs_name");

                    b.Property<string>("first_name");

                    b.Property<int>("followers_count");

                    b.Property<int>("followings_count");

                    b.Property<string>("full_name");

                    b.Property<bool>("isDefault");

                    b.Property<string>("kind");

                    b.Property<string>("last_modified");

                    b.Property<string>("last_name");

                    b.Property<string>("myspace_name");

                    b.Property<bool>("online");

                    b.Property<string>("permalink");

                    b.Property<string>("permalink_url");

                    b.Property<string>("plan");

                    b.Property<int>("playlist_count");

                    b.Property<int>("public_favorites_count");

                    b.Property<int>("track_count");

                    b.Property<string>("uri");

                    b.Property<string>("username");

                    b.Property<string>("website");

                    b.Property<string>("website_title");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
        }
    }
}
