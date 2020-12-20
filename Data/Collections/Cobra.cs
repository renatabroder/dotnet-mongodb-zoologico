namespace dotnet_mongodb_zoologico.Data.Collections
{
    public class Cobra: Animal
    {
        public Cobra(string nome, string sexo, int idade, double peso, string especie, bool venenosa) : base(nome, sexo, idade, peso)
        {
            this.tipo = "cobra";
            this.alimento = "carne";
            this.especie = especie;
            this.venenosa = venenosa;
        }

        public string especie {get; set;}
        public bool venenosa {get; set;}

    }
}