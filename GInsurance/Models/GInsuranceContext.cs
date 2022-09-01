using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GInsurance.Models
{
    public partial class GInsuranceContext : DbContext
    {
        public GInsuranceContext()
        {
        }

        public GInsuranceContext(DbContextOptions<GInsuranceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<PaymentTable> PaymentTables { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<PolicyTable> PolicyTables { get; set; }
        public virtual DbSet<Renewal> Renewals { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=VINAYKUMAR\\SQLEXPRESS02;database=GInsurance;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.HasKey(e => e.ClaimNo)
                    .HasName("PK__Claim__811C62F20102AE9F");

                entity.ToTable("Claim");

                entity.Property(e => e.ClaimNo).HasColumnName("Claim_No");

                entity.Property(e => e.ApproveStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Approve_Status");

                entity.Property(e => e.ClaimDate)
                    .HasColumnType("date")
                    .HasColumnName("Claim_Date");

                entity.Property(e => e.PlanId).HasColumnName("Plan_Id");

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Claim__Plan_Id__619B8048");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("FK__Claim__Policy_Id__6383C8BA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Claim__User_Id__628FA481");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                //entity.Property(e => e.Address)
                //    .IsRequired()
                //    .HasMaxLength(50)
                //    .IsUnicode(false);

                entity.Property(e => e.ChassisNumber).
                    HasColumnName("Chassis_Number")
                .HasMaxLength(20).IsUnicode(false);

                entity.Property(e => e.License)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Driving_License");

                entity.Property(e => e.EngineNumber)
                    .HasColumnName("Engine_Number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturerName)
                    .IsRequired().HasColumnName("Manufacturer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("date")
                    .HasColumnName("Purchase_Date");

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Reg_Number");

                entity.Property(e => e.TypeOfVehicle)
                    .IsRequired()
                    .HasMaxLength(20).HasColumnName("Type")
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Details__User_Id__38996AB5");
            });

            modelBuilder.Entity<PaymentTable>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__Payment___DA6C7FC1BDB46E3F");

                entity.ToTable("Payment_Table");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("Payment_Date");

                entity.Property(e => e.PlanId).HasColumnName("Plan_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PaymentTables)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Payment_T__Plan___3E52440B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Payment_T__User___3D5E1FD2");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.Property(e => e.PlanId).HasColumnName("Plan_Id");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            modelBuilder.Entity<PolicyTable>(entity =>
            {
                entity.HasKey(e => e.PolicyId)
                    .HasName("PK__Policy_T__4564AB61377D852D");

                entity.ToTable("Policy_Table");

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.Property(e => e.DateOfPurchase)
                    .HasColumnType("date")
                    .HasColumnName("Date_Of_Purchase");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.PlanId).HasColumnName("Plan_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PolicyTables)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Policy_Ta__Plan___412EB0B6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PolicyTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Policy_Ta__User___4222D4EF");
            });

            modelBuilder.Entity<Renewal>(entity =>
            {
                entity.HasKey(e => e.RenewId)
                    .HasName("PK__Renewal__17394C8E21EE2B30");

                entity.ToTable("Renewal");

                entity.Property(e => e.RenewId).HasColumnName("Renew_Id");

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Renewals)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("FK__Renewal__Policy___6FE99F9F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Renewals)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Renewal__User_Id__6EF57B66");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("Contact")
                    .HasMaxLength(10).IsUnicode(false);
                    

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
