namespace dotnet_mongodb_zoologico.Data.Collections
{
    public class Leao : Animal
    {
        public Leao(string nome, string sexo, int idade, double peso, string pelagem) : base(nome, sexo, idade, peso)
        {
            this.tipo = "leão";
            this.alimento = "carne";
            this.pelagem = pelagem;
        }

        public string pelagem {get; set;}

    }
}