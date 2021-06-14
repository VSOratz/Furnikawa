using ColetaEntrega.Context;
using ColetaEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;

namespace ColetaEntrega.Controllers
{
    public class ClsImportacao
    {
        private ColetaContext db = new ColetaContext();
        public void SU_ImportaArquivo()
        {
            string LSTR_Local;
            decimal LDEC_CPF;
            string LSTR_NomeMotorista;
            //Declaro o StreamReader para o caminho onde se encontra o arquivo 
            StreamReader LSR_Arquivo = null;
            //Declaro uma string que será utilizada para receber a linha completa do arquivo 
            string LSTR_linha = null;
            //Declaro um array do tipo string que será utilizado para adicionar o conteudo da linha separado 
            string[] LAST_LinhaSeparada = null;
            //Declaro um datatable para atribuir os valores importados do arquivo CSV
            DataTable LDTT_EDI_IMPORTA = null;

            EdiImportaMestre LCLS_EDI_MESTRE = null;
            EdiImportaItem[] LARR_EDI_ITEM = null;
            EdiImportaItem LCLS_EDI_ITEM = null;
            int LINT_IDITEM = 1;
            int LINT_IDMESTRE = 0;
            int LINT_Index = 0;
            Boolean LBOL_MESTRE = false;

            try
            {
                //LSTR_Local = @"D:\Morpheus\PickingByVoice\ColetaEntrega\Content\Entrega20191005.csv";
                LSTR_Local = @"C:\Users\BdO\Source\Workspaces\PickingByVoice\ColetaEntrega\Content\Entrega20191005.csv";
                if (LSTR_Local.Length == 0) throw new Exception("Local do arquivo não informado!");

                LSR_Arquivo = new StreamReader(LSTR_Local);

                LCLS_EDI_MESTRE = new EdiImportaMestre();
                LCLS_EDI_MESTRE.DtImportacao = DateTime.Now;
                LCLS_EDI_MESTRE.NmArquivo = "Entrega20191005.csv";
                LCLS_EDI_MESTRE.Status = "I";
                LCLS_EDI_MESTRE.SgUser = "API";
                LCLS_EDI_MESTRE.DtManutencao = DateTime.Now;

                var EDI_MESTRE = db.EdiImportaMestre.Add(LCLS_EDI_MESTRE);
                LINT_IDMESTRE = EDI_MESTRE.EdiImportaMestreId;

                while ((LSTR_linha = LSR_Arquivo.ReadLine()) != null)
                {
                    LINT_Index = 0;
                    //com o split adiciono a string  'quebrada' dentro do array 
                    LAST_LinhaSeparada = LSTR_linha.Split(';');

                    LCLS_EDI_ITEM = new EdiImportaItem();
                    LCLS_EDI_ITEM.EdiImportaMestreId = LINT_IDMESTRE;
                    LCLS_EDI_ITEM.SEQITEM = LINT_IDITEM;
                    LCLS_EDI_ITEM.STATUS = "I";
                    LCLS_EDI_ITEM.NRROMANEIO = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.CPFMOTORISTA = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.NOMEMOTORISTA = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.PLACA = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.NRNOTA = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.DTCOLETA = Convert.ToDateTime(LAST_LinhaSeparada[LINT_Index++].ToString());
                    LCLS_EDI_ITEM.CNPJEMPRESA = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.NOMEEMPRESA = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.RUA = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.NUMERO = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.COMPLEMENTO = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.BAIRRO = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.VLNOTA = Convert.ToDecimal(LAST_LinhaSeparada[LINT_Index++].ToString());
                    LCLS_EDI_ITEM.QUANTIDADE = Convert.ToDecimal(LAST_LinhaSeparada[LINT_Index++].ToString());
                    LCLS_EDI_ITEM.PESO = Convert.ToDecimal(LAST_LinhaSeparada[LINT_Index++].ToString());
                    LCLS_EDI_ITEM.TPENTREGA = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.DTPREVISAO = Convert.ToDateTime(LAST_LinhaSeparada[LINT_Index++].ToString());
                    LCLS_EDI_ITEM.FGATIVO = LAST_LinhaSeparada[LINT_Index++].ToString();
                    LCLS_EDI_ITEM.SGUSER = "API";
                    LCLS_EDI_ITEM.DTMANUTENCAO = DateTime.Now;


                    db.EdiImportaItem.Add(LCLS_EDI_ITEM);
                    LARR_EDI_ITEM = new EdiImportaItem[LSTR_linha.Length];
                    LARR_EDI_ITEM[LINT_IDITEM] = LCLS_EDI_ITEM;
                    LINT_IDITEM++;
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.InnerException.Message);
                db = new ColetaContext();

                for (int LINT_COUNT = 0; LINT_IDITEM > LARR_EDI_ITEM.Length; LINT_IDITEM++)
                {
                    db.EdiImportaItem.Remove(LCLS_EDI_ITEM);
                    db.SaveChanges();
                }

                db = new ColetaContext();
                db.EdiImportaMestre.Remove(LCLS_EDI_MESTRE);
                db.SaveChanges();
            }

            try
            {
                db.SaveChanges();
                LSR_Arquivo.Close();
                db.GetValidationErrors();
            }
            catch (DbEntityValidationException e)
            {
                string LSTR_ErroEntity = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    LSTR_ErroEntity = String.Format("Entidade do tipo \"{0}\" com estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    LSTR_ErroEntity += Environment.NewLine;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        LSTR_ErroEntity += String.Format("- Propriedade: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        LSTR_ErroEntity += Environment.NewLine;
                    }
                }
                throw new Exception(LSTR_ErroEntity);
            }
        }

