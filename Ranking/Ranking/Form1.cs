﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*for (int i = 0; i < tab.Length; i++)
            {
                this.listView1.Items[i] = tab[i];
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Znajomi", 250);
            ImageList list = new ImageList();
            list.ImageSize = new Size(30,30);
            // dodanie obrazków z bazy danych
            listView1.SmallImageList = list;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
