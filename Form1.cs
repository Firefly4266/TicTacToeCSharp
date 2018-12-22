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
            PictureBox[] squares = 
            { pictureBox0,
                pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                pictureBox5, pictureBox6, pictureBox7, pictureBox8
            };

            foreach (var square in squares)
            {
                square.Image = null;
                square.BackColor = Color.White;
            }
        turn = PlayerTurn.Player1;
            ShowStatus();
        }
        // This is a refactor introducing a local variable  

        void ShowStatus()
        {
            string status = "";

            if(turn == PlayerTurn.Player1)
            {
                status = "Turn: Player 1";
            }
            else
            {
                status = "Turn: Player 2";
            }
            lbl1Status.Text = status;
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

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to start a new game?",
                "New Game",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                OnNewGame();
            }
        }
    }
}
