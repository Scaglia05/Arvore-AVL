using ArvoreAVL.Model;
using System;
using System.IO;
using System.Linq;

namespace ArvoreAVL {
    class Program {
        static void Main(string[] args) {
            var arvore = new Arvore_AVL();

            Console.WriteLine("Digite o caminho completo do arquivo .txt com os valores:");
            string caminhoArquivo = Console.ReadLine();

            if (!File.Exists(caminhoArquivo)) {
                Console.WriteLine($"\nArquivo '{caminhoArquivo}' não encontrado.");
                return;
            }

            try {
                string conteudo = File.ReadAllText(caminhoArquivo);

                var valores = conteudo
                    .Split(new[] { ' ', ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                // Exibe os valores lidos do arquivo
                Console.WriteLine($"\nValores lidos do arquivo. Quantidade: ({valores.Count}):");
                Console.WriteLine(string.Join(" ", valores));

                foreach (int valor in valores) {
                    arvore.Inserir(valor);
                }

                Console.WriteLine("\nExibindo a árvore AVL no formato solicitado:");
                arvore.ImprimirVisualTradicional();

            } catch (Exception ex) {
                Console.WriteLine("\nErro ao ler ou processar o arquivo:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
