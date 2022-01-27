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
namespace Banka_uygulaması
{
    public partial class Form1 : Form
    {
        string username;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "Accounts.txt");
            string[] lines = File.ReadAllLines(path);
            string[,] accounts = new string[lines.Length, 2];
            for (int i = 0; i < accounts.GetLength(0); i++)
            {
                string[] split = lines[i].Split(';');
                accounts[i, 0] = split[0]; // Username
                accounts[i, 1] = split[1]; // Password
            }
            bool result = false;
            for (int i = 0; i < accounts.GetLength(0); i++)
            {
                if (textBox1.Text == accounts[i,0] && textBox2.Text == accounts[i,1])
                {
                    username = accounts[i,0];
                    result = true;
                    break;
                }
            }
            if (!result == true)
            {
                MessageBox.Show("We couldn't find your account...");
                label3.Text = "*";
                label4.Text = "*";
            }
            else
            {
                AccountMenu menu = new AccountMenu();
                menu.username = username;
                menu.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register regfrm = new Register();
            regfrm.Show();
        }
    }
}
