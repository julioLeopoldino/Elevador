using Elevador.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;



class Program
{
    static void Main(string[] args)
    {
        var elevadorFactory = new ElevadorFactory();
        var elevador = elevadorFactory.GerarElevador();
        while(true)
        {
            elevador.SelecionarQtdPassageiros();
            elevador.Menu();
            elevador.Destino();
        }
        
    }
}
