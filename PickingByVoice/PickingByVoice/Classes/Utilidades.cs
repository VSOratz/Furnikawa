using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PickingByVoice.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;
using PickingByVoice.Controllers;
using ProjectSendMessagemOneSignal;


namespace PickingByVoice.Classes
{
    public class Utilidades
    {
        private static ApplicationDbContext userContext = new ApplicationDbContext();
        private static ControleContext db = new ControleContext();

        public static void CheckRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public static void CheckSuperUser(string role)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var email = WebConfigurationManager.AppSettings["AdminUser"];
            var password = WebConfigurationManager.AppSettings["AdminPassWord"];
            var userASP = userManager.FindByName(email);
            if (userASP == null)
            {
                CreateUserASP(email, role, password);
                return;
            }
        }

        public static void CreateUserASP(string email)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, email);
        }

        public static void CreateUserASP(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, email);
            userManager.AddToRole(userASP.Id, roleName);

        }

        public static void AddRoleToUser(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(email);
            if (userASP == null)
            {
                return;
            }

            userManager.AddToRole(userASP.Id, roleName);
        }

        public static void CreateUserASP(string email, string roleName, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, email);
            userManager.AddToRole(userASP.Id, roleName);
        }

        public static async Task SendMail(string to, string subject, string body)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(to));
            message.From = new MailAddress(WebConfigurationManager.AppSettings["AdminUser"]);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = WebConfigurationManager.AppSettings["AdminUser"],
                    Password = WebConfigurationManager.AppSettings["AdminPassWord"]
                };

                smtp.Credentials = credential;
                smtp.Host = WebConfigurationManager.AppSettings["SMTPName"];
                smtp.Port = int.Parse(WebConfigurationManager.AppSettings["SMTPPort"]);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }

        public static async Task SendMail(List<string> Mails, string subject, string body)
        {
            var message = new MailMessage();

            foreach (var to in Mails)
            {
                message.To.Add(new MailAddress(to));
            }

            message.From = new MailAddress(WebConfigurationManager.AppSettings["AdminUser"]);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {

                var credential = new NetworkCredential
                {
                    UserName = WebConfigurationManager.AppSettings["AdminUser"],
                    Password = WebConfigurationManager.AppSettings["AdminPassWord"]
                };

                smtp.Credentials = credential;
                smtp.Host = WebConfigurationManager.AppSettings["SMTPName"];
                smtp.Port = int.Parse(WebConfigurationManager.AppSettings["SMTPPort"]);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }

        public static async Task PasswordRecovery(string email)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(email);
            if (userASP == null)
            {
                return;
            }

            var user = db.Usuarios.Where(tp => tp.USERNAME == email).FirstOrDefault();
            if (user == null)
            {
                return;
            }

            var random = new Random();
            var newPassword = string.Format("{0}{1}{2:04}*",
                user.NOME.Trim().ToUpper().Substring(0, 1),
                user.SOBRENOME.Trim().ToLower(),
                random.Next(10000));

            userManager.RemovePassword(userASP.Id);
            userManager.AddPassword(userASP.Id, newPassword);

            var subject = "Notes Password Recovery";
            var body = string.Format(@"
                <h1> Taxes Password Recovery</h1>
                <p>Please Change it for one, that you remeber easyly",
                newPassword);

            await SendMail(email, subject, body);
        }

        public static string UploadPhoto(HttpPostedFileBase file)
        {
            string path = string.Empty;
            string pic = string.Empty;

            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Photos"), pic);
                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }

            return pic;
        }

        public void Dispose()
        {
            userContext.Dispose();
            db.Dispose();
        }

        public static void SU_Recebe_ArquivoExcel1()
        {
            DataSet PDTS_ENTRADAXLS;
            OleDbConnection ODBC_ConexaoExcel = null;
            OleDbDataAdapter ODTA_Adapter = null;
            string PSTR_CAMINHO = "";
            PDTS_ENTRADAXLS = new DataSet();
            EDI_IMPORTA_MESTRE LCLS_EDI_IMPORTA_MESTRE = null;
            try
            {
                //ODBC_ConexaoExcel = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;" +
                //                        "Data Source=" + PSTR_CAMINHO.ToString().Trim() + ";" +
                //                        "Extended Properties=Excel 8.0;");
                //ODTA_Adapter = new OleDbDataAdapter("Select  From [Arquivoimportacao20171226$] WHERE 1=1", ODBC_ConexaoExcel);
                //ODTA_Adapter.Fill(PDTS_ENTRADAXLS);

                StreamReader rd = new StreamReader("C:\\Users\\Giovanni\\Desktop\\Arquivoimportacao20171226.csv");
                //Declaro uma string que será utilizada para receber a linha completa do arquivo 
                string linha = null;
                //Declaro um array do tipo string que será utilizado para adicionar o conteudo da linha separado 
                string[] linhaseparada = null;
                //realizo o while para ler o conteudo da linha 
                while ((linha = rd.ReadLine()) != null)
                {
                    //com o split adiciono a string 'quebrada' dentro do array 
                    linhaseparada = linha.Split(';');
                    //aqui incluo o método necessário para continuar o trabalho 

                    //aqui o vinicius vai incluir as classes para importar para o banco
                    LCLS_EDI_IMPORTA_MESTRE = new EDI_IMPORTA_MESTRE();
                    LCLS_EDI_IMPORTA_MESTRE.ID_IMPORTAMESTRE = 1;
                    LCLS_EDI_IMPORTA_MESTRE.NmArquivo = rd.ToString();
                    LCLS_EDI_IMPORTA_MESTRE.Status = "A";
                    db.EDI_IMPORTA_MESTRE.Add(LCLS_EDI_IMPORTA_MESTRE);
                    db.SaveChanges();


                }
                rd.Close();
            }
            catch (Exception ex)
            {
                try
                {
                    ODBC_ConexaoExcel = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
                            "Data Source=" + PSTR_CAMINHO.ToString().Trim() + ";" +
                            "Extended Properties=Excel 8.0;");
                    ODTA_Adapter = new OleDbDataAdapter("Select  From [rel_pedido$] WHERE 1=1", ODBC_ConexaoExcel);
                    ODTA_Adapter.Fill(PDTS_ENTRADAXLS);
                }
                catch (Exception ex1)
                { throw new Exception("Versão do Office não compativel"); }
            }


            ODBC_ConexaoExcel.Close();

            //PDTS_ENTRADAXLS.Tables[0].Rows[0][""]
        }

        public static void FU_VerificaNotificacao()
        {
            ClsNotification LCLS_Notification = null;
            ClsNewsSocial LCLS_NewSocial = null;

            NotificationSocialNetworks LCLS_NotificationSocialNetworks = null;

            DataTable LDTT_Notifications = null;
            int LINT_COUNT = 0;

            try
            {
                LCLS_NewSocial = new ClsNewsSocial();
                //LCLS_NewSocial.SU_NotitifaInstagram("https://www.instagram.com/","delegado_mikalovski_2018");


                LDTT_Notifications = LCLS_NewSocial.SU_NotificaFacebook("https://m.facebook.com/", "DelegadoMikalovski");

                if (LDTT_Notifications.Rows.Count > 0)
                {
                    for (LINT_COUNT = 0; LDTT_Notifications.Rows.Count > LINT_COUNT; LINT_COUNT++)
                    {

                        String str = LDTT_Notifications.Rows[LINT_COUNT]["NOTIFICATION"].ToString();
                        var user = db.NotificationSocialNetworks.Where(tp => tp.DescriptionSN == str).FirstOrDefault();
                        if (user == null)
                        {
                            LCLS_NotificationSocialNetworks = new NotificationSocialNetworks();
                            LCLS_NotificationSocialNetworks.DhModification = LDTT_Notifications.Rows[LINT_COUNT]["DATE"].ToString();
                            LCLS_NotificationSocialNetworks.DescriptionSN = LDTT_Notifications.Rows[LINT_COUNT]["NOTIFICATION"].ToString();
                            LCLS_NotificationSocialNetworks.TiteSN = "titulo";
                            LCLS_NotificationSocialNetworks.UserID = "1";
                            //LCLS_NotificationSocialNetworks.NotificationSocialNetwork_ID = 1;
                            LCLS_NotificationSocialNetworks.LinkSocial = "https://m.facebook.com/";
                            db.NotificationSocialNetworks.Add(LCLS_NotificationSocialNetworks);

                            db.SaveChanges();
                            db.GetValidationErrors();

                            LCLS_Notification = new ClsNotification();
                            LCLS_Notification.FU_Notification_All(str);
                            return;
                        }

                        using (ControleContext ctr = new ControleContext())
                        {
                            IEnumerable<NotificationSocialNetworks> notf = from p in ctr.NotificationSocialNetworks
                                                                           where p.DescriptionSN.Contains(str)
                                                                           select p;
                            var nn = notf.ToList();
                        }

                    }

                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }




        }
    }
}