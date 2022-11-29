namespace Exercicio03
{
    public static class Amstrong
    {
        public static bool IsAmstrong(this int numero)
        {
            if(numero.ToString().Length == 1) return true;
            
            int expoente = numero.ToString().Length;
            string nString = numero.ToString();

            //153 = 1^3 + 5^3 + 3^3
            List<int> listNumero = new List<int>();
            for (int i = 1; i <= expoente; i++)
            {
                int resultado = 1;
                for(int j = 1;j <= expoente; j++)
                {
                    resultado *= int.Parse(nString.Substring(i-1, 1));
                }
                listNumero.Add(resultado);
            }

            int resultadoSomatoria = 0;
            foreach(int i in listNumero)
            {
                resultadoSomatoria += i;
            }

            if(resultadoSomatoria == numero) return true; 

            return false;
        }
    }
}