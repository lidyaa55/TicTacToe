using System;

class TicTacToe
{
    static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int currentPlayer = 1; // Player 1 starts
    static int choice;
    static int flag = 0;

    public static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            DisplayBoard();
            Console.WriteLine($"Player {currentPlayer}'s turn (Enter 1-9):");

            choice = int.Parse(Console.ReadLine());

            if (choice >= 1 && choice <= 9 && board[choice] != 'X' && board[choice] != 'O')
            {
                board[choice] = (currentPlayer == 1) ? 'X' : 'O';
                flag = CheckWin();

                currentPlayer = (currentPlayer % 2) + 1; // Switch player
            }
            else
            {
                Console.WriteLine("Invalid move, please try again.");
                Console.ReadLine();
            }
        }
        while (flag != 1 && flag != 2);

        Console.Clear();
        DisplayBoard();
        if (flag == 1)
            Console.WriteLine("Player 1 (X) wins!");
        else
            Console.WriteLine("Player 2 (O) wins!");

        Console.ReadLine();
    }

    private static void DisplayBoard()
    {
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[1]}  |  {board[2]}  |  {board[3]} ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[4]}  |  {board[5]}  |  {board[6]} ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[7]}  |  {board[8]}  |  {board[9]} ");
        Console.WriteLine("     |     |     ");
    }

    private static int CheckWin()
    {
        // Horizontal, Vertical, and Diagonal checks
        if ((board[1] == board[2] && board[2] == board[3]) || 
            (board[4] == board[5] && board[5] == board[6]) || 
            (board[7] == board[8] && board[8] == board[9]) ||
            (board[1] == board[4] && board[4] == board[7]) || 
            (board[2] == board[5] && board[5] == board[8]) || 
            (board[3] == board[6] && board[6] == board[9]) ||
            (board[1] == board[5] && board[5] == board[9]) || 
            (board[3] == board[5] && board[5] == board[7]))
            return (board[1] == 'X') ? 1 : 2;

        // Check for tie
        foreach (var space in board)
        {
            if (space != 'X' && space != 'O')
                return 0; // Game still ongoing
        }

        return -1; // Tie
    }
}
