using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using flashplayerpp_install_cn;


namespace FlashInstaller
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            MainClass.Run();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new flashplayerpp_install_cn());
        }

        static void test()
        {


            // 加密
            /*
            String str = "http://xxxxxxxxxxx.apig.cn-north-4.xxxxxxxxxx.com/flash.png";
            str= "http://xxxxx-xxxxxx.xxxxx.com/favicon.bmp";
            String key = "yvfvsdt56tfguj";
            String encrypt_data = Enc.EncryptToBase64String(str, key);
            MessageBox.Show(encrypt_data);

            */


            /*
             * 
             * 
            */

            // String Key = "yvfvsdt56tfguj";
            // byte[] bytes = new byte[Key.Length * sizeof(char)];
            // System.Buffer.BlockCopy(Key.ToCharArray(), 0, bytes, 0, bytes.Length);

        }

    }
}
