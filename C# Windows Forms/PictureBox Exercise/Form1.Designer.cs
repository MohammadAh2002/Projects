namespace PictureBox_Exercise
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
            this.rdBoy = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdGirl = new System.Windows.Forms.RadioButton();
            this.rdBook = new System.Windows.Forms.RadioButton();
            this.rdPin = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdBoy
            // 
            this.rdBoy.AutoSize = true;
            this.rdBoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBoy.Location = new System.Drawing.Point(256, 465);
            this.rdBoy.Name = "rdBoy";
            this.rdBoy.Size = new System.Drawing.Size(59, 24);
            this.rdBoy.TabIndex = 0;
            this.rdBoy.Text = "Boy";
            this.rdBoy.UseVisualStyleBackColor = true;
            this.rdBoy.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(203, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(506, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Goudy Stout", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(305, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 68);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdGirl
            // 
            this.rdGirl.AutoSize = true;
            this.rdGirl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdGirl.Location = new System.Drawing.Point(359, 465);
            this.rdGirl.Name = "rdGirl";
            this.rdGirl.Size = new System.Drawing.Size(57, 24);
            this.rdGirl.TabIndex = 3;
            this.rdGirl.TabStop = true;
            this.rdGirl.Text = "Girl";
            this.rdGirl.UseVisualStyleBackColor = true;
            this.rdGirl.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdBook
            // 
            this.rdBook.AutoSize = true;
            this.rdBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBook.Location = new System.Drawing.Point(460, 465);
            this.rdBook.Name = "rdBook";
            this.rdBook.Size = new System.Drawing.Size(77, 24);
            this.rdBook.TabIndex = 4;
            this.rdBook.TabStop = true;
            this.rdBook.Text = "Books";
            this.rdBook.UseVisualStyleBackColor = true;
            this.rdBook.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rdPin
            // 
            this.rdPin.AutoSize = true;
            this.rdPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPin.Location = new System.Drawing.Point(581, 465);
            this.rdPin.Name = "rdPin";
            this.rdPin.Size = new System.Drawing.Size(54, 24);
            this.rdPin.TabIndex = 5;
            this.rdPin.TabStop = true;
            this.rdPin.Text = "Pin";
            this.rdPin.UseVisualStyleBackColor = true;
            this.rdPin.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 550);
            this.Controls.Add(this.rdPin);
            this.Controls.Add(this.rdBook);
            this.Controls.Add(this.rdGirl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rdBoy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdBoy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdGirl;
        private System.Windows.Forms.RadioButton rdBook;
        private System.Windows.Forms.RadioButton rdPin;
    }
}

