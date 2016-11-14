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
        // STRUCT PARA SALVAR OS DADOS DA MOCHILA DO USUÁRIO JÁ EVOLUÍDOS
        struct MochiUsuarEvol
        {
            public string pokemEvol;
            public int qtdPokemEvol;
            public int qtdCandiesRestEvo;
        }

        // STRUCT PARA SALVAR OS DADOS DA MOCHILA PARA EVOLUIR DO USUÁRIO
        struct MochiUsuar
        {
            public string pokem;
            public string qtdPokem;
            public string qtdCandies;
        }


        // STRUCT PARA SALVAR OS DADOS DE EVOLUÇÃO (COMPARAÇÃO)
        struct MochiDadosEvo
        {
            public string pokemOrig;
            public string qtdCandies;
            public string pokemEvol;
        }

        // MOCHILA FINAL PARA SALVAR A SEGUNDA EVOLUÇÃO, OU SEJA, ESTA VAI SER A MOCHILA FINAL DO USUÁRIO
        struct MochiFinal
        {
            public string nomePokem;
            public int qtdCandies;
            public int qtdPokem;
        }

        // STRUCT PARA SALVAR OS POKEMONS QUE NÃO EVOLUIRAM POR FALTA DE CANDIES
        struct NaoEvo
        {
            public string nomePokem;
            public int qtdCandies;
            public int qtdPokem;
        }
        // OS MÉTODOS ESTÃO SEQUENCIADOS NA ORDEM DE EXECUÇÃO, ALTERNANDO-SE ENTRE MÉTODOS DE PROCESSAMENTO E DE INTERFACE

        // MÉTODOS DE PROCESSAMENTO:

        // CARREGAR A MOCHILA COM A BASE DE DADOS PARA A EVOLUÇÃO (evo.txt), FAZENDO A CONTAGEM PARA MOSTRAR QUANTOS POKEMONS FORAM CARREGADOS
        static string LerEvo(ref int cont)
        {
            string texto, linha;
            cont = 0;

            using (StreamReader arqProd = new StreamReader("evo.txt"))
            {

                while ((linha = arqProd.ReadLine()) != null)
                {
                    cont++;
                }
                arqProd.Close();
            }
            // MOSTRA NO CONSOLE OS POKEMONS QUE FORAM CARREGADOS
            using (StreamReader arqProd2 = new StreamReader("evo.txt"))
            {
                texto = arqProd2.ReadToEnd();
                arqProd2.Close();
            }
            return texto;
        }


        // MÉTODO PARA LER O ARQUIVO E FAZER A CONTABEM DAS LINHAS PARA MOSTRAR QUANTOS POKEMONS DA MOCHILA DO USUÁRIO FORAM CARREGADOS
        static string LerMochi(string mochi, ref int contMochi, ref string usuario)
        {
            string linha;
            contMochi = 0;
            StreamReader arqProd = new StreamReader(@mochi + ".txt");
            while ((linha = arqProd.ReadLine()) != null)
            {
                contMochi++;
            }
            arqProd.Close();
            // MOSTRA NO CONSOLE OS POKEMONS QUE FORAM CARREGADOS
            StreamReader arqProd2 = new StreamReader(@mochi + ".txt");
            usuario = arqProd2.ReadToEnd();
            arqProd2.Close();
            return usuario;
        }


        // MÉTODO PARA EFETUAR O SPLIT DA MOCHILA E CARREGA NO VETOR
        static void Split(string mochi, ref string[] mochiSplit)
        {
            mochi = mochi.Replace("\n", "").Replace("ã", "a");

            // mochi = mochi.Replace('ã', 'a');
            mochiSplit = mochi.Split(new char[] { ';', '\r', });
        }


        // MÉTODO PARA CONVERTER PARA INTEIRO
        static void ConvStrToInt(string[] candiesConverte, ref int[] candiesInt)
        {
            candiesInt = new int[candiesConverte.Length];
            for (int i = 0; i < candiesConverte.Length; i++)
            {
                candiesInt[i] = int.Parse(candiesConverte[i]);
            }
        }

        // COUNTDOWN INICIAL
        private static int Contador = 5;

        static public void Tick(Object obj)
        {
            if (Contador >= 0)
            {
                Console.SetCursorPosition(35, 11);
                Console.WriteLine(String.Format("{0:00}", Contador));
                Contador--;
            }
        }

        // RECEBE TEXTO QUE DEVERÁ AGUARDAR TEMPO DETERMINADO ANTES DE APARECER NA TELA
        static void Timer(string texto)
        {
            Timer stateTimer = new Timer(new TimerCallback(Tick), null, 0, 1000);
            System.Threading.Thread.Sleep(Contador*1000);
            Console.WriteLine(texto);
            
            Console.ReadLine();
            Console.Clear();
        }

        // Verifica se o arquivo existe
        static void ArqExiste(ref string nomeArq)
        {
            if (!File.Exists(@nomeArq + ".txt"))
            {
                do
                {
                    MensagemColor("Nome do arquivo inexistente!\n", "red");
                    Console.WriteLine("Digite novamente: ");
                    nomeArq = Console.ReadLine();
                    Console.Clear();
                } while (!File.Exists(@nomeArq + ".txt"));
                
            }
        }

        // MÉTODOS INTERFACE

        static void MensagemColor(string texto, string nomeCor = "RED")
        {
            nomeCor = nomeCor.ToUpper();

                if (nomeCor == "RED")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(texto);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(texto);
                    Console.ResetColor();
                }
        }

        static void MensagemColor(string texto, int cont, string nomeCor)
        {
            MensagemColor(cont + " " + texto, nomeCor);
        }

        static int MenuInicial(int opcao)
        {
            int contWhile = 0, contCatch = 1;
            
            try
            {
                Console.WriteLine("\nDIGITE A OPÇÃO/ DESEJADA: \n\n1 - CARREGAR TABELA DE EVOLUÇÃO \n2 - CARREGAR MOCHILA \n3 - EVOLUIR MOCHILA \n4 - EXIBIR MOCHILA EVOLUÍDA \n0 - DIGITE '0' PARA SAIR");
                opcao = int.Parse(Console.ReadLine());
                if (opcao >= 0 && opcao <= 4) return opcao;
            }
            catch (Exception)
            {
                contCatch++;
            }
            while (contWhile < contCatch)
            {
                MensagemColor("\nDigite um valor numérico entre \"0\" e \"4\"");
                Console.WriteLine("\nPressione qualquer tecla para continuar.");
                Console.ReadKey(true);
                Console.Clear();
                contWhile++;
                return MenuInicial(opcao);
            }

            return opcao;
        }

        static int MenuCase3(int opcao)
        {
            int contWhile = 0, contCatch = 1;

            try
            {
                Console.WriteLine("Digite a opção desejada:\n\n1 - Apresentar pokémons evoluídos na tela.\n2 - Gravar pokémons evoluídos em arquivo. \n3 - Voltar ao menu inicial. \n0 - SAIR");
                opcao = int.Parse(Console.ReadLine());
                if (opcao >= 0 && opcao <= 3) return opcao;
            }
            catch (Exception)
            {
                contCatch++;
            }
            while (contWhile < contCatch)
            {
                MensagemColor("\nDigite um valor numérico entre \"0\" e \"3\"");
                Console.WriteLine("\nPressione qualquer tecla para continuar.");
                Console.ReadKey(true);
                Console.Clear();
                contWhile++;
                return MenuCase3(opcao);
            }

            return opcao;
        }
        
                            

    static void Main(string[] args)
        {
            int opcao = 0, contEvo = 0, contMochi = 0, pos = 0;
            string texto = "", usuario = "", nomeArq = "";
            string[] evoSplit = null, qtdCandiesUsuar = null, mochiSplit = null, qtdCandiesDados = null, qtdPokemUsuarStr = null;
            MochiUsuar[] mochiParaEvo = null;
            MochiDadosEvo[] mochiDados = new MochiDadosEvo[137];
            MochiUsuarEvol[] mochiEvol = new MochiUsuarEvol[137];
            MochiFinal[] mochiFinal = new MochiFinal[137];
            NaoEvo[] naoEvo = new NaoEvo[137];
            int[] candiesUsuarInt, candiesDadosEvoInt, qtdPokemUsuarInt;

            Console.SetWindowSize(70, 25);
            string criador = "Programa criado por:"; // STRING CRIADA PARA UTILIZAR O COMPRIMENTO DA FRASE COMO PARÂMETRO PARA "NEW STRING", LOGO ABAIXO.
            Console.SetCursorPosition(24, 1);
            Console.WriteLine(criador);
            Console.SetCursorPosition(23, 2);
            Console.WriteLine(new string('-', criador.Length + 2));
            Console.SetCursorPosition(19, 3);
            Console.WriteLine("-Ítalo Coura - Matrícula: 573962");
            Console.SetCursorPosition(18, 5);
            Console.WriteLine("-Pedro Henrique - Matrícula: 580544");
            Console.WriteLine(new String('-', 70));
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("SISTEMAS DE INFORMAÇÃO - NOITE");
            Console.WriteLine(new String('-', 70));
            Console.SetCursorPosition(20, 7);
            Console.Write("\n\nEm 05 segundos se iniciará o Evolui Filezin D+.");

            Timer("\nPressione a tecla \"ENTER\" para iniciar.");

            do
            {

                opcao = MenuInicial(opcao);

                Console.Clear();
                    // SWITCH COM TODAS OPÇÕES
                    switch (opcao)
                    {

                        // OPÇÃO PARA CARREGAR MOCHILA COM OS DADOS PARA EVOLUÇÃO
                        case 1:
                            texto = LerEvo(ref contEvo);
                            Split(texto, ref evoSplit);

                            Console.Write(texto + "\n");
                            Console.WriteLine(new string('-', 50));
                            MensagemColor("Pokémons carregados com sucesso!", contEvo, "green");
                            Console.WriteLine("\nPressione qualquer tecla para continuar.", true);
                            Console.ReadKey();
                            Console.Clear();

                            pos = 0;
                            // CARREGA AS POSIÇÕES DO STRUCT DA MOCHILA DADOS (A BASE DE COMPARAÇÃO) COM OS POKEMONS SPLITADOS
                            for (int i = 0; i < mochiDados.Length * 3; i += 3)
                            {
                                mochiDados[pos].pokemOrig = evoSplit[i];
                                mochiDados[pos].qtdCandies = evoSplit[i + 1];
                                mochiDados[pos].pokemEvol = evoSplit[i + 2];
                                pos++;
                            }
                            break;

                        // OPÇÃO PARA CARREGAR MOCHILA COM OS POKEMONS DO USUÁRIO
                        case 2:
                            Console.WriteLine("Digite o nome da mochila para ser carregada: ");
                            texto = Console.ReadLine();
                            Console.Clear();

                            ArqExiste(ref texto);
                            Console.WriteLine();

                            texto = LerMochi(texto, ref contMochi, ref usuario);
                            Split(usuario, ref mochiSplit);

                            Console.Write(texto + "\n");
                            Console.WriteLine(new string('-', 50));
                            MensagemColor("Pokémons carregados com sucesso!",contMochi, "green");
                            Console.WriteLine("\nPressione qualquer tecla para continuar.", true);
                            Console.ReadKey();
                            Console.Clear();

                            pos = 0;

                            // mochiParaEvo = new MochiUsuar[contEvo];
                            mochiParaEvo = new MochiUsuar[mochiSplit.Length / 3];

                            // CARREGA AS POSIÇÕES DO STRUCT DA MOCHILA DO USUÁRIO (QUE SERÁ EVOLUÍDA) COM OS POKEMONS SPLITADOS
                            for (int i = 0; i < mochiParaEvo.Length * 3; i += 3)
                            {
                                mochiParaEvo[pos].pokem = mochiSplit[i];
                                mochiParaEvo[pos].qtdPokem = mochiSplit[i + 1];
                                mochiParaEvo[pos].qtdCandies = mochiSplit[i + 2];
                                pos++;
                            }
                            break;

                    case 3:
                        //TRATAMENTO DE ERRO SE O USUÁRIO NAO CARREGAR UMA OU OUTRA MOCHILA
                        for (int a = 0; a < 1; a++)
                        {
                            if (mochiDados[a].pokemOrig == null)
                            {

                                texto = LerEvo(ref contEvo);
                                Split(texto, ref evoSplit);

                                Console.Write(texto + "\n");
                                Console.WriteLine(new string('-', 50));
                                MensagemColor("TABELA DE EVOLUÇÃO de comparação não carregada!");
                                MensagemColor("\nCALMA!!! Fizemos isto para você!\n");
                                MensagemColor("Pokémons carregados com sucesso!", contEvo, "green");
                                Console.WriteLine("\nPressione qualquer tecla para continuar.", true);
                                Console.ReadKey();
                                Console.Clear();


                                // CARREGA AS POSIÇÕES DO STRUCT DA MOCHILA DADOS (A BASE DE COMPARAÇÃO) COM OS POKEMONS SPLITADOS
                                pos = 0;
                                for (int i = 0; i < mochiDados.Length * 3; i += 3)
                                {
                                    mochiDados[pos].pokemOrig = evoSplit[i];
                                    mochiDados[pos].qtdCandies = evoSplit[i + 1];
                                    mochiDados[pos].pokemEvol = evoSplit[i + 2];
                                    pos++;
                                }
                                break;
                            }
                        }

                        for (int p = 0; p < 1; p++)
                        {
                            if (mochiParaEvo == null)
                            {
                                MensagemColor("Mochila do USUÁRIO não carregada.");
                                MensagemColor("\nCALMA!!! Pode fazer isto agora!");
                                Console.WriteLine("\nDigite o nome da mochila para ser carregada: ");
                                texto = Console.ReadLine();
                                Console.Clear();

                                ArqExiste(ref texto);
                                Console.WriteLine();

                                texto = LerMochi(texto, ref contMochi, ref usuario);
                                Split(usuario, ref mochiSplit);

                                Console.Write(texto + "\n");
                                Console.WriteLine(new string('-', 50));
                                MensagemColor("Pokémons carregados com sucesso!", contMochi, "green");
                                Console.WriteLine("\nPressione qualquer tecla para continuar.", true);
                                Console.ReadKey();
                                Console.Clear();

                                pos = 0;

                                // mochiParaEvo = new MochiUsuar[contEvo];
                                mochiParaEvo = new MochiUsuar[mochiSplit.Length / 3];

                                // CARREGA AS POSIÇÕES DO STRUCT DA MOCHILA DO USUÁRIO (QUE SERÁ EVOLUÍDA) COM OS POKEMONS SPLITADOS
                                for (int i = 0; i < mochiParaEvo.Length * 3; i += 3)
                                {
                                    mochiParaEvo[pos].pokem = mochiSplit[i];
                                    mochiParaEvo[pos].qtdPokem = mochiSplit[i + 1];
                                    mochiParaEvo[pos].qtdCandies = mochiSplit[i + 2];
                                    pos++;
                                }
                            }
                        }

                        // INICIALIZAÇÃO ARRAYS MOCHILA USUÁRIO
                        candiesUsuarInt = new int[contMochi];
                        qtdPokemUsuarInt = new int[contMochi];
                        qtdCandiesUsuar = new string[contMochi];
                        qtdPokemUsuarStr = new string[contMochi];

                        // INICIALIZAÇÃO ARRAYS MOCHILA DADOS
                        candiesDadosEvoInt = new int[contEvo];
                        qtdCandiesDados = new string[contEvo];

                        // FOR's PARA PASSAR OS STRINGS DO STRUCT PARA NOVOS ARRAYS
                        for (int i = 0; i < mochiParaEvo.Length; i++)
                        {
                            qtdCandiesUsuar[i] = mochiParaEvo[i].qtdCandies;
                        }
                        for (int i = 0; i < mochiParaEvo.Length; i++)
                        {
                            qtdPokemUsuarStr[i] = mochiParaEvo[i].qtdPokem;
                        }
                        for (int i = 0; i < mochiDados.Length; i++)
                        {
                            qtdCandiesDados[i] = mochiDados[i].qtdCandies;
                        }

                        // CHAMA OS MÉTODOS PARA CONVERTER OS ARRAYS DOS CANDIES DE STRING PARA INT
                        ConvStrToInt(qtdCandiesUsuar, ref candiesUsuarInt);
                        ConvStrToInt(qtdCandiesDados, ref candiesDadosEvoInt);
                        ConvStrToInt(qtdPokemUsuarStr, ref qtdPokemUsuarInt);

                        // AQUI COMEÇA O RITUAL DA PRIMEIRA EVOLUÇÃO

                        // FAZ A EVOLUÇÃO DOS POKEMONS A PRIMEIRA VEZ e/ou GUARDA NA MOCHILA EVOLUÍDA DO USUÁRIO OS POKEMONS QUE NÃO EVOLUEM PARA NENHUM OUTRO
                        for (int i = 0; i < mochiParaEvo.Length; i++)
                        {
                            for (int j = 0; j < mochiDados.Length; j++)
                            {
                                if (mochiParaEvo[i].pokem == mochiDados[j].pokemOrig && candiesDadosEvoInt[j] == 0)
                                {
                                    naoEvo[i].nomePokem = mochiParaEvo[i].pokem;
                                    naoEvo[i].qtdCandies = candiesUsuarInt[i];
                                    naoEvo[i].qtdPokem = qtdPokemUsuarInt[i];
                                    continue;
                                }
                                // SE O POKEMON EVOLUI, ESTE ELSE IF MOSTRAR QUE ENCONTROU O POKEMON DO USUÁRIO NA MOCHILA PARA COMPARAR
                                else if (mochiParaEvo[i].pokem == mochiDados[j].pokemOrig)
                                {
                                    // VERIFICA SE TEM QUANTIDADE DECANDIES SUFICIENTE PARA A EVOLUÇÃO, SE NÃO TIVER, GUARDA NA MOCHILA naoEvo
                                    if (candiesUsuarInt[i] < candiesDadosEvoInt[j])
                                    {
                                        naoEvo[i].nomePokem = mochiParaEvo[i].pokem;
                                        naoEvo[i].qtdCandies = candiesUsuarInt[i];
                                        naoEvo[i].qtdPokem = qtdPokemUsuarInt[i];
                                        continue;
                                    }

                                    // POKEMON EVOLUI, OS CANDIES DO USUARIO PERMITEM A EVOLUÇÃO E A QTD DE POKEMON É MAIOR QUE '0'
                                    // ESTE WHILE FAZ A PRIMEIRA EVOLUÇÃO
                                    while (candiesUsuarInt[i] >= candiesDadosEvoInt[j] && qtdPokemUsuarInt[i] > 0)
                                    {
                                        candiesUsuarInt[i] -= candiesDadosEvoInt[j]; // DECREMENTA A QTD DE CANDIES QUE FORAM UTILIZADOS NA EVOLUÇÃO
                                        qtdPokemUsuarInt[i] -= 1; // DECREMENTA EM 1, PORQUE 1 POKEMON EVOLUIU
                                        mochiEvol[i].pokemEvol = mochiDados[j].pokemEvol; // MOCHILA EVOLUIDA RECEBE O NOME DO POKEMON EVOLUIDO
                                        mochiEvol[i].qtdCandiesRestEvo = candiesUsuarInt[i]; // MOCHILA EVOLUIDA RECEBE A QUANTIDADE DE CANDIES RESTANTES DEPOIS DE CADA EVOLUÇÃO
                                        mochiEvol[i].qtdPokemEvol++; // INCREMENTA 1 POKEMON EVOLUIDO A CADA EVOLUÇÃO
                                    }
                                    // IF PARA GUARDAR OS POKEMONS QUE NÃO EVOLUIRAM A PRIMEIRA VEZ(QTD DE CANDIES INSUFICIENTES)
                                    // GUARDA NA POSIÇÃO i+1
                                    if (qtdPokemUsuarInt[i] > 0)
                                    {
                                        naoEvo[i].nomePokem = mochiParaEvo[i].pokem; // MOCHILA EVOLUIDA RECEBE O NOME DO POKEMON QEU NÃO EVOLUIU
                                        naoEvo[i].qtdCandies = 0; // CANDIES IGUAL A ZERO, OS CANDIES PASSARÃO PARA O POKEMON EVOLUIDO
                                        naoEvo[i].qtdPokem = qtdPokemUsuarInt[i]; // QTD DE POKEMON É A QUANTIDAD DE POKEMONS QUE RESTARAM
                                    }
                                }
                            }
                        }

                        //AQUI COMEÇA A SEGUNDA EVOLUÇÃO

                        // "FOR" PARA PERCORRER A MOCHILA EVOLUÍDA
                        for (int i = 0; i < mochiEvol.Length; i++)
                        {
                            for (int j = 0; j < mochiDados.Length; j++)
                            {
                                //SE O POKEMON QUE EVOLUIU 1 VEZ VAI EVOLUIR NOVAMENTE
                                //AQUI VAI VER SE O BICHO EVOLUI NOVAMENTE, SE NÃO EVOLUI NOVAMENTE, GUARDA NA MOCHILA FINAL DO USUÁRIO
                                if (mochiEvol[i].pokemEvol == mochiDados[j].pokemOrig && candiesDadosEvoInt[j] == 0)
                                {
                                    mochiFinal[i].nomePokem = mochiEvol[i].pokemEvol;
                                    mochiFinal[i].qtdPokem = mochiEvol[i].qtdPokemEvol;
                                    mochiFinal[i].qtdCandies = mochiEvol[i].qtdCandiesRestEvo;
                                    continue;
                                }

                                // AQUI SIGNIFICA QUE O POKEMON EVOLUI NOVAMENTE;
                                //PORÉM SOMENTE IRÁ EVOLUIR SE O POKEMON "EVOLUIDO" APARECER COMO POKEMON ORIGINAL, OU SEJA, SIGNIFICA QUE ELE TEM UMA EVOLUÇÃO
                                //E SÓ IRÁ EVOLUIR SE A QTD DE CANDIES PERMITIR E SE A QTD DE POKEMONS FOR MAIOR QUE 0
                                else if (mochiEvol[i].pokemEvol == mochiDados[j].pokemOrig && mochiEvol[i].qtdCandiesRestEvo >= candiesDadosEvoInt[j] && mochiEvol[i].qtdPokemEvol > 0)
                                {
                                    while (mochiEvol[i].qtdCandiesRestEvo >= candiesDadosEvoInt[j] && mochiEvol[i].qtdPokemEvol > 0)
                                    {
                                        mochiEvol[i].qtdCandiesRestEvo -= candiesDadosEvoInt[j]; //DECREMENTA A QUANTIDADE DE CANDIES UTILIZADA PARA EFETUAR A EVOLUÇÃO
                                        mochiEvol[i].qtdPokemEvol -= 1; // DECREMENTA EM 1 A QTD DE POKEMONS QUE FORAM EVOLUIDOS

                                        mochiFinal[i].nomePokem = mochiDados[j].pokemEvol; //MOCHILA FINAL RECEBE O NOME DO POKEMON EVOLUIDO
                                        mochiFinal[i].qtdCandies = mochiEvol[i].qtdCandiesRestEvo; //MOCHILA FINAL RECEBE A QUANTIDADE DE CANDIES RESTANTES
                                        mochiFinal[i].qtdPokem++; //INCREMENTA EM 1 A QTD DE POKEMONS EVOLUIDOS (somente um contador da quantidade de vezes que é evoluido)
                                    }

                                    //VERIFICA SE RESTARAM POKEMONS QUE NÃO EVOLUIRAM UMA SEGUNDA VEZ (FALTA DE CANDIES)
                                    //SE RESTARAM, GRAVA NA MOCHILA FINAL NA POSIÇÃO K+1
                                    if (mochiEvol[i].qtdPokemEvol > 0)
                                    {
                                        //for para preencher o struct naoEvo e if para verificar se a posição está vazia ou não
                                        for (int k = 0; k < naoEvo.Length; k++)
                                            if (naoEvo[k].nomePokem == null)
                                            {
                                                naoEvo[i].nomePokem = mochiEvol[i].pokemEvol; // MOCHILA EVOLUIDA RECEBE O NOME DO POKEMON QEU NÃO EVOLUIU
                                                naoEvo[i].qtdCandies = 0; // CANDIES IGUAL A ZERO, OS CANDIES PASSARÃO PARA O POKEMON EVOLUIDO
                                                naoEvo[i].qtdPokem = mochiEvol[i].qtdPokemEvol; //QTD DE POKEMON É A QUANTIDAD DE POKEMONS QUE RESTARAM
                                            }
                                    }
                                }
                            }
                        }
                        Console.Clear();

                        MensagemColor("Pokémons evoluídos com sucesso!\n", "green");

                        do
                        {
                            opcao = MenuCase3(opcao);

                            Console.Clear();
                            switch (opcao)
                            {
                                case 1:
                                    Console.Clear();

                                    Console.WriteLine("Pokémons evoluídos:\n");
                                    //OPÇÃO PARA APRESENTAR NA TELA
                                    for (int i = 0; i < mochiFinal.Length; i++)
                                    {
                                        if (mochiFinal[i].nomePokem != null)
                                            Console.WriteLine("{0};{1};{2}", mochiFinal[i].nomePokem, mochiFinal[i].qtdPokem, mochiFinal[i].qtdCandies);
                                        if (naoEvo[i].nomePokem != null)
                                            Console.WriteLine("{0};{1};{2}", naoEvo[i].nomePokem, naoEvo[i].qtdPokem, naoEvo[i].qtdCandies);
                                    }

                                    Console.WriteLine("\nPressione qualquer tecla para continuar.", true);

                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                // OPCÃO PARA CRIAR ARQUIVO
                                case 2:
                                    Console.Clear();

                                    Console.Write("Digite o nome do arquivo a ser criado: ");
                                    nomeArq = Console.ReadLine();
                                    using (StreamWriter txt = new StreamWriter(@nomeArq + ".txt"))
                                    {

                                        for (int u = 0; u < mochiFinal.Length; u++)
                                        {
                                            if (mochiFinal[u].nomePokem != null)
                                            {
                                                txt.Write(mochiFinal[u].nomePokem + ";");
                                                txt.Write(mochiFinal[u].qtdPokem + ";");
                                                txt.Write(mochiFinal[u].qtdCandies + "\r\n");
                                            }
                                        }
                                        for (int u = 0; u < naoEvo.Length; u++)
                                        {
                                            if (naoEvo[u].nomePokem != null)
                                            {
                                                txt.Write(naoEvo[u].nomePokem + ";");
                                                txt.Write(naoEvo[u].qtdPokem + ";");
                                                txt.Write(naoEvo[u].qtdCandies + "\r\n");
                                            }
                                        }
                                        txt.Close();
                                    }
                                    Console.Clear();
                                    MensagemColor("Pokémons carregados com sucesso!", contMochi, "green");
                                    Console.WriteLine();
                                    break;
                            }
                        } while (opcao != 0 && opcao != 3);

                        Console.Clear();
                        break;

                    //APRESENTAR MOCHILA JÁ CRIADA NA TELA
                    case 4:
                            Console.WriteLine("Digite o nome da mochila evoluída: ");
                            texto = Console.ReadLine();
                            Console.Clear();

                            ArqExiste(ref texto);

                            Console.WriteLine("Mochila evoluída: \n");
                            texto = LerMochi(nomeArq, ref contMochi, ref usuario);
                            Console.WriteLine(texto);

                            Console.WriteLine("Digite qualquer tecla para voltar ao menu inicial.");
                            Console.ReadKey();
                            break;
                    }

                } while (opcao != 0);
        }
    }
}
