using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elevador.Models;


namespace Elevador.Factories
{
    public class ElevadorFactory
    {
        public ElevadorFactory() { }

        public ElevadorModel GerarElevador()
        {
           var quantidadePassageiros = 0;
           var andarTotal = 10;
           var capacidade = 5;
           var status = "Parado";
           var rota = new List<int>();
           var andarAtual = 0;


            return new ElevadorModel(andarTotal, capacidade, quantidadePassageiros, status, rota, andarAtual);
        }
    }
}
