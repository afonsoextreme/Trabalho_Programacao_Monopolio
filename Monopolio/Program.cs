using System;

class Program
{
    static void Main(string[] args)
    {
        var controller = new GameController();

        int n;
        do
        {
            n = ConsoleView.PromptInt("Quantos jogadores? (1-5) ", 0);
            if (n < 1 || n > 5)
            {
                ConsoleView.ShowError("Número inválido — introduz entre 1 e 5 jogadores.");
            }
        } while (n < 1 || n > 5);

        for (int i = 1; i <= n; i++)
        {
            var nome = ConsoleView.Prompt($"Nome do jogador {i}: ");
            var player = controller.registarJogador(nome);
            if (player == null)
            {
                ConsoleView.ShowError("Registo falhou. Tenta um nome diferente.");
                i--; // repetir este índice
            }
        }

        Console.WriteLine();
        ConsoleView.ShowPlayers(controller.GetPlayers());

        Console.WriteLine();
        var board = new Board();
        ConsoleView.ShowBoard(board);
    }
}