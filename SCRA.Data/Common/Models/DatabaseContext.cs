using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using SCRA.Data.Clinical.Entities;

namespace SCRA.Data.Common.Models
{
    public class DatabaseContext : DbContext
    {
        private string connectionString;

        public DatabaseContext() : base()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();
            connectionString = configuration.GetConnectionString("DefaultConnection").ToString();
        }

        public DbSet<ApplicationEntity> Application { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<RuleEntity> Rule { get; set; }
        public DbSet<SegmentEntity> Segment { get; set; }
        public DbSet<ContractEntity> Contract { get; set; }
        public DbSet<PbpEntity> Pbp { get; set; }
        public DbSet<MeasureEntity> Measure { get; set; }
        public DbSet<TinEntity> Tin { get; set; }

        public DbSet<UserApplicationEntity> UserApplication { get; set; }
        public DbSet<UserRuleEntity> UserRule { get; set; }
        public DbSet<ContractPbpEntity> ContractPbp { get; set; }
        public DbSet<RuleSegmentEntity> RuleSegment { get; set; }
        public DbSet<RuleContractEntity> RuleContract { get; set; }
        public DbSet<RulePbpEntity> RulePbp { get; set; }
        public DbSet<RuleTinEntity> RuleTin { get; set; }
        public DbSet<RuleMeasureEntity> RuleMeasure { get; set; }
        public DbSet<RuleApplicationEntity> RuleApplication { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RuleApplicationEntity>()
            .HasKey(o => new { o.RuleId, o.ApplicationId });

            modelBuilder.Entity<RuleApplicationEntity>()
                .HasOne(e => e.Application)
                .WithMany(e => e.RuleApplication)
                .HasForeignKey(ec => ec.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RuleApplicationEntity>()
                .HasOne(e => e.Rule)
                .WithMany(e => e.RuleApplication)
                .HasForeignKey(ec => ec.RuleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RuleSegmentEntity>()
            .HasKey(o => new { o.RuleId, o.SegmentId });

            modelBuilder.Entity<RuleSegmentEntity>()
                .HasOne(e => e.Segment)
                .WithMany(e => e.RuleSegment)
                .HasForeignKey(ec => ec.SegmentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RuleSegmentEntity>()
                .HasOne(e => e.Rule)
                .WithMany(e => e.RuleSegment)
                .HasForeignKey(ec => ec.RuleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RuleContractEntity>()
            .HasKey(o => new { o.RuleId, o.ContractId });

            modelBuilder.Entity<RuleContractEntity>()
               .HasOne(e => e.Contract)
               .WithMany(e => e.RuleContract)
               .HasForeignKey(ec => ec.ContractId)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RuleContractEntity>()
               .HasOne(e => e.Rule)
               .WithMany(e => e.RuleContract)
               .HasForeignKey(ec => ec.RuleId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RulePbpEntity>()
           .HasKey(o => new { o.RuleId, o.PbpId });

            modelBuilder.Entity<RulePbpEntity>()
               .HasOne(e => e.Pbp)
               .WithMany(e => e.RulePbp)
               .HasForeignKey(ec => ec.PbpId)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RulePbpEntity>()
              .HasOne(e => e.Rule)
              .WithMany(e => e.RulePbp)
              .HasForeignKey(ec => ec.RuleId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RuleTinEntity>()
            .HasKey(o => new { o.RuleId, o.TinId });

            modelBuilder.Entity<RuleTinEntity>()
              .HasOne(e => e.Tin)
              .WithMany(e => e.RuleTin)
              .HasForeignKey(ec => ec.TinId)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RuleTinEntity>()
              .HasOne(e => e.Rule)
              .WithMany(e => e.RuleTin)
              .HasForeignKey(ec => ec.RuleId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RuleMeasureEntity>()
            .HasKey(o => new { o.RuleId, o.MeasureId });

            modelBuilder.Entity<RuleMeasureEntity>()
              .HasOne(e => e.Measure)
              .WithMany(e => e.RuleMeasure)
              .HasForeignKey(ec => ec.MeasureId)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RuleMeasureEntity>()
              .HasOne(e => e.Rule)
              .WithMany(e => e.RuleMeasure)
              .HasForeignKey(ec => ec.RuleId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ContractPbpEntity>()
               .HasOne(e => e.Pbp)
               .WithMany(e => e.ContractPbp);

            modelBuilder.Entity<UserApplicationEntity>()
                .HasKey(o => new { o.UserId, o.ApplicationId });

            modelBuilder.Entity<UserApplicationEntity>()
              .HasOne(e => e.Application)
              .WithMany(e => e.UserApplication)
              .HasForeignKey(ec => ec.ApplicationId)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserApplicationEntity>()
              .HasOne(e => e.User)
              .WithMany(e => e.UserApplication)
              .HasForeignKey(ec => ec.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRuleEntity>()
               .HasKey(o => new { o.UserId, o.RuleId });

            modelBuilder.Entity<UserRuleEntity>()
              .HasOne(e => e.Rule)
              .WithMany(e => e.UserRule)
              .HasForeignKey(ec => ec.RuleId)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserRuleEntity>()
              .HasOne(e => e.User)
              .WithMany(e => e.UserRule)
              .HasForeignKey(ec => ec.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}
