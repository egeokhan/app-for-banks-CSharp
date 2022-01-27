using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banka_uygulaması
{
    public partial class AccountMenu : Form
    {
        public string username;
        int meter = 0;
        public AccountMenu()
        {
            InitializeComponent();
        }

        private void AccountMenu_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            string path = Path.Combine(Application.StartupPath, "AccountInfo.txt");
            string[] lines = File.ReadAllLines(path);
            string[,] accountinfos = new string[lines.Length, 3];
            for (int i = 0; i < accountinfos.GetLength(0); i++)
            {
                string[] split = lines[i].Split(';');
                accountinfos[i, 0] = split[0]; // Username
                accountinfos[i, 1] = split[1]; // Balance
                accountinfos[i, 2] = split[2]; // Number
            }
            for (int i = 0; i < accountinfos.GetLength(0); i++)
            {
                if (accountinfos[i, 0] == username)
                {
                    lblname.Text = accountinfos[i, 0];
                    lblBalance.Text = accountinfos[i, 1];
                    lblNumber.Text = accountinfos[i, 2];
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            meter++;
            if (meter % 5 == 0)
            {
                string path = Path.Combine(Application.StartupPath, "AccountInfo.txt");
                string[] lines = File.ReadAllLines(path);
                string[,] accountinfos = new string[lines.Length, 3];
                for (int i = 0; i < accountinfos.GetLength(0); i++)
                {
                    string[] split = lines[i].Split(';');
                    accountinfos[i, 0] = split[0]; // Username
                    accountinfos[i, 1] = split[1]; // Balance
                    accountinfos[i, 2] = split[2]; // Number
                }
                Form1 frm = new Form1();
                for (int i = 0; i < accountinfos.GetLength(0); i++)
                {
                    if (accountinfos[i, 0] == username)
                    {
                        lblname.Text = accountinfos[i, 0];
                        lblBalance.Text = accountinfos[i, 1];
                        lblNumber.Text = accountinfos[i, 2];
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var addmoney = new AddMoney();
            addmoney.name = lblname.Text;
            addmoney.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var withdraw = new Withdraw();
            withdraw.name = lblname.Text;
            withdraw.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
