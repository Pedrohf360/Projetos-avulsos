using System;
using System.IO;
//using System.Timers;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_I_
{
    class Program
    {


        //STRUCT PARA SALVAR OS DADOS DA MOCHILA DO USUÁRIO JÁ EVOLUÍDOS
        struct MochilaUsuarioEvol
        {
            public string pokemonEvoluido;
            public string pokemonOrig;
            public int qtdPokemEvol;
            public int qtdPokemonRestantesOriginais;
            public int qtdCandiesRestantesevo;
        }

        //STRUCT PARA SALVAR OS DADOS DA MOCHILA PARA EVOLUIR DO USUÁRIO
        struct MochilaUsuario
        {
            public string pokemon;
            public string qtdPokemon;
            public string qtdCandies;
        }


        //STRUCT PARA SALVAR OS DADOS DE EVOLUÇÃO (COMPARAÇÃO)
        struct MochilaDadosEvoluir
        {
            public string pokemonOrig;
            public string qtdCandies;
            public string pokemonEvoluido;
        }

        //MOCHILA FINAL PARA SALVAR A SEGUNDA EVOLUÇÃO, OU SEJA, ESTA VAI SER A MOCHILA FINAL DO USUÁRIO
        struct MochilaFinal
        {
            public string nomePokemon;
            public int qtdCandies;
            public int qtdPokemon;
        }

        //STRUCT PARA SALVAR OS POKEMONS QUE NÃO EVOLUIRAM POR FALTA DE CANDIES
        struct NaoEvo
        {
            public string nomePokemon;
            public int qtdCandies;
            public int qtdPokemon;
        }

        //MÉTODO PARA CARREGAR A MOCHILA COM A BASE DE DADOS PARA A EVOLUÇÃO FAZENDO A CONTAGEM PARA MOSTRAR QUANTOS POKEMONS FORAM CARREGADOS
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


        //MÉTODO PARA LER O ARQUIVO E FAZER A CONTABEM DAS LINHAS PARA MOSTRAR QUANTOS POKEMONS DA MOCHILA DO USUÁRIO FORAM CARREGADOS
        static string LerMochila(string mochila, ref int contMochi, ref string usuario)
        {
            string linha;
            contMochi = 0;
            StreamReader arqProd = new StreamReader(@mochila + ".txt");
            while ((linha = arqProd.ReadLine()) != null)
            {
                contMochi++;
            }
            arqProd.Close();
            //MOSTRA NO CONSOLE OS POKEMONS QUE FORAM CARREGADOS
            StreamReader arqProd2 = new StreamReader(@mochila + ".txt");
            usuario = arqProd2.ReadToEnd();
            arqProd2.Close();
            return usuario;
        }


        //MÉTODO PARA EFETUAR O SPLIT DA MOCHILA E CARREGA NO VETOR
        static void Split(string mochi, ref string[] mochiSplit)
        {
            mochi = mochi.Replace("\n", "").Replace("ã", "a");

            //mochi = mochi.Replace('ã', 'a');
            mochiSplit = mochi.Split(new char[] { ';', '\r', });
        }


        //MÉTODO PARA CONVERTER PARA INTEIRO
        static void Converte(string[] candiesConverte, ref int[] candiesInt)
        {
            candiesInt = new int[candiesConverte.Length];
            for (int i = 0; i < candiesConverte.Length; i++)
            {
                candiesInt[i] = int.Parse(candiesConverte[i]);
            }
        }


        //COUNTDOWN INICIAL
        private static int Contador = 5;

        static public void Tick(Object obj)
        {
            if (Contador >= 0)
            {
                Console.SetCursorPosition(20, 13);
                Console.WriteLine(String.Format("{0:00}", Contador));
                Contador--;
            }
        }

        static void Main(string[] args)
        {
            int opcao = 0, contEvo = 0, contMochi = 0, pos = 0;
            string evo = "", mochila = "", texto = "", usuario = "", nomeArq = "";
            string[] evoSplit = null, qtdCandiesUsuario = null, mochiSplit = null, qtdCandiesDados = null, qtdPokemonUsuarioStr = null;
            MochilaUsuario[] mochilaParaEvo = null;
            MochilaDadosEvoluir[] mochilaDados = new MochilaDadosEvoluir[137];
            MochilaUsuarioEvol[] mochilaEvol = new MochilaUsuarioEvol[137];
            MochilaFinal[] mochilaFinal = new MochilaFinal[137];
            NaoEvo[] naoEvo = new NaoEvo[137];
            int[] candiesUsuarioInt, candiesDadosEvoInt, qtdPokemonUsuarioInt;

            Console.SetWindowSize(70, 25);
            Console.WriteLine(new String('-', 70));
            Console.SetCursorPosition(20, 1);
            Console.WriteLine("TRABALHO CRIADO POR:");
            Console.WriteLine(new String('-', 70));
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("ITALO COURA - MATRÍCULA: 573962");
            Console.WriteLine(new String('-', 70));
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("PEDRO HENRIQUE - MATRÍCULA: 580544");
            Console.WriteLine(new String('-', 70));
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("SISTEMAS DE INFORMAÇÃO - NOITE");
            Console.SetCursorPosition(20, 7);
            Console.Write("\n\nEm 05 segundos se iniciará o Evoluidor Filezin.");

            
            Timer stateTimer = new Timer(new TimerCallback(Tick), null, 0, 1000);
            System.Threading.Thread.Sleep(5000);
            Console.Write("Digite qualquer tecla para iniciar.");
            Console.ReadLine();
            Console.Clear();

            do
            {

                Console.Clear();
                //SWITCH COM TODAS OPÇÕES
                Console.WriteLine("\nDIGITE A OPAÇÃO/ DESEJADA: \n1 - CARREGAR TABELA DE EVOLUÇÃO \n2 - CARREGAR MOCHILA \n3 - EVOLUIR MOCHILA \n4 - EXIBIR MOCHILA EVOLUIDA \n0 - DIGITE '0' PARA SAIR");
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                while (opcao < 0 || opcao > 5)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOPÇÃO INVÁLIDA. DIGITE UMA DAS OPÇÕES ABAIXO");
                    Console.ResetColor();
                    Console.WriteLine("\nDIGITE A OPÇÃO/ DESEJADA: \n1 - CARREGAR TABELA DE EVOLUÇÃO \n2 - CARREGAR MOCHILA \n3 - EVOLUIR MOCHILA \n4 - EXIBIR MOCHILA EVOLUIDA \n0 - DIGITE '0' PARA SAIR");
                    opcao = int.Parse(Console.ReadLine());

                    Console.Clear();
                }

                switch (opcao)
                {

                    //OPÇÃO PARA CARREGAR MOCHILA DE COM OS DADOS PARA EVOLUÇÃO
                    case 1:
                        texto = LerEvo(ref evo, ref contEvo);
                        Split(texto, ref evoSplit);

                        Console.Write(texto + "\n");
                        Console.WriteLine(new string('-', 50));
                        Console.WriteLine("{0} carregados com sucesso.", contEvo);
                        Console.WriteLine("\nAperte qualquer tecla para continuar.", true);
                        Console.ReadKey();
                        Console.Clear();

                        //CARREGA AS POSIÇÕES DO STRUCT DA MOCHILA DADOS(A BASE DE COMPARAÇÃO) COM OS POKEMONS SPLITADOS
                        for (int i = 0; i < mochilaDados.Length * 3; i += 3)
                        {

                            mochilaDados[pos].pokemonOrig = evoSplit[i];
                            mochilaDados[pos].qtdCandies = evoSplit[i + 1];
                            mochilaDados[pos].pokemonEvoluido = evoSplit[i + 2];
                            pos++;
                        }
                        pos = 0;
                        break;

                    //OPÇÃO PARA CARREGAR MOCHILA COM OS POKEMONS DO USUÁRIO
                    case 2:
                        Console.WriteLine("Digite o nome da mochila para ser carregada: ");
                        mochila = Console.ReadLine();
                        Console.WriteLine();
                        texto = LerMochila(mochila, ref contMochi, ref usuario);
                        Split(usuario, ref mochiSplit);
                        Console.Write(texto + "\n");
                        Console.WriteLine(new string('-', 50));
                        Console.WriteLine("{0} Pokemons carregados com sucesso da mochila.", contMochi);
                        Console.WriteLine("\nAperte qualquer tecla para continuar.", true);
                        Console.ReadKey();
                        Console.Clear();
                        pos = 0;
                        //  mochilaParaEvo = new MochilaUsuario[contEvo];
                        mochilaParaEvo = new MochilaUsuario[mochiSplit.Length / 3];
                        //CARREGA AS POSIÇÕES DO STRUCT DA MOCHILA DO USUÁRIO(QUE SERÁ EVOLUÍDA) COM OS POKEMONS SPLITADOS
                        for (int i = 0; i < mochilaParaEvo.Length * 3; i += 3)
                        {
                            mochilaParaEvo[pos].pokemon = mochiSplit[i];
                            mochilaParaEvo[pos].qtdPokemon = mochiSplit[i + 1];
                            mochilaParaEvo[pos].qtdCandies = mochiSplit[i + 2];
                            pos++;
                        }
                        break;

                    case 3:
                        //INICIALIZAÇÃO ARRAYS MOCHILA USUÁRIO
                        candiesUsuarioInt = new int[contMochi];
                        qtdPokemonUsuarioInt = new int[contMochi];
                        qtdCandiesUsuario = new string[contMochi];
                        qtdPokemonUsuarioStr = new string[contMochi];

                        //INICIALIZAÇÃO ARRAYS MOCHILA DADOS
                        candiesDadosEvoInt = new int[contEvo];
                        qtdCandiesDados = new string[contEvo];

                        //FOR's PARA PASSAR OS STRINGS DO STRUCT  PARA NOVOS ARRAYS
                        for (int i = 0; i < mochilaParaEvo.Length; i++)
                        {
                            qtdCandiesUsuario[i] = mochilaParaEvo[i].qtdCandies;
                        }
                        for (int i = 0; i < mochilaParaEvo.Length; i++)
                        {
                            qtdPokemonUsuarioStr[i] = mochilaParaEvo[i].qtdPokemon;
                        }
                        for (int i = 0; i < mochilaDados.Length; i++)
                        {
                            qtdCandiesDados[i] = mochilaDados[i].qtdCandies;
                        }

                        //CHAMA OS MÉTODOS PARA CONVERTER OS ARRAYS DOS CANDIES DE STRING PARA INT
                        Converte(qtdCandiesUsuario, ref candiesUsuarioInt);
                        Converte(qtdCandiesDados, ref candiesDadosEvoInt);
                        Converte(qtdPokemonUsuarioStr, ref qtdPokemonUsuarioInt);

                        //AQUI COMEÇA O RITUAL DA PRIMEIRA EVOLUÇÃO

                        //FAZ A EVOLUÇÃO DOS POKEMONS A PRIMEIRA VEZ e/ou GUARDA NA MOCHILA EVOLUÍDA DO USUÁRIO OS POKEMONS QUE NÃO EVOLUEM PARA NENHUM OUTRO
                        for (int i = 0; i < mochilaParaEvo.Length; i++)
                        {
                            for (int j = 0; j < mochilaDados.Length; j++)
                            {
                                //IF QUE VERIFICA SE O POKEMONS EVOLUEM OU NAO
                                //SE O POKEMON NÃO EVOLUI, GUARDA NA MOCHILA EVOLUIDA (MOCHILA INTERMEDIÁRIA)
                                /*  for (int L = 0; L < i; L++)
                                      if (mochilaEvol[i].pokemonEvoluido == null) //VERIFICA SE A POSIÇÃO i NA MOCHILA EVOLUIDA ESTÁ VAZIA OU NÃO
                                      { */
                                if (mochilaParaEvo[i].pokemon == mochilaDados[j].pokemonOrig && candiesDadosEvoInt[j] == 0)
                                {
                                    naoEvo[i].nomePokemon = mochilaParaEvo[i].pokemon;
                                    naoEvo[i].qtdCandies = candiesUsuarioInt[i];
                                    naoEvo[i].qtdPokemon = qtdPokemonUsuarioInt[i];
                                    continue;
                                }
                                // SE O POKEMON EVOLUI, ESTE ELSE IF SERVE PARA MOSTRAR QUE ENCONTROU O POKEMON DO USUÁRIO NA MOCHILA PARA COMPARAR
                                else if (mochilaParaEvo[i].pokemon == mochilaDados[j].pokemonOrig)
                                {
                                    //VERIFICA SE TEM QUANTIDADE DECANDIES SUFICIENTE PARA A EVOLUÇÃO, SE NÃO TIVER, GUARDA NA MOCHILA nãoEvo
                                    if (candiesUsuarioInt[i] < candiesDadosEvoInt[j])
                                    {
                                        naoEvo[i].nomePokemon = mochilaParaEvo[i].pokemon;
                                        naoEvo[i].qtdCandies = candiesUsuarioInt[i];
                                        naoEvo[i].qtdPokemon = qtdPokemonUsuarioInt[i];
                                        continue;
                                    }

                                    // POKEMON EVOLUI, OS CANDIES DO USUARIO PERMITEM A EVOLUÇÃO E A QTD DE POKEMON É MAIOR QUE '0'
                                    //ESTE WHILE FAZ A PRIMEIRA EVOLUÇÃO
                                    while (candiesUsuarioInt[i] >= candiesDadosEvoInt[j] && qtdPokemonUsuarioInt[i] > 0)
                                    {
                                        candiesUsuarioInt[i] -= candiesDadosEvoInt[j]; //DECREMENTA A QTD DE CANDIES QUE FORAM UTILIZADOS NA EVOLUÇÃO
                                        qtdPokemonUsuarioInt[i] -= 1; // DECREMENTA EM 1, PORQUE 1 POKEMON EVOLUIU
                                        mochilaEvol[i].pokemonEvoluido = mochilaDados[j].pokemonEvoluido; // MOCHILA EVOLUIDA RECEBE O NOME DO POKEMON EVOLUIDO
                                        mochilaEvol[i].qtdCandiesRestantesevo = candiesUsuarioInt[i]; // MOCHILA EVOLUIDA RECEBE A QUANTIDADE DE CANDIES RESTANTES DEPOIS DE CADA EVOLUÇÃO
                                        mochilaEvol[i].qtdPokemEvol++; // INCREMENTA 1 POKEMON EVOLUIDO A CADA EVOLUÇÃO
                                    }
                                    // IF PARA GUARDAR OS POKEMONS QUE NÃO EVOLUIRAM A PRIMEIRA VEZ(QTD DE CANDIES INSUFICIENTES)
                                    // GUARDA NA POSIÇÃO i+1
                                    if (qtdPokemonUsuarioInt[i] > 0)
                                    {
                                        naoEvo[i].nomePokemon = mochilaParaEvo[i].pokemon; //mochilaEvol[i + 1].pokemonEvoluido = mochilaParaEvo[i].pokemon; // MOCHILA EVOLUIDA RECEBE O NOME DO POKEMON QEU NÃO EVOLUIU
                                        naoEvo[i].qtdCandies = 0; //mochilaEvol[i + 1].qtdCandiesRestantesevo = 0; // CANDIES IGUAL A ZERO, OS CANDIES PASSARÃO PARA O POKEMON EVOLUIDO
                                        naoEvo[i].qtdPokemon = qtdPokemonUsuarioInt[i]; //mochilaEvol[i + 1].qtdPokemEvol = qtdPokemonUsuarioInt[i]; //QTD DE POKEMON É A QUANTIDAD DE POKEMONS QUE RESTARAM
                                    }
                                }
                                //}
                            }
                        }

                        //AQUI COMEÇA O RITUAL DA SEGUNDA EVOLUÇÃO

                        // FOR PARA PERCORRER A MOCHILA EVOLUIDA
                        for (int k = 0; k < mochilaEvol.Length; k++)
                        {
                            for (int b = 0; b < mochilaDados.Length; b++)
                            {
                                /*   for (int N = 0; N < k; N++)
                                       if (mochilaFinal[k].nomePokemon == null)
                                       {*/
                                //SE O POKEMON QUE EVOLUIU 1 VEZ VAI EVOLUIR NOVAMENTE
                                //AQUI VAI VER SE O BICHO EVOLUI NOVAMENTE, SE NÃO EVOLUI NOVAMENTE, GUARDA NA MOCHILA FINAL DO USUÁRIO
                                if (mochilaEvol[k].pokemonEvoluido == mochilaDados[b].pokemonOrig && candiesDadosEvoInt[b] == 0)
                                {
                                    mochilaFinal[k].nomePokemon = mochilaEvol[k].pokemonEvoluido;
                                    mochilaFinal[k].qtdPokemon = mochilaEvol[k].qtdPokemEvol;
                                    mochilaFinal[k].qtdCandies = mochilaEvol[k].qtdCandiesRestantesevo;
                                    continue;
                                }

                                // AQUI SIGNIFICA QUE O POKEMON EVOLUI NOVAMENTE;
                                //PORÉM SOMENTE IRÁ EVOLUIR SE O POKEMON "EVOLUIDO" APARECER COMO POKEMON ORIGINAL, OU SEJA, SIGNIFICA QUE ELE TEM UMA EVOLUÇÃO
                                //E SÓ IRÁ EVOLUIR SE A QTD DE CANDIES PERMITIR E SE A QTD DE POKEMONS FOR MAIOR QUE 0
                                else if (mochilaEvol[k].pokemonEvoluido == mochilaDados[b].pokemonOrig && mochilaEvol[k].qtdCandiesRestantesevo >= candiesDadosEvoInt[b] && mochilaEvol[k].qtdPokemEvol > 0)
                                {
                                    while (mochilaEvol[k].qtdCandiesRestantesevo >= candiesDadosEvoInt[b] && mochilaEvol[k].qtdPokemEvol > 0)
                                    {
                                        mochilaEvol[k].qtdCandiesRestantesevo -= candiesDadosEvoInt[b]; //DECREMENTA A QUANTIDADE DE CANDIES UTILIZADA PARA EFETUAR A EVOLUÇÃO
                                        mochilaEvol[k].qtdPokemEvol -= 1; // DECREMENTA EM 1 A QTD DE POKEMONS QUE FORAM EVOLUIDOS

                                        mochilaFinal[k].nomePokemon = mochilaDados[b].pokemonEvoluido; //MOCHILA FINAL RECEBE O NOME DO POKEMON EVOLUIDO
                                        mochilaFinal[k].qtdCandies = mochilaEvol[k].qtdCandiesRestantesevo; //MOCHILA FINAL RECEBE A QUANTIDADE DE CANDIES RESTANTES
                                        mochilaFinal[k].qtdPokemon++; //INCREMENTA EM 1 A QTD DE POKEMONS EVOLUIDOS (somente um contador da quantidade de vezes que é evoluido)
                                    }

                                    //VERIFICA SE RESTARAM POKEMONS QUE NÃO EVOLUIRAM UMA SEGUNDA VEZ (FALTA DE CANDIES)
                                    //SE RESTARAM, GRAVA NA MOCHILA FINAL NA POSIÇÃO K+1
                                    if (mochilaEvol[k].qtdPokemEvol > 0)
                                    {
                                        //for para preencher o struct naoEvo e if para verificar se a posição está vazia ou não
                                        for (int i = 0; i < naoEvo.Length; i++)
                                            if (naoEvo[i].nomePokemon == null)
                                            {
                                                naoEvo[k].nomePokemon = mochilaEvol[k].pokemonEvoluido; // MOCHILA EVOLUIDA RECEBE O NOME DO POKEMON QEU NÃO EVOLUIU
                                                naoEvo[k].qtdCandies = 0; // CANDIES IGUAL A ZERO, OS CANDIES PASSARÃO PARA O POKEMON EVOLUIDO
                                                naoEvo[k].qtdPokemon = mochilaEvol[k].qtdPokemEvol; //QTD DE POKEMON É A QUANTIDAD DE POKEMONS QUE RESTARAM
                                            }
                                    }
                                }
                            }
                        }
                        Console.Clear();


                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Pokémons evoluídos com sucesso!");
                        Console.ResetColor();

                        do
                        {
                            Console.WriteLine("Digite a opção:\n1 - Apresentar pokémons evoluídos na tela.\n2 - Gravar pokémons evoluídos em arquivo. \n3 - Voltar ao menu inicial. \n0 - SAIR");
                            opcao = int.Parse(Console.ReadLine());
                            while (opcao < 0 || opcao > 3)

                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nOPÇÃO INVÁLIDA. DIGITE UMA DAS OPÇÕES ABAIXO");
                                Console.ResetColor();
                                Console.WriteLine("Digite a opção:\n1 - Apresentar pokémons evoluídos na tela.\n2 - Gravar pokémons evoluídos em arquivo. \n3 - Voltar ao menu inicial. \n0 - SAIR");
                                opcao = int.Parse(Console.ReadLine());

                                Console.Clear();
                            }

                            switch (opcao)
                            {
                                case 1:

                                    //OPÇÃO PARA APRESENTAR NA TELA
                                    for (int i = 0; i < mochilaFinal.Length; i++)
                                    {
                                        if (mochilaFinal[i].nomePokemon != null)
                                            Console.WriteLine("{0};{1};{2}", mochilaFinal[i].nomePokemon, mochilaFinal[i].qtdPokemon, mochilaFinal[i].qtdCandies);
                                        if (naoEvo[i].nomePokemon != null)
                                            Console.WriteLine("{0};{1};{2}", naoEvo[i].nomePokemon, naoEvo[i].qtdPokemon, naoEvo[i].qtdCandies);
                                    }

                                    Console.ReadKey();
                                    opcao = 0;
                                    Console.Clear();
                                    break;

                                // OPCÃO PARA CRIAR ARQUIVO
                                case 2:
                                    Console.Write("Digite o nome do arquivo a ser criado: ");
                                    nomeArq = Console.ReadLine();
                                    StreamWriter txt = new StreamWriter(@nomeArq + ".txt");
                                    for (int u = 0; u < mochilaFinal.Length; u++)
                                    {
                                        if (mochilaFinal[u].nomePokemon != null)
                                        {
                                            txt.Write(mochilaFinal[u].nomePokemon + ";");
                                            txt.Write(mochilaFinal[u].qtdPokemon + ";");
                                            txt.Write(mochilaFinal[u].qtdCandies + "\r\n");
                                        }
                                    }
                                    for (int u = 0; u < naoEvo.Length; u++)
                                    {
                                        if (naoEvo[u].nomePokemon != null)
                                        {
                                            txt.Write(naoEvo[u].nomePokemon + ";");
                                            txt.Write(naoEvo[u].qtdPokemon + ";");
                                            txt.Write(naoEvo[u].qtdCandies + "\r\n");
                                        }
                                    }
                                    txt.Close();
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Arquivo criado com sucesso!");
                                    Console.ResetColor();
                                    break;
                            }
                        } while (opcao != 3 && opcao != 0);
                        Console.Clear();
                        break;

                    //APRESENTAR MOCHILA JÁ CRIADA NA TELA
                    case 4:


                        //não está verificando se o arquivo existe ou não...

                        
                            Console.WriteLine("Digite o nome da mochila evoluida: .");
                            nomeArq = Console.ReadLine();
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nome de mochila digitada não existe.");
                            Console.ResetColor();
                            Console.WriteLine("Digite o nome da mochila evoluida: ");
                            nomeArq = Console.ReadLine();
                            
                        } while (!File.Exists(@nomeArq + ".txt"));

                        texto = LerMochila(nomeArq, ref contMochi, ref usuario);
                        Console.WriteLine(texto + "\n");

                        Console.WriteLine("Digite qualquer tecla para voltar ao menu inicial.");
                        Console.ReadKey();
                        break;
                }

            } while (opcao != 0);
            Console.WriteLine("\nPressione qualquer tecla para sair.", true);
            Console.ReadKey();
        }
    }
}
