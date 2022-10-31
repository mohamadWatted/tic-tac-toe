using System;
using System.Threading;

namespace prog
{
    class Program
    {
        static void Main(string[] args)
        {
            bool start = true;
            while (start) {
                Console.Clear();
                char[] build = new char[10];
                char[] ar = Build(build);
                //char player1Choice, player2Choice, choose;
                int player = 0;
                string[] namePlayer = new string[3];
                int flag = 0;
                int choice;
                char choose;
                string namePlayer1, namePlayer2;
                Console.WriteLine("player 1,Enter Your Name:");
                namePlayer1 = Console.ReadLine();
                Console.WriteLine("Choose X or O");

                choose = char.Parse(Console.ReadLine());
                char[] arrChoice = { 'X', 'O' };
                bool isZero = true;
                if (choose == 'X')
                    arrChoice[0] = 'X';
                else if (choose == 'O')
                    arrChoice[0] = 'O';
                else
                {
                    Console.WriteLine("GAME OVER!! because You have selected an invalid character");
                    isZero = false;
                }
                if (isZero)
                {
                    Console.WriteLine("player 2,Enter Your Name:");
                    namePlayer2 = Console.ReadLine();
                    Console.WriteLine("Choose X or O");
                    choose = char.Parse(Console.ReadLine());

                    if (choose == 'X')
                        arrChoice[1] = 'X';
                    else if (choose == 'O')
                        arrChoice[1] = 'O';
                    else
                    {
                        Console.WriteLine("GAME OVER!! because You have selected an invalid character");
                        isZero = false;
                    }

                    namePlayer[1] = namePlayer1;
                    namePlayer[2] = namePlayer2;
                }
                while (flag != -1 && flag != 1 && isZero)
                {
                    Console.Clear();
                    Console.WriteLine($"****Tic Tac Game****\n\t{namePlayer[1]}:{arrChoice[0]} and {namePlayer[2]}:{arrChoice[1]}");
                    Console.WriteLine("\n");
                    if (player % 2 == 0)
                        Console.WriteLine($"{namePlayer[1]} your chance to win");
                    else
                        Console.WriteLine($"{namePlayer[2]} your chance to win");
                    Console.WriteLine("\n");
                    Board(ar);

                    choice = int.Parse(Console.ReadLine());
                    if (ar[choice] != 'X' && ar[choice] != 'O')
                    {
                        if (player % 2 == 0)
                        {
                            if (choice!=0)
                            {
                                ar[choice] = arrChoice[0];
                                player++;
                            }
                            else
                            {
                                Console.WriteLine("GAME OVER!! because You have selected an invalid number");
                                isZero = false;
                            }
                        }

                        else
                        {
                            if (choice != 0)
                            {
                                ar[choice] = arrChoice[1];
                                player++;
                            }
                            else
                            {
                                Console.WriteLine("GAME OVER!! because You have selected an invalid number");
                                isZero = false;
                            }

                        }
                    }
                    else

                    {
                        Console.WriteLine($"Sorry the row {choice} is already marked with {ar[choice]}");
                        Console.WriteLine("\n");
                        Console.WriteLine("Please wait 2 second board is loading again.....");
                        Thread.Sleep(2000);
                    }
                    flag = CheckWin(ar);


                }
                if (!isZero)
                { 
                    Console.WriteLine("Do you want to play again? enter yes and print enter");
                    string again = Console.ReadLine();
                    if (again == "yes")
                        Console.WriteLine("Nice,The game started again");
                    else
                    {
                        start = false;
                        Console.WriteLine("You can try again later,Have a nice day");
                    }
                 }

                else if (flag == 1)
                {
                    int winner = ((player % 2) + 1);
                    Console.Clear();
                    Console.WriteLine("The winner is player number " + winner + " The name of the winner is " + namePlayer[winner]);
                    Board(ar);
                    start = false;
                }
                else if (flag == -1)
                {
                    Console.Clear();
                    Console.WriteLine("There is no winner");
                    Board(ar);
                    start = false;
                }


                Console.ReadKey();
            }
        }

         static int CheckWin(char[]arr)
        {
            if (arr[1] == arr[2] && arr[2] == arr[3])
                return 1;
            else if (arr[4] == arr[5] && arr[5] == arr[6])
                return 1;
            else if (arr[7] == arr[8] && arr[8] == arr[9])
                return 1;
            else if (arr[1] == arr[5] && arr[5] == arr[9])
                return 1;
            else if (arr[3] == arr[5] && arr[5] == arr[7])
                return 1;
            else if (arr[1] == arr[4] && arr[4] == arr[7])
                return 1;
            else if (arr[2] == arr[5] && arr[5] == arr[8])
                return 1;
            else if (arr[3] == arr[6] && arr[6] == arr[9])
                return 1;
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            else return 0;


        }

        static void Board(char[] arr)
        {
            Console.WriteLine($"     |     |      ");
            Console.WriteLine($"  {arr[1]}  |  {arr[2]}  |  {arr[3]}");
            Console.WriteLine($"_____|_____|_____ ");
            Console.WriteLine($"     |     |      ");
            Console.WriteLine($"  {arr[4]}  |  {arr[5]}  |  {arr[6]}");
            Console.WriteLine($"_____|_____|_____ ");
            Console.WriteLine($"     |     |      ");
            Console.WriteLine($"  {arr[7]}  |  {arr[8]}  |  {arr[9]}");
            Console.WriteLine($"     |     |      ");
        }

        static void Print(char[] ar)
        {
            for (int i = 1; i < ar.Length; i++)
                Console.Write(ar[i]+"\t");
        }

        static char[] Build(char[] build)
        {
            for (int i = 1; i < build.Length; i++)
                build[i] = (char)(i+'0');
            return build;
        }
    }
}