using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_I_
{
    class Program
    {


        //STRUCT PARA SALVAR OS DADOS DA MOCHILA DO USUÁRIO JÁ EVOLUÍDOS
        struct MochilaUsuarioEvoluída
        {
            public string pokemonEvoluído;
            public string pokemonOriginal;
            public int qtdPokemonEvoluídos;
            public int qtdPokemonRestantesOriginais;
            public int qtdCandiesRestantes;
            public string pokemonQueNaoEvolue;
        }


        //STRUCT PARA SALVAR OS DADOS DA MOCHILA DO USUÁRIO PARA EVOLUIR
        struct MochilaUsuario
        {
            public string pokemon;
            public string qtdPokemon;
            public string qtdCandies;
        }


        //STRUCT PARA SALVAR OS DADOS DE VOLUÇÃO
        struct MochilaDadosEvoluir
        {
            public string pokemonOriginal;
            public string qtdCandies;
            public string pokemonEvoluido;
        }



        // CARREGA A MOCHILA COM A BASE DE DADOS PARA A EVOLUÇÃO FAZENDO A CONTAGEM PARA MOSTRAR QUANTOS POKEMONS FORAM CARREGADOS
        static string LerEvo(ref string arq, ref int cont)
        {
            string texto;
            StreamReader arqProd = new StreamReader("evo.txt");
            string linha;
            cont = 0;
            while ((linha = arqProd.ReadLine()) != null)
            {
                cont++;
            }
            arqProd.Close();
            //MOSTRA NO CONSOLE OS POKEMONS QUE FORAM CARREGADOS
            StreamReader arqProd2 = new StreamReader("evo.txt");
            texto = arqProd2.ReadToEnd();
            arqProd2.Close();
            return texto;
        }


        //LÊ O ARQUIVO E FAZ A CONTABEM DAS LINHAS PARA MOSTRAR QUANTOS POKEMONS DA MOCHILA DO USUÁRIO FORAM CARREGADOS
        static string LerMochila(string mochila, ref int contMochi, ref string usuario)
        {
            string linha;
            contMochi = 0;
            StreamReader arqProd = new StreamReader(@mochila);
            while ((linha = arqProd.ReadLine()) != null)
            {
                contMochi++;
            }
            arqProd.Close();
            //MOSTRA NO CONSOLE OS POKEMONS QUE FORAM CARREGADOS
            StreamReader arqProd2 = new StreamReader(@mochila);
            usuario = arqProd2.ReadToEnd();
            arqProd2.Close();
            return usuario;
        }


        //FAZ O SPLIT DA MOCHILA E CARREGA NO VETOR
        static void Split(string mochi, ref string[] mochiSplit)
        {
            mochi = mochi.Replace("\n", "");
            mochiSplit = mochi.Split(new char[] { ';', '\r', });
        }


        //CONVERTE CANDIES PARA INTEIRO
        static void Converte(string[] candiesConverte, ref int[] candiesInt)
        {
            int pos = 0;
            candiesInt = new int[candiesConverte.Length];
            for (int i = 0; i < candiesConverte.Length; i++)
            {
                candiesInt[i] = int.Parse(candiesConverte[pos]);
                pos++;
            }
        }



        static void Main(string[] args)
        {
            int opcao = 0, contEvo = 0, contMochi = 0, pos = 0, contPokemonsEvoluidos1x = 0, contPokemonsEvoluidos2x = 0;
            string evo = "", mochila = "", texto = "", usuario = "";
            string[] evoSplit = null, qtdCandiesUsuario = null, mochiSplit = null, qtdCandiesDados = null, qtdPokemonUsuario = null;
            MochilaUsuario[] mochilaParaEvo = null;
            MochilaDadosEvoluir[] mochilaDados = new MochilaDadosEvoluir[136];
            MochilaUsuarioEvoluída[] mochilaEvoluida = null;
            int[] candiesUsuarioInt, candiesDadosEvoInt, qtdPokemonUsuarioInt;


            do
            {
                //SWITCH COM TODAS OPÇÕES
                Console.WriteLine("\n\nDIGITE A OPAÇÃO/ DESEJADA: \n1 - CARREGAR TABELA DE EVOLUÇÃO \n2 - CARREGAR MOCHILA \n3 - EVOLUIR MOCHILA \n4 - EXIBIR MOCHILA EVOLUIDA \n5 - GRAVAR MOCHILA EVOLUÍDA EM ARQUIVO.\n0 - DIGITE '0' PARA SAIR");
                opcao = int.Parse(Console.ReadLine());

                while (opcao < 1 || opcao > 5)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOPÇÃO INVÁLIDA. DIGITE UMA DAS OPÇÕES ABAIXO");
                    Console.ResetColor();
                    Console.WriteLine("\n\nDIGITE A OPAÇÃO DESEJADA: \n1 - CARREGAR TABELA DE EVOLUÇÃO \n2 - CARREGAR MOCHILA \n3 - EVOLUIR MOCHILA \n4 - EXIBIR MOCHILA EVOLUIDA \n5 - GRAVAR MOCHILA EVOLUÍDA EM ARQUIVO.");
                    opcao = int.Parse(Console.ReadLine());

                    Console.Clear();
                }

                switch (opcao)
                {

                    //OPÇÃO PARA CARREGAR MOCHILA DE COM OS DADOS PARA EVOLUÇÃO
                    case 1:
                        texto = LerEvo(ref evo, ref contEvo);
                        Split(texto, ref evoSplit);
                        Console.Write(texto);
                        Console.WriteLine("\n{0} carregados com sucesso.", contEvo);
                        Console.WriteLine("Aperte qualquer tecla para continuar.", true);
                        Console.ReadKey();
                        Console.Clear();

                        for (int i = 0; i < mochilaDados.Length * 3; i += 3)
                        {
                            mochilaDados[pos].pokemonOriginal = evoSplit[i];
                            mochilaDados[pos].qtdCandies = evoSplit[i + 1];
                            mochilaDados[pos].pokemonEvoluido = evoSplit[i + 2];
                            pos++;
                        }
                        break;

                    //OPÇÃO PARA CARREGAR MOCHILA COM OS POKEMONS DO USUÁRIO
                    case 2:
                        Console.WriteLine("Digite o nome da mochila para ser carregada: ");
                        mochila = Console.ReadLine();
                        texto = LerMochila(mochila, ref contMochi, ref usuario);
                        Split(usuario, ref mochiSplit);
                        Console.Write(texto);
                        Console.WriteLine("\n{0} Pokemons carregados com sucesso da mochila.", contMochi);
                        Console.WriteLine("Aperte qualquer tecla para continuar.", true);
                        Console.ReadKey();
                        Console.Clear();
                        pos = 0;
                        mochilaParaEvo = new MochilaUsuario[contEvo];
                        mochilaParaEvo = new MochilaUsuario[mochiSplit.Length / 3];
                        for (int i = 0; i < mochilaParaEvo.Length * 3; i += 3)
                        {
                            mochilaParaEvo[pos].pokemon = mochiSplit[i];
                            mochilaParaEvo[pos].qtdPokemon = mochiSplit[i + 1];
                            mochilaParaEvo[pos].qtdCandies = mochiSplit[i + 2];
                            pos++;
                        }
                        break;

                    case 3:

                        candiesUsuarioInt = new int[contMochi];
                        candiesDadosEvoInt = new int[contEvo];
                        qtdPokemonUsuarioInt = new int[contMochi];
                        qtdCandiesUsuario = new string[contMochi];
                        qtdCandiesDados = new string[contEvo];
                        qtdPokemonUsuario = new string[contMochi];

                        //FOR's PARA PASSAR OS STRINGS DO STRUCT PARA NOVOS ARRAYS
                        for (int i = 0; i < mochilaParaEvo.Length; i++)
                        {
                            qtdCandiesUsuario[i] = mochilaParaEvo[i].qtdCandies;
                        }
                        for (int i = 0; i < mochilaDados.Length; i++)
                        {
                            qtdCandiesDados[i] = mochilaDados[i].qtdCandies;
                        }
                        for (int i = 0; i < mochilaParaEvo.Length; i++)
                        {
                            qtdPokemonUsuario[i] = mochilaParaEvo[i].qtdPokemon;
                        }
                        //CHAMA OS MÉTODOS PARA CONVERTER OS ARRAYS DOS CANDIES DE STRING PARA INT
                        Converte(qtdCandiesUsuario, ref candiesUsuarioInt);
                        Converte(qtdCandiesDados, ref candiesDadosEvoInt);
                        Converte(qtdPokemonUsuario, ref qtdPokemonUsuarioInt);





                        break;

                    case 4:
                        for (int i = 0; i < mochilaEvoluida.Length; i++)
                        {
                            Console.WriteLine("\nPokemon de Origem: {0};Qtd de Pokemons originais Restantes: {1};Qtd Pokemons Evoluídos: {2};Pokemon evolui para: {3}; Qtd de candies restantes: {4}",
                                mochilaEvoluida[i].pokemonOriginal, mochilaEvoluida[i].qtdPokemonRestantesOriginais,
                                mochilaEvoluida[i].qtdPokemonEvoluídos, mochilaEvoluida[i].pokemonEvoluído, mochilaEvoluida[i].qtdCandiesRestantes);
                            Console.WriteLine();
                        }
                        break;
                }
            } while (opcao != 0);

            Console.WriteLine("\nPressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}





