using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio04
{
    public class Exercicio04
    {
        public static void Main(string[] args)
        {

            List<int> numeros = new List<int>();
            List<string> palavras = new List<string>();
            List<Cliente> clientes = new List<Cliente>();

            numeros.Add(1);
            numeros.Add(2);
            numeros.Add(3);
            numeros.Add(4);
            numeros.Add(4);

            palavras.Add("banana");
            palavras.Add("chinelo");
            palavras.Add("chinelo");
            palavras.Add("mamão");
            palavras.Add("coruja");

            clientes.Add(new Cliente("jose", 123456));
            clientes.Add(new Cliente("jose",123456));
            clientes.Add(new Cliente("ana",123456));
            clientes.Add(new Cliente("claudio",65713));
            clientes.Add(new Cliente("antunes",645398));

            Console.WriteLine("imprimindo valores ANTES da exclusão");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Numero " + numeros[i]);
                Console.WriteLine("Palavra " + palavras[i]);
                Console.WriteLine("Cliente nome " + clientes[i].Nome + " cpf " + clientes[i].Cpf);
            }

            numeros.RemoveRepetidos();
            palavras.RemoveRepetidos();
            clientes.RemoveRepetidos<Cliente>();
            Console.WriteLine("\n\n");
            Console.WriteLine("imprimindo valores DEPOIS da exclusão");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Numero " + numeros[i]);
                Console.WriteLine("Palavra " + palavras[i]);
                Console.WriteLine("Cliente nome " + clientes[i].Nome + " cpf " + clientes[i].Cpf);
            }
        }
    }
}
