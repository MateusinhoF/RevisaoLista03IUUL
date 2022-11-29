namespace Exercicio04
{
    public static class Removedor
    {
        public static List<T> RemoveRepetidos<T>(this List<T> listaGenerica)
        {
            for(int i = 0; i < listaGenerica.Count; i++)
            {
                for(int t = 0; t < listaGenerica.Count; t++)
                {
                    if (t != i)
                    {
                        if (listaGenerica[t].Equals(listaGenerica[i]))
                        {
                            listaGenerica.RemoveAt(t);
                        }
                    }
                }
            }
            return listaGenerica;
        }
    }
}