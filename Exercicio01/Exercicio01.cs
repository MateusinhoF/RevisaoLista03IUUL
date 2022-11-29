using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    public class Exercicio01
    {
        public static void Main(String[] args)
        {
            ServicePessoa servicePessoa = new ServicePessoa("../../../../../Unidade 1 - Exercicios - Parte 3/clientes.json");
            List<Pessoa> pessoas = servicePessoa.iniciarLeitura();
        }
    }
}
