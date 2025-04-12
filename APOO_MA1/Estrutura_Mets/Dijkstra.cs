using APOO_MA1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOO_MA1.Estrutura_Mets;
public class Dijkstra {

    // Metodo estatico que calcula o menor caminho entre dois vértices usando o algoritimo de Dijkstra
    public static (List<int> caminho, int custo) CalcularMenorCaminho(Grafo grafo, int origem, int destino) {

        // Dicionario para armzenar as distâncias mínimas de cada vértice até a origem
        var distancias = new Dictionary<int, int>();

        // Dicionario para guardar o verticie anterior de cada um no camminho
        var anteriores = new Dictionary<int, int>();

        // Lista com todos os vértices que ainda não foram visitados
        var naoVisitados = new List<int>();

        // Inicializa as distâncias como infinito e adiciona os vértices à lista de não visitados
        foreach (var vertice in grafo.Dictonaryvertices) {
            distancias[vertice.Key] = int.MaxValue;
            naoVisitados.Add(vertice.Key);
        }

        // A distância da origem para ela mesma é zero
        distancias[origem] = 0;

        // Loop até que todos os vérticis sejam visitados
        while (naoVisitados.Count > 0) {

            // Seleciona o vértcie não visitado com menor distãncia até agora
            int atual = naoVisitados.OrderBy(x => distancias[x]).First();
            naoVisitados.Remove(atual);

            // Se chegarmos ao destino, podemos parar
            if (atual == destino)
                break;

            // Para cada aresta ligada ao vértice atual
            foreach (var aresta in grafo.Dictonaryvertices[atual].ListArestas) {

                // Pega o vizinho do vértce atual na aresta
                int vizinho = (aresta.Origem.Id == atual) ? aresta.Destino.Id : aresta.Origem.Id;

                // Calcula a nova distância até esse vizinho
                int novaDistancia = distancias[atual] + aresta.Peso;

                // Se a nova distância for menor, atualiza a distância e o anterior
                if (novaDistancia < distancias[vizinho]) {
                    distancias[vizinho] = novaDistancia;
                    anteriores[vizinho] = atual;
                }
            }
        }

        // Se o destino não tiver anterior, então não há camminho
        if (!anteriores.ContainsKey(destino))
            return (new List<int>(), -1);

        // Reconstrói o camminho a partir do destino até a origem
        List<int> caminho = new List<int>();
        int custo = distancias[destino];

        for (int at = destino; at != origem; at = anteriores[at]) {
            caminho.Insert(0, at);
        }
        caminho.Insert(0, origem);

        // Retorna o caminho e o custo total
        return (caminho, custo);
    }
}
