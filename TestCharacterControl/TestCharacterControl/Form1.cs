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

namespace TestCharacterControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            string Post1 = textPost1.Text.Trim();
            string Post2 = textPost2.Text.Trim();
            string Prefecture = textPrefecture.Text.Trim();
            string City = textCity.Text.Trim();
            string Street = textStreet.Text.Trim();
            string Building = textBuilding.Text.Trim();

            if(Post1.Length != 3)
            {
                message += "郵便番号１は３桁で入力してください。";
            }

            if (Post2.Length != 4)
            {
                if(message.Length > 0)
                {
                    message += Environment.NewLine;
                }
                message += "郵便番号２は４桁で入力してください。";
            }

            if (Prefecture.Length == 0)
            {
                if (message.Length > 0)
                {
                    message += Environment.NewLine;
                }
                message += "都道府県を入力してください。";
            }
            else if (!Prefecture.EndsWith("都") && !Prefecture.EndsWith("道") && !Prefecture.EndsWith("府") && !Prefecture.EndsWith("県"))
            {
                if (message.Length > 0)
                {
                    message += Environment.NewLine;
                }
                message += "都道府県の値が不正です。";
            }

            if (City.Length == 0)
            {
                if (message.Length > 0)
                {
                    message += Environment.NewLine;
                }
                message += "市区町村を入力してください。";
            }

            if (message.Length > 0)
            {
                MessageBox.Show(message);
            }
            else
            {
                StringBuilder addr = new StringBuilder();
                addr.Capacity = 200;
                // 郵便番号
                addr.Append("郵便番号：");
                addr.Append(Post1);
                addr.Append("-");
                addr.Append(Post2);
                addr.Append(Environment.NewLine);
                // 住所
                addr.Append("住所：");
                addr.Append(Prefecture);
                addr.Append(City);
                addr.Append(Street);
                addr.Append(Building);
                //
                textAddress.Text = addr.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string addr10 = string.Empty;
            addr10 = textAddress.Text;

            if(addr10.Length <= 10)
            {
                textAddress10.Text = addr10;
            }
            else
            {
                textAddress10.Text = addr10.Substring(0,10);
            }
        }

        /// <summary>
        /// ファイル書き込みボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWrite_Click(object sender, EventArgs e)
        {
            // インスタンス生成
            FileControl file = new FileControl(@"C:\Address\address.csv");
            // プロパティにテキストボックスの値をセット
            file.Post1 = textPost1.Text.Trim();
            file.Post2 = textPost2.Text.Trim();
            file.Prefecture = textPrefecture.Text.Trim();
            file.City = textCity.Text.Trim();
            file.Street = textStreet.Text.Trim();
            file.Building = textBuilding.Text.Trim();
            // 書き込み実行
            string message = file.Write();
            if (message.Length > 0)
            {
                // エラーメッセージの表示
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("ファイル書き込み処理が完了しました");
            }
        }

        /// <summary>
        /// ファイル読み込みボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRead_Click(object sender, EventArgs e)
        {
            // インスタンス生成
            FileControl file = new FileControl(@"C:\Address\address.csv");
            // 読み込み実行
            string message = file.Read();
            if (message.Length > 0)
            {
                // エラーメッセージの表示
                MessageBox.Show(message);
            }
            else
            {
                // テキストボックスに読み込んだ値をセット
                textPost1.Text = file.Post1;
                textPost2.Text = file.Post2;
                textPrefecture.Text = file.Prefecture;
                textCity.Text = file.City;
                textStreet.Text = file.Street;
                textBuilding.Text = file.Building;
                MessageBox.Show("ファイル読込処理が完了しました");
             }
        }

    }
}
