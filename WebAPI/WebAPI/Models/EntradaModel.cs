using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models {
    
    public class EntradaModel {
        public string entrada {get; set;}
        public bool entradaVazia {get; set;}
        public bool palindromo {get; set;}
        public List<EntradaOcorrencias> listaOcorrencias {get; set;}
        public string textoSaida {get; set;}
    }

    public class EntradaOcorrencias {
        public char caracter {get; set;}
        public int quantidade {get; set;}
    }
}