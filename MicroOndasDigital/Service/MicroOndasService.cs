using MicroOndasDigital.Model;
using System;
using System.Threading;

namespace MicroOndasDigital.Service

{
    public class MicroOndasService
    {
        private readonly MicroOndasModel Ajustes;

        public MicroOndasService(string args = null)
        {
            if (string.IsNullOrWhiteSpace(args))
                args = "30;8";
            string[] ms = args.Split(';');
            //QUEBRANDO A STRING args, FAZENDO COM QUE O PROGRAMA ENTENDA QUE É UM SEPARADOR.
            this.Ajustes = new MicroOndasModel(int.Parse(ms[0]), int.Parse(ms[1] ?? "10"));
        }

        //MÉTODO QUE VALIDA O TEMPO.
        public static int TempoValido(string TempoStr)
        {
            int Tempo;
            if (!int.TryParse(TempoStr, out Tempo))
            {
                throw new Exception("Por favor, Digite um tempo valido.");
            }
            if (!(Tempo < 1 || Tempo > 120))
            {
                return Tempo;
            }
            throw new Exception("Insira um tempo entre 1(um) segundo e 120 segundos(2 minutos).");
        }

        //MÉTODO QUE VALIDA A POTÊNCIA.
        public static int PotenciaValida(string PotenciaStr)
        {
            int Potencia;
            //SE A POTÊNCIA FOR NULLA, INCLUIRÁ O NÍVEL 10 AUTOMATICAMENTE. 
            if (!int.TryParse(PotenciaStr, out Potencia))
            {
                Potencia = 10;
            }
            if (!(Potencia < 1 || Potencia > 10))
            {
                return Potencia;
            }
            throw new Exception("Insira uma potência entre o nível 1 e 10.");
        }

        //MÉTODO QUE ADICIONA O TEMPO E OS PONTOS DE ACORDO COM O PARÂMETRO.
        public void Cozinhar()
        {
            for (int i = 0; i < Ajustes.Tempo; i++)
            {
                Console.WriteLine($"Tempo: {(Ajustes.Tempo - i).ToString("000")} - {Aquecer(Ajustes.Potencia, "")}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Aquecida");
        }

        //MÉTODO QUE REALIZA A FUNÇÃO RECURSIVA PARA ADICIONAR OS PONTOS.
        private string Aquecer(int Potencia, string Alimento)
        {
            if (Potencia == 0)
                return $"{Alimento} ";
            return Aquecer(Potencia - 1, $"{Alimento}.");
        }
    }
}