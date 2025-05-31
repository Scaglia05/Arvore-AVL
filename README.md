# 🌳 Projeto: Árvore AVL em C#

## ✅ Descrição
Este projeto implementa uma **Árvore AVL** (Adelson-Velsky and Landis) — uma árvore binária de busca autobalanceada — utilizando a linguagem **C#**.

A aplicação permite:  
- Inserção de valores na árvore.  
- Remoção de valores.  
- Busca de elementos.  
- Impressão da árvore em pré-ordem.  
- Exibição dos fatores de balanceamento de cada nó.  
- Consulta à altura da árvore.

Todos os comandos são lidos a partir de um **arquivo de entrada** contendo uma sequência de operações.

---

## ✅ Estrutura do Projeto

- **NoAVL.cs**: Define o nó da árvore AVL, com atributos de valor, filhos esquerdo e direito e altura.
- **BaseArvoreAVL.cs**: Implementa toda a lógica da árvore AVL: inserção, remoção, balanceamento, rotações, busca, impressão e cálculo de altura.
- **ProcessadorDeComandos.cs**: Responsável por ler o arquivo de entrada, interpretar e executar os comandos.
- **entrada.txt**: Arquivo exemplo de entrada com comandos para manipular a árvore.
- **Program.cs**: (Opcional) Pode ser criado para rodar o `ProcessadorDeComandos`.

---

## ✅ Tecnologias Utilizadas

- ✅ C# (.NET Core ou .NET Framework)  
- ✅ Sistema de arquivos para entrada de comandos

---

## ✅ Como Funciona

1. O usuário fornece um arquivo de texto contendo os comandos.
2. O `ProcessadorDeComandos` lê e executa cada comando sequencialmente.
3. A árvore AVL é manipulada conforme as instruções, garantindo o balanceamento automático.

---

## ✅ Comandos Suportados

| Comando | Descrição |
|---------|----------|
| I x     | Insere o número x na árvore AVL |
| R x     | Remove o número x da árvore AVL |
| B x     | Busca o número x e informa se foi encontrado |
| P       | Imprime a árvore em pré-ordem |
| F       | Exibe o fator de balanceamento de cada nó |
| H       | Mostra a altura da árvore |

---

## ✅ Exemplo de Arquivo de Entrada (`entrada.txt`):

I 10
I 20
I 30
P
I 15
P
R 20
P
B 15
B 25
F
H

---

## ✅ Exemplo de Saída Esperada:

Árvore em pré-ordem: 20 10 30
Árvore em pré-ordem: 20 10 15 30
Árvore em pré-ordem: 15 10 30
Valor encontrado
Valor não encontrado
Fatores de balanceamento:
Nó 15: Fator de balanceamento 0
Nó 10: Fator de balanceamento 0
Nó 30: Fator de balanceamento 0
Altura da árvore: 2


## ✅ Como Usar

### 1️⃣ Pré-requisitos

- Ter o **.NET SDK** instalado.  
Para verificar:  
```bash

2️⃣ Clonar o repositório
bash
Copy
Edit

3️⃣ Criar o arquivo de entrada
Crie um arquivo chamado entrada.txt com os comandos desejados, ou utilize o modelo de exemplo.
dotnet --version
git clone https://github.com/seu-usuario/arvore-avl-csharp.git
cd arvore-avl-csharp

✅ Estrutura de Pastas Sugerida
/ArvoreAVL
  /Model
    - BaseArvoreAVL.cs
    - NoAVL.cs
    - ProcessadorDeComandos.cs
  - Program.cs
  - entrada.txt
  - ArvoreAVL.csproj
  - README.md

✅ Observações
A AVL garante que a árvore permaneça balanceada após cada inserção ou remoção.
A saída pode variar conforme as rotações aplicadas.
Muito útil para estudar conceitos de estrutura de dados e algoritmos!
