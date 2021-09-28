using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;
using System.Threading;

namespace flashplayerpp_install_cn
{
    class Utils
    {


        public static void Delay(int DelayTime = 100)
        {
            int time = Environment.TickCount;
            while (true)
            {
                if (Environment.TickCount - time >= DelayTime)
                {
                    break;
                }
                Application.DoEvents();
                Thread.Sleep(10);
            }
        }
     }
}
