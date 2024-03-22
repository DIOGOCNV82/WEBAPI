using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers {
    public class ManipulacaoStringController : ApiController {


        [HttpPost]
        public IHttpActionResult PostString(HttpRequestMessage request) {
            EntradaModel e = new EntradaModel();
            StringHelper strHelper = new StringHelper();

            try {
                //captura string de entrada
                e.entrada = request.Content.ReadAsStringAsync().Result;
                
                //corrige string de entrada
                e.entrada = strHelper.CorrigeStringDeEntrada(e.entrada);

                //valida vazio
                e.entradaVazia = strHelper.StringVazia(e.entrada);
                if(e.entradaVazia) {
                    throw new Exception("Entrada inválida - string vazia.");
                }

                //verifica palindromo
                e.palindromo = strHelper.textoEpalindromo(e.entrada);

                //conta ocorrencias
                e.listaOcorrencias = strHelper.contaOcorrenciaCaracteres(e);

                //json de saída
                SaidaModel s = new SaidaModel();
                s.palindromo = e.palindromo;
                s.listaOcorrencias = e.listaOcorrencias;

                string textoSaida = JsonConvert.SerializeObject(s);
                return Ok(s);

            }catch(Exception ex) {
                return Ok(ex.Message);
            }
        }
    }


}
