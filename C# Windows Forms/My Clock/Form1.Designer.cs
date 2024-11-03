namespace My_Clock
{
    partial class ClockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClockForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.nudHours = new System.Windows.Forms.NumericUpDown();
            this.btAlarm = new System.Windows.Forms.Button();
            this.nudMinutes = new System.Windows.Forms.NumericUpDown();
            this.nudSeconds = new System.Windows.Forms.NumericUpDown();
            this.lbHours = new System.Windows.Forms.Label();
            this.lbMinutes = new System.Windows.Forms.Label();
            this.lbSeconds = new System.Windows.Forms.Label();
            this.lbAlarmAt = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.pAlarm = new System.Windows.Forms.Panel();
            this.pPicked = new System.Windows.Forms.Panel();
            this.rdAlarm = new System.Windows.Forms.RadioButton();
            this.rdStopWatch = new System.Windows.Forms.RadioButton();
            this.rdTimer = new System.Windows.Forms.RadioButton();
            this.AlarmTick = new System.Windows.Forms.Timer(this.components);
            this.bCancelAlarm = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.bResetTimer = new System.Windows.Forms.Button();
            this.BStartTimer = new System.Windows.Forms.Button();
            this.TimerTick = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.StopWatchTick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeconds)).BeginInit();
            this.pAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "alarm.png");
            this.imageList1.Images.SetKeyName(1, "stop watch.jpg");
            this.imageList1.Images.SetKeyName(2, "Timer.png");
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 1000;
            this.MainTimer.Tick += new System.EventHandler(this.CurrentTime);
            // 
            // nudHours
            // 
            this.nudHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHours.Location = new System.Drawing.Point(64, 353);
            this.nudHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudHours.Name = "nudHours";
            this.nudHours.Size = new System.Drawing.Size(90, 38);
            this.nudHours.TabIndex = 4;
            this.nudHours.Visible = false;
            this.nudHours.ValueChanged += new System.EventHandler(this.nudHours_ValueChanged);
            // 
            // btAlarm
            // 
            this.btAlarm.Location = new System.Drawing.Point(64, 424);
            this.btAlarm.Name = "btAlarm";
            this.btAlarm.Size = new System.Drawing.Size(165, 109);
            this.btAlarm.TabIndex = 5;
            this.btAlarm.Text = "Set Alarm";
            this.btAlarm.UseVisualStyleBackColor = true;
            this.btAlarm.Click += new System.EventHandler(this.SetAlarm);
            // 
            // nudMinutes
            // 
            this.nudMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinutes.Location = new System.Drawing.Point(206, 353);
            this.nudMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMinutes.Name = "nudMinutes";
            this.nudMinutes.Size = new System.Drawing.Size(90, 38);
            this.nudMinutes.TabIndex = 6;
            this.nudMinutes.Visible = false;
            this.nudMinutes.ValueChanged += new System.EventHandler(this.nudMinutes_ValueChanged);
            // 
            // nudSeconds
            // 
            this.nudSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSeconds.Location = new System.Drawing.Point(363, 353);
            this.nudSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudSeconds.Name = "nudSeconds";
            this.nudSeconds.Size = new System.Drawing.Size(90, 38);
            this.nudSeconds.TabIndex = 7;
            this.nudSeconds.Visible = false;
            this.nudSeconds.ValueChanged += new System.EventHandler(this.nudSeconds_ValueChanged);
            // 
            // lbHours
            // 
            this.lbHours.AutoSize = true;
            this.lbHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbHours.Location = new System.Drawing.Point(66, 302);
            this.lbHours.Name = "lbHours";
            this.lbHours.Size = new System.Drawing.Size(87, 31);
            this.lbHours.TabIndex = 8;
            this.lbHours.Text = "Hours";
            this.lbHours.Visible = false;
            // 
            // lbMinutes
            // 
            this.lbMinutes.AutoSize = true;
            this.lbMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinutes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbMinutes.Location = new System.Drawing.Point(197, 302);
            this.lbMinutes.Name = "lbMinutes";
            this.lbMinutes.Size = new System.Drawing.Size(109, 31);
            this.lbMinutes.TabIndex = 9;
            this.lbMinutes.Text = "minutes";
            this.lbMinutes.Visible = false;
            // 
            // lbSeconds
            // 
            this.lbSeconds.AutoSize = true;
            this.lbSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeconds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbSeconds.Location = new System.Drawing.Point(350, 302);
            this.lbSeconds.Name = "lbSeconds";
            this.lbSeconds.Size = new System.Drawing.Size(116, 31);
            this.lbSeconds.TabIndex = 10;
            this.lbSeconds.Text = "seconds";
            this.lbSeconds.Visible = false;
            // 
            // lbAlarmAt
            // 
            this.lbAlarmAt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbAlarmAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlarmAt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbAlarmAt.Location = new System.Drawing.Point(35, 192);
            this.lbAlarmAt.Name = "lbAlarmAt";
            this.lbAlarmAt.Size = new System.Drawing.Size(508, 85);
            this.lbAlarmAt.TabIndex = 2;
            this.lbAlarmAt.Text = "Alarm At: ";
            this.lbAlarmAt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAlarmAt.Visible = false;
            // 
            // lbTime
            // 
            this.lbTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbTime.Location = new System.Drawing.Point(35, 12);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(508, 85);
            this.lbTime.TabIndex = 0;
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTime.Visible = false;
            // 
            // pAlarm
            // 
            this.pAlarm.Controls.Add(this.lbTime);
            this.pAlarm.Location = new System.Drawing.Point(1, 63);
            this.pAlarm.Name = "pAlarm";
            this.pAlarm.Size = new System.Drawing.Size(578, 115);
            this.pAlarm.TabIndex = 3;
            // 
            // pPicked
            // 
            this.pPicked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pPicked.Location = new System.Drawing.Point(1, 0);
            this.pPicked.Name = "pPicked";
            this.pPicked.Size = new System.Drawing.Size(189, 5);
            this.pPicked.TabIndex = 16;
            // 
            // rdAlarm
            // 
            this.rdAlarm.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdAlarm.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAlarm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rdAlarm.Image = ((System.Drawing.Image)(resources.GetObject("rdAlarm.Image")));
            this.rdAlarm.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdAlarm.Location = new System.Drawing.Point(1, 0);
            this.rdAlarm.Name = "rdAlarm";
            this.rdAlarm.Size = new System.Drawing.Size(196, 64);
            this.rdAlarm.TabIndex = 12;
            this.rdAlarm.Text = "Alarm";
            this.rdAlarm.UseVisualStyleBackColor = true;
            this.rdAlarm.CheckedChanged += new System.EventHandler(this.rdAlarm_CheckedChanged);
            // 
            // rdStopWatch
            // 
            this.rdStopWatch.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdStopWatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdStopWatch.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStopWatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rdStopWatch.Image = ((System.Drawing.Image)(resources.GetObject("rdStopWatch.Image")));
            this.rdStopWatch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdStopWatch.Location = new System.Drawing.Point(383, 0);
            this.rdStopWatch.Name = "rdStopWatch";
            this.rdStopWatch.Size = new System.Drawing.Size(196, 64);
            this.rdStopWatch.TabIndex = 13;
            this.rdStopWatch.Text = "Stop Watch";
            this.rdStopWatch.UseVisualStyleBackColor = true;
            this.rdStopWatch.CheckedChanged += new System.EventHandler(this.rdStopWatch_CheckedChanged);
            // 
            // rdTimer
            // 
            this.rdTimer.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdTimer.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rdTimer.Image = ((System.Drawing.Image)(resources.GetObject("rdTimer.Image")));
            this.rdTimer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdTimer.Location = new System.Drawing.Point(191, 0);
            this.rdTimer.Name = "rdTimer";
            this.rdTimer.Size = new System.Drawing.Size(196, 64);
            this.rdTimer.TabIndex = 14;
            this.rdTimer.Text = "Timer";
            this.rdTimer.UseVisualStyleBackColor = true;
            this.rdTimer.CheckedChanged += new System.EventHandler(this.rdTimer_CheckedChanged);
            // 
            // AlarmTick
            // 
            this.AlarmTick.Enabled = true;
            this.AlarmTick.Interval = 1000;
            this.AlarmTick.Tick += new System.EventHandler(this.IsAlarmTime);
            // 
            // bCancelAlarm
            // 
            this.bCancelAlarm.Location = new System.Drawing.Point(288, 424);
            this.bCancelAlarm.Name = "bCancelAlarm";
            this.bCancelAlarm.Size = new System.Drawing.Size(165, 109);
            this.bCancelAlarm.TabIndex = 15;
            this.bCancelAlarm.Text = "Cancel Alarm";
            this.bCancelAlarm.UseVisualStyleBackColor = true;
            this.bCancelAlarm.Click += new System.EventHandler(this.CancelAlarm);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // bResetTimer
            // 
            this.bResetTimer.Location = new System.Drawing.Point(64, 424);
            this.bResetTimer.Name = "bResetTimer";
            this.bResetTimer.Size = new System.Drawing.Size(165, 109);
            this.bResetTimer.TabIndex = 1;
            this.bResetTimer.Text = "Reset Timer";
            this.bResetTimer.UseVisualStyleBackColor = true;
            this.bResetTimer.Visible = false;
            this.bResetTimer.Click += new System.EventHandler(this.ResetTimer);
            // 
            // BStartTimer
            // 
            this.BStartTimer.Location = new System.Drawing.Point(288, 424);
            this.BStartTimer.Name = "BStartTimer";
            this.BStartTimer.Size = new System.Drawing.Size(165, 109);
            this.BStartTimer.TabIndex = 17;
            this.BStartTimer.Text = "start Timer";
            this.BStartTimer.UseVisualStyleBackColor = true;
            this.BStartTimer.Visible = false;
            this.BStartTimer.Click += new System.EventHandler(this.StartTimer);
            // 
            // TimerTick
            // 
            this.TimerTick.Interval = 1000;
            this.TimerTick.Tick += new System.EventHandler(this.IsTimerFinshed);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 230);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PauseStopWatch);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(327, 230);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(139, 117);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.StartStopWatch);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(191, 372);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(139, 117);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.ResetStopWatch);
            // 
            // StopWatchTick
            // 
            this.StopWatchTick.Interval = 1000;
            this.StopWatchTick.Tick += new System.EventHandler(this.StopWatchRunning);
            // 
            // ClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(579, 545);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BStartTimer);
            this.Controls.Add(this.bResetTimer);
            this.Controls.Add(this.bCancelAlarm);
            this.Controls.Add(this.pPicked);
            this.Controls.Add(this.rdTimer);
            this.Controls.Add(this.rdStopWatch);
            this.Controls.Add(this.rdAlarm);
            this.Controls.Add(this.lbAlarmAt);
            this.Controls.Add(this.lbSeconds);
            this.Controls.Add(this.lbMinutes);
            this.Controls.Add(this.lbHours);
            this.Controls.Add(this.nudSeconds);
            this.Controls.Add(this.nudMinutes);
            this.Controls.Add(this.btAlarm);
            this.Controls.Add(this.nudHours);
            this.Controls.Add(this.pAlarm);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClockForm";
            this.Text = "Clock";
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeconds)).EndInit();
            this.pAlarm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.NumericUpDown nudHours;
        private System.Windows.Forms.Button btAlarm;
        private System.Windows.Forms.NumericUpDown nudMinutes;
        private System.Windows.Forms.NumericUpDown nudSeconds;
        private System.Windows.Forms.Label lbHours;
        private System.Windows.Forms.Label lbMinutes;
        private System.Windows.Forms.Label lbSeconds;
        private System.Windows.Forms.Label lbAlarmAt;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Panel pAlarm;
        private System.Windows.Forms.RadioButton rdAlarm;
        private System.Windows.Forms.RadioButton rdStopWatch;
        private System.Windows.Forms.RadioButton rdTimer;
        private System.Windows.Forms.Timer AlarmTick;
        private System.Windows.Forms.Button bCancelAlarm;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel pPicked;
        private System.Windows.Forms.Button bResetTimer;
        private System.Windows.Forms.Button BStartTimer;
        private System.Windows.Forms.Timer TimerTick;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer StopWatchTick;
    }
}

