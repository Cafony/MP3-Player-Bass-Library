using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bass_Dll_Player
{
    public static class Vars
    {
        public static List<string>  Files = new List<string>();


        public static string GetFileName(string filename)
        {
            string[] tmp = filename.Split('\\');
            return tmp[tmp.Length-1];
        }



    }
}
