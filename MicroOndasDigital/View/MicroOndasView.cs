using MicroOndasDigital.Service;
using System;

namespace MicroOndasDigital.View
{
    public class MicroOndasView
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("BEM-VINDO AO MICRO-ONDAS DIGITAL \n");
            MicroOndasService MicroOndas;
            if (AjusteRapido())
            {
                MicroOndas = new MicroOndasService();
            }
            else
            {
                int Tempo = PerguntarTempo();
                int Potencia = PerguntarPotencia();
                MicroOndas = new MicroOndasService($"{Tempo};{Potencia}");
            }
            MicroOndas.Cozinhar();
            Console.ReadKey();
        }

        private static bool AjusteRapido()
        {
            Console.WriteLine("Aperte uma tecla para ajustar o micro-ondas, ou aperte [R] para o Início Rápido: ");
            string tecla = Console.ReadLine();
            return tecla.ToLower() == "r";
        }

        private static int PerguntarPotencia()
        {
            while (true)
            {
                Console.WriteLine("Digite uma Potência: ");
                try
                {
                    return MicroOndasService.PotenciaValida(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static int PerguntarTempo()
        {
            while (true)
            {
                Console.WriteLine("Digite um tempo: ");
                try
                {
                    return MicroOndasService.TempoValido(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
