namespace My_Math_Game
{
    partial class CustomLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomLevel));
            this.nudFrom = new System.Windows.Forms.NumericUpDown();
            this.lbFrom = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.lbTo = new System.Windows.Forms.Label();
            this.nudTo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTo)).BeginInit();
            this.SuspendLayout();
            // 
            // nudFrom
            // 
            this.nudFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFrom.Location = new System.Drawing.Point(38, 94);
            this.nudFrom.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudFrom.Name = "nudFrom";
            this.nudFrom.Size = new System.Drawing.Size(64, 34);
            this.nudFrom.TabIndex = 0;
            this.nudFrom.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFrom.Location = new System.Drawing.Point(38, 50);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(70, 29);
            this.lbFrom.TabIndex = 1;
            this.lbFrom.Text = "From";
            // 
            // btOk
            // 
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.Location = new System.Drawing.Point(48, 162);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(141, 56);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(146, 50);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(43, 29);
            this.lbTo.TabIndex = 3;
            this.lbTo.Text = "To";
            // 
            // nudTo
            // 
            this.nudTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTo.Location = new System.Drawing.Point(146, 94);
            this.nudTo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTo.Name = "nudTo";
            this.nudTo.Size = new System.Drawing.Size(64, 34);
            this.nudTo.TabIndex = 4;
            this.nudTo.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // CustomLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 273);
            this.Controls.Add(this.nudTo);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.nudFrom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Level";
            ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudFrom;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.NumericUpDown nudTo;
    }
}