
using Microsoft.EntityFrameworkCore;
using myWorks.Domain.myWorkDb;

namespace myWorks.Persistence.MyWorkDbContexts;

public partial class MyWorkDbContext : DbContext
{
    public MyWorkDbContext()
    {
    }

    public MyWorkDbContext(DbContextOptions<MyWorkDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicantInformation> ApplicantInformations { get; set; }

    public virtual DbSet<InterviewDetail> InterviewDetails { get; set; }

    public virtual DbSet<JobApplication> JobApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicantInformation>(entity =>
        {
            entity.HasKey(e => e.ApplicantId).HasName("PK__Applican__39AE91A8C59DF2A4");

            entity.ToTable("ApplicantInformation");

            entity.HasIndex(e => e.Email, "UQ__Applican__A9D105345B4D7C42").IsUnique();

            entity.Property(e => e.ApplicantId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(100);
        });

        modelBuilder.Entity<InterviewDetail>(entity =>
        {
            entity.HasKey(e => e.InterviewId).HasName("PK__Intervie__C97C5852080497BF");

            entity.Property(e => e.InterviewId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Interviewer).HasMaxLength(100);

            entity.HasOne(d => d.Application).WithMany(p => p.InterviewDetails)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interview__Appli__5165187F");
        });

        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__JobAppli__C93A4C9914C87476");

            entity.ToTable("JobApplication");

            entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ApplicationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.JobTitle).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Applicant).WithMany(p => p.JobApplications)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JobApplic__Appli__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
