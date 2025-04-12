using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOO_MA1.Classes;
public class Aresta {

    public Vertice Origem { get; set; }
    public Vertice Destino { get; set; }    
    public int Peso { get; set; }   

    public Aresta(Vertice origem, Vertice destino, int peso) {
        Origem = origem;
        Destino = destino;
        Peso = peso;
    }
}

