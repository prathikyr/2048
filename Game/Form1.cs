using System;
using System.Windows.Forms;
using System.Drawing;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += new KeyEventHandler(move);
            start_program();
        }
        int gameNotOver = 1;

         int[,] board = new int[,]
          {
               {0, 0, 0, 0},
               {0, 0, 0, 0},
               {0, 0, 0, 0},
               {0, 0, 0, 0}
          };

         int[,] prevState = new int[,]
        {
               {0, 0, 0, 0},
               {0, 0, 0, 0},
               {0, 0, 0, 0},
               {0, 0, 0, 0}
        };

         public void initBoard()
        {

            int pick1, pick2;
            Random rnd = new Random();
            do
            {
                pick1 = rnd.Next(1, 17) - 1;
                pick2 = rnd.Next(1, 17) - 1;
            } while (pick1 == pick2);
            //Console.WriteLine(pick1);
            //Console.WriteLine(pick2);
            board[pick1 / 4, (pick1) % 4] = 2;
            board[pick2 / 4, (pick2) % 4] = 2;

        }


         public void displayBoard()
        {
            //for (int i = 0; i < 4; i++)
            //{
              //  for (int j = 0; j < 4; j++)
                //{
                    //Console.Write(board[i, j] + "\t");
            pictureBox1.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[0,0].ToString() + ".jpg";
            pictureBox2.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[0,1].ToString() + ".jpg";
            pictureBox3.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[0,2].ToString() + ".jpg";
            pictureBox4.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[0,3].ToString() + ".jpg";
            pictureBox5.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[1,0].ToString() + ".jpg";
            pictureBox6.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[1,1].ToString() + ".jpg";
            pictureBox7.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[1,2].ToString() + ".jpg";
            pictureBox8.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[1,3].ToString() + ".jpg";
            pictureBox9.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[2,0].ToString() + ".jpg";
            pictureBox10.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[2,1].ToString() + ".jpg";
            pictureBox11.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[2,2].ToString() + ".jpg";
            pictureBox12.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[2,3].ToString() + ".jpg";
            pictureBox13.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[3,0].ToString() + ".jpg";
            pictureBox14.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[3,1].ToString() + ".jpg";
            pictureBox15.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[3,2].ToString() + ".jpg";
            pictureBox16.ImageLocation = @"C:\Users\ANEESH\Desktop\image" + board[3,3].ToString() + ".jpg";

           

            //}
            //Console.WriteLine();
            //}

            //Image image = Image.FromFile(@"C:\Users\ANEESH\Desktop\image2.jpg");
            //pictureBox1.Image = image;

        }

         void genereateNewItem()
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

         int changeInState()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (board[i, j] != prevState[i, j])
                        return 1;
            return 0;
        }

         void copyState()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    prevState[i, j] = board[i, j];
        }


         int filledAll()
        {
            int filled = 1;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (board[i, j] == 0)
                        filled = 0;
            return filled;
        }

         int checkGameOver()
        {
            return filledAll();// && CheckCollapseDown() && CheckCollapseUp() && CheckCollapseLeft() && CheckCollapseRight();
        }

         public void moveDown()
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


         public void moveUp()
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

        public void moveLeft()
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

        public void moveRight()
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

        public void move(object sender, KeyEventArgs input)
        {
            //Console.WriteLine("key was pressed");
            copyState();
            if (input.KeyCode == Keys.Down)
            {
                //CheckCollapseDown();
                moveDown();
                //return 1;
            }
            else if (input.KeyCode == Keys.Up)
            {
                //CheckCollapseUp();
                moveUp();
                //return 1;
            }
            else if (input.KeyCode == Keys.Left)
            {
                //CheckCollapseLeft();
                moveLeft();
                //return 1;
            }
            else if (input.KeyCode == Keys.Right)
            {
                //CheckCollapseRight();
                moveRight();
                //return 1;
            }
            //else
            //  ;// return 0;
            genereateNewItem();
            displayBoard();

            gameNotOver = checkGameOver();

        }
        void start_program()
        {
            initBoard();
            //Console.WriteLine("Hello World");
            //Console.Clear();
            displayBoard();
            /*int gameNotOver = 1;
            while (gameNotOver == 1)
            {

                //Console.WriteLine(key);
                do
                {
                    //ConsoleKeyInfo input = Console.ReadKey(true);
                    //gameNotOver = move(input);
                } while (changeInState() == 0);

                genereateNewItem();

                gameNotOver = checkGameOver();
                if(gameNotOver == 0)
                	break;

                //Console.WriteLine("-----------------");
                //Console.Clear();*/
                //displayBoard();

           // }
            
        }
        
    }
}
