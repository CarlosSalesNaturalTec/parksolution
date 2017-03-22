using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ParkWebService
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://parkwebservice.azurewebsites.net")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string BoasVindas()
        {
            return "GLORIFICADO SEJA O NOME DE JESUS CRISTO!";
        }

        [WebMethod]
        public string RegistraEntrada(string param1, string param2, string param3, string param4, string param5, string param6)
        {
            string retorno = "REGISTRO DE ENTRADA - TENTATIVA";
            OperacaoBanco operacao2 = new OperacaoBanco();

            string strInsert = "insert into Tbl_Movimento  (ID_Controle , ID_Operador, Placa, Data_Entrada, Setor_Entrada, encerrado ) " +
                               "values (" + param1 + ", " + param2 + ", '" + param3 + "', '" + param4 + "', '" + param5 + "',0)";
            Boolean inserir2 = operacao2.Insert(strInsert);
            ConexaoBancoSQL.fecharConexao();

            if (inserir2 == true)
            {
                retorno = "OK. GLORIFICADO SEJA O NOME DO SENHOR JESUS CRISTO";
            }

            return retorno;
        }

        [WebMethod]
        public string RegistraSaida(string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8)
        {
            string retorno = "REGISTRO DE SAIDA - TENTATIVA";
            OperacaoBanco operacao3 = new OperacaoBanco();

            string strUpdate = "update Tbl_Movimento set " +
                               "ID_Operador = " + param2 + "," +
                               "Data_Saida ='" + param3 + "'," +
                               "Permancencia  =" + param4 + "," +
                               "Ocorrencia ='" + param5 + "'," +
                               "Setor_Saida ='" + param6 + "'," +
                               "ID_Lojista =" + param7 + "," +
                               "Obs  ='" + param8 + "'," +
                               "encerrado = 1 " +
                               "where ID_Controle = " + param1;

            Boolean update = operacao3.Update(strUpdate);
            if (update == true)
            {
                retorno = "OK. GLORIFICADO SEJA O NOME DO SENHOR JESUS CRISTO";
            }
            ConexaoBancoSQL.fecharConexao();
            return retorno;
        }

    }
}
