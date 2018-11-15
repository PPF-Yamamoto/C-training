using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace TestCharacterControl
{
    public class FileControl
    {
        // 定数
        const int CsvCulumnNumber = 6;

        #region プロパティの定義
        // プロパティの定義
        private string post1;
        public string Post1
        {
            get { return post1; }
            set { post1 = value; }
        }
        private string post2;
        public string Post2
        {
            get { return post2; }
            set { post2 = value; }
        }
        private string prefecture;
        public string Prefecture
        {
            get { return prefecture; }
            set { prefecture = value; }
        }
        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string street;
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        private string building;
        public string Building
        {
            get { return building; }
            set { building = value; }
        }
        private string FilePath;
        #endregion

        // コンストラクタ  
        public FileControl()
        {
            
        }

        public FileControl(string InputFilePath)
        {
            FilePath = InputFilePath;
        }

        #region メソッド
        /// <summary>
        /// ファイル書き込み処理
        /// </summary>
        /// <returns></returns>
        public string Write()
        {
            string message = "";
            StreamWriter sw = null;
            try
            {
                //BOMなしUTF-8・上書きモード
                sw = new StreamWriter(FilePath, false, new UTF8Encoding(false));
                sw.Write(string.Format("{0},{1},{2},{3},{4},{5}",
                                       Post1, Post2, Prefecture, City, Street, Building));
            }
            catch (Exception ex)
            {
                message = "エラー発生：" + ex.Message;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
            return message;
        }

        /// <summary>
        /// ファイル読み込み処理
        /// </summary>
        /// <returns></returns>
        public string Read()
        {
            string address = "";
            string message = "";
            StreamReader sr = null;
            try
            {
                //BOMなしUTF-8として開く
                sr = new StreamReader(FilePath, new UTF8Encoding(false));
                int count = 0;
                while (sr.Peek() > -1)
                {
                    // 1行目だけ読み込む
                    if (count > 0)break;

                    address = sr.ReadLine();

                    // １行目を配列化
                    string[] AddressArray = address.Split(',');

                    // 項目数チェック
                    if (AddressArray.Length != CsvCulumnNumber)
                    {
                        message = "CSVの項目数が不正です";
                    }
                    else
                    {
                        // 項目数が正しければ読み込んでプロパティにセット
                        int len = AddressArray.Length;
                        if (len > 0) Post1 = AddressArray[0].Trim();
                        if (len > 1) Post2 = AddressArray[1].Trim();
                        if (len > 2) Prefecture = AddressArray[2].Trim();
                        if (len > 3) City = AddressArray[3].Trim();
                        if (len > 4) Street = AddressArray[4].Trim();
                        if (len > 5) Building = AddressArray[5].Trim();

                    }
                    count++;
                }
            }
            catch (Exception ex)
            {
                message = "エラー発生：" + ex.Message;
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            return message;
        }
        #endregion
    }
}
