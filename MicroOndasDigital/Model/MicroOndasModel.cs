namespace MicroOndasDigital.Model
{
    public class MicroOndasModel
    {
        public int Tempo { get; private set; }
        public int Potencia { get; private set; }

        //CONSTRUTOR
        public MicroOndasModel(int Tempo, int Potencia)
        {
            this.Tempo = Tempo;
            this.Potencia = Potencia;
        }

    }

}
