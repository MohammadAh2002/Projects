using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tree_View_Exercise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum enGender {Girl, Boy};

        enGender GirlorBoy()
        {

            if(comboBox1.SelectedItem.ToString() == "Girl")
                return enGender.Girl;
            else
                return enGender.Boy;
        }
        bool CheckVailedInput()
        {

            if (comboBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("enter the gender & the name","problem taking data",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            return true;

        }

        private void AddParent_Click(object sender, EventArgs e)
        {
            TreeNode ParentNode = new TreeNode();

            if (CheckVailedInput())
            {
                ParentNode.Text = textBox1.Text;
               
                if(GirlorBoy() == enGender.Girl)
                {

                    ParentNode.ImageKey = "Girl";
                    ParentNode.SelectedImageKey = "Girl";

                }
                else
                {
                    ParentNode.ImageKey = "Boy";
                    ParentNode.SelectedImageKey = "Boy";
                }

            }
            else
            {

                return;

            }

            treeView1.Nodes.Add(ParentNode);
            comboBox1.Text = "";
            textBox1.Text = "";

        }

        private void AddChild_Click(object sender, EventArgs e)
        {

            TreeNode ChildNode = new TreeNode();

            if (CheckVailedInput())
            {

                ChildNode.Text = textBox1.Text;

                if (GirlorBoy() == enGender.Girl)
                {

                    ChildNode.ImageKey = "Girl";
                    ChildNode.SelectedImageKey = "Girl";

                }
                else
                {

                    ChildNode.ImageKey = "Boy";
                    ChildNode.SelectedImageKey = "Boy";
                        
                }


            }
            else
            {

                return;

            }

            treeView1.SelectedNode.Nodes.Add(ChildNode);
            comboBox1.Text = "";
            textBox1.Text = "";

        }

        private void DeleteNode_Click(object sender, EventArgs e)
        {

            treeView1.SelectedNode.Remove();
        }

        private void EditNode_Click(object sender, EventArgs e)
        {

            if(CheckVailedInput())
            {

                treeView1.SelectedNode.Text = textBox1.Text;

                if (GirlorBoy() == enGender.Girl)
                {

                    treeView1.SelectedNode.ImageKey = "Girl";
                    treeView1.SelectedNode.SelectedImageKey = "Girl";

                }
                else
                {

                    treeView1.SelectedNode.ImageKey = "Boy";
                    treeView1.SelectedNode.SelectedImageKey = "Boy";

                }

            }
            else
            {

                return;

            }

            comboBox1.Text = "";
            textBox1.Text = "";

        }
    }
}
