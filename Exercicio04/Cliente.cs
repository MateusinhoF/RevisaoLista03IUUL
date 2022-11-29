using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio04
{
    public class Cliente
    {
        public string Nome { get; set; }

        public long Cpf { get; set; }


        public Cliente(string nome, long cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente && this.Nome == cliente.Nome && this.Cpf == cliente.Cpf;
        }
    }
}
