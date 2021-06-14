using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace PickingByVoice.Models
{
    public class ControleContext : DbContext
    {
        public ControleContext() : base("DefaultConnection")
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<SocialNetwork>().HasRequired(cls_SocialNetwork => cls_SocialNetwork.NotificationSocialNetwork).WithRequiredDependent();
            //modelBuilder.Entity<SocialNetwork>().HasRequired(cls_SocialNetwork => cls_SocialNetwork.NotificationSocialNetwork).WithRequiredDependent();
            //modelBuilder.Entity<NotificationSocialNetwork>().HasRequired(cls_NotiicationSocialNetwork=> cls_NotiicationSocialNetwork.SocialNetwork).WithOptional();
        }


        public System.Data.Entity.DbSet<PickingByVoice.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<PickingByVoice.Models.Grupos> Grupos { get; set; }

        public System.Data.Entity.DbSet<PickingByVoice.Models.Notas> Notas { get; set; }

        public System.Data.Entity.DbSet<PickingByVoice.Models.GruposDetalhes> GruposDetalhes { get; set; }

        public System.Data.Entity.DbSet<PickingByVoice.Models.ListaExpedicao> ListaExpedicaos { get; set; }

        public System.Data.Entity.DbSet<PickingByVoice.Models.Inconformidade> Inconformidades { get; set; }

        public System.Data.Entity.DbSet<PickingByVoice.Models.Documento> Documentoes { get; set; }

        public System.Data.Entity.DbSet<PickingByVoice.Models.EDI_IMPORTA_MESTRE> EDI_IMPORTA_MESTRE { get; set; }

        public System.Data.Entity.DbSet<PickingByVoice.Models.PEDIDO_ITEM> PEDIDO_ITEM { get; set; }

        public System.Data.Entity.DbSet<PickingByVoice.Models.EDI_IMPORTA_ITEM> EDI_IMPORTA_ITEM { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public System.Data.Entity.DbSet<PickingByVoice.Models.SocialNetwork> SocialNetworks { get; set; }

        public System.Data.Entity.DbSet<PickingByVoice.Models.NotificationSocialNetworks> NotificationSocialNetworks { get; set; }
    }
}