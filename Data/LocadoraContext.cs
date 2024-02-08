using Microsoft.EntityFrameworkCore;
using SistemaLocadora.Models;
using System;

namespace SistemaLocadora.Data
{
    public partial class LocadoraContext : DbContext
    {
        public LocadoraContext()
        {
}
        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<VeiculoModel> Veiculos { get; set; }
        public DbSet<LocacaoModel> Locacaos { get; set; }
        public DbSet<VendaModel> Vendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=DB_SistemaLocadora;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>(entity =>
            {
                entity.HasKey(e => e.IdCliente);
                entity.ToTable("Cliente");
                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
                entity.Property(e => e.Cpf)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPF");
                entity.Property(e => e.Endereco)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Nome)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Rg)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("RG");
                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocacaoModel>(entity =>
            {
                entity.HasKey(e => e.IdLocacao);
                entity.ToTable("Locacao");
                entity.Property(e => e.IdLocacao).HasColumnName("Id_Locacao");
                entity.Property(e => e.DataLocacao).HasColumnName("Data_Locacao");
                entity.Property(e => e.FkClienteIdCliente).HasColumnName("fk_Cliente_Id_Cliente");
                entity.Property(e => e.FkVeiculoIdVeiculo).HasColumnName("fk_Veiculo_Id_Veiculo");
                entity.HasOne(d => d.Cliente).WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.FkClienteIdCliente)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Locacao_2");
                entity.HasOne(d => d.Veiculo).WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.FkVeiculoIdVeiculo)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Locacao_3");
            });


            modelBuilder.Entity<VeiculoModel>(entity =>
            {
                entity.HasKey(e => e.IdVeiculo);
                entity.ToTable("Veiculo");
                entity.Property(e => e.IdVeiculo).HasColumnName("Id_Veiculo");
                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Modelo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Marca)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Placa)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Categoria)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ValorDeCompra).HasColumnName("Valor_de_Compra");
                entity.Property(e => e.ValorDiaria).HasColumnName("Valor_Diaria");
            });

            modelBuilder.Entity<VendaModel>(entity =>
            {
                entity.HasKey(e => e.IdVenda);
                entity.Property(e => e.IdVenda).HasColumnName("Id_Venda");
                entity.Property(e => e.DataVenda).HasColumnName("Data_Venda");
                entity.Property(e => e.ValorDeVenda).HasColumnName("Valor_Venda");
                entity.Property(e => e.FkVeiculoIdVeiculo).HasColumnName("fk_Veiculo_Id_Veiculo");

                entity.HasOne(d => d.Veiculo).WithMany(p => p.Venda)
                    .HasForeignKey(d => d.FkVeiculoIdVeiculo)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Venda_3");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
