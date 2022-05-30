using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Accesa.SportsBuddy.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Accesa.SportsBuddy.Controllers.Models;

#nullable disable

namespace Accesa.SportsBuddy.Database
{
    public partial class SportsBuddyDBContext : IdentityDbContext<ApplicationUser>
    {
        public SportsBuddyDBContext()
        {
        }

        public SportsBuddyDBContext(DbContextOptions<SportsBuddyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AdministratedSportCenter> AdministratedSportCenters { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventCreatedBySportCenter> EventCreatedBySportCenters { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<JoinEvent> JoinEvents { get; set; }
        public virtual DbSet<JoinEventCreatedBySportCenter> JoinEventCreatedBySportCenters { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SportCenter> SportCenters { get; set; }
        public virtual DbSet<SportCenterAdmin> SportCenterAdmins { get; set; }
        public virtual DbSet<TraineeChallenge> TraineeChallenges { get; set; }
        public virtual DbSet<TraineeTrainingProgram> TraineeTrainingPrograms { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TrainerSportCenter> TrainerSportCenters { get; set; }
        public virtual DbSet<TrainerTrainingProgram> TrainerTrainingPrograms { get; set; }
        public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SportsBuddyDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
                
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.PostalCode).IsRequired();

                entity.Property(e => e.State).IsRequired();

                entity.Property(e => e.Street).IsRequired();
            });

            modelBuilder.Entity<AdministratedSportCenter>(entity =>
            {
                entity.ToTable("AdministratedSportCenter");

                entity.HasOne(d => d.SportCenterAdmin)
                    .WithMany(p => p.AdministratedSportCenters)
                    .HasForeignKey(d => d.SportCenterAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdministratedSportCenter_SportCenterAdmin");

                entity.HasOne(d => d.SportCenter)
                    .WithMany(p => p.AdministratedSportCenters)
                    .HasForeignKey(d => d.SportCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdministratedSportCenter_SportCenter");
            });

            modelBuilder.Entity<Challenge>(entity =>
            {
                entity.ToTable("Challenge");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrackedOutcome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Challenges)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Challenge__Autho__5070F446");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Goal)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__AddressID__571DF1D5");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__AuthorId__5812160E");
            });

            modelBuilder.Entity<EventCreatedBySportCenter>(entity =>
            {
                entity.ToTable("EventCreatedBySportCenter");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Goal)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.EventCreatedBySportCenters)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventCrea__Addre__5AEE82B9");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.EventCreatedBySportCenters)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventCrea__Autho__5BE2A6F2");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorite");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorite_Trainee");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.TrainingId)
                    .HasConstraintName("FK_Favorite_TrainingProgram");
            });

            modelBuilder.Entity<JoinEvent>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.UserId })
                    .HasName("PK__JoinEven__A83C44DA08E59EB3");

                entity.ToTable("JoinEvent");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.JoinEvents)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JoinEvent__Event__5EBF139D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JoinEvents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JoinEvent__UserI__5FB337D6");
            });

            modelBuilder.Entity<JoinEventCreatedBySportCenter>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.UserId })
                    .HasName("PK__JoinEven__A83C44DABD6A0789");

                entity.ToTable("JoinEventCreatedBySportCenter");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.JoinEventCreatedBySportCenters)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JoinEvent__Event__628FA481");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JoinEventCreatedBySportCenters)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JoinEvent__UserI__6383C8BA");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.Rating).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Review");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.TrainingId)
                    .HasConstraintName("FK_Review_TrainingProgram");
            });

            modelBuilder.Entity<SportCenter>(entity =>
            {
                entity.ToTable("SportCenter");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.AddressNavigation)
                    .WithMany(p => p.SportCenters)
                    .HasForeignKey(d => d.Address)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SportCenter_Addresses");
            });

            modelBuilder.Entity<SportCenterAdmin>(entity =>
            {
                entity.ToTable("SportCenterAdmin");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SportCenterAdmins)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SportCenterAdmin_Roles");
            });

            modelBuilder.Entity<TraineeChallenge>(entity =>
            {
                entity.HasKey(e => new { e.ChallengeId, e.TraineeId })
                    .HasName("PK__TraineeC__7416103276A32BCE");

                entity.ToTable("TraineeChallenge");

                entity.Property(e => e.ChallengeId).HasColumnName("ChallengeID");

                entity.Property(e => e.TraineeId).HasColumnName("TraineeID");

                entity.Property(e => e.Proof)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Challenge)
                    .WithMany(p => p.TraineeChallenges)
                    .HasForeignKey(d => d.ChallengeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TraineeCh__Chall__534D60F1");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeChallenges)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TraineeCh__Train__5441852A");
            });

            modelBuilder.Entity<TraineeTrainingProgram>(entity =>
            {
                entity.ToTable("TraineeTrainingProgram");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeTrainingPrograms)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeTrainingProgram_Trainee");

                entity.HasOne(d => d.TrainingProgram)
                    .WithMany(p => p.TraineeTrainingPrograms)
                    .HasForeignKey(d => d.TrainingProgramId)
                    .HasConstraintName("FK_TraineeTrainingProgram_TrainingProgram");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.Property(e => e.Rating).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trainers_User");
            });

            modelBuilder.Entity<TrainerSportCenter>(entity =>
            {
                entity.ToTable("TrainerSportCenter");

                entity.HasOne(d => d.SportCenter)
                    .WithMany(p => p.TrainerSportCenters)
                    .HasForeignKey(d => d.SportCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainerSportCenter_SportCenter");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainerSportCenters)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainerSportCenter_Trainers");
            });

            modelBuilder.Entity<TrainerTrainingProgram>(entity =>
            {
                entity.ToTable("TrainerTrainingProgram");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainerTrainingPrograms)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK_TrainerTrainingProgram_Trainers");

                entity.HasOne(d => d.TrainingProgram)
                    .WithMany(p => p.TrainerTrainingPrograms)
                    .HasForeignKey(d => d.TrainingProgramId)
                    .HasConstraintName("FK_TrainerTrainingProgram_TrainingProgram");
            });

            modelBuilder.Entity<TrainingProgram>(entity =>
            {
                entity.ToTable("TrainingProgram");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Difficulty).IsRequired();

                entity.Property(e => e.Duration).IsRequired();

                entity.Property(e => e.Location).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Rating).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.RecommendedSteps).IsRequired();

                entity.HasOne(d => d.SportCenter)
                    .WithMany(p => p.TrainingPrograms)
                    .HasForeignKey(d => d.SportCenterId)
                    .HasConstraintName("FK_TrainingProgram_SportCenter");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.AddressNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Address)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trainee_Addresses");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Trainee_Roles_RoleId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
