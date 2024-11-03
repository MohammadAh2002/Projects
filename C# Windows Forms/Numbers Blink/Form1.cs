using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Numbers_Blink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum enLevel {enThree = 3, enFour = 4, enFive = 5, enSix = 6,
                      enSeven = 7, enEight = 8, enNine = 9, enTen = 10};

        struct stGameInfo {

            public enLevel Level;
            public byte QustionsNumber, HideTime, TimeLeftToHide;

            public string stQustion;

        }
        stGameInfo GameInfo;

        private Random RandChar = new Random();

        // Buttons
        private void btStart_Click(object sender, EventArgs e)
        {

            MakeQustion();

        }
        private void btDone_Click(object sender, EventArgs e)
        {

            CheckAnswer();

        }
        private void BtHide_Click(object sender, EventArgs e)
        {

            lbQustion.Text = "What is Your\nAnswer";

            Timer.Enabled = false;

            lbTimer.Text = "Time Out";
         
        }

        // Change Game Info
        private void nudQustionsNumber_ValueChanged(object sender, EventArgs e)
        {

            GameInfo.QustionsNumber = (byte) nudQustionsNumber.Value;

        }
        private void cbNumberDigits_SelectedIndexChanged(object sender, EventArgs e)
        {

            GameInfo.Level = (enLevel) cbNumberDigits.SelectedIndex + 3;

            SetHideTime(GameInfo.Level);
            
        }
        private void SetHideTime(enLevel Level)
        {

            switch (Level)
            {

                case enLevel.enThree:
                case enLevel.enFour:
                case enLevel.enFive:
                case enLevel.enSix:

                    GameInfo.HideTime = 3;
                    break;

                case enLevel.enSeven:
                case enLevel.enNine:
                case enLevel.enEight:
                case enLevel.enTen:

                    GameInfo.HideTime = 5;
                    break;
            }

        }
        
        private void MakeQustion()
        {

            AnswerPanel.BackColor = Color.Transparent;
            lbAnswer.BackColor = Color.Transparent;
            lbAnswer.Text = string.Empty;

            GameInfo.stQustion = string.Empty;

            do {

               GameInfo.stQustion += GetRandomCherNumber();

            }while (GameInfo.stQustion.Length < (byte) GameInfo.Level);

            lbQustion.Text = GameInfo.stQustion;

            GameInfo.TimeLeftToHide = GameInfo.HideTime;

            Timer.Enabled = true;

        }
        private char GetRandomCherNumber()
        {

            return (char) RandChar.Next(48,58);

        }

        // Timer
        private void Timer_Tick(object sender, EventArgs e)
        {        

            lbTimer.Text = GameInfo.TimeLeftToHide.ToString() + 's';

            GameInfo.TimeLeftToHide--;

            if (GameInfo.TimeLeftToHide == 0)
            {

                lbQustion.Text = "What is Your\nAnswer";

                lbTimer.Text = "Time Out";

                Timer.Enabled = false;

            }

        }

        // Answer
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            UpdateAnswer(e);

            if (lbAnswer.Text.Length == GameInfo.stQustion.Length)
            {

                CheckAnswer();

            }


        }

        private void UpdateAnswer(KeyEventArgs e)
        {

           switch (e.KeyCode)
           {
                case Keys.D0:
                case Keys.NumPad0:
                    lbAnswer.Text += '0';
                    break;

                case Keys.D1:
                case Keys.NumPad1:
                    lbAnswer.Text += '1';
                    break;

                case Keys.D2:
                case Keys.NumPad2:
                    lbAnswer.Text += '2';
                    break;

                case Keys.D3:
                case Keys.NumPad3:
                    lbAnswer.Text += '3';
                    break;

                case Keys.D4:
                case Keys.NumPad4:
                    lbAnswer.Text += '4';
                    break;

                case Keys.D5:
                case Keys.NumPad5:
                    lbAnswer.Text += '5';
                    break;

                case Keys.D6:
                case Keys.NumPad6:
                    lbAnswer.Text += '6';
                    break;

                case Keys.D7:
                case Keys.NumPad7:
                    lbAnswer.Text += '7';
                    break;

                case Keys.D8:
                case Keys.NumPad8:
                    lbAnswer.Text += '8';
                    break;

                case Keys.D9:
                case Keys.NumPad9:
                    lbAnswer.Text += '9';
                    break;
           }

        }
        private void CheckAnswer()
        {

            if (lbAnswer.Text == GameInfo.stQustion)
            {

                AnswerPanel.BackColor = Color.Green;
                lbAnswer.BackColor = Color.Green;
                MessageBox.Show("Right Answer");
            
            }
            else
            {

                AnswerPanel.BackColor = Color.Red;
                lbAnswer.BackColor = Color.Red;
                MessageBox.Show("Wrong Answer");
            
            }

            MakeQustion();

        }

    }
}
