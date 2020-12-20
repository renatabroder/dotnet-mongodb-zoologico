namespace dotnet_mongodb_zoologico.Data.Collections
{
    public abstract class Animal
    {
        public Animal(string nome, string sexo, int idade, double peso)
        {
            this.nome = nome;
            this.sexo = sexo;
            this.idade = idade;
            this.peso = peso;
        }

        public string nome {get; set;}
        public string sexo {get; set;}
        public int idade {get; set;}
        public double peso {get; set;}
        public string tipo {get; set;}
        public string alimento {get; set;}

    }
}