using System;


namespace TicTacToeGame

{
    // Main Entrypoint of TIcTacToe Game
    class Program {

        // A 3 x 3 board used in the game. Here we use a one-dimensional character array to make representation easier
        static char[] Board = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};

        static char currentPlayer = 'X';

        // The number of open cells is 9 in the beginning.
        static int numOpenCells = 9;

        static void Main(string[] args) {
            bool gameOver = false;
            int move;
            

            while(!gameOver) {
                DrawBoard();
                move = GetPlayerMove();

                Board[move - 1] = currentPlayer;

                numOpenCells -= 1;

                if (checkWin()) {
                    DrawBoard();
                    gameOver = true;
                    Console.WriteLine("---- Game Over ----");
                    Console.WriteLine($"{currentPlayer} wins");
                } else{
                    if (checkDraw()) {
                        DrawBoard();
                        gameOver = true;
                        Console.WriteLine("---- Game Over ----");
                        Console.WriteLine("The game ends in draw! Please play again to settle for winner.");
                    }
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';  
            
            }

            // Console.WriteLine("Do you want to play another game? Type 'Y' / 'y' for Yes or enter anything to exit the game.");
            // string? reGame = Console.ReadLine();
            // if (reGame == "Y" || reGame == "y"){
            //     gameOver = false;
            // }
        } 


        // Draws 3x3 gameboard to be printed on the console
        private static void DrawBoard() {
            Console.Clear();
            Console.WriteLine("Tic-Tac-Toe");
            Console.WriteLine("-----------");
            Console.WriteLine($" {Board[0]} | {Board[1]} | {Board[2]}");
            Console.WriteLine("-----+-----");
            Console.WriteLine($" {Board[3]} | {Board[4]} | {Board[5]}");
            Console.WriteLine("-----+-----");
            Console.WriteLine($" {Board[6]} | {Board[7]} | {Board[8]}");
            Console.WriteLine("-----------");
            }

        private static int GetPlayerMove() {
            int move = 0;
            bool validMove = false;
            while(!validMove) {
                Console.WriteLine($"Player {currentPlayer}, please enter your move from 1 - 9.");

                // Putting string? as type for INPUT will let the compiler know that the values can be null. Don't forget to place a null check before proceding any further after assigning. For example:
                // string? input = Console.ReadLine();

                // if (input != null) {
                    // your code here
                // }

                // Whereas if we are certain that the value will not be null, then we can add null-forgiving operator(!) at the end. For example
                // string input = Console.ReadLine()!;

                // In this case, we are certain that the input will not be null. Therefore, we take the latter approach.

                string input = Console.ReadLine()!;

                // int.TryParse(input, out move) checks if INPUT is parsable to integer and if it is, then it assigns the 
                // parsed integer value to MOVE
                if (int.TryParse(input, out move) && move >= 1 && move <= 9 && Board[move - 1] != 'X' && Board[move - 1] != 'O') {
                    validMove = true;
                } else {
                    Console.WriteLine("Please enter a valid number for you move.");
                }
            }
            return move;
        }

        // Checks if currentPlayer has won. Returns true if won, false if not.
        private static bool checkWin() {

            // check rows
            bool firstRow = Board[0] == Board[1] && Board[1] == Board[2];
            bool secondRow = Board[3] == Board[4] && Board[4] == Board[5];
            bool thirdRow = Board[6] == Board[7] && Board[7] == Board[8];

            if (firstRow || secondRow || thirdRow) return true;

            // check columns
            bool firstCol = Board[0] == Board[3] && Board[3] == Board[6];
            bool secondCol = Board[1] == Board[4] && Board[4] == Board[7];
            bool thirdCol = Board[2] == Board[5] && Board[5] == Board[8];

            if (firstCol || secondCol || thirdCol) return true;

            // Check diagonals
            bool firstdiag = Board[0] == Board[4] && Board[4] == Board[8];
            bool secondDiag = Board[2] == Board[4] && Board[4] == Board[6];
            
            if (firstdiag || secondDiag) return true;

            return false;

        }

        // Checks is the game ends in a draw by cheking first that there is no winner and then chekcing if the number of open cells in the grid is zero.
        private static bool checkDraw() {
            return !checkWin() && numOpenCells == 0;
        }
    }
}



