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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "Accounts.txt");
            string path1 = Path.Combine(Application.StartupPath, "AccountInfo.txt");
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
                if (textBox1.Text == accounts[i,0])
                {
                    result = true;
                }
            }
            if(result == true)
            {
                MessageBox.Show("This username is already in use. ");
            }
            else if(result == false)
            {
                string satir = $"\n{textBox1.Text};{textBox2.Text}";
                StreamWriter sw = new StreamWriter(path, true);
                sw.Write(satir);
                sw.Close();
                StreamWriter sw1 = new StreamWriter(path1, true);
                string satir1 = $"\n{textBox1.Text};0;{textBox3.Text}";
                sw1.Write(satir1);
                sw1.Close();
                MessageBox.Show("Hesabınız oluşturuldu.");
                this.Close();
            }
        }
    }
}
