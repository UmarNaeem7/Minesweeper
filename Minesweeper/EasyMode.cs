using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class EasyMode : Form
    {
        private bool start = false;
        private int[] mines;
        private System.Windows.Forms.Button[] btnArray;
        private int numOfMines = 10;
        private List<int> revealedCells = new List<int>();

        public EasyMode()
        {
            InitializeComponent();
            AddButtons();
            this.scoreCount.Text = revealedCells.Count().ToString();
            Image image = Minesweeper.Properties.Resources.happy;
            this.resetButton.Image = image;
        }

        private void AddButtons()
        {
            int xPos = this.buttonsPanel.Location.X;
            int yPos = this.buttonsPanel.Location.Y;
            int xTemp = xPos;
            int yTemp = yPos;
            // Declare and assign number of buttons = 81
            btnArray = new System.Windows.Forms.Button[81];
            // Create (26) Buttons:
            for (int i = 0; i < 81; i++)
            {
                // Initialize one variable
                btnArray[i] = new System.Windows.Forms.Button();
            }
            int n = 0;

            while (n <= 80)
            {
                btnArray[n].Tag = n + 1; // Tag of button
                btnArray[n].Width = 30; // Width of button
                btnArray[n].Height = 30; // Height of button
                if (n % 9 == 0) // Location of second line of buttons:
                {
                    xPos = xTemp;
                    yPos = yTemp + 30;
                    yTemp = yPos;
                }
                // Location of button:
                btnArray[n].Left = xPos;
                btnArray[n].Top = yPos;
                // Add buttons to a Panel:
                this.buttonsPanel.Controls.Add(btnArray[n]); // Let panel hold the Buttons
                xPos = xPos + btnArray[n].Width; // Left of next button
                                                 // Write English Character:
                btnArray[n].BackColor = Color.FloralWhite;

                // the Event of click Button
                int c = n;
                btnArray[n].MouseUp += new MouseEventHandler((s, e) => ClickButton(s, e, c));
                n++;
            }

        }

        private void placeMines(int n)
        {
            mines = new int[numOfMines];
            for (int i = 0; i < numOfMines; i++)
            {
                Random r = new Random();
                int index = r.Next(0, 80);
                if (index == n)
                    i--;
                else
                {
                    bool flag = true;
                    for (int j = 0; j < i; j++)
                    {
                        if (index == mines[j])
                        {
                            flag = false;
                            i--;
                            break;
                        }
                    }
                    if (flag)
                        mines[i] = index;
                }
            }

        }

        private void displayAllMines()
        {
            Image image = Minesweeper.Properties.Resources.mine;
            for (int i = 0; i < numOfMines; i++)
            {
                btnArray[mines[i]].Image = image;
            }
        }

        private bool isMine(int n)
        {
            for (int i = 0; i < numOfMines; i++)
                if (mines[i] == n)
                    return true;
            return false;
        }

        private bool isFlag(int n)
        {
            if (btnArray[n].Image == null)
                return false;
            return true;
        }

        private int countMines(int n)
        {
            int count = 0;
            //check left cell
            if (n % 9 != 0)
            {
                if (isMine(n - 1))
                    count++;
            }
            //check right cell
            if (n % 9 != 8)
            {
                if (isMine(n + 1))
                    count++;
            }
            //check up cell
            if ((n - 9) >= 0)
            {
                if (isMine(n - 9))
                    count++;
            }
            //check down cell
            if ((n + 9) <= 80)
            {
                if (isMine(n + 9))
                    count++;
            }
            //check left upper cell
            if ((n - 10) >= 0 && n % 9 != 0)
            {
                if (isMine(n - 10))
                    count++;
            }
            //check right upper cell
            if ((n - 8) >= 0 && n % 9 != 8)
            {
                if (isMine(n - 8))
                    count++;
            }
            //check left lower cell
            if ((n + 8) <= 80 && n % 9 != 0)
            {
                if (isMine(n + 8))
                    count++;
            }
            //check right lower cell
            if ((n + 10) <= 80 && n % 9 != 8)
            {
                if (isMine(n + 10))
                    count++;
            }
            return count;
        }

        private void placeFlag(int n)
        {
            Image image = Minesweeper.Properties.Resources.flag;
            btnArray[n].Image = image;
        }

        private bool isGameComplete()
        {
            if (revealedCells.Count == 81 - numOfMines)
                return true;
            return false;
        }

        // Result of (Click Button) event, get the text of button
        public void ClickButton(Object sender, MouseEventArgs e, int n)
        {
            if (!start)
            {
                placeMines(n);
                start = true;
                return;
            }



            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                    if (isFlag(n))
                    {
                        btnArray[n].Image = null;
                        revealedCells.Remove(n);
                        return;
                    }

                    if (!revealedCells.Contains(n))
                    {
                        placeFlag(n);
                        if (!isMine(n))
                            revealedCells.Add(n);
                    }



            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //MessageBox.Show("Left click");

                //game over
                if (isMine(n))
                {
                    displayAllMines();
                    MessageBox.Show("Game Over, your score = " + revealedCells.Count().ToString(),"GAME OVER");

                    Image image = Minesweeper.Properties.Resources.sad;
                    this.resetButton.Image = image;
                }
                else
                {
                    if (countMines(n) == 0)
                    {
                        if (!revealedCells.Contains(n))
                        {
                            //expand recursively
                            Queue<int> q = new Queue<int>();
                            //reveal clicked cell
                            btnArray[n].BackColor = Color.ForestGreen;
                            revealedCells.Add(n);

                            q.Enqueue(n);
                            while (q.Count != 0)
                            {
                                int cell = q.Dequeue();
                                //check left cell
                                if (cell % 9 != 0)
                                {
                                    int x = cell - 1;
                                    if (!revealedCells.Contains(x))
                                    {                                       
                                        revealedCells.Add(x);
                                        if (countMines(x) == 0)
                                        {
                                            q.Enqueue(x);
                                            btnArray[x].BackColor = Color.ForestGreen;
                                        }
                                        else
                                        {
                                            btnArray[x].Text = countMines(x).ToString();
                                        }
                                    }
                                }
                                //check right cell
                                if (cell % 9 != 8)
                                {
                                    int x = cell + 1;
                                    if (!revealedCells.Contains(x))
                                    {
                                        revealedCells.Add(x);
                                        if (countMines(x) == 0)
                                        {
                                            q.Enqueue(x);
                                            btnArray[x].BackColor = Color.ForestGreen;
                                        }
                                        else
                                        {
                                            btnArray[x].Text = countMines(x).ToString();
                                        }
                                    }
                                }
                                //check up cell
                                if ((cell - 9) >= 0)
                                {
                                    int x = cell - 9;
                                    if (!revealedCells.Contains(x))
                                    {
                                        revealedCells.Add(x);
                                        if (countMines(x) == 0)
                                        {
                                            q.Enqueue(x);
                                            btnArray[x].BackColor = Color.ForestGreen;
                                        }
                                        else
                                        {
                                            btnArray[x].Text = countMines(x).ToString();
                                        }
                                    }
                                }
                                //check down cell
                                if ((cell + 9) <= 80)
                                {
                                    int x = cell + 9;
                                    if (!revealedCells.Contains(x))
                                    {
                                        revealedCells.Add(x);
                                        if (countMines(x) == 0)
                                        {
                                            q.Enqueue(x);
                                            btnArray[x].BackColor = Color.ForestGreen;
                                        }
                                        else
                                        {
                                            btnArray[x].Text = countMines(x).ToString();
                                        }
                                    }
                                }
                                //check left upper cell
                                if ((cell - 10) >= 0 && cell % 9 != 0)
                                {
                                    int x = cell - 10;
                                    if (!revealedCells.Contains(x))
                                    {
                                        revealedCells.Add(x);
                                        if (countMines(x) == 0)
                                        {
                                            q.Enqueue(x);
                                            btnArray[x].BackColor = Color.ForestGreen;
                                        }
                                        else
                                        {
                                            btnArray[x].Text = countMines(x).ToString();
                                        }
                                    }
                                }
                                //check right upper cell
                                if ((cell - 8) >= 0 && cell % 9 != 8)
                                {
                                    int x = cell - 8;
                                    if (!revealedCells.Contains(x))
                                    {
                                        revealedCells.Add(x);
                                        if (countMines(x) == 0)
                                        {
                                            q.Enqueue(x);
                                            btnArray[x].BackColor = Color.ForestGreen;
                                        }
                                        else
                                        {
                                            btnArray[x].Text = countMines(x).ToString();
                                        }
                                    }
                                }
                                //check left lower cell
                                if ((cell + 8) <= 80 && cell % 9 != 0)
                                {
                                    int x = cell + 8;
                                    if (!revealedCells.Contains(x))
                                    {
                                        revealedCells.Add(x);
                                        if (countMines(x) == 0)
                                        {
                                            q.Enqueue(x);
                                            btnArray[x].BackColor = Color.ForestGreen;
                                        }
                                        else
                                        {
                                            btnArray[x].Text = countMines(x).ToString();
                                        }
                                    }
                                }
                                //check right lower cell
                                if ((cell + 10) <= 80 && cell % 9 != 8)
                                {
                                    int x = cell + 10;
                                    if (!revealedCells.Contains(x))
                                    {
                                        revealedCells.Add(x);
                                        if (countMines(x) == 0)
                                        {
                                            q.Enqueue(x);
                                            btnArray[x].BackColor = Color.ForestGreen;
                                        }
                                        else
                                        {
                                            btnArray[x].Text = countMines(x).ToString();
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        if (!revealedCells.Contains(n))
                        {
                            btnArray[n].Text = countMines(n).ToString();
                            revealedCells.Add(n);
                        }
                    }
                }

                if (isGameComplete())
                {
                    this.resetButton.Image = Minesweeper.Properties.Resources.cool;
                    MessageBox.Show("Game Won", "Nice work");
                }

            }
            scoreCount.Text = revealedCells.Count().ToString();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var easyForm = new EasyMode();
            easyForm.Closed += (s, args) => this.Close();
            easyForm.Show();
        }
    }
}
