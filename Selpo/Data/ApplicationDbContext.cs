using Microsoft.EntityFrameworkCore;
using Selpo.Models;

namespace Selpo.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<InvoicePrint> InvoicePrints { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<Sender> Senders { get; set; }

    public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CACDDF3C46C");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyAddress).HasMaxLength(500);
            entity.Property(e => e.CompanyMobile).HasMaxLength(20);
            entity.Property(e => e.CompanyName).HasMaxLength(255);
        });

        modelBuilder.Entity<InvoicePrint>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__InvoiceP__D796AAB5C1F6C0BF");

            entity.ToTable("InvoicePrint");

            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AmountWithCharges).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Bank).HasMaxLength(255);
            entity.Property(e => e.Charges).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CompanyAddress).HasMaxLength(500);
            entity.Property(e => e.CompanyMobile).HasMaxLength(20);
            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.Ifsc)
                .HasMaxLength(50)
                .HasColumnName("IFSC");
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.RecipientName).HasMaxLength(255);
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.SenderName).HasMaxLength(255);
            entity.Property(e => e.TransactionDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.ReceiptId).HasName("PK__Receipt__CC08C42022CFB7E7");

            entity.ToTable("Receipt");

            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.Bank).HasMaxLength(255);
            entity.Property(e => e.Ifsc)
                .HasMaxLength(50)
                .HasColumnName("IFSC");
            entity.Property(e => e.RecipientName).HasMaxLength(255);
            entity.Property(e => e.Remark).HasMaxLength(500);

            entity.HasOne(d => d.Sender).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__Receipt__SenderI__3F466844");
        });

        modelBuilder.Entity<Sender>(entity =>
        {
            entity.HasKey(e => e.SenderId).HasName("PK__Sender__BB49918BAEAEB901");

            entity.ToTable("Sender");

            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TransactionDetail>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A6BC2F8AB61");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AmountWithCharges).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Charges).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Invoice).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_Transaction_Invoice");

            entity.HasOne(d => d.Receipt).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.ReceiptId)
                .HasConstraintName("FK__Transacti__Recei__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
