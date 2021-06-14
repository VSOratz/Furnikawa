using ColetaEntrega.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ColetaEntrega.Context
{
    public class ColetaContext : DbContext
    {
        public ColetaContext() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConve‌​ntion>();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MestreColeta> MestreCarga { get; set; }
        public DbSet<ItemColeta> ItemColeta { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Inconformidade> Inconformidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioEmpresa> UsuarioEmpresas { get; set; }
        public DbSet<UsuarioEmpresaHistorico> UsuarioEmpresaHistoricos { get; set; }
        public DbSet<ItemColetaMovimentacao> ItemColetaMovimentacaos { get; set; }
        public DbSet<EdiImportaMestre> EdiImportaMestre { get; set; }
        public DbSet<EdiImportaItem> EdiImportaItem { get; set; }
    }
}