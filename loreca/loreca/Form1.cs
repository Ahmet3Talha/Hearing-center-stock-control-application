﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loreca
{
    public partial class Form1 : Form
    {
        //      Colors     
        //      background   #bc7572
        //      menüstrip 159; 90; 116
        //      menüstrip font snow

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void stokEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2=new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void stokMenüsüToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
