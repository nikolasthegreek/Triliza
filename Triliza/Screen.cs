using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triliza
{
    class Screen
    {
        public void PrintLine(int? sel)
        {
            string[] line = { "---", "---", "---" };
            if (sel != null)
            {
                int selection = (int)sel;
                line[selection] = "===";
            }
            Console.WriteLine(" " + line[0]+ " " + line[1]+ " " + line[2]);
        }
        public void PrintRow(char[] Marks,int? sel)
        {
            string[] draw={"e","e","e"};
            for (int i = 0; i < 3; i++)
            {
                if (i==sel)
                {
                    draw[i]=("|" + Marks[i] + "|" );
                }
                else
                {
                    draw[i] = (" " + Marks[i] + " ");
                }
            }

            Console.WriteLine("|" + draw[0] + "|" + draw[1] + "|" + draw[2]+"|");
        }


    }
}
