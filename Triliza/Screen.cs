using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triliza
{
    class Screen
    {
        void PrintLine(int? sel)
        {
            string[] line = { "---", "---", "---" };
            if (sel != null)
            {
                int selection = (int)sel;
                line[selection] = "===";
            }
            Console.WriteLine(" " + line[0]+ " " + line[1]+ " " + line[2]);
        }
        void PrintRow(char[] Marks,int? sel)
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

        public void Update(char[,]Mark,int SelRow,int SelCol)
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                if (SelRow==i)
                {
                    PrintLine(SelCol);
                    PrintRow(Mark.GetRow(i), SelCol);
                }
                else if (SelRow==i-1)
                {
                    PrintLine(SelCol);
                    PrintRow(Mark.GetRow(i), null);
                }
                else
                {
                    PrintLine(null);
                    PrintRow(Mark.GetRow(i), null);
                }
            }
            if (SelRow==2)
            {
                PrintLine(SelCol);
            }
            else
            {
                PrintLine(null);
            }
        }

    }
}
