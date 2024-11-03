using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace My_Math_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            SetAnswerTextBox();
            SetAnswerOptions();

        }

        enum enLevel { Hard = 1, Medium = 2, Easy = 3, Custom = 4 };
        enum enOpration
        {
            Addition = 1, Subtraction = 2, Multiplication = 3,
            Division = 4, Mixed = 5
        };
        enum enQuestionStyle { WriteAnswer = 1, Options = 2 };

        struct stGameInfo
        {

            public enLevel enGameLevel;
            public enOpration enGameOpration;
            public enQuestionStyle enGameQuestionStyle;
            public short GameQuestionsNumber, RightAnswer, WrongAnswers;
            
        }
        stGameInfo GameInfo;

        struct stQuestionInfo
        {

            public int Number1, Number2, Result, QuestionNumber;
            public char Opration;

        }
        stQuestionInfo QuestionInfo;

        public struct stCustomLevel {

           public int from, to;

        }public static stCustomLevel CustomLevel;

        Random RandomNumber = new Random();

        struct stGameTime
       {

            public DateTime GameTime;
            public TimeSpan GameTimeSpan;

       }
        stGameTime GameTimeInfo;

        // Game Functions
        void PlayGame()
        {

            if (QuestionInfo.QuestionNumber >= GameInfo.GameQuestionsNumber)
            {

                ShowEndGameScreen();
                return;

            }

            MakeQuestion();

        }
        void MakeQuestion()
        {

            PrepareQuestion();

            lbQoestion.Text = QuestionInfo.Number1.ToString() + " " +
                              GetOpration() + " " +
                              QuestionInfo.Number2.ToString() + " =";

            if(rdOptionsStyle.Checked)
                SetOptinsAnswer();

        }
        void PrepareQuestion()
        {

            QuestionInfo.Number1 = GetRandomNumber();
            QuestionInfo.Number2 = GetRandomNumber();

            QuestionInfo.Opration = GetOpration();

            QuestionInfo.Result = GetQuestionResult();

            QuestionInfo.QuestionNumber++;
            lbQuestionNumber.Text = "Question Number: " + QuestionInfo.QuestionNumber;


        }
        void ShowEndGameScreen()
        {

            string GameResult = "Level: " + GameInfo.enGameLevel +
                                "\nGame Opration: " + GameInfo.enGameOpration +
                                "\nQuestions Style: " + GameInfo.enGameQuestionStyle +
                                "\nQuestions Number: " + QuestionInfo.QuestionNumber +
                                "\nRight Answers: " + GameInfo.RightAnswer +
                                "\nWrong Answer: " + GameInfo.WrongAnswers +
                                "\n" + lbTime.Text;

            GameEnd();

            MessageBox.Show(GameResult, "Round Result",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
        void GameEnd()
        {
            // Disable Group Box
            gbQuestionsNumber.Enabled = true;
            gbQuestionStyle.Enabled = true;
            gbLevel.Enabled = true;
            gbTime.Enabled = true;
            gbOpration.Enabled = true;

            // Buttons
            btStartGame.Enabled = true;
            btEndGame.Enabled = false;
            btPauseGame.Enabled = false;

            // TextBox
            AnswerTextBox.Enabled = false;
            AnswerTextBox.Text = string.Empty;

            // Labels
            lbGameStatus.Text = "Game Status \n";
            lbQoestion.Text = "The Game Did\n Not Start";
            lbWrongAnswers.Text = "Wrong Answers: ";
            lbRightAnswers.Text = "Right Answer: ";
            lbQuestionNumber.Text = "Question Number: ";
            lbTimeLeft.Text = "Time Left: ";

            // GameInfo
            GameInfo.WrongAnswers = 0;
            GameInfo.RightAnswer = 0;
            QuestionInfo.QuestionNumber = 0;
            GameTimeTimer.Enabled = false;

            // Answers
            AnswerTextBox.Text = string.Empty;
            AnswerOption1.Text = string.Empty;
            AnswerOption2.Text = string.Empty;
            AnswerOption3.Text = string.Empty;
            AnswerOption4.Text = string.Empty;

        }
        void SetOptinsAnswer()
        {

            SetCorrectOption();
            SetRandomOpionAnswers();

        }
        void SetCorrectOption()
        {

            AnswerOption1.Tag = "No";
            AnswerOption3.Tag = "No";
            AnswerOption2.Tag = "No";
            AnswerOption4.Tag = "No";

            switch (RandomNumber.Next(1,4) + 1)
            {

                case 1:
                    AnswerOption1.Text = QuestionInfo.Result.ToString();
                    AnswerOption1.Tag = "yes";
                    break;
                case 2:
                    AnswerOption2.Text = QuestionInfo.Result.ToString();
                    AnswerOption2.Tag = "yes";
                    break;
                case 3:
                    AnswerOption3.Text = QuestionInfo.Result.ToString();
                    AnswerOption3.Tag = "yes";
                    break;
                default:
                    AnswerOption4.Text = QuestionInfo.Result.ToString();
                    AnswerOption4.Tag = "yes";
                    break;

            }

        }
        void SetRandomOpionAnswers()
        {

            if(AnswerOption1.Tag.ToString() == "No")
            {

                AnswerOption1.Text = RandomNumber.Next(QuestionInfo.Result - 10, QuestionInfo.Result + 10).ToString();

            }
            if (AnswerOption2.Tag.ToString() == "No")
            {
                do
                {

                    AnswerOption2.Text = RandomNumber.Next(QuestionInfo.Result - 10, QuestionInfo.Result + 10).ToString();
               
                } while (AnswerOption2.Text == AnswerOption1.Text);
            }
            if (AnswerOption3.Tag.ToString() == "No")
            {
                do{
                  
                    AnswerOption3.Text = RandomNumber.Next(QuestionInfo.Result - 10, QuestionInfo.Result + 10).ToString();
               
                } while (AnswerOption3.Text == AnswerOption1.Text || AnswerOption3.Text == AnswerOption2.Text);
            }
            if (AnswerOption4.Tag.ToString() == "No")
            {

                do
                {

                    AnswerOption4.Text = RandomNumber.Next(QuestionInfo.Result - 10, QuestionInfo.Result + 10).ToString();

                } while (AnswerOption4.Text == AnswerOption1.Text || AnswerOption4.Text == AnswerOption2.Text
                        || AnswerOption4.Text == AnswerOption3.Text);

            }

        }
        // Level
        private void rdHard_CheckedChanged(object sender, EventArgs e)
        {

            lbLevel.Text = "Level\nHard";
            GameInfo.enGameLevel = enLevel.Hard;

            LevelValidating();

        }
        private void rdMeduim_CheckedChanged(object sender, EventArgs e)
        {

            lbLevel.Text = "Level\nMeduim";
            GameInfo.enGameLevel = enLevel.Medium;
            LevelValidating();

        }
        private void rdEasy_CheckedChanged(object sender, EventArgs e)
        {

            lbLevel.Text = "Level\nEasy";
            GameInfo.enGameLevel = enLevel.Easy;
            LevelValidating();

        }
        private void rdcustom_CheckedChanged(object sender, EventArgs e)
        {

            CustomLevel frmCustomLevel = new CustomLevel();

            lbLevel.Text = "Level\nCustom";
            GameInfo.enGameLevel = enLevel.Custom;

            frmCustomLevel.ShowDialog();

            LevelValidating();

        }

        // Opration
        private void rdMix_CheckedChanged(object sender, EventArgs e)
        {

            lbOpration.Text = "Opration\nMixed";
            GameInfo.enGameOpration = enOpration.Mixed;
            OprationValidating();
        }
        private void rdaddition_CheckedChanged(object sender, EventArgs e)
        {
            lbOpration.Text = "Opration\nAddition";
            GameInfo.enGameOpration = enOpration.Addition;
            OprationValidating();
        }
        private void rdsubtraction_CheckedChanged(object sender, EventArgs e)
        {
            lbOpration.Text = "Opration\nSubtraction";
            GameInfo.enGameOpration = enOpration.Subtraction;
            OprationValidating();
        }
        private void rdmultiplication_CheckedChanged(object sender, EventArgs e)
        {
            lbOpration.Text = "Opration\nMultiplication";
            GameInfo.enGameOpration = enOpration.Multiplication;
            OprationValidating();
        }
        private void rddivision_CheckedChanged(object sender, EventArgs e)
        {
            lbOpration.Text = "Opration\nDivision";
            GameInfo.enGameOpration = enOpration.Division;
            OprationValidating();
        }

        // Questions Style
        private void rdWriteAnswer_CheckedChanged(object sender, EventArgs e)
        {

            lbQuestionStyle.Text = "Question Style\nWrite Answer";
            GameInfo.enGameQuestionStyle = enQuestionStyle.WriteAnswer;

            QuestionStyleValidating();

           

        }
        private void rd4Options_CheckedChanged(object sender, EventArgs e)
        {

            lbQuestionStyle.Text = "Question Style\n4 Options";
            GameInfo.enGameQuestionStyle = enQuestionStyle.Options;

            QuestionStyleValidating();
        }

        // Questions Number
        private void nudQuestionNumber_ValueChanged(object sender, EventArgs e)
        {

            lbQuestionsNumber.Text = "Question Number\n" + nudQuestionNumber.Value.ToString();

            GameInfo.GameQuestionsNumber = Convert.ToInt16(nudQuestionNumber.Value);
        }

        // Time
        string GetMinutes()
        {

            if (Convert.ToInt16(mtbMinutes.Text) < 10 && mtbMinutes.Text.Length < 2)
            {

                return "0" + mtbMinutes.Text;

            }

            return mtbMinutes.Text;
        }
        string GetSeconds()
        {

            if (Convert.ToInt16(mtbSeconds.Text) < 10 && mtbSeconds.Text.Length < 2)
            {

                return "0" + mtbSeconds.Text;

            }

            return mtbSeconds.Text;
        }
        private void cbWithTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWithTime.Checked)
            {

                mtbMinutes.Enabled = true;
                mtbSeconds.Enabled = true;

                lbTime.Text = "Game Time: 00:00";
                lbTimeLeft.Text = "Time Left: " + GameTimeInfo.GameTime.ToString("mm:ss");
            }
            else
            {

                mtbMinutes.Enabled = false;
                mtbSeconds.Enabled = false;
               
                lbTime.Text = "Game Time: No Time";
                lbTimeLeft.Text = "Time Left: ";
            }

        }
        void UpdateTimeInGameInfo()
        {

            lbTime.Text = "Game Time: " + GetMinutes() + ":" + GetSeconds();

            GameTimeInfo.GameTime = DateTime.Today
            .AddMinutes(Convert.ToInt16(mtbMinutes.Text))
            .AddSeconds(Convert.ToInt16(mtbSeconds.Text));

            lbTimeLeft.Text = "Time Left: " + GameTimeInfo.GameTime.ToString("mm:ss");

        }
        private void mtbMinutes_Validating(object sender, CancelEventArgs e)
        {
            UpdateTimeInGameInfo();
        }
        private void mtbSeconds_Validating(object sender, CancelEventArgs e)
        {
            UpdateTimeInGameInfo();
        }
        private void GameTime_Tick(object sender, EventArgs e)
        {

            if (GameTimeInfo.GameTimeSpan.ToString("mm\\:ss") == "00:00")
            {

                ShowEndGameScreen();

            }
            else
            {

                GameTimeInfo.GameTimeSpan = GameTimeInfo.GameTimeSpan.Subtract(TimeSpan.FromSeconds(1));

                lbTimeLeft.Text = "Time Left: " + GameTimeInfo.GameTimeSpan.ToString("mm\\:ss");

            }

        }
        
        // Start Game
        void GameStartScreen() 
        {

            // Disable Group Box
            gbQuestionsNumber.Enabled = false;
            gbQuestionStyle.Enabled = false;
            gbLevel.Enabled = false;
            gbTime.Enabled = false;
            gbOpration.Enabled = false;

            // Buttons
            btStartGame.Enabled = false;
            btEndGame.Enabled = true;

            lbGameStatus.Text = "Game Status \nin Prograsess";
            GameInfo.GameQuestionsNumber = Convert.ToInt16(nudQuestionNumber.Value);

            if (rdWriteAnswerStyle.Checked)
            {
                AnswerTextBox.Enabled = true;
                this.ActiveControl = AnswerTextBox;
                AnswerTextBox.Focus();
                AnswerTextBox.Enabled = true;
            }
            else
            {

                AnswerOption1.Enabled = true;
                AnswerOption2.Enabled = true;
                AnswerOption3.Enabled = true;
                AnswerOption4.Enabled = true;
            
            }

            if (cbWithTime.Checked)
            {
                btPauseGame.Enabled = true;

                GameTimeTimer.Enabled = true;

                GameTimeInfo.GameTimeSpan = TimeSpan.FromSeconds(GameTimeInfo.GameTime.Second)
                                     .Add(TimeSpan.FromMinutes(GameTimeInfo.GameTime.Minute));

            }
        }
        private void btStartGame_Click(object sender, EventArgs e)
        {


            if(ValidateGameInfo()){

                GameStartScreen();

                PlayGame();

            }
            
            

        }
        
        // Pause Game
        private void btPauseGame_Click(object sender, EventArgs e)
        {

            if (GameTimeTimer.Enabled)
            {

                GameTimeTimer.Enabled = false;
                btPauseGame.Text = "continue Game";

            }
            else
            {

                GameTimeTimer.Enabled = true;
                btPauseGame.Text = "Pause Game";

            }
        }

        // End Game
        private void btEndGame_Click(object sender, EventArgs e)
        {

            ShowEndGameScreen();

        }

        // Answer
        MaskedTextBox AnswerTextBox = new MaskedTextBox();
        Button AnswerOption1 = new Button();
        Button AnswerOption2 = new Button();
        Button AnswerOption3 = new Button();
        Button AnswerOption4 = new Button();
        void SetAnswerTextBox()
        {

            AnswerTextBox.Location = new Point(371,186);
            AnswerTextBox.Size = new Size(395, 55);

            AnswerTextBox.Font = new Font("Microsoft Sans Serif", 25);
            AnswerTextBox.TextAlign = HorizontalAlignment.Center;

            AnswerTextBox.KeyDown += mtbEnterAnswer;
            AnswerTextBox.Enabled = false;

        }
        void DrawAnswerTextBox()
        {

            this.Controls.Add(AnswerTextBox);

        }
        void RemoveAnswerTextBox()
        {

            this.Controls.Remove(AnswerTextBox);

        }
        void SetAnswerOptions()
        {
            // Answer Option 1
            AnswerOption1.Location = new Point(302, 193);
            AnswerOption1.Size = new Size(116, 62);

            AnswerOption1.Font = new Font("Microsoft Sans Serif", 18);
            AnswerOption1.TextAlign = ContentAlignment.MiddleCenter;
            AnswerOption1.BackColor = Color.White;

            AnswerOption1.Click += OptinsClickAnswer;
            AnswerOption1.Enabled = false;

            // Answer Option 2
            AnswerOption2.Location = new Point(442, 193);
            AnswerOption2.Size = new Size(116, 62);

            AnswerOption2.Font = new Font("Microsoft Sans Serif", 18);
            AnswerOption2.TextAlign = ContentAlignment.MiddleCenter;
            AnswerOption2.BackColor = Color.White;

            AnswerOption2.Click += OptinsClickAnswer;
            AnswerOption2.Enabled = false;

            // Answer Option 3
            AnswerOption3.Location = new Point(582, 193);
            AnswerOption3.Size = new Size(116, 62);

            AnswerOption3.Font = new Font("Microsoft Sans Serif", 18);
            AnswerOption3.TextAlign = ContentAlignment.MiddleCenter;
            AnswerOption3.BackColor = Color.White;

            AnswerOption3.Click += OptinsClickAnswer;
            AnswerOption3.Enabled = false;

            // Answer Option 4
            AnswerOption4.Location = new Point(722, 193);
            AnswerOption4.Size = new Size(116, 62);

            AnswerOption4.Font = new Font("Microsoft Sans Serif", 18);
            AnswerOption4.TextAlign = ContentAlignment.MiddleCenter;
            AnswerOption4.BackColor = Color.White;

            AnswerOption4.Click += OptinsClickAnswer;
            AnswerOption4.Enabled = false;

        }
        void DrwaAnswerOptions()
        {

            this.Controls.Add(AnswerOption1);
            this.Controls.Add(AnswerOption2);
            this.Controls.Add(AnswerOption3);
            this.Controls.Add(AnswerOption4);

        }
        void RemoveAnswerOptions()
        {

            this.Controls.Remove(AnswerOption1);
            this.Controls.Remove(AnswerOption2);
            this.Controls.Remove(AnswerOption3);
            this.Controls.Remove(AnswerOption4);

        }
        void CheckAnswer(int Result)
        {

            if (QuestionInfo.Result == Result)
            {

                lbRightAnswers.Text = "Right Answers: " + ++GameInfo.RightAnswer;
                                
            }
            else
            {

                lbWrongAnswers.Text = "Wrong Answers: " + ++GameInfo.WrongAnswers;
             
            }

            PlayGame();

        }
        void mtbEnterAnswer(object sender, KeyEventArgs e)
        {

             if (e.KeyCode == Keys.Enter)
             {

                MaskedTextBox maskedTextBox = (MaskedTextBox)sender;

                int.TryParse(maskedTextBox.Text, out int result);

                CheckAnswer(result);

                AnswerTextBox.Text = string.Empty;

             }

        }
        void OptinsClickAnswer(object sender, EventArgs e)
        {

            CheckAnswer(Convert.ToInt16(((Button)sender).Text));

        }
       
        // Validate Game Info
        bool ValidateGameInfo()
        {

            if (LevelValidating() && OprationValidating() && QuestionStyleValidating()) {

                return true;
            
            }
            else
            {

                return false;
            }

        }
        bool LevelValidating()
        {

            if(rdHard.Checked || rdMeduim.Checked || rdEasy.Checked || rdcustom.Checked) {               

                GameInfoError.Clear();

                return true;
            }
            else
            {

                GameInfoError.SetError(gbLevel, "you need to pick the level");

                return false;
            }
        }
        bool OprationValidating()
        {
            if (rdMix.Checked || rdaddition.Checked || rddivision.Checked ||
                rdmultiplication.Checked || rdsubtraction.Checked)
            {
              
                GameInfoError.Clear();


                return true;
            }
            else
            {

                GameInfoError.SetError(gbOpration, "you need to pick the Opration");

                GameInfoError.SetIconAlignment(gbOpration, ErrorIconAlignment.MiddleLeft);
                
                return false;
            }

        }
        bool QuestionStyleValidating()
        {
            if (rdWriteAnswerStyle.Checked || rdOptionsStyle.Checked)
            {

                GameInfoError.Clear();

                if (rdWriteAnswerStyle.Checked)
                {

                    RemoveAnswerOptions();
                    DrawAnswerTextBox();

                }
                else
                {

                    RemoveAnswerTextBox();
                    DrwaAnswerOptions();

                }
                return true;
            }
            else
            {

                GameInfoError.SetError(gbQuestionStyle, "you need to pick the Question Style");

                GameInfoError.SetIconAlignment(gbQuestionStyle, ErrorIconAlignment.MiddleLeft);


                return false;
            }

        }

        // ------------------

        int GetRandomNumber()
        {

            switch (GameInfo.enGameLevel)
            {
                case enLevel.Hard:
                    return RandomNumber.Next(0, 100) + 1;

                case enLevel.Medium:
                    return RandomNumber.Next(0, 50) + 1;

                case enLevel.Easy:
                    return RandomNumber.Next(0, 10) + 1;

                default:
                    return RandomNumber.Next(CustomLevel.from, CustomLevel.to) + 1;

            }
        }
        char GetRandomOpration()
        {

            Random rndnum = new Random();

            switch (rndnum.Next(1, 5))
            {
                case 1:
                    return '+';

                case 2:
                    return '-';

                case 3:
                    return '*';

                case 4:
                    return '/';

                default:
                    return '+';
            }
        }
        char GetOpration()
        {

            switch (GameInfo.enGameOpration)
            {

                case enOpration.Addition:
                    return '+';

                case enOpration.Subtraction:
                    return '-';

                case enOpration.Multiplication:
                    return '*';

                case enOpration.Division:
                    return '/';

                default:
                    return GetRandomOpration();

            }
        }
        int GetQuestionResult()
        {

            switch (QuestionInfo.Opration)
            {

                case '+':
                    return QuestionInfo.Number1 + QuestionInfo.Number2;

                case '-':
                    return QuestionInfo.Number1 - QuestionInfo.Number2;

                case '*':
                    return QuestionInfo.Number1 * QuestionInfo.Number2;

                case '/':
                    return QuestionInfo.Number1 / QuestionInfo.Number2;

                default:
                    return QuestionInfo.Number1 + QuestionInfo.Number2;

            }

        }

       
    }
}
