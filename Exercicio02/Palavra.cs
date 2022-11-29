using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio02
{
    public class Palavra
    {
        private string palavra;
        private int quantidade;
        private List<int> posicoes;

        public Palavra(string palavra)
        {
            this.palavra = palavra;
            posicoes= new List<int>();
            quantidade= 0;
        }

        public void setPalavra(string palavra)
        {
            this.palavra= palavra;
        }
        public string getPalavra()
        {
            return this.palavra;
        }

        public void setQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }
        public int getQuantidade() 
        { 
            return this.quantidade;
        }
        public void inserirPosicao(int posicao)
        {
            posicoes.Add(posicao);
        }
        public void removerPosicao(int posicao)
        {
            posicoes.Remove(posicao);
        }
        public List<int> getPosicoes()
        {
            return posicoes;
        }

        public void incrementaQuantidade()
        {
            quantidade++;
        }
    }
}
