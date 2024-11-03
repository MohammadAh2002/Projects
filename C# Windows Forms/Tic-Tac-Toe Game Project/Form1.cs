using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game_Project.Properties;

namespace Tic_Tac_Toe_Game_Project
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        stGameStatus GameStatus;

        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2
        }
        
        enum enWinner
        {
            GameInProgress,
            Player1,
            Player2,
            Draw,
            
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }

        // Data.
        void CheckGame(Button bt)
        {

            if (bt.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {

                    case enPlayer.Player1:

                        bt.Image = Resources.x;
                        PlayerTurn = enPlayer.Player2;
                        GameStatus.PlayCount++;
                        bt.Tag = "X";
                        lbTurn.Text = "Player2";
                        CheckWinner();
                        break;

                    case enPlayer.Player2:

                        bt.Image = Resources.o;
                        PlayerTurn = enPlayer.Player1;
                        GameStatus.PlayCount++;
                        bt.Tag = "O";
                        lbTurn.Text = "Player1";
                        CheckWinner();
                        break;


                }
            }
            else
            {

                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

           

            if (GameStatus.PlayCount == 9 && GameStatus.Winner == enWinner.GameInProgress)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();


            }





        }
        void EndGame()
        {

            DisableTheGame();

            lbTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {

                case enWinner.Player1:

                    lbWinner.Text = "Player1";
                    MessageBox.Show("Player 1 Won Congrats", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case enWinner.Player2:

                    lbWinner.Text = "Player2";
                    MessageBox.Show("Player 2 Won Congrats", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                default:

                    lbWinner.Text = "Draw";
                    MessageBox.Show("it's a Draw", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

            }

        }
        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {


            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {

                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

            }

            //GameStatus.GameOver = false;
            return false;


        }
        public void CheckWinner()
        {


            //checked rows
            //check Row1
            if (CheckValues(bt00, bt01, bt02))
                return;

            //check Row2
            if (CheckValues(bt10, bt11, bt12))
                return;

            //check Row3
            if (CheckValues(bt20, bt21, bt22))
                return;

            //checked cols
            //check col1
            if (CheckValues(bt00, bt10, bt20))
                return;

            //check col2
            if (CheckValues(bt01, bt11, bt21))
                return;

            //check col3
            if (CheckValues(bt02, bt12, bt22))
                return;

            //check Diagonal

            //check Diagonal1
            if (CheckValues(bt00, bt11, bt22))
                return;

            //check Diagonal2
            if (CheckValues(bt02, bt11, bt20))
                return;
        }

        void DisableTheGame()
        {

            bt00.Enabled = false;
            bt01.Enabled = false;
            bt02.Enabled = false;
            bt10.Enabled = false;
            bt20.Enabled = false;
            bt21.Enabled = false;
            bt22.Enabled = false;
            bt11.Enabled = false;
            bt12.Enabled = false;

        }

        // Lines Draw.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color LinesColor = Color.FromArgb(255, 255, 255, 255);

            Pen pen = new Pen(LinesColor);

            pen.Width = 10;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //draw Horizental lines
            e.Graphics.DrawLine(pen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(pen, 400, 460, 1050, 460);

            //draw Vertical lines
            e.Graphics.DrawLine(pen, 610, 140, 610, 620);
            e.Graphics.DrawLine(pen, 840, 140, 840, 620);

        }

        // Game Reset.
        private void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
            btn.Enabled = true;

        }
        private void RestartGame()
        {

            RestButton(bt00);
            RestButton(bt01);
            RestButton(bt02);
            RestButton(bt10);
            RestButton(bt11);
            RestButton(bt12);
            RestButton(bt20);
            RestButton(bt21);
            RestButton(bt22);

            PlayerTurn = enPlayer.Player1;
            lbTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lbWinner.Text = "In Progress";



        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();

        }
        
        // Buttons.
        void ButtonClick(object sender, EventArgs e)
        {

            CheckGame((Button) sender);

        }
     
        
    }
}
