using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreAVL.Model {
    public class NoAVL {
        public int Valor;
        public NoAVL Esquerda;
        public NoAVL Direita;
        public int Altura;

        public NoAVL(int valor) {
            Valor = valor;
            Altura = 1;
        }
    }
}
