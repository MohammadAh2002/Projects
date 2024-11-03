using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Math_Game
{
    public partial class CustomLevel : Form
    {
        public CustomLevel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            Form1.CustomLevel.to = (int)nudTo.Value;
            ValidateRange();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            Form1.CustomLevel.from = (int)nudFrom.Value;
            ValidateRange();
        }

        void ValidateRange()
        {

            if(Form1.CustomLevel.to < Form1.CustomLevel.from)
            {

                Form1.CustomLevel.to = Form1.CustomLevel.from;

            }


        }

    }
}
