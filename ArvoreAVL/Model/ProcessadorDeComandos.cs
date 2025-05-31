
using System;
using System.IO;

using System;
using System.Collections.Generic;
using System.IO;

namespace ArvoreAVL.Model {
    public class ProcessadorDeComandos {
        private List<(string instrucao, string argumento)> operacoes = new List<(string, string)>();
        private BaseArvoreAVL arvore;

        public ProcessadorDeComandos() {
            arvore = new BaseArvoreAVL();
        }

        // Método para obter caminho do arquivo
        public string ObterCaminhoArquivo() {
            Console.Write("Por favor, informe o caminho do arquivo de entrada (pressione ENTER para 'entrada.txt'): ");
            string entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada)) {
                Console.WriteLine("Usando 'entrada.txt' como padrão.");
                return "entrada.txt";
            }

            return entrada.Trim();
        }

        // Método para ler o arquivo e armazenar comandos
        public void CarregarComandos(string caminhoArquivo) {
            if (!File.Exists(caminhoArquivo)) {
                throw new FileNotFoundException($"Arquivo '{caminhoArquivo}' não encontrado.");
            }

            string[] linhas = File.ReadAllLines(caminhoArquivo);

            foreach (string linha in linhas) {
                ParseLinha(linha);
            }
        }

        // Método para parsear linha e armazenar comando e argumento
        private void ParseLinha(string linha) {
            if (string.IsNullOrWhiteSpace(linha) ||
                linha.TrimStart().StartsWith("#") ||
                linha.TrimStart().StartsWith("//")) {
                return; // Ignorar comentários e linhas vazias
            }

            string[] partes = linha.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length == 0)
                return;

            string comando = partes[0].ToUpper();
            string argumento = partes.Length > 1 ? partes[1] : "";

            // Para comandos P, F, H ignoramos argumentos
            if (comando == "P" || comando == "F" || comando == "H") {
                operacoes.Add((comando, ""));
            } else if (comando == "I" || comando == "R" || comando == "B") {
                operacoes.Add((comando, argumento));
            }
            // comandos inválidos são ignorados
        }

        // Método para executar todos os comandos armazenados
        public void ExecutarComandos() {
            foreach (var (instrucao, argumento) in operacoes) {
                switch (instrucao) {
                    case "I":
                        if (int.TryParse(argumento, out int valorInserir)) {
                            arvore.Inserir(valorInserir);
                        }
                        break;

                    case "R":
                        if (int.TryParse(argumento, out int valorRemover)) {
                            arvore.Remover(valorRemover);
                        }
                        break;

                    case "B":
                        if (int.TryParse(argumento, out int valorBuscar)) {
                            bool encontrado = arvore.Buscar(valorBuscar);
                            Console.WriteLine(encontrado ? "Valor encontrado" : "Valor não encontrado");
                        }
                        break;

                    case "P":
                        arvore.ImprimirPreOrdem();
                        break;

                    case "F":
                        arvore.ImprimirFatoresDeBalanceamento();
                        break;

                    case "H":
                        Console.WriteLine($"Altura da árvore: {arvore.AlturaArvore()}");
                        break;

                    default:
                        // Ignorar comandos inválidos
                        break;
                }
            }
        }
    }
}
