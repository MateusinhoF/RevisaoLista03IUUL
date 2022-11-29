namespace Exercicio01
{
    public class Pessoa
    {
        public string Nome { get; set; }

        public long Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public float RendaMensal { get; set; }

        public char EstadoCivil { get; set; }

        public int Dependentes { get; set; }

        public Pessoa(string nome, long cpf, DateTime dataNascimento, float rendaMensal, char estadoCivil, int dependentes)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            RendaMensal = rendaMensal;
            EstadoCivil = estadoCivil;
            Dependentes = dependentes;
        }

    }
}