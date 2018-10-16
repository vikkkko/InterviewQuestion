using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testPartner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testCode.Test01(this.pictureBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            testCode.Test02(this.treeView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            testCode.Test03(this.treeView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            testCode.Test04(this.pictureBox1);
        }
        TestCode testCode = new TestCode();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            testCode.update();
        }
    }
}
