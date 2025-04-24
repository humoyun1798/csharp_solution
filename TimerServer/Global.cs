using System;
using System.Collections.Generic;
using System.Text;

namespace TimerServer
{
    public class Global
    {
        private static Global _instance;

        //单例
        public static Global Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Global();
                }
                return _instance;
            }
        }


        public string Name = "🐶子";

    }
}
