using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Text;
using Microsoft.Ajax.Utilities;
using PickingByVoice.Models;

namespace PickingByVoice.Controllers
{
    public class ClsImportacao
    {
        private ControleContext db = new ControleContext();
        public void SU_ImportaArquivo()
        {
            string LSTR_Local;
            //Declaro o StreamReader para o caminho onde se encontra o arquivo 
            StreamReader LSR_Arquivo = null;
            //Declaro uma string que será utilizada para receber a linha completa do arquivo 
            string LSTR_linha = null;
            //Declaro um array do tipo string que será utilizado para adicionar o conteudo da linha separado 
            string[] LAST_LinhaSeparada = null;
            //Declaro um datatable para atribuir os valores importados do arquivo CSV
            DataTable LDTT_EDI_IMPORTA = null;

            EDI_IMPORTA_MESTRE LCLS_EDI_IMPORTA_MESTRE = null;
            EDI_IMPORTA_ITEM[] LARR_EDI_IMPORTA_ITEM = null;
            EDI_IMPORTA_ITEM LCLS_EDI_IMPORTA_ITEM = null;
            UsuarioController LCUC_Usuario = new UsuarioController();
            Usuario LUSR_Usuario = new Usuario();
            int LINT_IDITEM = 1;
            int LINT_IDMESTRE = 0;
            Boolean LBOL_MESTRE = false;
            StringBuilder sbMensagem = new StringBuilder();

            try
            {
                LSTR_Local = @"C:\Users\Giovanni\Desktop\Arquivoimportacao20190615.csv";
                if (LSTR_Local.Length == 0) throw new Exception("Local do arquivo não informado!");

                LSR_Arquivo = new StreamReader(LSTR_Local);

                while ((LSTR_linha = LSR_Arquivo.ReadLine()) != null)
                {
                    //com o split adiciono a string  'quebrada' dentro do array 
                    LAST_LinhaSeparada = LSTR_linha.Replace("\"", "").Split(';');

                    if (LAST_LinhaSeparada.Length == 1)
                        LAST_LinhaSeparada = LSTR_linha.Replace("\"", "").Split(',');

                    if (LINT_IDMESTRE == Convert.ToInt32(LAST_LinhaSeparada[0].Replace("\"", "")))
                        LBOL_MESTRE = true;
                    else
                        LBOL_MESTRE = false;

                    if (!LBOL_MESTRE)
                    {
                        db.SaveChanges();
                        //testar se sempre será primeira vez sempre
                        LUSR_Usuario = LCUC_Usuario.GetUsuario(LAST_LinhaSeparada[27] + "@email.com");
                        if (LUSR_Usuario == null)
                        {
                            LUSR_Usuario = new Usuario();
                            LUSR_Usuario.USERNAME = FU_ValidaCampo(LAST_LinhaSeparada[27]).ToString().Trim().ToLower() +"@email.com";
                            LUSR_Usuario.NOME = FU_ValidaCampo(LAST_LinhaSeparada[27], "CDPRODUTO", "String", 100,false, sbMensagem).ToString();
                            LUSR_Usuario.SOBRENOME = FU_ValidaCampo(LAST_LinhaSeparada[27], "CDPRODUTO", "String", 100,false, sbMensagem).ToString();
                            db.Usuarios.Add(LUSR_Usuario);

                            //LUSR_Usuario = LCUC_Usuario.GetUsuario(FU_ValidaCampo(LAST_LinhaSeparada[27]);
                        }
                        EDI_IMPORTA_ITEMController LCEDC_IMPORTAITEM = new EDI_IMPORTA_ITEMController();
                        if (LCEDC_IMPORTAITEM.EDI_IMPORTA_ITEMExists(Convert.ToInt32(FU_ValidaCampo(LAST_LinhaSeparada[0]).ToString().Replace("\"", ""))) == false)
                        {continue;}

                        LCLS_EDI_IMPORTA_MESTRE = new EDI_IMPORTA_MESTRE();
                        //if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[0]).ToString()))
                        //    LCLS_EDI_IMPORTA_MESTRE.ID_IMPORTAMESTRE = Convert.ToInt32(FU_ValidaCampo(LAST_LinhaSeparada[0]).ToString().Replace("\"", ""));
                        //else
                        //    throw new Exception("ID lista nao pode ser vazio ou nulo");
                        if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[1]).ToString()))
                            LCLS_EDI_IMPORTA_MESTRE.DtImportacao =
                                Convert.ToDateTime(FU_ValidaCampo(LAST_LinhaSeparada[1]).ToString());
                        else
                            LCLS_EDI_IMPORTA_MESTRE.DtImportacao =
                                Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        LCLS_EDI_IMPORTA_MESTRE.NmArquivo = "teste";
                        LCLS_EDI_IMPORTA_MESTRE.Status = "A";
                        LCLS_EDI_IMPORTA_MESTRE.SgUser = LUSR_Usuario.USERNAME;
                        LCLS_EDI_IMPORTA_MESTRE.DtManutencao =
                            Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        db.EDI_IMPORTA_MESTRE.Add(LCLS_EDI_IMPORTA_MESTRE);
                        LINT_IDMESTRE =
                            Convert.ToInt32(FU_ValidaCampo(LAST_LinhaSeparada[0]).ToString().Replace("\"", ""));

                        LBOL_MESTRE = false;
                        LINT_IDITEM = 1;
                    }

