using ArvoreAVL.Model;
using System;

try {
    ProcessadorDeComandos processador = new ProcessadorDeComandos();

    string caminhoArquivo = processador.ObterCaminhoArquivo();

    processador.CarregarComandos(caminhoArquivo);

    processador.ExecutarComandos();
} catch (Exception ex) {
    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
}
