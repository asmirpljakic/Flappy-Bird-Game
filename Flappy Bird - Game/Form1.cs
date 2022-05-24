using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird___Game
{
    public partial class Flappy : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        public Flappy()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeButtom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeButtom.Left < -150)
            {
                pipeButtom.Left = 800;
                score++;

            }
            if (pipeTop.Left < -180)
            {

                pipeTop.Left = 950;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeButtom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -1)
            {
                endGame();

            }
            if (score > 3)
            {
                pipeSpeed = 11;
            }
            if (score > 10)

            {
                pipeSpeed = 15;
            }
            if (score > 14)

            {
                pipeSpeed = 19;
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.ForeColor = Color.Red;
            scoreText.BackColor = Color.Yellow;
            scoreText.Text = "GAME OVER! \n" + scoreText.Text;

        }
    }
}
