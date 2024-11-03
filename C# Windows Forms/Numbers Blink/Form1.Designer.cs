namespace Numbers_Blink
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
            this.BtHide = new System.Windows.Forms.Button();
            this.cbNumberDigits = new System.Windows.Forms.ComboBox();
            this.AnswerPanel = new System.Windows.Forms.Panel();
            this.lbAnswer = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.lbQustion = new System.Windows.Forms.Label();
            this.QustionPanel = new System.Windows.Forms.Panel();
            this.lbDigits = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.btDone = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.lbTimer = new System.Windows.Forms.Label();
            this.nudQustionsNumber = new System.Windows.Forms.NumericUpDown();
            this.lbQustionsNumber = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AnswerPanel.SuspendLayout();
            this.QustionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQustionsNumber)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtHide
            // 
            this.BtHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtHide.Location = new System.Drawing.Point(35, 471);
            this.BtHide.Name = "BtHide";
            this.BtHide.Size = new System.Drawing.Size(130, 73);
            this.BtHide.TabIndex = 10;
            this.BtHide.Text = "Hide";
            this.BtHide.UseVisualStyleBackColor = true;
            this.BtHide.Click += new System.EventHandler(this.BtHide_Click);
            // 
            // cbNumberDigits
            // 
            this.cbNumberDigits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumberDigits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNumberDigits.FormattingEnabled = true;
            this.cbNumberDigits.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbNumberDigits.Location = new System.Drawing.Point(400, 52);
            this.cbNumberDigits.Name = "cbNumberDigits";
            this.cbNumberDigits.Size = new System.Drawing.Size(121, 33);
            this.cbNumberDigits.TabIndex = 2;
            this.cbNumberDigits.SelectedIndexChanged += new System.EventHandler(this.cbNumberDigits_SelectedIndexChanged);
            // 
            // AnswerPanel
            // 
            this.AnswerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnswerPanel.Controls.Add(this.lbAnswer);
            this.AnswerPanel.Location = new System.Drawing.Point(101, 291);
            this.AnswerPanel.Name = "AnswerPanel";
            this.AnswerPanel.Size = new System.Drawing.Size(350, 120);
            this.AnswerPanel.TabIndex = 3;
            // 
            // lbAnswer
            // 
            this.lbAnswer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbAnswer.BackColor = System.Drawing.SystemColors.Control;
            this.lbAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnswer.Location = new System.Drawing.Point(40, 21);
            this.lbAnswer.Name = "lbAnswer";
            this.lbAnswer.Size = new System.Drawing.Size(273, 80);
            this.lbAnswer.TabIndex = 2;
            this.lbAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // lbQustion
            // 
            this.lbQustion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbQustion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQustion.Location = new System.Drawing.Point(40, 15);
            this.lbQustion.Name = "lbQustion";
            this.lbQustion.Size = new System.Drawing.Size(273, 80);
            this.lbQustion.TabIndex = 1;
            this.lbQustion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QustionPanel
            // 
            this.QustionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QustionPanel.Controls.Add(this.lbQustion);
            this.QustionPanel.Location = new System.Drawing.Point(101, 134);
            this.QustionPanel.Name = "QustionPanel";
            this.QustionPanel.Size = new System.Drawing.Size(350, 120);
            this.QustionPanel.TabIndex = 4;
            // 
            // lbDigits
            // 
            this.lbDigits.AutoSize = true;
            this.lbDigits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDigits.Location = new System.Drawing.Point(383, 18);
            this.lbDigits.Name = "lbDigits";
            this.lbDigits.Size = new System.Drawing.Size(155, 25);
            this.lbDigits.TabIndex = 2;
            this.lbDigits.Text = "Number of Digits";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(3, 18);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(159, 25);
            this.lbTime.TabIndex = 2;
            this.lbTime.Text = "Time Left to Hide";
            // 
            // btDone
            // 
            this.btDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDone.Location = new System.Drawing.Point(201, 471);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(130, 73);
            this.btDone.TabIndex = 5;
            this.btDone.Text = "Done";
            this.btDone.UseVisualStyleBackColor = true;
            this.btDone.Click += new System.EventHandler(this.btDone_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStart.Location = new System.Drawing.Point(367, 471);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(130, 73);
            this.btStart.TabIndex = 6;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer.Location = new System.Drawing.Point(36, 55);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(93, 25);
            this.lbTimer.TabIndex = 7;
            this.lbTimer.Text = "Time Out";
            this.lbTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudQustionsNumber
            // 
            this.nudQustionsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQustionsNumber.Location = new System.Drawing.Point(190, 53);
            this.nudQustionsNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudQustionsNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQustionsNumber.Name = "nudQustionsNumber";
            this.nudQustionsNumber.Size = new System.Drawing.Size(159, 30);
            this.nudQustionsNumber.TabIndex = 2;
            this.nudQustionsNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudQustionsNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQustionsNumber.ValueChanged += new System.EventHandler(this.nudQustionsNumber_ValueChanged);
            // 
            // lbQustionsNumber
            // 
            this.lbQustionsNumber.AutoSize = true;
            this.lbQustionsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQustionsNumber.Location = new System.Drawing.Point(187, 18);
            this.lbQustionsNumber.Name = "lbQustionsNumber";
            this.lbQustionsNumber.Size = new System.Drawing.Size(164, 25);
            this.lbQustionsNumber.TabIndex = 0;
            this.lbQustionsNumber.Text = "Qustions Number";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nudQustionsNumber);
            this.panel3.Controls.Add(this.lbQustionsNumber);
            this.panel3.Controls.Add(this.lbDigits);
            this.panel3.Controls.Add(this.lbTime);
            this.panel3.Controls.Add(this.lbTimer);
            this.panel3.Controls.Add(this.cbNumberDigits);
            this.panel3.Location = new System.Drawing.Point(3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(547, 97);
            this.panel3.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 675);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btDone);
            this.Controls.Add(this.QustionPanel);
            this.Controls.Add(this.AnswerPanel);
            this.Controls.Add(this.BtHide);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numbers Blink Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.AnswerPanel.ResumeLayout(false);
            this.QustionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQustionsNumber)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtHide;
        private System.Windows.Forms.ComboBox cbNumberDigits;
        private System.Windows.Forms.Panel AnswerPanel;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label lbQustion;
        private System.Windows.Forms.Panel QustionPanel;
        private System.Windows.Forms.Label lbDigits;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button btDone;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.NumericUpDown nudQustionsNumber;
        private System.Windows.Forms.Label lbQustionsNumber;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbAnswer;
    }
}

