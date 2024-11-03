namespace My_Math_Game
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btStartGame = new System.Windows.Forms.Button();
            this.rdMix = new System.Windows.Forms.RadioButton();
            this.rdHard = new System.Windows.Forms.RadioButton();
            this.gbLevel = new System.Windows.Forms.GroupBox();
            this.rdcustom = new System.Windows.Forms.RadioButton();
            this.rdEasy = new System.Windows.Forms.RadioButton();
            this.rdMeduim = new System.Windows.Forms.RadioButton();
            this.gbOpration = new System.Windows.Forms.GroupBox();
            this.rddivision = new System.Windows.Forms.RadioButton();
            this.rdmultiplication = new System.Windows.Forms.RadioButton();
            this.rdsubtraction = new System.Windows.Forms.RadioButton();
            this.rdaddition = new System.Windows.Forms.RadioButton();
            this.lbQoestion = new System.Windows.Forms.Label();
            this.gbQuestionStyle = new System.Windows.Forms.GroupBox();
            this.rdOptionsStyle = new System.Windows.Forms.RadioButton();
            this.rdWriteAnswerStyle = new System.Windows.Forms.RadioButton();
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.cbWithTime = new System.Windows.Forms.CheckBox();
            this.lbSeconds = new System.Windows.Forms.Label();
            this.mtbSeconds = new System.Windows.Forms.MaskedTextBox();
            this.lbMinutes = new System.Windows.Forms.Label();
            this.mtbMinutes = new System.Windows.Forms.MaskedTextBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbLevel = new System.Windows.Forms.Label();
            this.lbQuestionsNumber = new System.Windows.Forms.Label();
            this.lbOpration = new System.Windows.Forms.Label();
            this.lbQuestionStyle = new System.Windows.Forms.Label();
            this.gbQuestionsNumber = new System.Windows.Forms.GroupBox();
            this.nudQuestionNumber = new System.Windows.Forms.NumericUpDown();
            this.btEndGame = new System.Windows.Forms.Button();
            this.btPauseGame = new System.Windows.Forms.Button();
            this.gpGameInfo = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbQuestionNumber = new System.Windows.Forms.Label();
            this.lbTimeLeft = new System.Windows.Forms.Label();
            this.lbRightAnswers = new System.Windows.Forms.Label();
            this.lbWrongAnswers = new System.Windows.Forms.Label();
            this.lbGameStatus = new System.Windows.Forms.Label();
            this.GameInfoError = new System.Windows.Forms.ErrorProvider(this.components);
            this.GameTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.gbLevel.SuspendLayout();
            this.gbOpration.SuspendLayout();
            this.gbQuestionStyle.SuspendLayout();
            this.gbTime.SuspendLayout();
            this.gbQuestionsNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuestionNumber)).BeginInit();
            this.gpGameInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameInfoError)).BeginInit();
            this.SuspendLayout();
            // 
            // btStartGame
            // 
            this.btStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStartGame.Location = new System.Drawing.Point(908, 635);
            this.btStartGame.Name = "btStartGame";
            this.btStartGame.Size = new System.Drawing.Size(171, 75);
            this.btStartGame.TabIndex = 2;
            this.btStartGame.Text = "Start Game";
            this.btStartGame.UseVisualStyleBackColor = true;
            this.btStartGame.Click += new System.EventHandler(this.btStartGame_Click);
            // 
            // rdMix
            // 
            this.rdMix.AutoSize = true;
            this.rdMix.Cursor = System.Windows.Forms.Cursors.Default;
            this.rdMix.Location = new System.Drawing.Point(15, 34);
            this.rdMix.Name = "rdMix";
            this.rdMix.Size = new System.Drawing.Size(74, 24);
            this.rdMix.TabIndex = 3;
            this.rdMix.TabStop = true;
            this.rdMix.Text = "Mixed";
            this.rdMix.UseVisualStyleBackColor = true;
            this.rdMix.CheckedChanged += new System.EventHandler(this.rdMix_CheckedChanged);
            // 
            // rdHard
            // 
            this.rdHard.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdHard.Font = new System.Drawing.Font("Britannic Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdHard.Location = new System.Drawing.Point(6, 31);
            this.rdHard.Name = "rdHard";
            this.rdHard.Size = new System.Drawing.Size(161, 67);
            this.rdHard.TabIndex = 4;
            this.rdHard.TabStop = true;
            this.rdHard.Text = "Hard\r\n0 - 100";
            this.rdHard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdHard.UseVisualStyleBackColor = true;
            this.rdHard.Click += new System.EventHandler(this.rdHard_CheckedChanged);
            // 
            // gbLevel
            // 
            this.gbLevel.Controls.Add(this.rdcustom);
            this.gbLevel.Controls.Add(this.rdEasy);
            this.gbLevel.Controls.Add(this.rdMeduim);
            this.gbLevel.Controls.Add(this.rdHard);
            this.gbLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLevel.Location = new System.Drawing.Point(24, 28);
            this.gbLevel.Name = "gbLevel";
            this.gbLevel.Size = new System.Drawing.Size(173, 387);
            this.gbLevel.TabIndex = 6;
            this.gbLevel.TabStop = false;
            this.gbLevel.Text = "Level";
            // 
            // rdcustom
            // 
            this.rdcustom.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdcustom.Font = new System.Drawing.Font("Britannic Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdcustom.Location = new System.Drawing.Point(6, 301);
            this.rdcustom.Name = "rdcustom";
            this.rdcustom.Size = new System.Drawing.Size(161, 67);
            this.rdcustom.TabIndex = 10;
            this.rdcustom.TabStop = true;
            this.rdcustom.Text = "Custom";
            this.rdcustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdcustom.UseVisualStyleBackColor = true;
            this.rdcustom.Click += new System.EventHandler(this.rdcustom_CheckedChanged);
            // 
            // rdEasy
            // 
            this.rdEasy.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdEasy.Font = new System.Drawing.Font("Britannic Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdEasy.Location = new System.Drawing.Point(6, 211);
            this.rdEasy.Name = "rdEasy";
            this.rdEasy.Size = new System.Drawing.Size(161, 67);
            this.rdEasy.TabIndex = 9;
            this.rdEasy.TabStop = true;
            this.rdEasy.Text = "Easy\r\n0 - 10";
            this.rdEasy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdEasy.UseVisualStyleBackColor = true;
            this.rdEasy.Click += new System.EventHandler(this.rdEasy_CheckedChanged);
            // 
            // rdMeduim
            // 
            this.rdMeduim.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdMeduim.Font = new System.Drawing.Font("Britannic Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMeduim.Location = new System.Drawing.Point(6, 121);
            this.rdMeduim.Name = "rdMeduim";
            this.rdMeduim.Size = new System.Drawing.Size(161, 67);
            this.rdMeduim.TabIndex = 8;
            this.rdMeduim.TabStop = true;
            this.rdMeduim.Text = "Meduim\r\n0 - 50\r\n";
            this.rdMeduim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdMeduim.UseVisualStyleBackColor = true;
            this.rdMeduim.Click += new System.EventHandler(this.rdMeduim_CheckedChanged);
            // 
            // gbOpration
            // 
            this.gbOpration.Controls.Add(this.rddivision);
            this.gbOpration.Controls.Add(this.rdmultiplication);
            this.gbOpration.Controls.Add(this.rdsubtraction);
            this.gbOpration.Controls.Add(this.rdaddition);
            this.gbOpration.Controls.Add(this.rdMix);
            this.gbOpration.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbOpration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOpration.Location = new System.Drawing.Point(908, 39);
            this.gbOpration.Name = "gbOpration";
            this.gbOpration.Size = new System.Drawing.Size(173, 239);
            this.gbOpration.TabIndex = 8;
            this.gbOpration.TabStop = false;
            this.gbOpration.Text = "Opration";
            // 
            // rddivision
            // 
            this.rddivision.AutoSize = true;
            this.rddivision.Location = new System.Drawing.Point(15, 192);
            this.rddivision.Name = "rddivision";
            this.rddivision.Size = new System.Drawing.Size(90, 24);
            this.rddivision.TabIndex = 7;
            this.rddivision.TabStop = true;
            this.rddivision.Text = "Division";
            this.rddivision.UseVisualStyleBackColor = true;
            this.rddivision.CheckedChanged += new System.EventHandler(this.rddivision_CheckedChanged);
            // 
            // rdmultiplication
            // 
            this.rdmultiplication.AutoSize = true;
            this.rdmultiplication.Location = new System.Drawing.Point(15, 157);
            this.rdmultiplication.Name = "rdmultiplication";
            this.rdmultiplication.Size = new System.Drawing.Size(128, 24);
            this.rdmultiplication.TabIndex = 6;
            this.rdmultiplication.TabStop = true;
            this.rdmultiplication.Text = "Multiplication";
            this.rdmultiplication.UseVisualStyleBackColor = true;
            this.rdmultiplication.CheckedChanged += new System.EventHandler(this.rdmultiplication_CheckedChanged);
            // 
            // rdsubtraction
            // 
            this.rdsubtraction.AutoSize = true;
            this.rdsubtraction.Location = new System.Drawing.Point(15, 116);
            this.rdsubtraction.Name = "rdsubtraction";
            this.rdsubtraction.Size = new System.Drawing.Size(115, 24);
            this.rdsubtraction.TabIndex = 5;
            this.rdsubtraction.TabStop = true;
            this.rdsubtraction.Text = "Subtraction";
            this.rdsubtraction.UseVisualStyleBackColor = true;
            this.rdsubtraction.CheckedChanged += new System.EventHandler(this.rdsubtraction_CheckedChanged);
            // 
            // rdaddition
            // 
            this.rdaddition.AutoSize = true;
            this.rdaddition.Location = new System.Drawing.Point(15, 75);
            this.rdaddition.Name = "rdaddition";
            this.rdaddition.Size = new System.Drawing.Size(90, 24);
            this.rdaddition.TabIndex = 4;
            this.rdaddition.TabStop = true;
            this.rdaddition.Text = "Addition";
            this.rdaddition.UseVisualStyleBackColor = true;
            this.rdaddition.CheckedChanged += new System.EventHandler(this.rdaddition_CheckedChanged);
            // 
            // lbQoestion
            // 
            this.lbQoestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQoestion.Location = new System.Drawing.Point(350, 39);
            this.lbQoestion.Name = "lbQoestion";
            this.lbQoestion.Size = new System.Drawing.Size(437, 129);
            this.lbQoestion.TabIndex = 10;
            this.lbQoestion.Text = "The Game Did\r\n Not Start";
            this.lbQoestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbQuestionStyle
            // 
            this.gbQuestionStyle.Controls.Add(this.rdOptionsStyle);
            this.gbQuestionStyle.Controls.Add(this.rdWriteAnswerStyle);
            this.gbQuestionStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbQuestionStyle.Location = new System.Drawing.Point(908, 293);
            this.gbQuestionStyle.Name = "gbQuestionStyle";
            this.gbQuestionStyle.Size = new System.Drawing.Size(172, 155);
            this.gbQuestionStyle.TabIndex = 12;
            this.gbQuestionStyle.TabStop = false;
            this.gbQuestionStyle.Text = "Question Style";
            // 
            // rdOptionsStyle
            // 
            this.rdOptionsStyle.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdOptionsStyle.Location = new System.Drawing.Point(27, 91);
            this.rdOptionsStyle.Name = "rdOptionsStyle";
            this.rdOptionsStyle.Size = new System.Drawing.Size(126, 43);
            this.rdOptionsStyle.TabIndex = 9;
            this.rdOptionsStyle.TabStop = true;
            this.rdOptionsStyle.Text = "Options Style";
            this.rdOptionsStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdOptionsStyle.UseVisualStyleBackColor = true;
            this.rdOptionsStyle.CheckedChanged += new System.EventHandler(this.rd4Options_CheckedChanged);
            // 
            // rdWriteAnswerStyle
            // 
            this.rdWriteAnswerStyle.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdWriteAnswerStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdWriteAnswerStyle.Location = new System.Drawing.Point(27, 25);
            this.rdWriteAnswerStyle.Name = "rdWriteAnswerStyle";
            this.rdWriteAnswerStyle.Size = new System.Drawing.Size(126, 60);
            this.rdWriteAnswerStyle.TabIndex = 8;
            this.rdWriteAnswerStyle.TabStop = true;
            this.rdWriteAnswerStyle.Text = "Write Answer Style";
            this.rdWriteAnswerStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdWriteAnswerStyle.UseVisualStyleBackColor = true;
            this.rdWriteAnswerStyle.CheckedChanged += new System.EventHandler(this.rdWriteAnswer_CheckedChanged);
            // 
            // gbTime
            // 
            this.gbTime.Controls.Add(this.cbWithTime);
            this.gbTime.Controls.Add(this.lbSeconds);
            this.gbTime.Controls.Add(this.mtbSeconds);
            this.gbTime.Controls.Add(this.lbMinutes);
            this.gbTime.Controls.Add(this.mtbMinutes);
            this.gbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTime.Location = new System.Drawing.Point(908, 455);
            this.gbTime.Name = "gbTime";
            this.gbTime.Size = new System.Drawing.Size(171, 157);
            this.gbTime.TabIndex = 13;
            this.gbTime.TabStop = false;
            this.gbTime.Text = "Time";
            // 
            // cbWithTime
            // 
            this.cbWithTime.AutoSize = true;
            this.cbWithTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWithTime.Location = new System.Drawing.Point(27, 127);
            this.cbWithTime.Name = "cbWithTime";
            this.cbWithTime.Size = new System.Drawing.Size(102, 24);
            this.cbWithTime.TabIndex = 24;
            this.cbWithTime.Text = "WithTime";
            this.cbWithTime.UseVisualStyleBackColor = true;
            this.cbWithTime.CheckedChanged += new System.EventHandler(this.cbWithTime_CheckedChanged);
            // 
            // lbSeconds
            // 
            this.lbSeconds.AutoSize = true;
            this.lbSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeconds.Location = new System.Drawing.Point(3, 89);
            this.lbSeconds.Name = "lbSeconds";
            this.lbSeconds.Size = new System.Drawing.Size(103, 26);
            this.lbSeconds.TabIndex = 16;
            this.lbSeconds.Text = "Seconds:";
            // 
            // mtbSeconds
            // 
            this.mtbSeconds.Enabled = false;
            this.mtbSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbSeconds.Location = new System.Drawing.Point(120, 89);
            this.mtbSeconds.Mask = "00";
            this.mtbSeconds.Name = "mtbSeconds";
            this.mtbSeconds.Size = new System.Drawing.Size(40, 32);
            this.mtbSeconds.TabIndex = 15;
            this.mtbSeconds.Text = "00";
            this.mtbSeconds.Validating += new System.ComponentModel.CancelEventHandler(this.mtbSeconds_Validating);
            // 
            // lbMinutes
            // 
            this.lbMinutes.AutoSize = true;
            this.lbMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinutes.Location = new System.Drawing.Point(3, 43);
            this.lbMinutes.Name = "lbMinutes";
            this.lbMinutes.Size = new System.Drawing.Size(94, 26);
            this.lbMinutes.TabIndex = 14;
            this.lbMinutes.Text = "Minutes:";
            // 
            // mtbMinutes
            // 
            this.mtbMinutes.Enabled = false;
            this.mtbMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbMinutes.Location = new System.Drawing.Point(120, 43);
            this.mtbMinutes.Mask = "00";
            this.mtbMinutes.Name = "mtbMinutes";
            this.mtbMinutes.Size = new System.Drawing.Size(40, 32);
            this.mtbMinutes.TabIndex = 0;
            this.mtbMinutes.Text = "00";
            this.mtbMinutes.Validating += new System.ComponentModel.CancelEventHandler(this.mtbMinutes_Validating);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbTime.Location = new System.Drawing.Point(10, 265);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(241, 29);
            this.lbTime.TabIndex = 15;
            this.lbTime.Text = "Game Time: no Time";
            // 
            // lbLevel
            // 
            this.lbLevel.AutoSize = true;
            this.lbLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbLevel.Location = new System.Drawing.Point(10, 26);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(71, 29);
            this.lbLevel.TabIndex = 16;
            this.lbLevel.Text = "Level";
            this.lbLevel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbQuestionsNumber
            // 
            this.lbQuestionsNumber.AutoSize = true;
            this.lbQuestionsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbQuestionsNumber.Location = new System.Drawing.Point(10, 179);
            this.lbQuestionsNumber.Name = "lbQuestionsNumber";
            this.lbQuestionsNumber.Size = new System.Drawing.Size(215, 58);
            this.lbQuestionsNumber.TabIndex = 17;
            this.lbQuestionsNumber.Text = "Questions Number\r\n1";
            // 
            // lbOpration
            // 
            this.lbOpration.AutoSize = true;
            this.lbOpration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbOpration.Location = new System.Drawing.Point(107, 26);
            this.lbOpration.Name = "lbOpration";
            this.lbOpration.Size = new System.Drawing.Size(106, 29);
            this.lbOpration.TabIndex = 18;
            this.lbOpration.Text = "Opration";
            this.lbOpration.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbQuestionStyle
            // 
            this.lbQuestionStyle.AutoSize = true;
            this.lbQuestionStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbQuestionStyle.Location = new System.Drawing.Point(10, 103);
            this.lbQuestionStyle.Name = "lbQuestionStyle";
            this.lbQuestionStyle.Size = new System.Drawing.Size(169, 29);
            this.lbQuestionStyle.TabIndex = 19;
            this.lbQuestionStyle.Text = "Question Style";
            // 
            // gbQuestionsNumber
            // 
            this.gbQuestionsNumber.Controls.Add(this.nudQuestionNumber);
            this.gbQuestionsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbQuestionsNumber.Location = new System.Drawing.Point(24, 421);
            this.gbQuestionsNumber.Name = "gbQuestionsNumber";
            this.gbQuestionsNumber.Size = new System.Drawing.Size(173, 93);
            this.gbQuestionsNumber.TabIndex = 20;
            this.gbQuestionsNumber.TabStop = false;
            this.gbQuestionsNumber.Text = "Questions Number";
            // 
            // nudQuestionNumber
            // 
            this.nudQuestionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuestionNumber.Location = new System.Drawing.Point(33, 34);
            this.nudQuestionNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuestionNumber.Name = "nudQuestionNumber";
            this.nudQuestionNumber.Size = new System.Drawing.Size(90, 34);
            this.nudQuestionNumber.TabIndex = 0;
            this.nudQuestionNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuestionNumber.ValueChanged += new System.EventHandler(this.nudQuestionNumber_ValueChanged);
            // 
            // btEndGame
            // 
            this.btEndGame.Enabled = false;
            this.btEndGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEndGame.Location = new System.Drawing.Point(24, 640);
            this.btEndGame.Name = "btEndGame";
            this.btEndGame.Size = new System.Drawing.Size(173, 75);
            this.btEndGame.TabIndex = 21;
            this.btEndGame.Text = "End Game";
            this.btEndGame.UseVisualStyleBackColor = true;
            this.btEndGame.Click += new System.EventHandler(this.btEndGame_Click);
            // 
            // btPauseGame
            // 
            this.btPauseGame.Enabled = false;
            this.btPauseGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPauseGame.Location = new System.Drawing.Point(24, 545);
            this.btPauseGame.Name = "btPauseGame";
            this.btPauseGame.Size = new System.Drawing.Size(173, 75);
            this.btPauseGame.TabIndex = 22;
            this.btPauseGame.Text = "Pause Game";
            this.btPauseGame.UseVisualStyleBackColor = true;
            this.btPauseGame.Click += new System.EventHandler(this.btPauseGame_Click);
            // 
            // gpGameInfo
            // 
            this.gpGameInfo.Controls.Add(this.lbQuestionStyle);
            this.gpGameInfo.Controls.Add(this.lbOpration);
            this.gpGameInfo.Controls.Add(this.lbQuestionsNumber);
            this.gpGameInfo.Controls.Add(this.lbLevel);
            this.gpGameInfo.Controls.Add(this.lbTime);
            this.gpGameInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpGameInfo.Location = new System.Drawing.Point(250, 398);
            this.gpGameInfo.Name = "gpGameInfo";
            this.gpGameInfo.Size = new System.Drawing.Size(263, 317);
            this.gpGameInfo.TabIndex = 23;
            this.gpGameInfo.TabStop = false;
            this.gpGameInfo.Text = "Game Info";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbQuestionNumber);
            this.groupBox1.Controls.Add(this.lbTimeLeft);
            this.groupBox1.Controls.Add(this.lbRightAnswers);
            this.groupBox1.Controls.Add(this.lbWrongAnswers);
            this.groupBox1.Controls.Add(this.lbGameStatus);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(558, 398);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 317);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Info";
            // 
            // lbQuestionNumber
            // 
            this.lbQuestionNumber.AutoSize = true;
            this.lbQuestionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbQuestionNumber.Location = new System.Drawing.Point(6, 113);
            this.lbQuestionNumber.Name = "lbQuestionNumber";
            this.lbQuestionNumber.Size = new System.Drawing.Size(209, 29);
            this.lbQuestionNumber.TabIndex = 24;
            this.lbQuestionNumber.Text = "Question Number:";
            this.lbQuestionNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbTimeLeft
            // 
            this.lbTimeLeft.AutoSize = true;
            this.lbTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbTimeLeft.Location = new System.Drawing.Point(6, 272);
            this.lbTimeLeft.Name = "lbTimeLeft";
            this.lbTimeLeft.Size = new System.Drawing.Size(114, 29);
            this.lbTimeLeft.TabIndex = 23;
            this.lbTimeLeft.Text = "Time Left";
            this.lbTimeLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbRightAnswers
            // 
            this.lbRightAnswers.AutoSize = true;
            this.lbRightAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbRightAnswers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbRightAnswers.Location = new System.Drawing.Point(6, 166);
            this.lbRightAnswers.Name = "lbRightAnswers";
            this.lbRightAnswers.Size = new System.Drawing.Size(173, 29);
            this.lbRightAnswers.TabIndex = 22;
            this.lbRightAnswers.Text = "Right Answers:";
            this.lbRightAnswers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbWrongAnswers
            // 
            this.lbWrongAnswers.AutoSize = true;
            this.lbWrongAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbWrongAnswers.ForeColor = System.Drawing.Color.Maroon;
            this.lbWrongAnswers.Location = new System.Drawing.Point(6, 219);
            this.lbWrongAnswers.Name = "lbWrongAnswers";
            this.lbWrongAnswers.Size = new System.Drawing.Size(188, 29);
            this.lbWrongAnswers.TabIndex = 21;
            this.lbWrongAnswers.Text = "Wrong Answers:";
            this.lbWrongAnswers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbGameStatus
            // 
            this.lbGameStatus.AutoSize = true;
            this.lbGameStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbGameStatus.Location = new System.Drawing.Point(6, 39);
            this.lbGameStatus.Name = "lbGameStatus";
            this.lbGameStatus.Size = new System.Drawing.Size(150, 29);
            this.lbGameStatus.TabIndex = 20;
            this.lbGameStatus.Text = "Game Status";
            // 
            // GameInfoError
            // 
            this.GameInfoError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.GameInfoError.ContainerControl = this;
            // 
            // GameTimeTimer
            // 
            this.GameTimeTimer.Interval = 1000;
            this.GameTimeTimer.Tick += new System.EventHandler(this.GameTime_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1093, 729);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpGameInfo);
            this.Controls.Add(this.btPauseGame);
            this.Controls.Add(this.btEndGame);
            this.Controls.Add(this.gbQuestionsNumber);
            this.Controls.Add(this.gbTime);
            this.Controls.Add(this.gbQuestionStyle);
            this.Controls.Add(this.lbQoestion);
            this.Controls.Add(this.gbOpration);
            this.Controls.Add(this.gbLevel);
            this.Controls.Add(this.btStartGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Math Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLevel.ResumeLayout(false);
            this.gbOpration.ResumeLayout(false);
            this.gbOpration.PerformLayout();
            this.gbQuestionStyle.ResumeLayout(false);
            this.gbTime.ResumeLayout(false);
            this.gbTime.PerformLayout();
            this.gbQuestionsNumber.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuestionNumber)).EndInit();
            this.gpGameInfo.ResumeLayout(false);
            this.gpGameInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameInfoError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btStartGame;
        private System.Windows.Forms.RadioButton rdMix;
        private System.Windows.Forms.RadioButton rdHard;
        private System.Windows.Forms.GroupBox gbLevel;
        private System.Windows.Forms.GroupBox gbOpration;
        private System.Windows.Forms.Label lbQoestion;
        private System.Windows.Forms.RadioButton rdmultiplication;
        private System.Windows.Forms.RadioButton rdsubtraction;
        private System.Windows.Forms.RadioButton rdaddition;
        private System.Windows.Forms.RadioButton rddivision;
        private System.Windows.Forms.RadioButton rdcustom;
        private System.Windows.Forms.RadioButton rdEasy;
        private System.Windows.Forms.RadioButton rdMeduim;
        private System.Windows.Forms.GroupBox gbQuestionStyle;
        private System.Windows.Forms.RadioButton rdWriteAnswerStyle;
        private System.Windows.Forms.RadioButton rdOptionsStyle;
        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.Label lbSeconds;
        private System.Windows.Forms.MaskedTextBox mtbSeconds;
        private System.Windows.Forms.Label lbMinutes;
        private System.Windows.Forms.MaskedTextBox mtbMinutes;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbLevel;
        private System.Windows.Forms.Label lbQuestionsNumber;
        private System.Windows.Forms.Label lbOpration;
        private System.Windows.Forms.Label lbQuestionStyle;
        private System.Windows.Forms.GroupBox gbQuestionsNumber;
        private System.Windows.Forms.Button btEndGame;
        private System.Windows.Forms.Button btPauseGame;
        private System.Windows.Forms.GroupBox gpGameInfo;
        private System.Windows.Forms.NumericUpDown nudQuestionNumber;
        private System.Windows.Forms.CheckBox cbWithTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbGameStatus;
        private System.Windows.Forms.Label lbWrongAnswers;
        private System.Windows.Forms.Label lbTimeLeft;
        private System.Windows.Forms.Label lbRightAnswers;
        private System.Windows.Forms.Label lbQuestionNumber;
        private System.Windows.Forms.ErrorProvider GameInfoError;
        private System.Windows.Forms.Timer GameTimeTimer;
    }
}

