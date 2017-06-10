using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    static class Program
    {
        /*
        static int[,] board = new int[,]
          {
               {0, 0, 0, 0},
               {0, 0, 0, 0},
               {0, 0, 0, 0},
               {0, 0, 0, 0}
          };

        static int[,] prevState = new int[,]
        {
               {0, 0, 0, 0},
               {0, 0, 0, 0},
               {0, 0, 0, 0},
               {0, 0, 0, 0}
        };
        
        static public void initBoard()
        {

            int pick1, pick2;
            Random rnd = new Random();
            do
            {
                pick1 = rnd.Next(1, 17) - 1;
                pick2 = rnd.Next(1, 17) - 1;
            } while (pick1 == pick2);
            Console.WriteLine(pick1);
            Console.WriteLine(pick2);
            board[pick1 / 4, (pick1) % 4] = 2;
            board[pick2 / 4, (pick2) % 4] = 2;

        }

        
        static public void displayBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(board[i, j] + "\t");
                }
                Console.WriteLine();
            }
            
            Image image = Image.FromFile(@"C:\Users\ANEESH\Desktop\image1.jpg");
            pictureBox1.Image = image;
        }
        
        static void genereateNewItem()
        {
            Random rnd = new Random();
            int pick, row, col;
            do
            {
                pick = rnd.Next(1, 17) - 1;
                row = pick / 4;
                col = pick % 4;
            } while (board[row, col] != 0);
            board[row, col] = 2;
        }

        static int changeInState()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (board[i, j] != prevState[i, j])
                        return 1;
            return 0;
        }

        static void copyState()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    prevState[i, j] = board[i, j];
        }


        static int filledAll()
        {
            int filled = 1;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (board[i, j] == 0)
                        filled = 0;
            return filled;
        }

        static int checkGameOver()
        {
            return filledAll();// && CheckCollapseDown() && CheckCollapseUp() && CheckCollapseLeft() && CheckCollapseRight();
        }

        static public void moveDown()
        {
            for (int i = 0; i < 4; i++)
            {
                //Code here for ith column to collapse
                int[] temp = new int[4];
                int j, k = 0;
                for (j = 0; j < 4; j++)
                {
                    if (board[j, i] != 0)
                    {
                        temp[k] = board[j, i];
                        k++;
                    }
                }
                //total = k;
                k--;
                for (j = 3; j >= 0 && k >= 0; j--)
                {
                    board[j, i] = temp[k];
                    k--;
                }

                while (j >= 0)
                {
                    board[j, i] = 0;
                    j--;
                }

                if ((board[3, i] == board[2, i]) && (board[3, i] != 0))
                {
                    board[3, i] = board[2, i] + board[3, i];
                    board[2, i] = board[1, i];
                    board[1, i] = board[0, i];
                    board[0, i] = 0;
                }
                if ((board[2, i] == board[1, i]) && (board[2, i] != 0))
                {
                    board[2, i] = board[1, i] + board[2, i];
                    board[1, i] = board[0, i];
                    board[0, i] = 0;
                }
                if ((board[1, i] == board[0, i]) && (board[1, i] != 0))
                {
                    board[1, i] = board[0, i] + board[1, i];
                    board[0, i] = 0;
                }
            }
        }


        static public void moveUp()
        {
            for (int i = 0; i < 4; i++)
            {
                //Code here for ith column to collapse
                int[] temp = new int[4];
                int j, k = 0;
                for (j = 0; j < 4; j++)
                {
                    if (board[j, i] != 0)
                    {
                        temp[k] = board[j, i];
                        k++;
                    }
                }
                int total = k;
                k = 0;
                for (j = 0; j <= 3 && k < total; j++)
                {
                    board[j, i] = temp[k];
                    k++;
                }

                while (j <= 3)
                {
                    board[j, i] = 0;
                    j++;
                }

                if ((board[0, i] == board[1, i]) && (board[0, i] != 0))
                {
                    board[0, i] = board[0, i] + board[1, i];
                    board[1, i] = board[2, i];
                    board[2, i] = board[3, i];
                    board[3, i] = 0;
                }
                if ((board[1, i] == board[2, i]) && (board[1, i] != 0))
                {
                    board[1, i] = board[1, i] + board[2, i];
                    board[2, i] = board[3, i];
                    board[3, i] = 0;
                }
                if ((board[2, i] == board[3, i]) && (board[2, i] != 0))
                {
                    board[2, i] = board[2, i] + board[3, i];
                    board[3, i] = 0;
                }
            }
        }

        static public void moveLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                //Code here for ith row to collapse
                int[] temp = new int[4];
                int j, k = 0;
                for (j = 0; j < 4; j++)
                {
                    if (board[i, j] != 0)
                    {
                        temp[k] = board[i, j];
                        k++;
                    }
                }
                int total = k;
                k = 0;
                for (j = 0; j <= 3 && k < total; j++)
                {
                    board[i, j] = temp[k];
                    k++;
                }

                while (j <= 3)
                {
                    board[i, j] = 0;
                    j++;
                }

                if ((board[i, 0] == board[i, 1]) && (board[i, 0] != 0))
                {
                    board[i, 0] = board[i, 0] + board[i, 1];
                    board[i, 1] = board[i, 2];
                    board[i, 2] = board[i, 3];
                    board[i, 3] = 0;
                }
                if ((board[i, 1] == board[i, 2]) && (board[i, 2] != 0))
                {
                    board[i, 1] = board[i, 1] + board[i, 2];
                    board[i, 2] = board[i, 3];
                    board[i, 3] = 0;
                }
                if ((board[i, 2] == board[i, 3]) && (board[i, 2] != 0))
                {
                    board[i, 2] = board[i, 2] + board[i, 3];
                    board[i, 3] = 0;
                }
            }
        }

        static public void moveRight()
        {
            for (int i = 0; i < 4; i++)
            {
                //Code here for ith row to collapse
                int[] temp = new int[4];
                int j, k = 0;
                for (j = 0; j < 4; j++)
                {
                    if (board[i, j] != 0)
                    {
                        temp[k] = board[i, j];
                        k++;
                    }
                }
                //total = k;
                k--;
                for (j = 3; j >= 0 && k >= 0; j--)
                {
                    board[i, j] = temp[k];
                    k--;
                }

                while (j >= 0)
                {
                    board[i, j] = 0;
                    j--;
                }

                if ((board[i, 3] == board[i, 2]) && (board[i, 3] != 0))
                {
                    board[i, 3] = board[i, 2] + board[i, 3];
                    board[i, 2] = board[i, 1];
                    board[i, 1] = board[i, 0];
                    board[i, 0] = 0;
                }
                if ((board[i, 2] == board[i, 1]) && (board[i, 2] != 0))
                {
                    board[i, 2] = board[i, 1] + board[i, 2];
                    board[i, 1] = board[i, 0];
                    board[i, 0] = 0;
                }
                if ((board[i, 1] == board[i, 0]) && (board[i, 1] != 0))
                {
                    board[i, 1] = board[i, 0] + board[i, 1];
                    board[i, 0] = 0;
                }
            }
        }

        static public int move(ConsoleKeyInfo input)
        {
            copyState();
            if (input.Key == ConsoleKey.DownArrow)
            {
                //CheckCollapseDown();
                moveDown();
                return 1;
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                //CheckCollapseUp();
                moveUp();
                return 1;
            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                //CheckCollapseLeft();
                moveLeft();
                return 1;
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                //CheckCollapseRight();
                moveRight();
                return 1;
            }
            else
                return 0;

        }
        static void start_program()
        {
            initBoard();
            Console.WriteLine("Hello World");
            Console.Clear();
            displayBoard();
            int gameNotOver = 1;
            while (gameNotOver == 1)
            {

                //Console.WriteLine(key);
                do
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    gameNotOver = move(input);
                } while (changeInState() == 0);

                genereateNewItem();

                //gameNotOver = checkGameOver();
                //if(gameNotOver == 0)
                //	break;

                //Console.WriteLine("-----------------");
                Console.Clear();
                displayBoard();

            }
        }*/
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //start_program();
        }
    }
}
