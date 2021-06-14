using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PickingByVoice.Models;

namespace PickingByVoice.Controllers
{
    public class LISTAPRIORIDADEController : Controller
    {
        public void SU_Ordenar()
        {

            //3
            //votar contra
            //favorita
            //    Tenho a seguinte tabela

            //ID | NOME | ANO | REGISTO
            //    ----------------------------------
            //0       A          2015      4
            //1       B          2017      6
            //2       C          2014      15
            //3       D          2017      2
            //4       E          2013      55
            //5       F          2017      1
            //6       G          2017      6
            //7       H          2017      8
            //E fazendo a seguinte query recebo o resultado:

            //SELECT* FROM exemplo WHERE ano = 2017 ORDER BY nome ASC


            //ID | NOME | ANO | REGISTO
            //    ----------------------------------
            //1       B          2017      6
            //3       D          2017      2
            //5       F          2017      1
            //6       G          2017      6
            //7       H          2017      8
            //Pretendo fazer um UPDATE que me incremente o valor do REGISTO começando por 1 de acordo com a ordenação alfabética. Ou seja:

            //ID | NOME | ANO | REGISTO
            //    ----------------------------------
            //1       B          2017      1
            //3       D          2017      2
            //5       F          2017      3
            //6       G          2017      4
            //7       H          2017      5
            //E repetindo o processo pelo anos o resultado final seria:

            //SELECT* FROM EXEMPLO ORDER BY id

            //ID | NOME | ANO | REGISTO
            //    ----------------------------------
            //0       A          2015      1
            //1       B          2017      1
            //2       C          2014      1
            //3       D          2017      2
            //4       E          2013      1
            //5       F          2017      3
            //6       G          2017      4
            //7       H          2017      5
            //Estou questionando o processo apenas através de SQL, sem suporte a linguagens de programação.

            //    SET @prev := '';

            //SET @cnt := 1;

            //UPDATE exemplo e
            //JOIN(SELECT id, nome, IF(@prev <> ano, @cnt:= 1, @cnt:= @cnt + 1) AS rank, @prev:= ano as prev
            //FROM   exemplo
            //ORDER  BY ano, nome ASC) e1
            //    ON e.id = e1.id
            //SET registo = e1.rank

            //SET @prev := '';

            //SET @cnt := 1;

            //SELECT id, nome, IF(@prev <> ano, @cnt:= 1, @cnt:= @cnt + 1) AS rank, @prev := ano
            //    FROM exemplo
            //    ORDER BY ano, nome ASC
        }
    }
}