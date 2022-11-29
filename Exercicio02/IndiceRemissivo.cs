using System.Text.RegularExpressions;

namespace Exercicio02
{
    public class IndiceRemissivo
    {
        private string pathTXT;
        public string PathTXT
        {
            get
            {
                return pathTXT;
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new Exception("O valor do pathTXT não pode ser vazio nem nulo");
                }
                pathTXT = value;
            }
        }
        public string pathIgnore { get; set; }

        private List<string> palavrasTXT;
        private List<string> palavrasIgnore;

        public IndiceRemissivo(string pathTXT, string pathIgnore)
        {
            this.PathTXT = pathTXT;
            this.pathIgnore = pathIgnore;
            palavrasTXT = new List<string>();
            palavrasIgnore = new List<string>();
        }

        private void carregaArquivo()
        {
            var linhasTXT = File.ReadAllText(pathTXT);
            string txt = Regex.Replace(linhasTXT, @"[^\w@-]", " ");
            txt = Regex.Replace(txt, @"[\-]", " ");

            string[] txtarray = txt.Split(" ");

            foreach (string t in txtarray)
            {
                if (t.Length > 0 && t != " " && t != "\n")
                { 
                    palavrasIgnore.Add(t);
                }
            }
            

            var linhasIgnore = File.ReadAllText(pathIgnore);
            string ignore = Regex.Replace(linhasIgnore, @"[^\w@-]", " ");
            ignore = Regex.Replace(ignore, @"[\-]", " ");
            
            string[] ignorearray = ignore.Split(" ");
            
            foreach(string i in ignorearray)
            {
                if (i.Length > 0 && i != " " && i != "\n")
                {
                    palavrasIgnore.Add(i);
                }
            }


        }

        private List<Palavra> carregaPalavras()
        {
            List<Palavra> palavras = new List<Palavra>();

            List<string> palavrasTXTAux = palavrasTXT.ToList();
            foreach (string palavra in palavrasTXT)
            {
                if (palavras.Count() > 0)
                {
                    bool encontrado = false;
                    foreach (Palavra p in palavras.ToList())
                    {
                        if (p.getPalavra() == palavra)
                        {
                            p.incrementaQuantidade();
                            p.inserirPosicao(palavrasTXTAux.IndexOf(palavra) + 1);
                            palavrasTXTAux[palavrasTXTAux.IndexOf(palavra)] = "";
                            encontrado = true;
                            break;
                        }
                    }
                    if (!encontrado)
                    {
                        Palavra novaPalavra = new Palavra(palavra);
                        novaPalavra.incrementaQuantidade();
                        novaPalavra.inserirPosicao(palavrasTXTAux.IndexOf(palavra) + 1);
                        palavrasTXTAux[palavrasTXTAux.IndexOf(palavra)] = "";
                        palavras.Add(novaPalavra);

                    }
                }
                else
                {
                    Palavra primeiraPalavra = new Palavra(palavra);
                    primeiraPalavra.incrementaQuantidade();
                    primeiraPalavra.inserirPosicao(palavrasTXTAux.IndexOf(palavra) + 1);
                    palavrasTXTAux[palavrasTXTAux.IndexOf(palavra)] = "";
                    palavras.Add(primeiraPalavra);
                }
            }

            List<string> palavrasIgnoreAux = palavrasIgnore.ToList();
            foreach (string palavra in palavrasIgnore)
            {
                if (palavras.Count() > 0)
                {
                    bool encontrado = false;
                    foreach (Palavra p in palavras.ToList())
                    {
                        if (p.getPalavra() == palavra)
                        {
                            p.incrementaQuantidade();
                            p.inserirPosicao(palavrasIgnoreAux.IndexOf(palavra) + 1);
                            palavrasIgnoreAux[palavrasIgnoreAux.IndexOf(palavra)] = "";
                            encontrado = true;
                            break;
                        }
                    }
                    if (!encontrado)
                    {
                        Palavra novaPalavra = new Palavra(palavra);
                        novaPalavra.incrementaQuantidade();
                        novaPalavra.inserirPosicao(palavrasIgnoreAux.IndexOf(palavra) + 1);
                        palavrasIgnoreAux[palavrasIgnoreAux.IndexOf(palavra)] = "";
                        palavras.Add(novaPalavra);

                    }
                }
                else
                {
                    Palavra primeiraPalavra = new Palavra(palavra);
                    primeiraPalavra.incrementaQuantidade();
                    primeiraPalavra.inserirPosicao(palavrasIgnoreAux.IndexOf(palavra) + 1);
                    palavrasIgnoreAux[palavrasIgnoreAux.IndexOf(palavra)] = "";
                    palavras.Add(primeiraPalavra);
                }
            }
            
            List<Palavra> palavrasOrdenadas = palavras.OrderBy(p => p.getPalavra()).ToList();

            return palavrasOrdenadas;
        }

        public void imprime()
        {
            carregaArquivo();

            List<Palavra> palavras = carregaPalavras();

            foreach(Palavra p in palavras)
            {
                string linha = p.getPalavra() + ", Quantidade = " + p.getQuantidade() + ", posições = ";

                foreach (int pos in p.getPosicoes())
                {
                    linha += pos + ", ";
                }

                linha = linha.Substring(0, linha.Length - 2);

                Console.WriteLine(linha);
                Console.WriteLine("\n");
            }

        }

    }
}