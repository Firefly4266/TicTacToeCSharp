using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeCSharp
{
    public partial class Form1 : Form
    {

        enum PlayerTurn { None, Player1, Player2 };

        PlayerTurn turn;

        void OnNewGame()
        {
            turn = PlayerTurn.Player1;
            ShowStatus();
        }

        void ShowStatus()
        {
            if(turn == PlayerTurn.Player1)
            {
                lbl1Status.Text = "Turn: Player 1";
            }
            else
            {
                lbl1Status.Text = "Turn: Player 2";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnNewGame();
        }

        private void OnClick(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if(p.Image != null)
            {
                return;
            }

            if(turn == PlayerTurn.Player1)
            {
                p.Image = Player1.Image;
                p.BackColor = Color.Black;
            }
            else
            {
                p.Image = Player2.Image;
                p.BackColor = Color.Black;
            }
            turn = (PlayerTurn.Player1 == turn)? PlayerTurn.Player2 : PlayerTurn.Player1;

            ShowStatus();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Player2_Click(object sender, EventArgs e)
        {
            turn = PlayerTurn.Player1;
        }
    }
}