                    LCLS_EDI_IMPORTA_ITEM = new EDI_IMPORTA_ITEM();
                    LCLS_EDI_IMPORTA_ITEM.ID_IMPORTAMESTRE = LCLS_EDI_IMPORTA_MESTRE.ID_IMPORTAMESTRE;
                    LCLS_EDI_IMPORTA_ITEM.SEQITEM = LINT_IDITEM;
                    //LCLS_EDI_IMPORTA_MESTRE.ID_IMPORTAMESTRE = LINT_IDMESTRE
                    //VER COM O VINICIUS PQ E NAO LEMBRO A ORDEM DESSA PORRA
                    LCLS_EDI_IMPORTA_ITEM.FGATIVO = FU_ValidaCampo(LAST_LinhaSeparada[3], "FGATIVO", "String", 1, false, sbMensagem).ToString();
                    LCLS_EDI_IMPORTA_ITEM.CDPRODUTO = FU_ValidaCampo(LAST_LinhaSeparada[4], "CDPRODUTO", "String", 100, false, sbMensagem).ToString();
                    LCLS_EDI_IMPORTA_ITEM.DESCPRODUTO = FU_ValidaCampo(LAST_LinhaSeparada[5], "DESCPRODUTO", "String", 100, false, sbMensagem).ToString();
                    if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[6], "SGUNIDADE", "String", 5, false,sbMensagem).ToString()))
                        LCLS_EDI_IMPORTA_ITEM.SGUNIDADE = FU_ValidaCampo(LAST_LinhaSeparada[6], "SGUNIDADE", "String", 5, false, sbMensagem).ToString();
                    else
                        LCLS_EDI_IMPORTA_ITEM.SGUNIDADE = "Ñ INF";
                    LCLS_EDI_IMPORTA_ITEM.LOTEPRODUTO =FU_ValidaCampo(LAST_LinhaSeparada[7], "LOTEPRODUTO", "String", 100, false, sbMensagem).ToString();
                    LCLS_EDI_IMPORTA_ITEM.CDMARCA =FU_ValidaCampo(LAST_LinhaSeparada[8], "CDMARCA", "String", 100, false, sbMensagem).ToString();
                    LCLS_EDI_IMPORTA_ITEM.DESCMARCA =FU_ValidaCampo(LAST_LinhaSeparada[9], "DESCMARCA", "String", 100, false, sbMensagem).ToString();
                    LCLS_EDI_IMPORTA_ITEM.CDFABRICANTE = FU_ValidaCampo(LAST_LinhaSeparada[10], "CDFABRICANTE","String", 100, false, sbMensagem).ToString();
                    LCLS_EDI_IMPORTA_ITEM.CDFORNECEDOR = FU_ValidaCampo(LAST_LinhaSeparada[11], "CDFORNECEDOR","String", 100, false, sbMensagem).ToString();
                    LCLS_EDI_IMPORTA_ITEM.NMFORNECEDOR = FU_ValidaCampo(LAST_LinhaSeparada[12], "NMFORNECEDOR","String", 100, false, sbMensagem).ToString();
                    if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[13], "QTPEDIDO", "Int", 100, false, sbMensagem).ToString()))
                        LCLS_EDI_IMPORTA_ITEM.QTPEDIDO = Convert.ToInt32(FU_ValidaCampo(LAST_LinhaSeparada[13],"QTPEDIDO", "Int", 100, false, sbMensagem));
                    if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[14], "PESOLIQ", "Int", 100, false, sbMensagem).ToString()))
                        LCLS_EDI_IMPORTA_ITEM.PESOLIQ = Convert.ToDouble(FU_ValidaCampo(LAST_LinhaSeparada[14],"PESOLIQ", "Int", 100, false, sbMensagem));
                    if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[15], "PESOBRUTO", "Int", 100, false,sbMensagem).ToString()))
                        LCLS_EDI_IMPORTA_ITEM.PESOBRUTO = Convert.ToDouble(FU_ValidaCampo(LAST_LinhaSeparada[15],"PESOBRUTO", "Int", 100, false, sbMensagem));
                    if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[16], "DTVENCIMENTO", "datetime", 100,false, sbMensagem).ToString()))
                        LCLS_EDI_IMPORTA_ITEM.DTVENCIMENTO = Convert.ToDateTime(FU_ValidaCampo(LAST_LinhaSeparada[16],"DTVENCIMENTO", "datetime", 100, false, sbMensagem)); //.ToString("yyyy-MM-dd hh:mm:ss")
                    if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[17], "DTFABRICACAO", "datetime", 100,false, sbMensagem).ToString()))
                        LCLS_EDI_IMPORTA_ITEM.DTFABRICACAO = Convert.ToDateTime(FU_ValidaCampo(LAST_LinhaSeparada[17],"DTFABRICACAO", "datetime", 100, false, sbMensagem).ToString());
                    LCLS_EDI_IMPORTA_ITEM.CDEMBALAGEM =FU_ValidaCampo(LAST_LinhaSeparada[18], "CDEMBALAGEM", "String", 6, false, sbMensagem).ToString();
                    LCLS_EDI_IMPORTA_ITEM.SEQEMBALAGEM = FU_ValidaCampo(LAST_LinhaSeparada[19], "SEQEMBALAGEM","String", 6, false, sbMensagem).ToString();
                    if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[13], "QTPEDIDO", "Int", 100, false, sbMensagem).ToString()))
                        LCLS_EDI_IMPORTA_ITEM.QTEMBALAGEM = Convert.ToInt32(FU_ValidaCampo(LAST_LinhaSeparada[13],"QTPEDIDO", "Int", 100, false, sbMensagem));
                    LCLS_EDI_IMPORTA_ITEM.TPEMBALAGEM =FU_ValidaCampo(LAST_LinhaSeparada[20], "TPEMBALAGEM", "String", 6, false, sbMensagem).ToString();
                    if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[21], "CDEMBALAGEM", "Int", 6, false,sbMensagem).ToString()))
                        LCLS_EDI_IMPORTA_ITEM.NRLISTA = Convert.ToInt32(FU_ValidaCampo(LAST_LinhaSeparada[21],"CDEMBALAGEM", "Int", 6, false, sbMensagem));
                    if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[22], "NRPEDIDO", "Int", 6, false, sbMensagem).ToString()))
                        LCLS_EDI_IMPORTA_ITEM.NRPEDIDO = Convert.ToInt32(FU_ValidaCampo(LAST_LinhaSeparada[22],"NRPEDIDO", "Int", 6, false, sbMensagem));
                    else
                        LCLS_EDI_IMPORTA_ITEM.NRPEDIDO = LCLS_EDI_IMPORTA_ITEM.NRLISTA;
                    if (!String.IsNullOrEmpty(FU_ValidaCampo(LAST_LinhaSeparada[23], "DTLIMITE", "datetime", 6, false,sbMensagem).ToString()))
                        LCLS_EDI_IMPORTA_ITEM.DTLIMITE = Convert.ToDateTime(FU_ValidaCampo(LAST_LinhaSeparada[23],"DTLIMITE", "datetime", 100, false, sbMensagem).ToString());
                    LCLS_EDI_IMPORTA_ITEM.DESCENDERECO = FU_ValidaCampo(LAST_LinhaSeparada[24], "DESCENDERECO","String", 100, false, sbMensagem).ToString();
                    LCLS_EDI_IMPORTA_ITEM.STATUS =FU_ValidaCampo(LAST_LinhaSeparada[25], "STATUS", "String", 100, false, sbMensagem).ToString();
                    LCLS_EDI_IMPORTA_ITEM.DTMANUTENCAO = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    LCLS_EDI_IMPORTA_ITEM.SGUSER = LUSR_Usuario.USERNAME;

                    db.EDI_IMPORTA_ITEM.Add(LCLS_EDI_IMPORTA_ITEM);
                    LARR_EDI_IMPORTA_ITEM = new EDI_IMPORTA_ITEM[LSTR_linha.Length];
                    //LARR_EDI_IMPORTA_ITEM[LINT_IDITEM] = LCLS_EDI_IMPORTA_ITEM;
                    LINT_IDITEM++;
                }
                db.SaveChanges();
                LSR_Arquivo.Close();
                db.GetValidationErrors();


            }
            catch (DbEntityValidationException e)
            {
                string rs = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    rs = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    Console.WriteLine(rs);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        rs += "<br />" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                        sbMensagem.AppendLine(ve.PropertyName + ve.ErrorMessage);
                    }

                }
                throw new Exception(rs);

            }
            catch (Exception ex)
            {
                LSR_Arquivo.Dispose();
                //throw new Exception(ex.InnerException.Message);
                db = new ControleContext();

                for (int LINT_COUNT = 0; LINT_IDITEM > LARR_EDI_IMPORTA_ITEM.Length; LINT_IDITEM++)
                {
                    db.EDI_IMPORTA_ITEM.Remove(LCLS_EDI_IMPORTA_ITEM);
                    db.SaveChanges();
                }

                db = new ControleContext();
                db.EDI_IMPORTA_MESTRE.Remove(LCLS_EDI_IMPORTA_MESTRE);
                db.SaveChanges();


            }
            finally
            {
                LSR_Arquivo.Dispose();
            }
        }

        public object FU_ValidaCampo(object valor, object nmCampo = null, object tpCampo = null, int tamanhoCamp = 0, bool PermiteNullo = false, StringBuilder sbMensagem = null)
        {
            object objReturn = "";

            int intReturn = 0;
            decimal decReturn = 0;
            double douReturn = 0;
            string strReturn = "";
            DateTime dtReturn;
            try
            {
                if (tpCampo != null)
                {
                    if (PermiteNullo)
                    {
                        if (valor == null && valor.ToString().ToUpper() != "NULL" && valor.ToString().Trim() != "" && valor.ToString().Length == 0)
                        { return sbMensagem.AppendLine(String.Format("Não é permitido campo nulo , campo {0} , tamanho {1} , PermiteNulo {2} , tamanho contado {3} , valor campo {4}", nmCampo.GetType().FullName, tamanhoCamp, PermiteNullo, valor.ToString().Length, valor)); }
                    }

                    if (tamanhoCamp > 0)
                    {
                        if (valor.ToString().Length > tamanhoCamp)
                        {
                            sbMensagem.AppendLine(String.Format(
                                "Não é permitido campo tamanho maior que o definido \nTamanho contado {0} , Campo {1} , tamanho maximo {2}",
                                valor.ToString().Length, nmCampo.GetType().FullName, tamanhoCamp));
                            return "";
                        }
                    }
                    else
                    {
                        sbMensagem.AppendLine(String.Format("Não é permitido campo tamanho zero \nTamanho contado {0} , Campo {1}", valor.ToString().Length, nmCampo.GetType().FullName));
                    }

                    switch (tpCampo.ToString().ToUpper())
                    {
                        case "INT":
                            {
                                if (int.TryParse(valor.ToString(), out intReturn) == true)
                                {
                                    return (int)intReturn;
                                }
                                else
                                {
                                    sbMensagem.AppendLine(String.Format("O campo não está no valor esperado, \nValor esperado {0} , Campo {1}", tpCampo, nmCampo.GetType().FullName));
                                    return "";
                                }
                                break;
                            }
                        case @"DOUBLE":
                            {
                                if (double.TryParse(valor.ToString(), out douReturn) == true)
                                { return (double)douReturn; }
                                else
                                {
                                    sbMensagem.AppendLine(String.Format("O campo não está no valor esperado, \nValor esperado {0} , Campo {1}", tpCampo, nmCampo.GetType().FullName));
                                    return "";
                                }
                                break;
                            }
                        case @"DECIMAL":
                            {
                                if (decimal.TryParse(valor.ToString(), out decReturn) == true)
                                { return (decimal)decReturn; }
                                else
                                {
                                    sbMensagem.AppendLine(String.Format("O campo não está no valor esperado, \nValor esperado {0} , Campo {1}", tpCampo, nmCampo.GetType().FullName));
                                    return "";
                                }
                                break;
                            }
                        case @"DATETIME":
                            {
                                if (DateTime.TryParse(valor.ToString(), out dtReturn) == true)
                                { return (DateTime)dtReturn; }
                                else
                                {
                                    sbMensagem.AppendLine(String.Format("O campo não está no valor esperado, \nValor esperado {0} , Campo {1}", tpCampo, nmCampo.GetType().FullName));
                                    return DateTime.Now;
                                }
                                break;
                            }
                        case @"STRING":
                            {
                                if (valor != null && valor.ToString().ToUpper() != "NULL" && valor.ToString().Trim() != "")
                                {
                                    return valor;
                                }
                                else
                                    return "";
                                break;
                            }
                    }

                }


                if (int.TryParse(valor.ToString(), out intReturn) == true)
                { return (int)intReturn; }
                else if (double.TryParse(valor.ToString(), out douReturn) == true)
                { return (double)decReturn; }
                else if (decimal.TryParse(valor.ToString(), out decReturn) == true)
                { return (decimal)decReturn; }
                else if (DateTime.TryParse(valor.ToString(), out dtReturn) == true)
                { return (DateTime)dtReturn; }
                else
                {
                    if (valor != null && valor.ToString().ToUpper() != "NULL" && valor.ToString().Trim() != "")
                    {
                        return valor;
                    }
                }
                return objReturn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {

            }
        }
    }
}