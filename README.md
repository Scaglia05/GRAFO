# Manipulação de Grafos

Este projeto implementa uma aplicação para manipulação e análise de grafos, permitindo a visualização e a realização de diversas operações, como a inserção e remoção de vértices e arestas, o cálculo do menor caminho entre dois vértices utilizando o algoritmo de Dijkstra, e outras funções para trabalhar com grafos direcionados e ponderados.

## Funcionalidades

- **Visualização do Grafo**: Exibe os vértices e arestas do grafo.
- **Dijkstra**: Calcula o menor caminho entre dois vértices.
- **Inserir/Remover Vértices e Arestas**: Adiciona ou remove vértices e arestas ao grafo.
- **Substituir Valores**: Permite alterar o valor de vértices e o peso das arestas.
- **Vértices Finais (EndVertices)**: Exibe os vértices finais de uma aresta.
- **Vértice Oposto (Opposite)**: Identifica o vértice oposto em relação a uma aresta.
- **Verificar Adjacência (AreAdjacente)**: Verifica se dois vértices são adjacentes.
- **Exibição de Peso de Arestas e Valores de Vértices**: Exibe o peso de uma aresta e o valor de um vértice.

## Requisitos

- .NET 6.0 ou superior

## Como Usar

1. Clone este repositório;
2. Abra o projeto na sua IDE preferida e execute a aplicação.O programa irá solicitar o caminho do arquivo de entrada para carregar o grafo, no formato de um arquivo .txt.
Após carregar o grafo, você pode escolher as operações disponíveis no menu para manipular e analisar o grafo.



# Exemplo de Arquivo de Entrada
O arquivo de entrada deve conter a quantidade de vértices na primeira linha, seguida pelas arestas, onde cada linha contém três valores: ID do vértice de origem, ID do vértice de destino e o peso da aresta. 
Exemplo:

   ```bash
4
0 1 10
1 2 5
2 3 2
0 3 15

