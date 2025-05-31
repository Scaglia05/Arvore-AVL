using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreAVL.Model {
    public class BaseArvoreAVL {
        public NoAVL Raiz;

        private int Altura(NoAVL no) => no == null ? 0 : no.Altura;

        private int FatorDeBalanceamento(NoAVL no) => no == null ? 0 : Altura(no.Esquerda) - Altura(no.Direita);

        private NoAVL RotacaoDireita(NoAVL y) {
            NoAVL x = y.Esquerda;
            NoAVL T2 = x.Direita;

            x.Direita = y;
            y.Esquerda = T2;

            y.Altura = Math.Max(Altura(y.Esquerda), Altura(y.Direita)) + 1;
            x.Altura = Math.Max(Altura(x.Esquerda), Altura(x.Direita)) + 1;

            return x;
        }

        private NoAVL RotacaoEsquerda(NoAVL x) {
            NoAVL y = x.Direita;
            NoAVL T2 = y.Esquerda;

            y.Esquerda = x;
            x.Direita = T2;

            x.Altura = Math.Max(Altura(x.Esquerda), Altura(x.Direita)) + 1;
            y.Altura = Math.Max(Altura(y.Esquerda), Altura(y.Direita)) + 1;

            return y;
        }

        public void Inserir(int valor) {
            Raiz = Inserir(Raiz, valor);
        }

        private NoAVL Inserir(NoAVL no, int valor) {
            if (no == null)
                return new NoAVL(valor);

            if (valor < no.Valor)
                no.Esquerda = Inserir(no.Esquerda, valor);
            else if (valor > no.Valor)
                no.Direita = Inserir(no.Direita, valor);
            else
                return no; 

            no.Altura = 1 + Math.Max(Altura(no.Esquerda), Altura(no.Direita));

            return Balancear(no);
        }

        private NoAVL Balancear(NoAVL no) {
            int balanceamento = FatorDeBalanceamento(no);

            if (balanceamento > 1) {
                if (FatorDeBalanceamento(no.Esquerda) < 0)
                    no.Esquerda = RotacaoEsquerda(no.Esquerda);
                return RotacaoDireita(no);
            }

            if (balanceamento < -1) {
                if (FatorDeBalanceamento(no.Direita) > 0)
                    no.Direita = RotacaoDireita(no.Direita);
                return RotacaoEsquerda(no);
            }

            return no;
        }

        public void Remover(int valor) {
            Raiz = Remover(Raiz, valor);
        }

        private NoAVL Remover(NoAVL no, int valor) {
            if (no == null)
                return null;

            if (valor < no.Valor)
                no.Esquerda = Remover(no.Esquerda, valor);
            else if (valor > no.Valor)
                no.Direita = Remover(no.Direita, valor);
            else {
                if (no.Esquerda == null || no.Direita == null) {
                    no = no.Esquerda ?? no.Direita;
                } else {
                    NoAVL temp = MinimoValor(no.Direita);
                    no.Valor = temp.Valor;
                    no.Direita = Remover(no.Direita, temp.Valor);
                }
            }

            if (no == null)
                return null;

            no.Altura = 1 + Math.Max(Altura(no.Esquerda), Altura(no.Direita));

            return Balancear(no);
        }

        private NoAVL MinimoValor(NoAVL no) {
            NoAVL atual = no;
            while (atual.Esquerda != null)
                atual = atual.Esquerda;
            return atual;
        }

        public bool Buscar(int valor) {
            return Buscar(Raiz, valor);
        }

        private bool Buscar(NoAVL no, int valor) {
            if (no == null)
                return false;
            if (valor == no.Valor)
                return true;
            return valor < no.Valor ? Buscar(no.Esquerda, valor) : Buscar(no.Direita, valor);
        }

        public void ImprimirPreOrdem() {
            Console.Write("Árvore em pré-ordem: ");
            ImprimirPreOrdem(Raiz);
            Console.WriteLine();
        }

        private void ImprimirPreOrdem(NoAVL no) {
            if (no != null) {
                Console.Write($"{no.Valor} ");
                ImprimirPreOrdem(no.Esquerda);
                ImprimirPreOrdem(no.Direita);
            }
        }

        public void ImprimirFatoresDeBalanceamento() {
            Console.WriteLine("Fatores de balanceamento:");
            ImprimirFatoresDeBalanceamento(Raiz);
        }

        private void ImprimirFatoresDeBalanceamento(NoAVL no) {
            if (no != null) {
                Console.WriteLine($"Nó {no.Valor}: Fator de balanceamento {FatorDeBalanceamento(no)}");
                ImprimirFatoresDeBalanceamento(no.Esquerda);
                ImprimirFatoresDeBalanceamento(no.Direita);
            }
        }

        public int AlturaArvore() {
            return Altura(Raiz) - 1; 
        }
    }

}
