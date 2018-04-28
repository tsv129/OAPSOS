using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAPSOS_lab
{
    public partial class Form1 : Form
    {
        int X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, bn, sn;
        string bigN, smlN, tmpN;

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int c=0; c < 4; c++)
                for (int r=0; r < 5; r++)
                {
                    dataGridView1[c, r].Value = String.Empty;
                }

            X1 = dateTimePicker1.Value.Day;
            X2 = (X1 % 10);
            X1 = (X1 / 10);
            X3 = dateTimePicker1.Value.Month;
            X4 = (X3 % 10);
            X3 = (X3 / 10);
            X5 = dateTimePicker1.Value.Year;
            X6 = (X5 % 1000) / 100;
            X7 = (X5 % 100) / 10;
            X8 = (X5 % 10);
            X5 = (X5 / 1000);
            X9 = X1 + X2 + X3 + X4 + X5 + X6 + X7 + X8;
            X10 = (X9 % 10) + (X9 / 10);
            X11 = X9 - (X1 * 2);
            X12 = (X11 % 10) + (X11 / 10);
            X13 = X9 + X11;
            X14 = X10 + X12;

            textBox1.Text = X9.ToString();
            textBox2.Text = X10.ToString();
            textBox3.Text = X11.ToString();
            textBox4.Text = X12.ToString();
            textBox5.Text = X13.ToString();
            textBox6.Text = X14.ToString();

            bigN = dateTimePicker1.Value.ToShortDateString() + textBox1.Text +
                textBox2.Text + textBox3.Text + textBox4.Text;
            smlN = textBox5.Text + textBox6.Text;

            Calc(0);
            dataGridView1[3, 0].Value = bn.ToString() + '(' + sn.ToString() + ')';

            for (int i = 0; i < 3; i++)
            {
                bn = 0; sn = 0;
                for (int j = 1; j < 4; j++)
                    Calc(i * 3 + j);
                if (bn > 12)
                    bn = (bn % 10) + (bn / 10);
                if (sn > 12)
                    sn = (sn % 10) + (sn / 10);
                dataGridView1[3, i + 1].Value = bn.ToString() + '(' + sn.ToString() + ')';
            }

            for (int i = 10; i < 13; i++)
            {
                bn = 0; sn = 0;
                if ((i == X13) || (i == X14))
                {
                    switch (i)
                    {
                        case 10:
                            dataGridView1[0, 4].Value = "(10)";
                            break;
                        case 11:
                            dataGridView1[1, 4].Value = "(11)";
                            break;
                        case 12:
                            dataGridView1[2, 4].Value = "(12)";
                            break;
                    }
                    dataGridView1[3, 4].Value = '(' + i.ToString() + ')';
                }
            }
        }

        private void Calc(int num)
        {
            char c = char.Parse(num.ToString());
            int i = 0, j = 0, k = 0;
            for (i = 0; i < bigN.Length; i++)
                if (bigN[i].Equals(c))
                    j++;
            bn = bn + (j * num);

            for (i = 0; i < smlN.Length; i++)
                if (smlN[i].Equals(c))
                    k++;
            sn = sn + (k * num);

            for (i = 0; i < j; i++)
                tmpN = tmpN + c;

            if (k != 0)
            {
                tmpN = tmpN + '(';
                for (i = 0; i < k; i++)
                    tmpN = tmpN + c;
                tmpN = tmpN + ')';
            }

            switch (num)
            {
                case 0:
                    dataGridView1[1, 0].Value = tmpN;
                    break;
                case 1:
                    dataGridView1[0, 1].Value = tmpN;
                    break;
                case 2:
                    dataGridView1[1, 1].Value = tmpN;
                    break;
                case 3:
                    dataGridView1[2, 1].Value = tmpN;
                    break;
                case 4:
                    dataGridView1[0, 2].Value = tmpN;
                    break;
                case 5:
                    dataGridView1[1, 2].Value = tmpN;
                    break;
                case 6:
                    dataGridView1[2, 2].Value = tmpN;
                    break;
                case 7:
                    dataGridView1[0, 3].Value = tmpN;
                    break;
                case 8:
                    dataGridView1[1, 3].Value = tmpN;
                    break;
                case 9:
                    dataGridView1[2, 3].Value = tmpN;
                    break;
            }
            tmpN = String.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            for (byte b=0; b < 5; b++)
            dataGridView1.Rows.Add();
        }
    }
}
