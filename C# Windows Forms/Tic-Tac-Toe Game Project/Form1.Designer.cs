namespace Tic_Tac_Toe_Game_Project
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbWinner = new System.Windows.Forms.Label();
            this.lbTurn = new System.Windows.Forms.Label();
            this.btRestart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitel = new System.Windows.Forms.Label();
            this.bt02 = new System.Windows.Forms.Button();
            this.bt22 = new System.Windows.Forms.Button();
            this.bt21 = new System.Windows.Forms.Button();
            this.bt20 = new System.Windows.Forms.Button();
            this.bt12 = new System.Windows.Forms.Button();
            this.bt11 = new System.Windows.Forms.Button();
            this.bt10 = new System.Windows.Forms.Button();
            this.bt01 = new System.Windows.Forms.Button();
            this.bt00 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbWinner
            // 
            this.lbWinner.AutoSize = true;
            this.lbWinner.Font = new System.Drawing.Font("Goudy Stout", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWinner.ForeColor = System.Drawing.Color.Lime;
            this.lbWinner.Location = new System.Drawing.Point(60, 460);
            this.lbWinner.Name = "lbWinner";
            this.lbWinner.Size = new System.Drawing.Size(431, 47);
            this.lbWinner.TabIndex = 33;
            this.lbWinner.Text = "in Progress";
            // 
            // lbTurn
            // 
            this.lbTurn.AutoSize = true;
            this.lbTurn.Font = new System.Drawing.Font("Goudy Stout", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurn.ForeColor = System.Drawing.Color.White;
            this.lbTurn.Location = new System.Drawing.Point(85, 269);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Size = new System.Drawing.Size(375, 58);
            this.lbTurn.TabIndex = 32;
            this.lbTurn.Text = "Player1";
            // 
            // btRestart
            // 
            this.btRestart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btRestart.FlatAppearance.BorderSize = 3;
            this.btRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRestart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btRestart.Location = new System.Drawing.Point(81, 527);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(365, 164);
            this.btRestart.TabIndex = 31;
            this.btRestart.Text = "Restart Game";
            this.btRestart.UseVisualStyleBackColor = true;
            this.btRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Goudy Stout", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(101, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 58);
            this.label2.TabIndex = 30;
            this.label2.Text = "Winner";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Goudy Stout", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(131, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 58);
            this.label1.TabIndex = 29;
            this.label1.Text = "Turn";
            // 
            // lbTitel
            // 
            this.lbTitel.AutoSize = true;
            this.lbTitel.Font = new System.Drawing.Font("Goudy Stout", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.ForeColor = System.Drawing.SystemColors.Window;
            this.lbTitel.Location = new System.Drawing.Point(483, 5);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(761, 58);
            this.lbTitel.TabIndex = 27;
            this.lbTitel.Text = "Tic-Tac-Toe Game";
            // 
            // bt02
            // 
            this.bt02.BackColor = System.Drawing.Color.Transparent;
            this.bt02.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt02.Image = ((System.Drawing.Image)(resources.GetObject("bt02.Image")));
            this.bt02.Location = new System.Drawing.Point(1147, 153);
            this.bt02.Name = "bt02";
            this.bt02.Size = new System.Drawing.Size(172, 130);
            this.bt02.TabIndex = 42;
            this.bt02.Tag = "?";
            this.bt02.UseVisualStyleBackColor = false;
            this.bt02.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bt22
            // 
            this.bt22.BackColor = System.Drawing.Color.Transparent;
            this.bt22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt22.Image = ((System.Drawing.Image)(resources.GetObject("bt22.Image")));
            this.bt22.Location = new System.Drawing.Point(1147, 579);
            this.bt22.Name = "bt22";
            this.bt22.Size = new System.Drawing.Size(172, 130);
            this.bt22.TabIndex = 41;
            this.bt22.Tag = "?";
            this.bt22.UseVisualStyleBackColor = false;
            this.bt22.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bt21
            // 
            this.bt21.BackColor = System.Drawing.Color.Transparent;
            this.bt21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt21.Image = ((System.Drawing.Image)(resources.GetObject("bt21.Image")));
            this.bt21.Location = new System.Drawing.Point(880, 579);
            this.bt21.Name = "bt21";
            this.bt21.Size = new System.Drawing.Size(172, 130);
            this.bt21.TabIndex = 40;
            this.bt21.Tag = "?";
            this.bt21.UseVisualStyleBackColor = false;
            this.bt21.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bt20
            // 
            this.bt20.BackColor = System.Drawing.Color.Transparent;
            this.bt20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt20.Image = ((System.Drawing.Image)(resources.GetObject("bt20.Image")));
            this.bt20.Location = new System.Drawing.Point(617, 579);
            this.bt20.Name = "bt20";
            this.bt20.Size = new System.Drawing.Size(172, 130);
            this.bt20.TabIndex = 39;
            this.bt20.Tag = "?";
            this.bt20.UseVisualStyleBackColor = false;
            this.bt20.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bt12
            // 
            this.bt12.BackColor = System.Drawing.Color.Transparent;
            this.bt12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt12.Image = ((System.Drawing.Image)(resources.GetObject("bt12.Image")));
            this.bt12.Location = new System.Drawing.Point(1147, 377);
            this.bt12.Name = "bt12";
            this.bt12.Size = new System.Drawing.Size(172, 130);
            this.bt12.TabIndex = 38;
            this.bt12.Tag = "?";
            this.bt12.UseVisualStyleBackColor = false;
            this.bt12.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bt11
            // 
            this.bt11.BackColor = System.Drawing.Color.Transparent;
            this.bt11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt11.Image = ((System.Drawing.Image)(resources.GetObject("bt11.Image")));
            this.bt11.Location = new System.Drawing.Point(880, 377);
            this.bt11.Name = "bt11";
            this.bt11.Size = new System.Drawing.Size(172, 130);
            this.bt11.TabIndex = 37;
            this.bt11.Tag = "?";
            this.bt11.UseVisualStyleBackColor = false;
            this.bt11.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bt10
            // 
            this.bt10.BackColor = System.Drawing.Color.Transparent;
            this.bt10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt10.Image = ((System.Drawing.Image)(resources.GetObject("bt10.Image")));
            this.bt10.Location = new System.Drawing.Point(617, 377);
            this.bt10.Name = "bt10";
            this.bt10.Size = new System.Drawing.Size(172, 130);
            this.bt10.TabIndex = 36;
            this.bt10.Tag = "?";
            this.bt10.UseVisualStyleBackColor = false;
            this.bt10.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bt01
            // 
            this.bt01.BackColor = System.Drawing.Color.Transparent;
            this.bt01.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt01.Image = ((System.Drawing.Image)(resources.GetObject("bt01.Image")));
            this.bt01.Location = new System.Drawing.Point(880, 153);
            this.bt01.Name = "bt01";
            this.bt01.Size = new System.Drawing.Size(172, 130);
            this.bt01.TabIndex = 35;
            this.bt01.Tag = "?";
            this.bt01.UseVisualStyleBackColor = false;
            this.bt01.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bt00
            // 
            this.bt00.BackColor = System.Drawing.Color.Transparent;
            this.bt00.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt00.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt00.Image = global::Tic_Tac_Toe_Game_Project.Properties.Resources.question_mark_96;
            this.bt00.Location = new System.Drawing.Point(617, 153);
            this.bt00.Name = "bt00";
            this.bt00.Size = new System.Drawing.Size(172, 130);
            this.bt00.TabIndex = 34;
            this.bt00.Tag = "?";
            this.bt00.UseVisualStyleBackColor = false;
            this.bt00.Click += new System.EventHandler(this.ButtonClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1483, 826);
            this.Controls.Add(this.bt02);
            this.Controls.Add(this.bt22);
            this.Controls.Add(this.bt21);
            this.Controls.Add(this.bt20);
            this.Controls.Add(this.bt12);
            this.Controls.Add(this.bt11);
            this.Controls.Add(this.bt10);
            this.Controls.Add(this.bt01);
            this.Controls.Add(this.bt00);
            this.Controls.Add(this.lbWinner);
            this.Controls.Add(this.lbTurn);
            this.Controls.Add(this.btRestart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbTitel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt22;
        private System.Windows.Forms.Button bt21;
        private System.Windows.Forms.Button bt20;
        private System.Windows.Forms.Button bt12;
        private System.Windows.Forms.Button bt11;
        private System.Windows.Forms.Button bt10;
        private System.Windows.Forms.Button bt01;
        private System.Windows.Forms.Button bt00;
        private System.Windows.Forms.Label lbWinner;
        private System.Windows.Forms.Label lbTurn;
        private System.Windows.Forms.Button btRestart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.Button bt02;
    }
}

