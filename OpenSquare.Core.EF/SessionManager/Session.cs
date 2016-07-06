
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenSquare.Core.Model.Entity;
using OpenSquare.Core.Model.Enum;
using System;

namespace OpenSquare.Core.EF.SessionManager
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Session : Microsoft.EntityFrameworkCore.DbContext
    {


        //public Session(DbContextOptions<Session> options) : base(options)
        //{

        //}
        public Session() : base ()
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }


        //public DbSet<Open.Core.Model> ApplicationUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         //   optionsBuilder.UseSqlServer("ConnectionStrings:DefaultConnection");
             optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=StartUP;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Profile_User>(i => i.ToTable("TBO_Profile_User").HasKey(t => new { t.ProfileId, t.UserId }));
            builder.Entity<Profile_User>().HasOne(c => c.profile).WithMany(p => p.Users).HasForeignKey(f => f.ProfileId);
            builder.Entity<Profile_User>().HasOne(c => c.user).WithMany(p => p.Profile).HasForeignKey(f => f.UserId);

            builder.Entity<Profile>(i =>
            {
                i.ToTable("Tbo_Profile");
                i.Property<int>("id").HasColumnName("ProfileId");
                i.HasKey("id");
                i.Property<string>("Name").HasMaxLength(100).IsRequired();
                i.Property<DateTime>("Expired").ForSqlServerHasColumnType("DateTime").IsRequired();
                i.Property<bool>("status").HasColumnName("StatusProfile").IsRequired().ForSqlServerHasColumnType("bit").ForSqlServerHasDefaultValue(true);
                i.Property<Guid>("ProfileKey").HasColumnName("ProfileKey");
            });

            builder.Entity(typeof(Model.Entity.User), m =>
            {
                m.ToTable("Tbo_User");
                m.Property<int>("id").HasColumnName("UserId");
                m.HasKey("id");
                m.Property<long>("SocialMediaId").HasColumnName("SocialMediaId");
                m.Property<Status>("Status").HasColumnName("StatusUser").IsRequired();
                m.Property<string>("salt").HasColumnName("salt").HasMaxLength(256).ForSqlServerHasColumnType("nvarchar(256)").IsRequired();
                m.Property<Guid>("token").HasColumnName("token").HasMaxLength(256).ForSqlServerHasColumnType("nvarchar(256)").IsRequired();
                m.Property<SocialMedia>("SocialMedia").HasColumnName("SocialMedia").ForSqlServerHasColumnType("int");
                m.Property<DateTime>("date_last_access").HasColumnName("DT_LastAccess").ForSqlServerHasColumnType("DateTime").IsRequired();

                m.Property<string>("login").HasColumnName("NM_Login").HasMaxLength(100);
                m.Property<string>("password").HasColumnName("NM_password").HasMaxLength(256);
                m.Property<string>("salt").HasColumnName("Guid_Salt").HasMaxLength(256);
                m.Property<Guid>("ProfileKey").HasColumnName("ProfileKey").HasMaxLength(256);

            });




            //public ICollection<Profile> Profile { get; set; }

            //public Int64 SocialMediaId { get; set; }
            //public System.Guid ProfileKey { get; set; }

            //ToTable("Tbo_User");
            //HasKey(t => t.id);
            //Property(t => t.id).HasColumnName("UserId");
            //Property(t => t.StatusEnum).HasColumnName("Status_Enun").IsRequired();
            //Property(t => t.dt_lastaccess).HasColumnName("Dt_last_acess").IsRequired();
            ////Property(t => t.data_ultimo_acesso).HasColumnName("Dt_last_acess").IsRequired();
            //Property(t => t.Profile).HasColumnName("ProfileKey");
            //Property(t => t.login).HasColumnName("login").HasMaxLength(50);
            //Property(t => t.senha).HasColumnName("password").HasMaxLength(255);
            //Property(t => t.salt).HasColumnName("Salt").HasMaxLength(255);
            //Property(t => t.token).HasColumnName("TempToken");
            //HasMany(T => T.ls_profile)
            //    .WithMany()
            //    .Map(T => T.ToTable("Tbo_User_Profile")
            //        .MapLeftKey("UserId")
            //        .MapRightKey("ProfileId"));
            //Property(t => t.SocialMedia).HasColumnName("SocialMediaType");
            //Property(t => t.SocialMediaId).HasColumnName("SocialMediaId");


            //base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override thEntitye defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //  builder.Entity<ApplicationUser>(C=>C.Property<long>("UserID")).ToTable("TB_USER");
            //builder.Entity(typeof(Model.ApplicationUser), c =>
            //{
            //    c.Property<int>("id").ForSqlServerHasColumnName("UserID");
            //    c.ToTable("TBO_USER");

            //});

            //builder
            //  .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
            //  .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //builder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
            //{
            //    b.Property<string>("Id");

            //    b.Property<string>("ConcurrencyStamp")
            //        .IsConcurrencyToken();

            //    b.Property<string>("Name")
            //        .HasAnnotation("MaxLength", 256);

            //    b.Property<string>("NormalizedName")
            //        .HasAnnotation("MaxLength", 256);

            //    b.HasKey("Id");

            //    b.HasIndex("NormalizedName")
            //        .HasName("RoleNameIndex");

            //    b.ToTable("AspNetRoles");
            //});
        }
    }
}
