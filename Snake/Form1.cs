using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //TODO: add new boxes everytime snake intersects with apple

        Graphics graphics;
        Bitmap canvas;
        Apple apple;
        Snake snake;
        Direction nextDirection = Direction.East;
        int appleX;
        int appleY;
        int appleSize = 20;
        Random num;
        int points = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(800, 450);
            graphics = Graphics.FromImage(canvas);

            pictureBox1.Image = canvas;
            
            num = new Random();
            do
            {
                appleX = num.Next(1, 780);
            } while (appleX % 20 != 0);

            do
            {
                appleY = num.Next(1, 430);
            } while (appleY % 20 != 0);
            
            apple = new Apple(appleX, appleY, appleSize, Brushes.Red);
            snake = new Snake(1);
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);
            UpdateGame();

            apple.DrawApple(graphics);
            snake.DrawSnake(graphics);

            pictureBox1.Image = canvas;

        }

        private void UpdateGame()
        {
            snake.DirectSnake(nextDirection);
            snake.MoveSnake(ClientSize.Width, ClientSize.Height);
            if (apple.Intersects(snake))
            {
                do
                {
                    appleX = num.Next(1, 780);
                } while (appleX % 20 != 0);

                do
                {
                    appleY = num.Next(1, 430);
                } while (appleY % 20 != 0);
                apple = new Apple(appleX, appleY, appleSize, Brushes.Red);
                snake.addToSnake();
                snake.DrawSnake(graphics);
                points++;
                AppleLabel.Text = $"Apples: {points}";
            }
            if (snake.SnakeIntersectsSelf())
            {
                timer1.Enabled = false;
                var result = MessageBox.Show($"You ate {points} apples! Replay?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    snake.removeFromSnake();
                    snake = new Snake(1);
                    do
                    {
                        appleX = num.Next(1, 780);
                    } while (appleX % 20 != 0);

                    do
                    {
                        appleY = num.Next(1, 430);
                    } while (appleY % 20 != 0);
                    apple = new Apple(appleX, appleY, appleSize, Brushes.Red);
                    points = 0;
                    AppleLabel.Text = $"Apples: {points}";
                    timer1.Enabled = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                nextDirection = Direction.North;
            }
            else if (e.KeyCode == Keys.Down)
            {
                nextDirection = Direction.South;

            }
            if (e.KeyCode == Keys.Right)
            {
                nextDirection = Direction.East;
            }
            else if (e.KeyCode == Keys.Left)
            {
                nextDirection = Direction.West; 
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AppleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
