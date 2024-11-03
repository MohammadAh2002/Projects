using PictureBox_Exercise.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBox_Exercise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void UpdatePhoto()
        {

            if (rdBoy.Checked)
            {

                pictureBox1.Image = Resources.Boy;

                label1.Text = "Boy";

            }
            if (rdGirl.Checked)
            {

                pictureBox1.Image = Resources.Girl;
                label1.Text = "Girl";


            }
            if (rdBook.Checked)
            {

                pictureBox1.Image = Resources.Books;
                label1.Text = "Books";


            }
            if (rdPin.Checked)
            {

                pictureBox1.Image = Resources.pincel;
                label1.Text = "Pin";


            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            UpdatePhoto();

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePhoto();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePhoto();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePhoto();
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePhoto();
        }
    }
}
