using System;
using System.Threading;

namespace TICxTACxTOE
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;
            do
            {
                PlayGame();
                Console.WriteLine("Do you want to play again? (y/n)");
            } 
            while (Console.ReadLine().ToLower() == "y");

            Console.WriteLine("Thanks for playing! Do widzenia!");
        }

        static void PlayGame()
        {
            InitializeGame(); // Clears the board and reset variables

            do
            {
                Console.Clear();
                Console.WriteLine("Player1:X Player2:O");
                Console.WriteLine("\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's Turn");
                }
                else
                {
                    Console.WriteLine("Player 1's Turn");
                }

                Console.WriteLine("\n");
                Board();

                bool isValidInput = false;

                do
                {
                    Console.WriteLine("Please enter a number between 1 and 9:");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out choice) && choice >= 1 && choice <= 9)
                    {
                        isValidInput = true;

                        if (arr[choice] != 'X' && arr[choice] != 'O')
                        {
                            if (player % 2 == 0)
                            {
                                arr[choice] = 'O';
                                player++;
                            }
                            else
                            {
                                arr[choice] = 'X';
                                player++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, the place {0} is already marked with {1}", choice, arr[choice]);
                            Console.WriteLine("\n");
                            Console.WriteLine("Please wait 2 seconds; the board is loading again.....");
                            Thread.Sleep(2000);
                        }

                        flag = CheckWin();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number between 1 and 9 that you see on the table.");
                    }
                } while (!isValidInput);
            } while (flag != 1 && flag != -1);

            Console.Clear();
            Board();

            if (flag == 1)
            {
                Console.WriteLine("PLAYER {0} HAS WON THE BATTLE!!!!  ", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("ROUND DRAW!!!");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        static void InitializeGame() // Calls the reset function
        {
            for (int i = 1; i < 10; i++)
            {
                arr[i] = char.Parse(i.ToString());
            }

            player = 1;
            choice = 0;
            flag = 0;
        }

        private static void Board() // 3x3 table with base numbers
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        private static int CheckWin()
        {
            //Horizontal Winning Condition
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            //Vertical Winning Condition
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            //Checking if it is draw or not
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            // Last part
            else
            {
                return 0;
            }
        }
    }
}
