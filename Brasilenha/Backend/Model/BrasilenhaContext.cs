using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Model;

public partial class BrasilenhaContext : DbContext
{
    public BrasilenhaContext()
    {
    }

    public BrasilenhaContext(DbContextOptions<BrasilenhaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cupom> Cupoms { get; set; }

    public virtual DbSet<Imagem> Imagems { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoProduto> PedidoProdutos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-001YM\\SQLEXPRESS01;Initial Catalog=Brasilenha;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cupom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cupom__3214EC27C32B323A");

            entity.ToTable("Cupom");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Imagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imagem__3214EC27E07CB063");

            entity.ToTable("Imagem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Foto).IsRequired();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedido__3214EC27BEFCB5F7");

            entity.ToTable("Pedido");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoPedido)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.DataPedido).HasColumnType("datetime");

            entity.HasOne(d => d.Cupom).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.CupomId)
                .HasConstraintName("FK__Pedido__CupomId__412EB0B6");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedido__UsuarioI__403A8C7D");
        });

        modelBuilder.Entity<PedidoProduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PedidoPr__3214EC27067E9C35");

            entity.ToTable("PedidoProduto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.ProdutoId).HasColumnName("ProdutoID");

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoProdutos)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidoPro__Pedid__440B1D61");

            entity.HasOne(d => d.Produto).WithMany(p => p.PedidoProdutos)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidoPro__Produ__44FF419A");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto__3214EC27BD038AC1");

            entity.ToTable("Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descrição)
                .IsRequired()
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.ImagemId).HasColumnName("ImagemID");
            entity.Property(e => e.NomeProduto)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Imagem).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.ImagemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Produto__ImagemI__3B75D760");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC2784C3529A");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsAdm).HasColumnName("isADM");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .IsRequired()
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
