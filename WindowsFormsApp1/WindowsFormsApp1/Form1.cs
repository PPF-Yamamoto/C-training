using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string newString = "aaaaaa";


        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            const string strName = "Roto";
            int iLebel = 15;
            double dGold = 0;
            bool bFirst = true;

            double.Parse("1.01");
            dGold.ToString();


            Button btnObj = (Button)sender;
            string name = btnObj.Text;

            try
            {
                dGold = double.Parse("TEST");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("エラー発生");
                MessageBox.Show(ex.Message);
            }
            //finally
            //{
            //    MessageBox.Show("通過");
            //}


            //string[] strEnemys = {"スライム","ドラキーマ","はぐれメタル"};
            List<string> strEnemys = new List<string> { "スライム", "ドラキーマ", "はぐれメタル" };
            string[] strEnemys2 = strEnemys.ToArray();

            foreach (string str in strEnemys)
            {
                MessageBox.Show(str + "を倒した！");
            }


                //for (int i = 0; i < 10; i++)
                //{
                //    dGold += 100;
                //}

                //int iCnt = 0;
                //while ( iCnt < 10)
                //{
                //    dGold += 100;
                //    iCnt++;
                //}

                MessageBox.Show("現在のゴールドは" + dGold.ToString() + "です。");

            //if (iLebel < 10)
            //{
            //    MessageBox.Show("初心者です。");
            //}
            //else if (iLebel < 50)
            //{
            //    MessageBox.Show("中級者です。");
            //}
            //else
            //{
            //    MessageBox.Show("上級者です。");
            //}

            //switch (iLebel)
            //{
            //    case 5:
            //        MessageBox.Show("メラを覚えました。");
            //        break;
            //    case 15:
            //        MessageBox.Show("ホイミを覚えました。");
            //        break;
            //}





        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;

                StreamReader sr = new StreamReader(textBox1.Text, Encoding.GetEncoding("Shift_JIS"));
                label1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        public string getString(int num)
        {
            string newString = num.ToString();
            return newString;
        }

        public void showString(string str)
        {
            MessageBox.Show(str);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
            showString(getString(123));

            // 画面初期化

            // 設定ファイル読み込み

            // 初期値設定

            // 時刻タイマー表示
    
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            label3.Text = "押下";
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            label3.Text = "押上";
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            label3.Text = "重なった";
        }
    }
}
