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
        int counter = 0;
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
            CheckState();
            Update();
        }
        void CheckState()
        {
            if (counter==9){Reset();}
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
            counter++;
        }
        void Reset()
        {
            Mrk=new [,]
            {
                { ' ',' ',' '},
                { ' ',' ',' '},
                { ' ',' ',' '}
            };
            counter = 0;
            TurnX = true;
        }
        bool? CheckPos(int offsetRow,int offsetCol)
        {
            char player='o';
            if (TurnX)
            {
                player='x';
            }
            int RowPos = SelRow + offsetRow;
            int ColPos = SelCol + offsetCol;
            if (RowPos<0||RowPos>2||ColPos<0||ColPos>2){return null;}
            else
            {
                return Mrk[RowPos, ColPos] == player;
            }
        }
    }
}
