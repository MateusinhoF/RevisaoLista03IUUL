using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercicio01
{
    public class ServicePessoa
    {
        private string diretorio;
        private List<PessoaString> pessoas;


        public ServicePessoa(string diretorio) 
        {
            this.diretorio = diretorio;
            pessoas = new List<PessoaString>();
        }

        public void setDiretorio(string diretorio)
        {
            this.diretorio = diretorio;
        }

        private void lerArquivo()
        {
            string arquivo = File.ReadAllText(diretorio);
            this.pessoas = JsonSerializer.Deserialize<List<PessoaString>>(arquivo, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public List<Pessoa> iniciarLeitura()
        {
            lerArquivo();
            List<Pessoa> p = new List<Pessoa>();
            string arquivoErro = "[\n";
            foreach(PessoaString ps in pessoas)
            {
                string erros = null;
                string dados = null;

                if (validaNome(ps.nome) != null)
                {
                    erros += "{\"nome\" : \""+validaNome(ps.nome)+"\"},\n";
                }
                
                if (validaCpf(ps.cpf) != null)
                {
                    erros += "{\"cpf\" : \"" + validaCpf(ps.cpf) + "\"},\n";
                }
                
                if (validaDtNascimento(ps.dt_nascimento) != null)
                {
                    erros += "{\"dt_nascimento\" : \"" + validaDtNascimento(ps.dt_nascimento) + "\"},\n";
                }
                
                if (validaRendaMensal(ps.renda_mensal) != null)
                {
                    erros += "{\"renda_mensal\" : \"" + validaRendaMensal(ps.renda_mensal) + "\"},\n";
                }
                
                if (validaEstadoCivil(ps.estado_civil) != null)
                {
                    erros += "{\"estado_civil\" : \"" + validaEstadoCivil(ps.estado_civil) + "\"},\n";
                }
                
                if (validaDependentes(ps.dependentes) != null)
                {
                    erros += "{\"dependentes\" : \"" + validaDependentes(ps.dependentes) + "\"},\n";
                }

                if (erros != null)
                {
                    erros = erros.Substring(0, erros.Length - 2);

                    dados = "\"nome\" : \"" + ps.nome + "\",\n" +
                        "            \"cpf\" : \"" + ps.cpf + "\",\n"+
                        "            \"dt_nascimento\" : \"" + ps.dt_nascimento + "\",\n"+
                        "            \"renda_mensal\" : \"" + ps.renda_mensal + "\",\n"+
                        "            \"estado_civil\" : \"" + ps.estado_civil + "\",\n"+
                        "            \"dependentes\" : \"" + ps.dependentes + "\"\n";
                    arquivoErro += "{\"dados\" : {" + dados + "}, \n\"erros\" : [  "+erros+"  ]\n},\n";
                }
                else
                {
                    p.Add(new Pessoa(ps.nome, long.Parse(ps.cpf), DateTime.Parse(ps.dt_nascimento), float.Parse(ps.renda_mensal), char.Parse(ps.estado_civil), int.Parse(ps.dependentes)));
                }


            }
            arquivoErro = arquivoErro.Substring(0, arquivoErro.Length-2)+"\n]";
            if (arquivoErro.Length > 5/*numero de linhas que comeca a ter erro*/)
            {
                gravarErros(arquivoErro);
            }
            return p;
        }

        private void gravarErros(string arquivoErro)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\Karma\\Desktop\\erros.json");
                sw.Write(arquivoErro);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            

        }

        private string validaNome(string nome)
        {
            if (nome.Length < 5 || !new Regex(@"[a-zA-Z]").IsMatch(nome))
            {
                return "Nome inválido, digite corretamente e com 5 caracteres no minimo";
            }
            return null;
        }

        private string validaCpf(string cpf)
        {

            if (cpf.Length != 11 && !new Regex(@"[0-9]").IsMatch(cpf))
            {
                return "CPF inválido, digite o CPF corretamente";
            }
            else
            {
                int multiplosCPF = 0;
                int multiplicador = 10;
                for (int i = 0; i < 9; i++)
                {
                    multiplosCPF += int.Parse(cpf.Substring(i, 1)) * multiplicador;
                    multiplicador--;
                }

                int resto = multiplosCPF % 11;
                string j = cpf.Substring(9, 1);
                if (resto < 2)
                {
                    if (j != "0")
                    {
                        return "CPF inválido, digite um valor valido";
                    }
                }
                else if (resto > 1 && resto < 11)
                {
                    if (j != (11 - resto).ToString())
                    {
                        return "CPF inválido, digite um valor valido";
                    }
                }

                multiplosCPF = 0;
                multiplicador = 11;
                for (int i = 0; i < 10; i++)
                {
                    multiplosCPF += int.Parse(cpf.Substring(i, 1)) * multiplicador;
                    multiplicador--;
                }
                resto = multiplosCPF % 11;
                string k = cpf.Substring(10, 1);
                if (resto < 2)
                {
                    if (k != "0")
                    {
                        return "CPF inválido, digite um valor valido";
                    }
                }
                else if (resto > 1 && resto < 11)
                {
                    if (k != (11 - resto).ToString())
                    {
                        return "CPF inválido, digite um valor valido";
                    }
                }

            }

            bool igual = true;
            for (int i = 0; i < cpf.Length; i++)
            {
                if (cpf.Substring(0, 1) != cpf.Substring(i, 1))
                {
                    igual = false;
                }
            }
            if (igual)
            {
                return "CPf inválido, um CPF não repete os mesmo numeros o tempo todo";
            }

            return null;
        }

        private string validaDtNascimento(string dataNascimento)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR", false);
            if (dataNascimento.Length == 10)
            {
                DateTime dataNascimentoDateTime;

                try
                {
                    dataNascimentoDateTime = DateTime.Parse(dataNascimento);
                }
                catch (FormatException e)
                {
                    return "Data de nascimento inválida";
                }

                if (dataNascimentoDateTime.AddYears(18) > DateTime.Now)
                {
                    return "Não pode ter menos que 18 anos";
                }
            }
            else
            {
                return "Data de Nascimento inválida";
            }
            return null;
        }

        private string validaRendaMensal(string rendaMensal)
        {
            //IndexOutOfRangeException
            try
            {
                if (rendaMensal.Split(',')[1].Length != 2 || !new Regex(@"\,[0-9]").IsMatch(rendaMensal))
                {
                    return "Renda Mensal inválida";
                }
            }catch(IndexOutOfRangeException e)
            {
                return "Renda Mensal inválida";
            }
            return null;
        }

        private string validaEstadoCivil(string estadoCivil)
        {
            string valido = "cCsSvVdD";
            if (estadoCivil.Length != 1 || !valido.Contains(estadoCivil))
            {
                return "Estado civíl inválido";
            }
            return null;
        }

        private string validaDependentes(string dependentes)
        {
            if (!new Regex(@"[0-9]").IsMatch(dependentes) || (int.Parse(dependentes) < 0 || int.Parse(dependentes) > 10))
            {
                return "Número de dependentes inválido";
            }
            return null;

        }

    }
}
