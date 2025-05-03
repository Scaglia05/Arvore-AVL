using System;

namespace ArvoreAVL.Model {
    public class Arvore_AVL {

        private No raiz;

        public void Inserir(int valor) {
            raiz = InserirRecursivamente(raiz, valor);
        }

        private No InserirRecursivamente(No noAtual, int valor) {
            if (noAtual == null)
                return new No(valor);

            if (valor < noAtual.Valor)
                noAtual.Esquerda = InserirRecursivamente(noAtual.Esquerda, valor);
            else if (valor > noAtual.Valor)
                noAtual.Direita = InserirRecursivamente(noAtual.Direita, valor);
            else
                return noAtual; // Não permite valores duplicados

            AtualizarAlturaNo(noAtual);
            return BalancearNo(noAtual);
        }

        private void AtualizarAlturaNo(No no) {
            no.Altura = 1 + Math.Max(ObterAltura(no.Esquerda), ObterAltura(no.Direita));
        }

        private int ObterAltura(No no) {
            return no == null ? 0 : no.Altura;
        }

        private int ObterFatorBalanceamento(No no) {
            return no == null ? 0 : ObterAltura(no.Esquerda) - ObterAltura(no.Direita);
        }

        private No BalancearNo(No no) {
            int fatorBalanceamento = ObterFatorBalanceamento(no);

            if (fatorBalanceamento > 1) {
                if (ObterFatorBalanceamento(no.Esquerda) < 0)
                    no.Esquerda = RotacionarEsquerda(no.Esquerda);
                return RotacionarDireita(no);
            }

            if (fatorBalanceamento < -1) {
                if (ObterFatorBalanceamento(no.Direita) > 0)
                    no.Direita = RotacionarDireita(no.Direita);
                return RotacionarEsquerda(no);
            }

            return no;
        }

        private No RotacionarDireita(No noDesbalanceado) {
            No novaRaiz = noDesbalanceado.Esquerda;
            noDesbalanceado.Esquerda = novaRaiz.Direita;
            novaRaiz.Direita = noDesbalanceado;

            AtualizarAlturaNo(noDesbalanceado);
            AtualizarAlturaNo(novaRaiz);

            return novaRaiz;
        }

        private No RotacionarEsquerda(No noDesbalanceado) {
            No novaRaiz = noDesbalanceado.Direita;
            noDesbalanceado.Direita = novaRaiz.Esquerda;
            novaRaiz.Esquerda = noDesbalanceado;

            AtualizarAlturaNo(noDesbalanceado);
            AtualizarAlturaNo(novaRaiz);

            return novaRaiz;
        }

        public void ImprimirVisualTradicional() {
            int altura = ObterAltura(raiz);
            int largura = (int)Math.Pow(2, altura + 1);
            var linhas = new List<string>();
            MontarVisualTradicional(raiz, 0, largura / 2, largura / 2, altura, linhas);

            foreach (var linha in linhas)
                Console.WriteLine(linha);
        }

        private void MontarVisualTradicional(No no, int nivel, int pos, int espaco, int altura, List<string> linhas) {
            if (linhas.Count <= nivel)
                linhas.Add(new string(' ', (int)Math.Pow(2, altura + 2)));

            if (no == null)
                return;

            char[] linha = linhas[nivel].ToCharArray();
            string valorStr = no.Valor.ToString();
            for (int i = 0; i < valorStr.Length && (pos + i) < linha.Length; i++)
                linha[pos + i] = valorStr[i];

            linhas[nivel] = new string(linha);

            int deslocamento = espaco / 2;
            MontarVisualTradicional(no.Esquerda, nivel + 1, pos - deslocamento, deslocamento, altura, linhas);
            MontarVisualTradicional(no.Direita, nivel + 1, pos + deslocamento, deslocamento, altura, linhas);
        }

    }
}
