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
    public partial class AddMoney : Form
    {
        string[,] accountinfos;
        public string name;
        int balance;
        string number;
        string[] lines;
        List<string> infos = new List<string>();
        int j = 0;
        public AddMoney()
        {
            InitializeComponent();
        }

        private void AddMoney_Load(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "AccountInfo.txt");
            lines = File.ReadAllLines(path);
            accountinfos = new string[lines.Length,3];
            for (int i = 0; i < accountinfos.GetLength(0); i++)
            {
                string[] split = lines[i].Split(';');
                accountinfos[i, 0] = split[0]; // Username
                accountinfos[i, 1] = split[1]; // Balance
                accountinfos[i, 2] = split[2]; // number
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "AccountInfo.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (accountinfos[i, 0] == name)
                {
                    balance = int.Parse(accountinfos[i, 1]);
                    number = accountinfos[i, 2];
                    break;
                }
                j++;
            }
            int add = Convert.ToInt32(numericUpDown1.Value);
            balance += add;
            string line = $"{name};{balance};{number}";
            foreach (var item in lines)
            {
                infos.Add(item);
            }
            infos[j] = line;
            StreamWriter streamWriter1 = new StreamWriter(path);
            streamWriter1.Write("");
            streamWriter1.Close();
            StreamWriter streamWriter = new StreamWriter(path,true);
            foreach (var info in infos)
            {
                streamWriter.WriteLine(info);
            }
            streamWriter.Close();
            this.Close();
        }
    }
}
