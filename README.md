# Jogo da Memória em C# (Console)

Este projeto consiste no desenvolvimento de um Jogo da Memória no formato CLI (Console) utilizando a linguagem C#. O tabuleiro possui uma estrutura de 6 linhas por 3 colunas (totalizando 18 cartas / 9 pares) focado na fixação de conceitos de matrizes, loops e lógica estruturada.

## 🛠️ Documentação do Desenvolvimento Técnico

### Parte 1 — Preparação do Jogo
* **Estrutura Inicial**: O programa foi construído sob o paradigma estruturado utilizando o entry-point estático padrão `static void Main(string[] args)` dentro da classe principal do arquivo `Program.cs`.
* **Matriz Gabarito**: Foi implementada uma matriz bidimensional de caracteres (`char[,]`) com dimensões 6x3 encarregada de armazenar as posições originais das letras de 'A' até 'I'.
* **Matriz Visual**: Uma matriz do tipo string (`string[,]`), também 6x3, foi inicializada dinamicamente preenchendo todos os seus índices com o caractere oculto asterisco (`*`) através de loops aninhados do tipo `for`.
* **Etapa de Memorização**: Antes do início do jogo, renderiza-se a matriz gabarito em tela por 10 segundos utilizando o temporizador nativo `Thread.Sleep(10000)`. Na sequência, limpa-se o buffer do console chamando o comando `Console.Clear()` para esconder as posições.

### Parte 2 — Funcionamento Principal do Jogo
* **Contadores de Controle**: Foram estabelecidas as variáveis inteiras `paresEncontrados` (critério de parada) e `tentativas` (métrica de rodadas).
* **Controle de Loop**: Um laço lógico estrutural `while (paresEncontrados < 9)` dita a repetição contínua até o completo desfecho do jogo.
* **Escolha das Cartas**: O jogador informa os índices desejados por meio da leitura do teclado capturada através do `Console.ReadLine()`.
* **Revelação no Tabuleiro**: Ao selecionar uma coordenada válida, a string contida na matriz `visual` adota temporariamente o caractere original contido na mesma coordenada da matriz `gabarito`.
* **Lógica de Comparação**: O sistema confronta as duas entradas baseando-se no operador condicional de igualdade. O programa analisa se `gabarito[l1, c1] == gabarito[l2, c2]`. Em caso de erro, o jogo dá uma pausa visual de 2 segundos com `Thread.Sleep(2000)` e retorna os valores das coordenadas modificadas para o padrão oculto (`*`). Em caso de acerto, os caracteres correspondentes permanecem definitivamente expostos.

### Parte 3 — Organização e Regras de Negócio
* **Método ExibirTabuleiro**: Função modular criada para isolar e padronizar a renderização do jogo em tela. Ela recebe como parâmetros a matriz corrente, os pares atuais e as tentativas realizadas. Isso limpa códigos repetidos em lote e formata o layout com colunas numeradas de 0 a 2 e linhas de 0 a 5 de forma alinhada.
* **Critério de Vitória**: Quando a condição do `while` quebra (9 pares encontrados), o jogo salta para fora do bloco repetidor e emite os parabéns ao usuário limpando a tela.

### Parte 4 — Melhorias Implementadas (Bônus)
* **Validação contra Out-of-Bounds**: Verificação condicional que impede inputs inválidos de linhas fora do escopo 0-5 ou colunas fora do escopo 0-2.
* **Bloqueio de Duplicidade**: Filtro lógico estruturado que invalida a tentativa caso o jogador tente selecionar a mesma coordenada cartesiana exata para a carta um e dois da mesma rodada.
* **Filtro contra Cartas já Reveladas**: Impede o desperdício de tentativas bloqueando a seleção de cartas cujo conteúdo visual já não seja mais o asterisco (`*`).
* **Tratamento de Crash (TryParse)**: Implementação preventiva com `int.TryParse` para que entradas de texto acidentais ou comandos em branco não travem a aplicação.
* **Embaralhamento Dinâmico**: Aplicação do algoritmo estatístico Fisher-Yates para misturar as letras no vetor base de forma aleatória antes do mapeamento para o gabarito. Dessa forma, cada partida gera um jogo único.
* **Métrica de Desempenho**: Sistema condicional acoplado ao relatório final do jogo classificando o progresso do usuário de acordo com sua eficiência (Excelente, Muito Bom, Bom ou Pode Melhorar).
