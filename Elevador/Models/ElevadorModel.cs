using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevador.Models
{
    public class ElevadorModel
    {
        public ElevadorModel(int andarTotal, int capacidade, int quantidadePassageiros, string status, List<int> rota, int andarAtual){ 
            AndarTotal = andarTotal;
            Capacidade = capacidade;
            QuantidadePassageiros = quantidadePassageiros;
            Status = status;
            Rota = rota;
            AndarAtual = andarAtual;   
        }

        public int AndarTotal { get; set; }
        public int Capacidade { get; set; }
        public int QuantidadePassageiros { get; set; }
        public string Status { get; set; }
        public List<int> Rota { get; set; }
        public int AndarAtual { get; set; }

        public void Menu()
        {
            Console.WriteLine("Qual andar você deseja ir?");
            Console.WriteLine("0 - Terreo");
            Console.WriteLine("1 - Primeiro andar");
            Console.WriteLine("2 - Segundo andar");
            Console.WriteLine("3 - Terceiro andar");
            Console.WriteLine("4 - Quarto andar");
            Console.WriteLine("5 - Quinto andar");
            Console.WriteLine("6 - Sexto andar");
            Console.WriteLine("7 - Sétimo andar");
            Console.WriteLine("8 - Oitavo andar");
            Console.WriteLine("9 - Nono andar");
            Console.WriteLine("10 - Décimo andar");
            var andar = int.Parse(Console.ReadLine());
            if (andar < 0 || andar > 10)
                throw new ArgumentException("Andar digitado inválido");

            Rota.Add(andar);
            
            if (Rota.Count < QuantidadePassageiros)
            {
                Console.WriteLine("Deseja adicionar mais um andar?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                var addAndar = int.Parse(Console.ReadLine());

                if (addAndar == 1) Menu();
            }
        }
        public void Destino()
        {
            while (Rota.Count > 0)
            {
                bool deveSubir = Rota.Any(andar => andar > AndarAtual);

                if (deveSubir)
                    Rota = Rota.OrderBy(x => x).ToList();

                else
                    Rota = Rota.OrderByDescending(x => x).ToList();

                
                var rotaAtual = new List<int>(Rota);

                foreach (int andarDestino in rotaAtual)
                {
                    if (andarDestino == AndarAtual)
                    {
                        Console.WriteLine($"Elevador já está no andar {andarDestino}.");
                    }
                    else if (andarDestino > AndarAtual)
                    {
                        AlterarAndar(andarDestino, "Subindo");
                    }
                    else
                    {
                        AlterarAndar(andarDestino, "Descendo");
                    }

                    Rota.Remove(andarDestino);
                }
                QuantidadePassageiros = 0;

            }
           
        }

            public void Porta()
            {
                if (Status == "Parado")
                {
                    Console.WriteLine("Porta aberta");
                    Thread.Sleep(1500);
                }
                if (Status == "Subindo" || Status == "Descendo")
                {
                    Console.WriteLine("Porta fechada");
                    Thread.Sleep(1500);
                }
            }

            void AlterarAndar(int andarDestino, string status)
            {
                Status = status;
                Porta();
                Console.WriteLine(Status);
                Thread.Sleep(2000);
                Status = "Parado";
                AndarAtual = andarDestino;
                Console.WriteLine("Parando...");
                Thread.Sleep(1000);
                Porta();
                Console.WriteLine(Status);
                Console.WriteLine($"Você está no {AndarAtual}º andar");
            }
            public void SelecionarQtdPassageiros()
            {
                Console.WriteLine("Quantos passageiros há dentro do elevador? ");
                var qtd_passageiros = int.Parse(Console.ReadLine());
                if(qtd_passageiros > Capacidade)
                    throw new ArgumentException($"Quantidade de passageiros superior a capacidade de {Capacidade}");
                QuantidadePassageiros = qtd_passageiros;
            }
            
      }

  }