        public void SU_ProcessaEDI()
        {
            try
            {
                string nrRomaneio = "";
                Participante motorista = new Participante();
                Participante empresa = new Participante();
                Usuario user = new Usuario();
                var query = db.EdiImportaMestre
                    .Join(db.EdiImportaItem,
                        mestreEDI => mestreEDI.EdiImportaMestreId,
                        itemEDI => itemEDI.EdiImportaMestreId,
                        (mestreEDI, itemEDI) => new { MestreEDI = mestreEDI, ItemEDI = itemEDI })
                    .Where(MestreItem => MestreItem.MestreEDI.Status == "I").ToList();

                #region Importar Usuario de empresa

                foreach (var item in query)
                {
                    string cnpjEmpresaDestino = item.ItemEDI.CNPJEMPRESA;
                    empresa = db.Participantes.Where(w => w.CgcCPF == cnpjEmpresaDestino).FirstOrDefault();

                    if (empresa == null)
                    {
                        Participante participante = new Participante()
                        {
                            CgcCPF = item.ItemEDI.CNPJEMPRESA,
                            NmRazaoSocial = item.ItemEDI.NOMEEMPRESA,
                            NmFantasia = item.ItemEDI.NOMEEMPRESA,
                            SgUser = "API",
                            DtManutencao = DateTime.Now,
                            FgAtivo = "S",
                            FgTipoPessoa = "J",
                            Email = "empresa@email.com",
                            CEP = "00000000",
                            FgEmpresa = "S",
                        };

                        db.Participantes.Add(participante);
                        db.SaveChanges();
                    }
                    cnpjEmpresaDestino = item.ItemEDI.CNPJEMPRESA;
                    empresa = db.Participantes.Where(w => w.CgcCPF == cnpjEmpresaDestino).FirstOrDefault();

                    user = db.Usuarios.Where(w => w.ParticipanteId == empresa.ParticipanteId).FirstOrDefault();

                    if (user == null)
                    {
                        Usuario usuario = new Usuario()
                        {
                            Senha = FU_SenhaRandom(6),
                            DhCriacao = DateTime.Now,
                            NmUsuarioCriou = "API",
                            ParticipanteId = empresa.ParticipanteId,
                            Ativo = "S",
                            DhAlteracao = DateTime.Now,
                        };

                        db.Usuarios.Add(usuario);

                        UsuarioEmpresa usuarioEmpresa = new UsuarioEmpresa()
                        {
                            DhCriacao = DateTime.Now,
                            NmUsuarioCriou = "API",
                            ParticipanteId = empresa.ParticipanteId,
                            DhAlteracao = DateTime.Now,
                        };

                        db.UsuarioEmpresas.Add(usuarioEmpresa);
                    }
                    db.SaveChanges();
                }

                #endregion

                #region Importar Itens da Coleta

                foreach (var item in query)
                {
                    if (nrRomaneio != item.ItemEDI.NRROMANEIO)
                    {
                        string cpfMotorista = item.ItemEDI.CPFMOTORISTA;
                        motorista = db.Participantes.Where(w => w.CgcCPF == cpfMotorista).FirstOrDefault();

                        if (motorista == null)
                        {
                            Participante participante = new Participante()
                            {
                                CgcCPF = item.ItemEDI.CPFMOTORISTA,
                                NmRazaoSocial = item.ItemEDI.NOMEMOTORISTA,
                                NmFantasia = item.ItemEDI.NOMEMOTORISTA,
                                FgTipoPessoa = "F",
                                Email = "pessoa@email.com",
                                CEP = "00000000",
                                SgUser = "API",
                                DtManutencao = DateTime.Now,
                                FgAtivo = "S",
                            };

                            db.Participantes.Add(participante);
                            db.SaveChanges();
                        }
                        cpfMotorista = item.ItemEDI.CPFMOTORISTA;
                        motorista = db.Participantes.Where(w => w.CgcCPF == cpfMotorista).FirstOrDefault();

                        user = db.Usuarios.Where(w => w.ParticipanteId == motorista.ParticipanteId).FirstOrDefault();

                        if (user == null)
                        {
                            Usuario usuario = new Usuario()
                            {
                                Senha = FU_SenhaRandom(6),
                                DhCriacao = DateTime.Now,
                                NmUsuarioCriou = "API",
                                ParticipanteId = motorista.ParticipanteId,
                                Ativo = "S",
                                DhAlteracao = DateTime.Now,
                            };

                            db.Usuarios.Add(usuario);
                        }

                        MestreColeta mestreColeta = new MestreColeta()
                        {
                            Previsao_Retorno = item.ItemEDI.DTPREVISAO,
                            Status_Coleta = "A",
                            ParticipanteId = motorista.ParticipanteId,
                            NrRomaneio = item.ItemEDI.NRROMANEIO,
                            Placa = item.ItemEDI.PLACA,
                            SgUser = "API",
                            DtManutencao = DateTime.Now
                        };

                        db.MestreCarga.Add(mestreColeta);
                    }

                    ItemColeta itemColeta = new ItemColeta()
                    {
                        DhColeta = item.ItemEDI.DTCOLETA,
                        Valor = item.ItemEDI.VLNOTA,
                        Quantidade = item.ItemEDI.QUANTIDADE,
                        Peso = item.ItemEDI.PESO,
                        Nota = Convert.ToDecimal(item.ItemEDI.NRNOTA),
                        Tipo_Coleta = item.ItemEDI.TPENTREGA,
                        Status_Coleta = "A",
                        ParticipanteId = motorista.ParticipanteId,
                        CnpjEmpresaDestino = item.ItemEDI.CNPJEMPRESA,
                        EmpresaDestino = item.ItemEDI.NOMEEMPRESA,
                        Rua = item.ItemEDI.RUA,
                        Numero = Convert.ToDecimal(item.ItemEDI.NUMERO),
                        Complemento = item.ItemEDI.COMPLEMENTO,
                        Bairro = item.ItemEDI.BAIRRO,
                        SgUser = "API",
                        DtManutencao = DateTime.Now,
                    };

                    db.ItemColeta.Add(itemColeta);

                    nrRomaneio = item.ItemEDI.NRROMANEIO;
                }
                db.SaveChanges();

                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }

        public static string FU_SenhaRandom(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}