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

        enum Winner { None, Tie, Player1, Player2};

        Winner winner;
        PlayerTurn turn;
        
        void OnNewGame()
        {
            PictureBox[] squares = 
            { pictureBox0,
                pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                pictureBox5, pictureBox6, pictureBox7, pictureBox8
            };

        // clears board for new game
            foreach (var square in squares)
            {
                square.Image = null;
                square.BackColor = Color.White;
            }
            turn = PlayerTurn.Player1;
            winner = Winner.None;
            ShowStatus();
        }

        Winner ShowWinner()
        {
            // create an array containing all winning moves
            PictureBox[] AllMoves =
            {
                pictureBox0, pictureBox1, pictureBox2,
                pictureBox3, pictureBox4, pictureBox5,
                pictureBox6, pictureBox7, pictureBox8,

                pictureBox0, pictureBox3, pictureBox6,
                pictureBox1, pictureBox4, pictureBox7,
                pictureBox2, pictureBox5, pictureBox8,

                pictureBox0, pictureBox4, pictureBox8,
                pictureBox2, pictureBox4, pictureBox6
                };

            // check for a winner
            for (int i = 0; i < AllMoves.Length; i += 3)
            {
                if (AllMoves[i].Image != null)
                {
                    if (AllMoves[i].Image == AllMoves[i + 1].Image && AllMoves[i].Image == AllMoves[i + 2].Image)
                    {
                        // check winner against player
                        if (AllMoves[i].Image == Player1.Image)
                        {
                            return Winner.Player1;
                        }
                        else
                        {
                            return Winner.Player2;
                        }
                    }
                }
            }
            return Winner.None;
        }

        void ShowStatus()
        {
            string status = "";

            switch (winner)
            {
                case Winner.None:
                    if(turn == PlayerTurn.Player1)
                    {
                        status = "Turn: Player 1";
                    }
                    else
                    {
                        status = "Turn: Player 2";
                    }
                    break;
                case Winner.Player1:
                    status = "Player 1 Wins!!!";
                    break;
                case Winner.Player2:
                    status = "Player 2 Wins!!!";
                    break;
                case Winner.Tie:
                    status = "It's a Tie, try again.";
                    break;
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
            if(winner != Winner.None)
            {
                return;
            }

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

            winner = ShowWinner();
            if(winner == Winner.None)
            {
                turn = (PlayerTurn.Player1 == turn)? PlayerTurn.Player2 : PlayerTurn.Player1;
            }
            else
            {
                turn = PlayerTurn.None;
            }

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
