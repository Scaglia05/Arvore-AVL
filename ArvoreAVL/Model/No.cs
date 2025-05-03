using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreAVL.Model {
    public class No {
        public int Valor { get; set; }
        public No Esquerda { get; set; }
        public No Direita { get; set; }
        public int Altura { get; set; }

        public No(int valor) {
            Valor = valor;
            Esquerda = null;
            Direita = null;
            Altura = 1; // Inicialmente, a altura do nó é 1
        }
    }
}
