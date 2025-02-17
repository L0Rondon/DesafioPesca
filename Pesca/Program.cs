
    
        int qtdPeixes, qtdPessoas, qtdIscas;

        // Entradas
        Console.Write("Quantos Peixes tem no lago: ");
        qtdPeixes = int.Parse(Console.ReadLine());

        Console.Write("Número de Jogadores: ");
        qtdPessoas = int.Parse(Console.ReadLine());

        Console.Write("Número de Iscas/Tentativas: ");
        qtdIscas = int.Parse(Console.ReadLine());

        if (qtdIscas == 0 || qtdPessoas == 0)
        {
            Console.WriteLine("Não é possível iniciar o jogo! Valor inserido inválido");
            return;
        }

        string[] nomes = new string[qtdPessoas];
        int[,] escolha = new int[qtdIscas, qtdPessoas];
        int[] pontos = new int[qtdPessoas];

        // Pegando os nomes dos jogadores
        for (int i = 0; i < qtdPessoas; i++)
        {
            Console.Write("Escreva o nome da " + (i + 1) + "° pessoa: ");
            nomes[i] = Console.ReadLine();
        }

        // Criando o lago com peixes em posições aleatórias
        int[] lago = new int[50];
        Random r = new Random();
        int peixesPoscionados = 0;

        while (peixesPoscionados < qtdPeixes)
        {
            int pos = r.Next(1, 51); // Posições de 1 a 50
            if (Array.IndexOf(lago, pos) == -1) // Verifica se já tem peixe nessa posição
            {
                lago[peixesPoscionados] = pos;
                peixesPoscionados++;
            }
        }

        // Processamento/Jogo
        for (int rodadas = 0; rodadas < qtdIscas; rodadas++)
        {
            for (int j = 0; j < qtdPessoas; j++)
            {
                Console.WriteLine("\nOpções de posição:");
                for (int i = 1; i <= 50; i++)
                {
                    Console.Write("(" + i + ") ");
                    if (i % 10 == 0) {
                        Console.WriteLine(); // Quebra a linha a cada 10 números
                    }
                }

                Console.WriteLine();
                Console.Write(nomes[j] + ", escolha a posição: ");
                escolha[rodadas, j] = int.Parse(Console.ReadLine());

                if (Array.IndexOf(lago, escolha[rodadas, j]) != -1)
                {
                    Console.WriteLine("Parabéns " + nomes[j] + ", você pegou um peixe!");
                    pontos[j]++;
                }
                else
                {
                    Console.WriteLine(nomes[j] + ", você não pegou um peixe. Mais sorte na próxima!");
                }
            }
        }

        // Determinar o vencedor
        int maxPontos = pontos[0];
        int vencedorIndex = 0;

        for (int i = 1; i < qtdPessoas; i++)
        {
            if (pontos[i] > maxPontos)
            {
                maxPontos = pontos[i];
                vencedorIndex = i;
            }
        }

        Console.WriteLine("\nO vencedor é " + nomes[vencedorIndex] + " com " + maxPontos + " pontos!");
    
