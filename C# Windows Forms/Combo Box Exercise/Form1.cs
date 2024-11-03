using Combo_Box_Exercise.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combo_Box_Exercise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Boy")
            {
                pictureBox1.Image = Resources.Boy;
                label1.Text = "Boy";

            }
            if (comboBox1.Text == "Girl")
            {
                pictureBox1.Image = Resources.Girl;
                label1.Text = "Girl";

            }
            if (comboBox1.SelectedIndex == 0)
            {
                pictureBox1.Image = Resources.Books;
                label1.Text = "books";

            }
            if (comboBox1.Text == "Pen")
            {
                pictureBox1.Image = Resources.pincel;
                label1.Text = "Pen";

            }
        }
    }
}
