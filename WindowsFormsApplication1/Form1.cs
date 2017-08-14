using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int clicknum = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tin.Text.Trim() == String.Empty)//判断输入是否为空
            {
                MessageBox.Show("请输入数字");
                return;
            }

            DUI.sign = true;
            String s = tin.Text;
            String[] s_arr = s.Split(' ');
            int n = s_arr.Length;
            for (int i = 0; i < n; i++)
            {
                double tmp;
                if (!double.TryParse(s_arr[i], out tmp)) //判断输入格式是否正确
                {
                    MessageBox.Show("请正确输入数字");
                    tin.Text = "";
                    return;
                }
            }
            for (int i = 0; i < n; i++)
            {
                DUI.a[i] = double.Parse(s_arr[i]);
            }
            DUI.length = n;
            //DUI.rukou();

            if (clicknum < n)
            {
                if (clicknum == 0)
                    textBox3.Text = "";
                DUI.countnum = n - clicknum - 2;    //控制分步显示的变量 传递给DUI类 
                DUI.rukou();                    //进入堆排序函数类的入口
                textBox3.AppendText(DUI.duiding.ToString());    //显示排序结果
                textBox3.AppendText(" ");
                textBox1.Text = DUI.duiding.ToString();         //显示堆顶元素

                int n1 = n - clicknum;      //堆数组长度
                int cn1 = 0;                  //堆数组计数
                int kg = 5;                   //空格个数
                int[] kgarr1 = { 15, 7, 3, 1, 0 };
                int[] kgarr2 = { 0, 15, 7, 3, 1 };
                int layer = (int)(Math.Log(n1) / Math.Log(2)) + 1;
                textBox2.Text = "";

                //打印堆 以树结构显示
                for (int i = 1; i <= layer; i++)
                {
                    textBox2.AppendText(Environment.NewLine);//换行
                    for (int k = 1; k <= kg + kgarr1[i - 1]; k++)
                    {
                        textBox2.AppendText(" ");
                    }
                    for (int j = 1; j <= Math.Pow(2, i - 1); j++)
                    {
                        textBox2.AppendText(DUI.a_temp[cn1].ToString());
                        for (int k = 1; k <= kgarr2[i - 1]; k++)
                        {
                            textBox2.AppendText(" ");
                        }
                        cn1 += 1;
                        if (cn1 >= n1)
                            break;
                    }

                }

                clicknum += 1;                  //按钮计数
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (tin.Text.Trim() == String.Empty)
            {
                MessageBox.Show("请输入数字");
                return;
            }
            DUI.sign = false;
            String s = tin.Text;
            String[] s_arr = s.Split(' ');
            int n = s_arr.Length;
            for (int i = 0; i < n; i++)
            {
                double tmp;
                if (!double.TryParse(s_arr[i], out tmp)) //判断输入格式是否正确
                {
                    MessageBox.Show("请正确输入数字");
                    tin.Text = "";
                    return;
                }
            }

            for (int i = 0; i < n; i++)
            {
                DUI.a[i] = double.Parse(s_arr[i]);
            }
            DUI.length = n;
            DUI.rukou();                    //进入堆排序函数类的入口
            textBox3.Text = "";
            for (int i = n-1; i >=0; i--)
            {
                textBox3.AppendText(DUI.a[i].ToString());    //显示排序结果
                textBox3.AppendText(" ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          //初始化
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            tin.Text = "";
            clicknum = 0;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            clicknum = 0;
        }

    }
}
