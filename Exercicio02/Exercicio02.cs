using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio02
{
    public class Exercicio02
    {

        public static void Main(string[] args)
        {
            string txt = "../../../../../Unidade 1 - Exercicios - Parte 3/texto.txt";
            string ignore = "../../../../../Unidade 1 - Exercicios - Parte 3/ignore.txt";
            IndiceRemissivo ir = new IndiceRemissivo(txt, ignore);

            Console.WriteLine("Imprimindo palavras");
            ir.imprime();
        }
    }
}
