using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Space_Race
{
    public partial class Form1 : Form
    {

        //Make players
        new Rectangle p1 = new Rectangle(200, 325, 20, 30);
        new Rectangle p1Bubble = new Rectangle(205, 335, 10, 10);
        new Rectangle p1Booster1 = new Rectangle(200, 355, 5, 5);
        new Rectangle p1Booster2 = new Rectangle(215, 355, 5, 5);
        new Rectangle p2 = new Rectangle(380, 325, 20, 30);
        new Rectangle p2Bubble = new Rectangle(385, 335, 10, 10);
        new Rectangle p2Booster1 = new Rectangle(380, 355, 5, 5);
        new Rectangle p2Booster2 = new Rectangle(395, 355, 5, 5);
        new Rectangle divider = new Rectangle(295, 0, 10, 300);
        //Make rocket boosters, decorate ship
        int p1Line = 0;
        int p2Line = 0;
        //Lists

        List<Rectangle> leftAsteroids = new List<Rectangle>();
        List<Rectangle> rightAsteroids = new List<Rectangle>();

        int astSpeed = 4;
        int astSizeX = 8;
        int astSizeY = 2;

        int playerSpeed = 4;
        int playerSizeY = 30;
        int playerSizeX = 20;

        int p1Score = 0;
        int p2Score = 0;

        bool upPressed = false;
        bool downPressed = false;
        bool wPressed = false;
        bool sPressed = false;

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        Pen whitePen = new Pen(Color.White);

        Random randGen = new Random();

        SoundPlayer point = new SoundPlayer(Properties.Resources.point);
        SoundPlayer hit = new SoundPlayer(Properties.Resources.hit);
        SoundPlayer win = new SoundPlayer(Properties.Resources.win);
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (upPressed && p2.Y > 0)
            {
                p2.Y -= playerSpeed;
                p2Bubble.Y -= playerSpeed;
                p2Booster1.Y -= playerSpeed;
                p2Booster2.Y -= playerSpeed;
                p2Line -= playerSpeed;
            }

            if (downPressed && p2.Y < this.Height - p2.Height - p2.Height)
            {
                p2.Y += playerSpeed;
                p2Bubble.Y += playerSpeed;
                p2Booster1.Y += playerSpeed;
                p2Booster2.Y += playerSpeed;
                p2Line += playerSpeed;
            }

            if (wPressed && p1.Y > 0)
            {
                p1.Y -= playerSpeed;
                p1Bubble.Y -= playerSpeed;
                p1Booster1.Y -= playerSpeed;
                p1Booster2.Y -= playerSpeed;
                p1Line -= playerSpeed;
            }

            if (sPressed && p1.Y < this.Height - p1.Height - p1.Height)
            {
                p1.Y += playerSpeed;
                p1Bubble.Y += playerSpeed;
                p1Booster1.Y += playerSpeed;
                p1Booster2.Y += playerSpeed;
                p1Line += playerSpeed;
            }

            int y = randGen.Next(0, 101);

            if (y < 10)
            {
                Rectangle asteroid = new Rectangle(0, randGen.Next(0, this.Height - 100), astSizeX, astSizeY);
                leftAsteroids.Add(asteroid);
            }
            else if (y < 20)
            {
                Rectangle asteroid = new Rectangle(this.Width, randGen.Next(0, this.Height - 100), astSizeX, astSizeY);
                rightAsteroids.Add(asteroid);
            }

            for (int i = 0; i < leftAsteroids.Count; i++)
            {
                int x = leftAsteroids[i].X + astSpeed;
                leftAsteroids[i] = new Rectangle (x, leftAsteroids[i].Y, astSizeX, astSizeY);
            }

            for (int i = 0; i < rightAsteroids.Count; i++)
            {
                int x = rightAsteroids[i].X - astSpeed;
                rightAsteroids[i] = new Rectangle(x, rightAsteroids[i].Y, astSizeX, astSizeY);
            }

            for (int i = 0; i < rightAsteroids.Count; i++)
            {
                if (p1.IntersectsWith(rightAsteroids[i]))
                {
                    p1.Y = 325;
                    p1Bubble.Y = 335;
                    p1Booster1.Y = 355;
                    p1Booster2.Y = 355;
                    p1Line = 0;
                    hit.Play();
                }

                if (p2.IntersectsWith(rightAsteroids[i]))
                {
                    p2.Y = 325;
                    p2Bubble.Y = 335;
                    p2Booster1.Y = 355;
                    p2Booster2.Y = 355;
                    p2Line = 0;
                    hit.Play();
                }
            }



            for (int i = 0; i < leftAsteroids.Count; i++)
            {
                if (p1.IntersectsWith(leftAsteroids[i]))
                {
                    p1.Y = 325;
                    p1Bubble.Y = 335;
                    p1Booster1.Y = 355;
                    p1Booster2.Y = 355;
                    p1Line = 0;
                    hit.Play();
                }

                if (p2.IntersectsWith(leftAsteroids[i]))
                {
                    p2.Y = 325;
                    p2Bubble.Y = 335;
                    p2Booster1.Y = 355;
                    p2Booster2.Y = 355;
                    p2Line = 0;
                    hit.Play();
                }
            }

            if (p1.Y == 1)
            {
                p1Score++;
                p1ScoreOutput.Text = $"{p1Score}";
                p1.Y = 325;
                p1Bubble.Y = 335;
                p1Booster1.Y = 355;
                p1Booster2.Y = 355;
                p1Line = 0;
                point.Play();
            }

            if (p2.Y == 1)
            {
                p2Score++;
                p2ScoreOutput.Text = $"{p2Score}";
                p2.Y = 325;
                p2Bubble.Y = 335;
                p2Booster1.Y = 355;
                p2Booster2.Y = 355;
                p2Line = 0;
                point.Play();
            }

            if (p1Score == 3)
            {
                gameWatchOutput.Text = "The winner is Player 1!";
                gameTimer.Stop();
                win.Play();
            }

            if (p2Score == 3)
            {
                gameWatchOutput.Text = "The winner is Player 2!";
                gameTimer.Stop();
                win.Play();
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, p1);
            e.Graphics.DrawLine(whitePen, 200, 325 + p1Line, 210, 315 + p1Line);
            e.Graphics.DrawLine(whitePen, 210, 315 + p1Line, 220, 325 + p1Line);
            e.Graphics.FillEllipse(blackBrush, p1Bubble);
            e.Graphics.FillRectangle(whiteBrush, p1Booster1);
            e.Graphics.FillRectangle(whiteBrush, p1Booster2);
            e.Graphics.FillRectangle(whiteBrush, p1Booster2);
            e.Graphics.FillRectangle(whiteBrush, p2);
            e.Graphics.DrawLine(whitePen, 380, 325 + p2Line, 390, 315 + p2Line);
            e.Graphics.DrawLine(whitePen, 390, 315 + p2Line, 400, 325 + p2Line);
            e.Graphics.FillEllipse(blackBrush, p2Bubble);
            e.Graphics.FillRectangle(whiteBrush, p2Booster1);
            e.Graphics.FillRectangle(whiteBrush, p2Booster2);
            e.Graphics.FillRectangle(whiteBrush, divider);

            if (wPressed && sPressed == false)
            {
                e.Graphics.FillPie(orangeBrush, 192, 359 + p1Line, 20, 20, 250, 40);
                e.Graphics.FillPie(orangeBrush, 207, 359 + p1Line, 20, 20, 250, 40);
            }

            if (upPressed && downPressed == false)
            {
                e.Graphics.FillPie(orangeBrush, 372, 359 + p2Line, 20, 20, 250, 40);
                e.Graphics.FillPie(orangeBrush, 387, 359 + p2Line, 20, 20, 250, 40);
            }

            for (int i = 0; i < leftAsteroids.Count; i++)
            {
                e.Graphics.FillRectangle(whiteBrush, leftAsteroids[i]);
            }

            for (int i = 0; i < rightAsteroids.Count; i++)
            {
                e.Graphics.FillRectangle(whiteBrush, rightAsteroids[i]);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
