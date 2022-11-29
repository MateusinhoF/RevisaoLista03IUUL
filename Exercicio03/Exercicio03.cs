using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio03
{
    public class Exercicio03
    {
        public static void Main(string[] args)
        {
            for (int n = 1; n <= 10000; n++)
            {
                if(n.IsAmstrong())
                {
                    Console.WriteLine(n);
                }
            }
        }
    }
}
