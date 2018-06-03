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
        int graf = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            if (graf != 11)
            {
                chart1.ChartAreas[graf].Visible = false;
                graf++;
                chart1.ChartAreas[graf].Visible = true;
            }
        }

        int[] Y = new int[24];
        string bigN, smlN, tmpN;
        Color col = new Color();

        private void button3_Click(object sender, EventArgs e)
        {
            if (graf != 0)
            {
                chart1.ChartAreas[graf].Visible = false;
                graf--;
                chart1.ChartAreas[graf].Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Visible = !chart1.Visible;
        }

        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            dataGridView2.Rows.Clear();
            for (int c=0; c < 4; c++)
                for (int r=0; r < 5; r++)
                {
                    dataGridView1[c, r].Value = String.Empty;
                    dataGridView1[c, r].Style.BackColor = Color.White;
                }

            for (int r=0; r < 12; r++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[r].HeaderCell.Value = (r + 1).ToString();
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
                if ((i == X13) || (i == X14))
                {
                    switch (i)
                    {
                        case 10:
                            dataGridView1[0, 4].Value = "(10)";
                            dataGridView1[0, 4].Style.BackColor = Color.Blue;
                            break;
                        case 11:
                            dataGridView1[1, 4].Value = "(11)";
                            dataGridView1[1, 4].Style.BackColor = Color.Blue;
                            break;
                        case 12:
                            dataGridView1[2, 4].Value = "(12)";
                            dataGridView1[2, 4].Style.BackColor = Color.Blue;
                            break;
                    }
                    dataGridView1[3, 4].Value = '(' + i.ToString() + ')';
                }
            }

            BigTable();
            GrafMake();
        }

        private void GrafMake()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            int k = 0;
            for (int graf = 0; graf < 12; graf++)
            {
                chart1.ChartAreas.Add(graf.ToString());
                chart1.Series.Add(graf.ToString());
                chart1.Series[graf].ChartArea = graf.ToString();
                chart1.ChartAreas[graf].Visible = false;
                for (int i = 0; i < 31; i++)
                {
                    k = int.Parse(dataGridView2[i, graf].Value.ToString());
                    chart1.Series[graf].Points.AddXY(i, k);
                }
            }
            graf = 0;
            chart1.ChartAreas[0].Visible = true;
        }

        private void RollMonth(int day)
        {
            Y[1] = (day % 10);
            Y[2] = (day / 10);
            Y[3] = dateTimePicker2.Value.Month;
            Y[4] = (Y[3] % 10);
            Y[3] = (Y[3] / 10);
            Y[5] = dateTimePicker2.Value.Year;
            Y[6] = (Y[5] % 1000) / 100;
            Y[7] = (Y[5] % 100) / 10;
            Y[8] = (Y[5] % 10);
            Y[5] = (Y[5] / 1000);
            Y[9] = Y[1] + Y[2] + Y[3] + Y[4] + Y[5] + Y[6] + Y[7] + Y[8];
            Y[10] = (Y[9] % 10) + (Y[9] / 10);
            Y[11] = Y[9] - (X1 * 2);
            Y[12] = (Y[11] % 10) + (Y[11] / 10);
            Y[13] = Y[9] + Y[11];
            Y[14] = Y[10] + Y[2];
            if (Y[14] == 10)
                Y[21] = 10;
            if (Y[15] == 11)
                Y[22] = 11;
            if (Y[16] == 12)
                Y[23] = 12;
            Y[15] = (Y[9] % 10);
            Y[9] = (Y[9] / 10);
            Y[16] = (Y[10] % 10);
            Y[10] = (Y[10] / 10);
            Y[17] = (Y[11] % 10);
            Y[11] = (Y[11] / 10);
            Y[18] = (Y[12] % 10);
            Y[12] = (Y[12] / 10);
            Y[19] = (Y[13] % 10);
            Y[13] = (Y[13] / 10);
            Y[20] = (Y[14] % 10);
            Y[14] = (Y[14] / 10);
        }

        private void BigTable()
        {
            for (int i = 0; i < 31; i++)
            {
                RollMonth(i);
                for (int j = 0; j < 12; j++)
                dataGridView2[i, j].Value = SearchNumber(j+1);
            }
        }

        private int SearchNumber(int num)
        {
            int tmp = 0;
            String numbers = "";
            for (int i = 0; i < 20; i++)
            {
                numbers += Y[i];
            }
            if (num < 10)
            {
                for (int i = 0; i < numbers.Length; i++)
                    if (Char.Parse(num.ToString()) == numbers[i])
                        tmp++;
            }
            else
            {
                if ((num == Y[21]) || (num == Y[22]) || (num == Y[23]))
                    tmp++;
            }
            switch (num)
            {
                case 0:
                    tmp += Concat(1, 0);
                    break;
                case 1:
                    tmp += Concat(0, 1);
                    break;
                case 2:
                    tmp += Concat(1, 1);
                    break;
                case 3:
                    tmp += Concat(2, 1);
                    break;
                case 4:
                    tmp += Concat(0, 2);
                    break;
                case 5:
                    tmp += Concat(1, 2);
                    break;
                case 6:
                    tmp += Concat(2, 2);
                    break;
                case 7:
                    tmp += Concat(0, 3);
                    break;
                case 8:
                    tmp += Concat(1, 3);
                    break;
                case 9:
                    tmp += Concat(2, 3);
                    break;
                case 10:
                    if (dataGridView1[0, 4].Value.ToString() != "")
                        tmp++;
                    break;
                case 11:
                    if (dataGridView1[1, 4].Value.ToString() != "")
                        tmp++;
                    break;
                case 12:
                    if (dataGridView1[2, 4].Value.ToString() != "")
                        tmp++;
                    break;

            }
            return tmp;
        }

        private int Concat(int x, int y)
        {
            int tmp = 0;
            string nums = "";
            nums = dataGridView1[x, y].Value.ToString();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == '(')
                    break;
                tmp++;
            }
            return tmp;
        }

        private void Colorchange(int bnum, int snum)
        {
            if ((bnum + snum) < 1)
                col = Color.Red;
            else
            if ((bnum + snum) < 2)
                col = Color.Yellow;
            else
            if ((bnum + snum) < 3)
                col = Color.Blue;
            else
                col = Color.Green;
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

            Colorchange(j, k);

            switch (num)
            {
                case 0:
                    dataGridView1[1, 0].Value = tmpN;
                    dataGridView1[1, 0].Style.BackColor = col;
                    break;
                case 1:
                    dataGridView1[0, 1].Value = tmpN;
                    dataGridView1[0, 1].Style.BackColor = col;
                    break;
                case 2:
                    dataGridView1[1, 1].Value = tmpN;
                    dataGridView1[1, 1].Style.BackColor = col;
                    break;
                case 3:
                    dataGridView1[2, 1].Value = tmpN;
                    dataGridView1[2, 1].Style.BackColor = col;
                    break;
                case 4:
                    dataGridView1[0, 2].Value = tmpN;
                    dataGridView1[0, 2].Style.BackColor = col;
                    break;
                case 5:
                    dataGridView1[1, 2].Value = tmpN;
                    dataGridView1[1, 2].Style.BackColor = col;
                    break;
                case 6:
                    dataGridView1[2, 2].Value = tmpN;
                    dataGridView1[2, 2].Style.BackColor = col;
                    break;
                case 7:
                    dataGridView1[0, 3].Value = tmpN;
                    dataGridView1[0, 3].Style.BackColor = col;
                    break;
                case 8:
                    dataGridView1[1, 3].Value = tmpN;
                    dataGridView1[1, 3].Style.BackColor = col;
                    break;
                case 9:
                    dataGridView1[2, 3].Value = tmpN;
                    dataGridView1[2, 3].Style.BackColor = col;
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
