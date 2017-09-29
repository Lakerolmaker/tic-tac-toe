using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace tic_tac_toe
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();


            radioButton1.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string type = "";

            if (radioButton1.Checked)
                type = "paper";
            else
                type = "board";




            this.Hide();
            var frm = new Form1(type);
            frm.Closed += (s, args) => this.Close();

            frm.Text =  type + " Edition";

            frm.Show();


        }

        private void settings_Load(object sender, EventArgs e)
        {

        }

      
    }
}
