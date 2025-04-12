using APOO_MA1.Classes;
using APOO_MA1.Estrutura_Mets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program {
    static void Main(string[] args) {
        Console.Write("Caminho do arquivo do grafo (.txt): ");
        string caminho = Console.ReadLine();

        if (!File.Exists(caminho)) {
            Console.WriteLine("Arquivo não encontrado.");
            return;
        }

        var grafo = CarregarGrafo(caminho);

        while (true) {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Ver grafo");
            Console.WriteLine("2. Menor caminho (Dijkstra)");
            Console.WriteLine("3. Inserir vértice");
            Console.WriteLine("4. Remover vértice");
            Console.WriteLine("5. Inserir aresta");
            Console.WriteLine("6. Remover aresta");
            Console.WriteLine("7. Substituir valor de vértice");
            Console.WriteLine("8. Substituir peso de aresta");
            Console.WriteLine("9. Vértices finais de um vértice (EndVertices)");
            Console.WriteLine("10. Vértice oposto (Opposite)");
            Console.WriteLine("11. Verificar adjacência (AreAdjacente)");
            Console.WriteLine("12. Ver valor da aresta");
            Console.WriteLine("13. Ver valor do vértice");
            Console.WriteLine("14. Sair");
            Console.Write("Opção: ");

            switch (Console.ReadLine()) {
                case "1": ExibirGrafo(grafo); break;
                case "2": CalcularDijkstra(grafo); break;
                case "3": InserirVertice(grafo); break;
                case "4": RemoverVertice(grafo); break;
                case "5": InserirAresta(grafo); break;
                case "6": RemoverAresta(grafo); break;
                case "7": SubstituirValorVertice(grafo); break;
                case "8": SubstituirPesoAresta(grafo); break;
                case "9": MostrarEndVertices(grafo); break;
                case "10": MostrarOpposto(grafo); break;
                case "11": VerificarAdjacencia(grafo); break;
                case "12": MostrarValorAresta(grafo); break;
                case "13": MostrarValorVertice(grafo); break;
                case "14": return;
                default: Console.WriteLine("Opção inválida."); break;
            }
        }
    }

    static Grafo CarregarGrafo(string caminho) {
        var linhas = File.ReadAllLines(caminho);
        var grafo = new Grafo();
        int qtd = int.Parse(linhas[0]);

        for (int i = 0; i < qtd; i++)
            grafo.InsertVertex(i, $"V{i}");

        foreach (var linha in linhas.Skip(1)) {
            var partes = linha.Split(' ');
            if (partes.Length == 3)
                grafo.InsertEdge(int.Parse(partes[0]), int.Parse(partes[1]), int.Parse(partes[2]));
        }

        return grafo;
    }

    static void ExibirGrafo(Grafo grafo) {
        Console.WriteLine("\nVértices:");
        foreach (var v in grafo.Dictonaryvertices.Values)
            Console.WriteLine($"[{v.Id}] {v.Valor}");

        Console.WriteLine("Arestas:");
        foreach (var a in grafo.ListArestas)
            Console.WriteLine($"{a.Origem.Id} --({a.Peso})--> {a.Destino.Id}");
    }

    static void CalcularDijkstra(Grafo grafo) {
        Console.Write("Origem: ");
        int origem = int.Parse(Console.ReadLine());
        Console.Write("Destino: ");
        int destino = int.Parse(Console.ReadLine());

        var (caminho, custo) = Dijkstra.CalcularMenorCaminho(grafo, origem, destino);

        if (custo == -1)
            Console.WriteLine("Caminho não encontrado.");
        else {
            Console.WriteLine("Caminho: " + string.Join(" -> ", caminho));
            Console.WriteLine($"Custo total: {custo}");
        }
    }

    static void InserirVertice(Grafo grafo) {
        Console.Write("ID do vértice: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Valor do vértice: ");
        string valor = Console.ReadLine();
        grafo.InsertVertex(id, valor);
        Console.WriteLine($"Vértice {valor} inserido com sucesso!");
    }

    static void RemoverVertice(Grafo grafo) {
        Console.Write("ID do vértice a ser removido: ");
        int id = int.Parse(Console.ReadLine());
        grafo.RemoveVertex(id);
        Console.WriteLine($"Vértice {id} removido com sucesso!");
    }

    static void InserirAresta(Grafo grafo) {
        Console.Write("Origem (ID do vértice): ");
        int origem = int.Parse(Console.ReadLine());
        Console.Write("Destino (ID do vértice): ");
        int destino = int.Parse(Console.ReadLine());
        Console.Write("Peso da aresta: ");
        int peso = int.Parse(Console.ReadLine());
        try {
            grafo.InsertEdge(origem, destino, peso);
            Console.WriteLine("Aresta inserida com sucesso!");
        } catch (Exception ex) {
            Console.WriteLine($"Erro ao inserir aresta: {ex.Message}");
        }
    }

    static void RemoverAresta(Grafo grafo) {
        Console.Write("Origem (ID do vértice): ");
        int origem = int.Parse(Console.ReadLine());
        Console.Write("Destino (ID do vértice): ");
        int destino = int.Parse(Console.ReadLine());

        var aresta = grafo.ListArestas.FirstOrDefault(a => a.Origem.Id == origem && a.Destino.Id == destino);
        if (aresta != null) {
            grafo.RemoveEdge(aresta);
            Console.WriteLine("Aresta removida com sucesso!");
        } else {
            Console.WriteLine("Aresta não encontrada.");
        }
    }

    static void SubstituirValorVertice(Grafo grafo) {
        Console.Write("ID do vértice: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Novo valor para o vértice: ");
        string novoValor = Console.ReadLine();

        if (grafo.Dictonaryvertices.ContainsKey(id)) {
            grafo.ReplaceVertex(grafo.Dictonaryvertices[id], novoValor);
            Console.WriteLine("Valor do vértice atualizado com sucesso!");
        } else {
            Console.WriteLine("Vértice não encontrado.");
        }
    }

    static void SubstituirPesoAresta(Grafo grafo) {
        Console.Write("Origem (ID do vértice): ");
        int origem = int.Parse(Console.ReadLine());
        Console.Write("Destino (ID do vértice): ");
        int destino = int.Parse(Console.ReadLine());
        Console.Write("Novo peso da aresta: ");
        int novoPeso = int.Parse(Console.ReadLine());

        var aresta = grafo.ListArestas.FirstOrDefault(a => a.Origem.Id == origem && a.Destino.Id == destino);
        if (aresta != null) {
            grafo.ReplaceEdge(aresta, novoPeso);
            Console.WriteLine("Peso da aresta atualizado com sucesso!");
        } else {
            Console.WriteLine("Aresta não encontrada.");
        }
    }

    static void MostrarEndVertices(Grafo grafo) {
        Console.Write("ID da aresta (origem destino): ");
        int origem = int.Parse(Console.ReadLine());
        int destino = int.Parse(Console.ReadLine());

        var aresta = grafo.ListArestas.FirstOrDefault(a => a.Origem.Id == origem && a.Destino.Id == destino);
        if (aresta != null) {
            var (v1, v2) = grafo.EndVertices(aresta);
            Console.WriteLine($"Vértices finais: {v1.Id} e {v2.Id}");
        } else {
            Console.WriteLine("Aresta não encontrada.");
        }
    }

    static void MostrarOpposto(Grafo grafo) {
        Console.Write("ID do vértice: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("ID da aresta (origem destino): ");
        int origem = int.Parse(Console.ReadLine());
        int destino = int.Parse(Console.ReadLine());

        var aresta = grafo.ListArestas.FirstOrDefault(a => a.Origem.Id == origem && a.Destino.Id == destino);
        if (aresta != null && grafo.Dictonaryvertices.ContainsKey(id)) {
            var oposto = grafo.Opposite(grafo.Dictonaryvertices[id], aresta);
            Console.WriteLine($"Vértice oposto: {oposto.Id}");
        } else {
            Console.WriteLine("Aresta ou vértice não encontrados.");
        }
    }

    static void VerificarAdjacencia(Grafo grafo) {
        Console.Write("ID do primeiro vértice: ");
        int id1 = int.Parse(Console.ReadLine());
        Console.Write("ID do segundo vértice: ");
        int id2 = int.Parse(Console.ReadLine());

        bool adjacente = grafo.AreAdjacente(grafo.Dictonaryvertices[id1], grafo.Dictonaryvertices[id2]);
        Console.WriteLine(adjacente ? "Vértices são adjacentes." : "Vértices não são adjacentes.");
    }

    static void MostrarValorAresta(Grafo grafo) {
        Console.Write("Origem (ID do vértice): ");
        int origem = int.Parse(Console.ReadLine());
        Console.Write("Destino (ID do vértice): ");
        int destino = int.Parse(Console.ReadLine());

        var aresta = grafo.ListArestas.FirstOrDefault(a =>
            (a.Origem.Id == origem && a.Destino.Id == destino) ||
            (a.Origem.Id == destino && a.Destino.Id == origem)); 

        if (aresta != null) {
            int peso = grafo.EdgeValue(aresta); 
            Console.WriteLine($"Valor (peso) da aresta: {peso}");
        } else {
            Console.WriteLine("Aresta não encontrada.");
        }
    }


    static void MostrarValorVertice(Grafo grafo) {
        Console.Write("ID do vértice: ");
        int id = int.Parse(Console.ReadLine());

        if (grafo.Dictonaryvertices.TryGetValue(id, out var vertice)) {
            string valor = grafo.VertexValue(vertice);
            Console.WriteLine($"Valor do vértice: {valor}");
        } else {
            Console.WriteLine("Vértice não encontrado.");
        }
    }

}
