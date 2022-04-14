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
            if (CheckState()&&Input==' ')
            {
                Win();
            }
            else
            {
                Update();
            }
        }
        void Win()
        {
            Scr.Update(Mrk, null, null); ;
            if (TurnX)
            {
                Console.WriteLine("\n\nVicktory to O");
            }
            else
            {
                Console.WriteLine("\n\nVicktory to X");
            }
            Console.ReadLine();
        }
        bool CheckState()
        {
            if (CheckPos(1,0)&& CheckPos(2,0)){ return true; }
            else if (CheckPos(1,0)&& CheckPos(-1,0)) { return true; }
            else if (CheckPos(-1,0)&& CheckPos(-2,0)) { return true; }

            else if (CheckPos(0,1)&& CheckPos(0,2)) { return true; }
            else if (CheckPos(0,1)&& CheckPos(0,-1)) { return true; }
            else if (CheckPos(0,-2)&& CheckPos(0,-1)) { return true; }

            else if (CheckPos(-1,-1)&& CheckPos(1,1)) { return true; }
            else if (CheckPos(-1,-1)&& CheckPos(-2,-2)) { return true; }
            else if (CheckPos(1,1)&& CheckPos(2,2)) { return true; }

            else if (CheckPos(1,-1)&& CheckPos(2,-2)) { return true; }
            else if (CheckPos(-1,1)&& CheckPos(-2,2)) { return true; }
            else if (CheckPos(-1,1)&& CheckPos(1,-1)) { return true; }
            else if (counter==9){Reset();}
            return false;
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
        bool CheckPos(int offsetRow,int offsetCol)
        {
            char player='x';
            if (TurnX)
            {
                player='o';
            }
            int RowPos = SelRow + offsetRow;
            int ColPos = SelCol + offsetCol;
            if (RowPos<0||RowPos>2||ColPos<0||ColPos>2){return false;}
            else
            {
                return Mrk[RowPos, ColPos] == player;
            }
        }
    }
}
