using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOO_MA1.Classes;
public class Vertice {

    public int Id { get; set; }
    public string Valor { get; set; }
    public List<Aresta> ListArestas { get; set; }

    public Vertice(int id, string valor) {
        Id = id;
        Valor = valor;
        ListArestas = new List<Aresta>();
    }
}

