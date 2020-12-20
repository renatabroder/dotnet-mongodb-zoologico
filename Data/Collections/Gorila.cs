namespace dotnet_mongodb_zoologico.Data.Collections
{
    public class Gorila : Animal
    {
        public Gorila(string nome, string sexo, int idade, double peso) : base(nome, sexo, idade, peso)
        {
            this.tipo = "gorila";
            this.alimento = "vegetação";
        }

    }
}