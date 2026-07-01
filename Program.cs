using System;
using System.Threading;

class Program
{
    // Questão 17 e 18: Função auxiliar para exibir o tabuleiro de forma organizada
    static void ExibirTabuleiro(string[,] matriz, int pares, int tent)
    {
        Console.Clear();
        Console.WriteLine("=== JOGO DA MEMÓRIA 6x3 ===");
        Console.WriteLine($"Pares: {pares}/9 | Tentativas: {tent}\n");
        Console.WriteLine("        0       1       2");
        Console.WriteLine("----------------------------");

        for (int i = 0; i < 6; i++)
        {
            Console.Write($"{i} |     ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matriz[i, j] + "       ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // === PARTE 1: Configuração Inicial ===
        Console.WriteLine("=== JOGO DA MEMÓRIA 6x3 ===");
        Console.WriteLine("Bem-vindo ao jogo!\n");

        // Questão 2 e 24: Criação do Gabarito com Embaralhamento Automático
        char[,] gabarito = new char[6, 3];
        char[] letras = { 'A', 'A', 'B', 'B', 'C', 'C', 'D', 'D', 'E', 'E', 'F', 'F', 'G', 'G', 'H', 'H', 'I', 'I' };
        
        // Algoritmo de Fisher-Yates para embaralhar as cartas
        Random rand = new Random();
        for (int i = letras.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            char temp = letras[i];
            letras[i] = letras[j];
            letras[j] = temp;
        }

        // Preenche a matriz gabarito com as letras embaralhadas
        int index = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                gabarito[i, j] = letras[index++];
            }
        }

        // Questão 3 e 4: Matriz Visual preenchida com "*"
        string[,] visual = new string[6, 3];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                visual[i, j] = "*";
            }
        }

        // Questão 5: Exibição para Memorização Inicial
        Console.WriteLine("=== MEMORIZE AS POSIÇÕES ===");
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(gabarito[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Questão 6: Tempo para Memorização
        Thread.Sleep(10000);
        Console.Clear();

        // === PARTE 2 e 3: Funcionamento e Loop Principal ===
        int paresEncontrados = 0; // Questão 7
        int tentativas = 0;       // Questão 7

        while (paresEncontrados < 9) // Questão 8
        {
            int l1 = -1, c1 = -1;
            bool jogada1Valida = false;

            // Loop de validação da PRIMEIRA CARTA
            while (!jogada1Valida)
            {
                // Questão 19: Chamada da função organizada
                ExibirTabuleiro(visual, paresEncontrados, tentativas);

                Console.WriteLine("Escolha a 1ª carta:");
                Console.Write("Linha (0-5): ");
                string entradaL1 = Console.ReadLine();
                Console.Write("Coluna (0-2): ");
                string entradaC1 = Console.ReadLine();

                // Evita crash se o usuário apertar Enter sem digitar nada
                if (int.TryParse(entradaL1, out l1) && int.TryParse(entradaC1, out c1))
                {
                    // Questão 21: Validação das posições fora do intervalo
                    if (l1 < 0 || l1 > 5 || c1 < 0 || c1 > 2)
                    {
                        Console.WriteLine("\nPosição inválida. Digite uma linha entre 0 e 5 e uma coluna entre 0 e 2.");
                        Thread.Sleep(2500);
                    }
                    // Questão 23: Impedir escolha de carta já encontrada
                    else if (visual[l1, c1] != "*")
                    {
                        Console.WriteLine("\nEssa carta já foi encontrada. Escolha outra posição.");
                        Thread.Sleep(2500);
                    }
                    else
                    {
                        jogada1Valida = true;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida. Digite apenas números inteiros.");
                    Thread.Sleep(2500);
                }
            }

            // Questão 11: Revelação da primeira carta
            visual[l1, c1] = gabarito[l1, c1].ToString();
            ExibirTabuleiro(visual, paresEncontrados, tentativas); // Questão 19

            int l2 = -1, c2 = -1;
            bool jogada2Valida = false;

            // Loop de validação da SEGUNDA CARTA
            while (!jogada2Valida)
            {
                Console.WriteLine("Escolha a 2ª carta:");
                Console.Write("Linha (0-5): ");
                string entradaL2 = Console.ReadLine();
                Console.Write("Coluna (0-2): ");
                string entradaC2 = Console.ReadLine();

                if (int.TryParse(entradaL2, out l2) && int.TryParse(entradaC2, out c2))
                {
                    // Questão 21: Validação das posições fora do intervalo
                    if (l2 < 0 || l2 > 5 || c2 < 0 || c2 > 2)
                    {
                        Console.WriteLine("\nPosição inválida. Digite uma linha entre 0 e 5 e uma coluna entre 0 e 2.");
                        Thread.Sleep(2500);
                        ExibirTabuleiro(visual, paresEncontrados, tentativas);
                    }
                    // Questão 22: Impedir escolha da mesma carta duas vezes
                    else if (l1 == l2 && c1 == c2)
                    {
                        Console.WriteLine("\nVocê não pode escolher a mesma carta duas vezes.");
                        Thread.Sleep(2500);
                        ExibirTabuleiro(visual, paresEncontrados, tentativas);
                    }
                    // Questão 23: Impedir escolha de carta já encontrada
                    else if (visual[l2, c2] != "*")
                    {
                        Console.WriteLine("\nEssa carta já foi encontrada. Escolha outra posição.");
                        Thread.Sleep(2500);
                        ExibirTabuleiro(visual, paresEncontrados, tentativas);
                    }
                    else
                    {
                        jogada2Valida = true;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida. Digite apenas números inteiros.");
                    Thread.Sleep(2500);
                    ExibirTabuleiro(visual, paresEncontrados, tentatives);
                }
            }

            // Questão 13: Revelação da segunda carta
            visual[l2, c2] = gabarito[l2, c2].ToString();
            ExibirTabuleiro(visual, paresEncontrados, tentativas); // Questão 19

            tentativas++; // Questão 14

            // Questão 15: Comparação das cartas escolhidas
            if (gabarito[l1, c1] == gabarito[l2, c2])
            {
                Console.WriteLine("\nBOA! Par encontrado!");
                paresEncontrados++;
                Thread.Sleep(2000);
            }
            else
            {
                // Questão 16: Tratamento quando o jogador erra
                Console.WriteLine("\nERROU! Tente memorizar...");
                Thread.Sleep(2000);
                visual[l1, c1] = "*";
                visual[l2, c2] = "*";
            }
        }

        // Questão 20: Finalização do jogo fora do loop while
        Console.Clear();
        Console.WriteLine($"PARABÉNS! Você completou o jogo em {tentativas} tentativas.\n");

        // Questão 25: Relatório final do jogo e Desempenho
        string desempenho = "";
        if (tentativas <= 12) desempenho = "Excelente";
        else if (tentativas <= 18) desempenho = "Muito bom";
        else if (tentativas <= 25) automation_desempenho = "Bom";
        else desempenho = "Pode melhorar";

        Console.WriteLine("=== RELATÓRIO FINAL ===");
        Console.WriteLine($"Pares encontrados: {paresEncontrados}/9");
        Console.WriteLine($"Tentativas: {tentativas}");
        Console.WriteLine($"Desempenho: {desempenho}!");
    }
}
