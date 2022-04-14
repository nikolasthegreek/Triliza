using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triliza
{
    class GameMaster
    {
        char[,] Mrk = new[,]
            {
                {' ',' ',' '},
                {' ',' ',' '},
                {' ',' ',' '}
            };
        int SelRow=1;
        int SelCol=1;
        bool TurnX = true;

        char Input;
        ConsoleKeyInfo InputKey;

        Screen Scr = new Screen();
        public GameMaster()
        {
            Update();
        }
        void Update()
        {
            Scr.Update(Mrk, SelRow, SelCol);
            Input = GetInput();
            if (Input=='a'){SelLeft();}
            if (Input=='d'){SelRight();}
            if (Input=='w'){SelUp();}
            if (Input=='s'){SelDown();}
            if (Input==' '){SelPlace();}
            
            Update();
        }
        char GetInput()
        {
            InputKey = Console.ReadKey();
            return InputKey.KeyChar;
        }
        void SelLeft()
        {
            if (SelCol!=0)
            {
                SelCol--;
            }
        }
        void SelRight()
        {
            if (SelCol != 2)
            {
                SelCol++;
            }
        }
        void SelUp()
        {
            if (SelRow != 0)
            {
                SelRow--;
            }
        }
        void SelDown()
        {
            if (SelRow != 2)
            {
                SelRow++;
            }
        }
        void SelPlace()
        {
            if (Mrk[SelRow, SelCol]!=' ')
            {
                return;
            }
            if (TurnX)
            {
                Mrk[SelRow, SelCol] = 'x';
            }
            else
            {
                Mrk[SelRow, SelCol] = 'o';
            }
            TurnX = !(TurnX);
        }
    }
}
