using APOO_MA1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOO_MA1.Estrutura_Mets;
public class Grafo {

    // Dicionario que armazena os vértisces do grafo
    public Dictionary<int, Vertice> Dictonaryvertices;

    // Lista de todas as arestas do grafo
    public List<Aresta> ListArestas;

    // Construtor que inicializa o grafo com dicionario e lista vazias
    public Grafo() {
        Dictonaryvertices = new Dictionary<int, Vertice>();
        ListArestas = new List<Aresta>();
    }

    // Insere um novo vértice no grafo e retona ele
    public Vertice InsertVertex(int id, string valor) {
        var vertice = new Vertice(id, valor);
        Dictonaryvertices[id] = vertice;
        return vertice;
    }

    // Cria uma nova aresta entre dois vértices se eles existirem
    public Aresta InsertEdge(int origem, int destino, int peso) {

        if (!Dictonaryvertices.ContainsKey(origem) || !Dictonaryvertices.ContainsKey(destino))
            throw new Exception("Vértice não encontrado");

        var aresta = new Aresta(Dictonaryvertices[origem], Dictonaryvertices[destino], peso);
        Dictonaryvertices[origem].ListArestas.Add(aresta);
        Dictonaryvertices[destino].ListArestas.Add(aresta);
        ListArestas.Add(aresta);
        return aresta;
    }

    // Remove um vértice do grafo e suas respectivas aretas
    public void RemoveVertex(int id) {
        if (!Dictonaryvertices.ContainsKey(id))
            return;

        Vertice vertice = Dictonaryvertices[id];
        foreach (var aresta in vertice.ListArestas) {
            ListArestas.Remove(aresta);
        }
        Dictonaryvertices.Remove(id);
    }

    // Remove uma areta especifica do grafo
    public void RemoveEdge(Aresta a) {
        a.Origem.ListArestas.Remove(a);
        a.Destino.ListArestas.Remove(a);
        ListArestas.Remove(a);
    }

    // Retorna os dois vertces finais de uma aresta
    public (Vertice, Vertice) EndVertices(Aresta a) {
        return (a.Origem, a.Destino);
    }

    // Retorna o vértcie oposto de uma aresta em relação a um vértice dado
    public Vertice Opposite(Vertice v, Aresta a) {
        return a.Origem == v ? a.Destino : a.Origem;
    }

    // Verifica se dois vérticis são adjacentes no grafo
    public bool AreAdjacente(Vertice v, Vertice p) {
        return v.ListArestas.Exists(a => a.Origem == p || a.Destino == p);
    }

    // Substitue o valor de um vérticie
    public void ReplaceVertex(Vertice v, string novoValor) {
        v.Valor = novoValor;
    }

    // Altera o peso de uma aresta
    public void ReplaceEdge(Aresta a, int novoPeso) {
        a.Peso = novoPeso;
    }

    // Retorna o valor (peso) da aresta
    public int EdgeValue(Aresta a) {
        return a.Peso;
    }

    // Retorna o valor do vértcie
    public string VertexValue(Vertice v) {
        return v.Valor;
    }
}
