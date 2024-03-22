using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers {
    public class StringHelper {

        public string CorrigeStringDeEntrada(string entrada) {
            entrada = entrada.Replace(" ", "");
            
            if (entrada.Contains("texto:")) {
                entrada = entrada.Replace("texto:", "");
                entrada = entrada.Replace("{", "");
                entrada = entrada.Replace("}", "");
                entrada = entrada.Replace("\\", "");
                entrada = entrada.Replace("/", "");
                entrada = entrada.Replace("'", "");
            } else {
                throw new Exception("Entrada inválida - parâmetro incorreto.");
                return null;
            }  

            return entrada;
        }

        public bool StringVazia(string str) {
            if(str == "" || str == null) {
                return true;
            } else {
                return false;
            }
        }

        public bool textoEpalindromo(string str) {
            string primeiraMetade = str.Substring(0, str.Length / 2);
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            string temp = new string(arr);
            string segundaMetade = temp.Substring(0, temp.Length / 2);

            if (primeiraMetade.Equals(segundaMetade)) {
                return true;
            } else {
                return false;
            }
        }

        public  List<EntradaOcorrencias> contaOcorrenciaCaracteres(EntradaModel e) {
            List<char> listaChar = new List<char>();
            listaChar.AddRange(e.entrada);
            listaChar = listaChar.Distinct().ToList();

            e.listaOcorrencias = new List<EntradaOcorrencias>();
            foreach(char c in listaChar) {
                EntradaOcorrencias o = new EntradaOcorrencias();
                o.caracter = c;
                o.quantidade = e.entrada.Count(t => t == c);
                e.listaOcorrencias.Add(o);
            }

            return e.listaOcorrencias;
        }
    }
}