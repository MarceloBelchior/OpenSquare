using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenSquare.Core.EF.SessionManager;

namespace OpenSquare.Core.EF.Migrations
{
    [DbContext(typeof(Session))]
    partial class SessionModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenSquare.Core.Model.Entity.Profile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProfileId");

                    b.Property<DateTime>("Expired")
                        .HasAnnotation("SqlServer:ColumnType", "DateTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("ProfileKey")
                        .HasColumnName("ProfileKey");

                    b.Property<bool>("status")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StatusProfile")
                        .HasAnnotation("SqlServer:ColumnType", "bit")
                        .HasAnnotation("SqlServer:DefaultValue", true);

                    b.HasKey("id");

                    b.ToTable("Tbo_Profile");
                });

            modelBuilder.Entity("OpenSquare.Core.Model.Entity.Profile_User", b =>
                {
                    b.Property<int>("ProfileId");

                    b.Property<int>("UserId");

                    b.HasKey("ProfileId", "UserId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("UserId");

                    b.ToTable("TBO_Profile_User");
                });

            modelBuilder.Entity("OpenSquare.Core.Model.Entity.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserId");

                    b.Property<Guid>("ProfileKey")
                        .HasColumnName("ProfileKey")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("SocialMedia")
                        .HasColumnName("SocialMedia")
                        .HasAnnotation("SqlServer:ColumnType", "int");

                    b.Property<long>("SocialMediaId")
                        .HasColumnName("SocialMediaId");

                    b.Property<int>("Status")
                        .HasColumnName("StatusUser");

                    b.Property<DateTime>("date_last_access")
                        .HasColumnName("DT_LastAccess")
                        .HasAnnotation("SqlServer:ColumnType", "DateTime");

                    b.Property<string>("login")
                        .HasColumnName("NM_Login")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("password")
                        .HasColumnName("NM_password")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasColumnName("Guid_Salt")
                        .HasAnnotation("MaxLength", 256)
                        .HasAnnotation("SqlServer:ColumnType", "nvarchar(256)");

                    b.Property<string>("senha");

                    b.Property<Guid>("token")
                        .HasColumnName("token")
                        .HasAnnotation("MaxLength", 256)
                        .HasAnnotation("SqlServer:ColumnType", "nvarchar(256)");

                    b.HasKey("id");

                    b.ToTable("Tbo_User");
                });

            modelBuilder.Entity("OpenSquare.Core.Model.Entity.Profile_User", b =>
                {
                    b.HasOne("OpenSquare.Core.Model.Entity.Profile", "profile")
                        .WithMany("Users")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpenSquare.Core.Model.Entity.User", "user")
                        .WithMany("Profile")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
