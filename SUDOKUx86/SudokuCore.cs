using System;

namespace Sudoku
{
    class SudokuCore
    {
        private const int Size = 9;
        private int[,] Map;
        private int[,] Buffer;
        private bool[] Repeat;
        private int[,] Hidden;
        private int I;
        private int J;
        private int Point;
        private int HideCount;
        private Random Rand;
        public delegate void SendMapDelegate(int[,] Map);
        public event SendMapDelegate SendMap;
        public delegate void SendResultDelegate(String Result);
        public event SendResultDelegate SendResult;

        public SudokuCore()
        {
            this.Rand = new Random();
            this.Map = new int[Size, Size];
            this.Buffer = new int[Size, Size];
            this.Repeat = new bool[Size];
            this.Hidden = new int[Size / 3, Size * Size]; // визначається максимально можлива кількість приховувань;
            this.Point = this.I = this.J = 0;
            this.HideCount = 0;
        }

        public void RequestGenerateMapHandler(int HideCount)
        {
            this.HideCount = HideCount;
            this.SetMap(0);
            this.SetHidden(0);
            while (!this.GenerateMap());
            this.GenerateHidden(this.HideCount);
            this.MapToBuffer();
            this.SendMap(this.Buffer);
        }

        public void RequestMapHandler()
        {
            this.SendMap(this.Buffer);
        }

        public void RequestCheckResultHandler(int[,] OuterMap)
        {
            if (this.CheckWin(OuterMap) == true)
                this.SendResult("Win");
            else
                this.SendResult("Loose");
        }

        private void MapToBuffer()
        {
            for (int i = 0; i < Size; i++)
            {
                this.I = i;
                for (int j = 0; j < Size; j++)
                {
                    this.J = j;
                    if (this.CheckHidden() == true)
                        this.Buffer[i, j] = 0;
                    else
                        this.Buffer[i, j] = this.Map[i, j];
                }
            }
        }

        private void SetMap(int Num)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Map[i, j] = Num;
        }

        private void SetRepeat(bool Value)
        {
            for (int i = 0; i < Size; i++)
                Repeat[i] = Value;
        }

        private void SetHidden(int Num)
        {
            for (int i = 0; i < Size / 3; i++)
                for (int j = 0; j < Size; j++)
                    this.Hidden[i, j] = Num;
        }

        private void GenerateHidden(int Num)
        {
            for (int i = 0; i < Num; i++)
            {
                this.Hidden[0, i] = Rand.Next(0, 9);   // тут без +1, бо визначаються індекси в матриці; [ 0 - i ]
                this.Hidden[1, i] = Rand.Next(0, 9);   // тут без +1, бо визначаються індекси в матриці; [ 1 - j ]
                for (int j = i - 1; j >= 0; j--)
                {                                     // цикл уникнення можливості повторення елментів, що приховуються;
                    if (this.Hidden[0, i] == this.Hidden[0, j] && this.Hidden[1, i] == this.Hidden[1, j])
                        i--;
                }
            }
        }

        private bool GenerateMap()
        {
            this.SetMap(0);
            for (int i = 0; i < Size; i++)
            {
                this.I = i;
                for (int j = 0; j < Size; j++)
                {
                    this.J = j;
                    if (this.CheckPoint() == false)
                        return false;
                    this.Map[i, j] = this.Point;
                }
            }
            return true;
        }

        private bool CheckHidden()
        {
            for (int i = 0; i < this.HideCount; i++)
                if ((this.Hidden[0, i] == this.I) && (this.Hidden[1, i] == this.J))
                    return true;
            return false;
        }

        private bool CheckPoint()
        {                                           // БЛОК ПЕРЕВІРКИ ЗАПОВНЕННЯ МАТРИЦІ; (детально описана)
            this.SetRepeat(false);                      // очищення масиву повторень;
            while (true)
            {                                       // вічний цикл до виконання умови;
                if (this.CheckRepeat() == true)
                {                                   // перевірка масиву повторень на предмет того чи цикл не є в глухому куті;
                    this.Point = Rand.Next(1, 10);  //%9+1;// визначення рандому числа;
                    if (this.Repeat[this.Point - 1] == true) // якщо згідно масиву повторень значення вже випадало;
                        continue;                   // цикл починається знову;
                    this.Repeat[Point - 1] = true;      // запамятовування числа, що випало у масиві повторень;
                    if (this.CheckRow())            // перевірка повторення числа в рядку;
                        continue;                   // якщо є повторення цикл починається знову;
                    if (this.CheckCol())            // перевірка повторення числа в стовпці;
                        continue;                   // якщо є повторення цикл починається знову;
                    if (this.CheckZone())           // перевірка повторення числа в зонах ( 9 зон по 3 х 3 );
                        continue;                   // якщо є повторення цикл починається знову;
                    break;                          // якщо жодна з умов не спрацювала - цикл закінчується з значенням 1;
                }
                else                                // якщо цикл зайшов у глухий кут (перебрані цифри від 1 до 9, вихід з значенням 0;
                    return false;
            }
            return true;
        }

        private bool CheckRow()
        {
            for (int j = 0; j < Size; j++)
                if (this.Point == this.Map[I, j])
                    return true;
            return false;
        }

        private bool CheckCol()
        {
            for (int i = 0; i < Size; i++)
                if (this.Point == this.Map[i, J])
                    return true;
            return false;
        }

        private bool CheckZone()
        {                                          // ПЕРЕВІРКА ПО ЗОНАХ 9 ШТ 3 Х 3;
            if (I < 3 && J < 3)
            {                  // перша зона (3 х 3)
                for (int i1 = 0; i1 < 3; i1++)
                    for (int j1 = 0; j1 < 3; j1++)
                        if (this.Point == this.Map[i1, j1])
                            return true;
            }
            else if (I < 3 && J >= 3 && J < 6)    // друга зона (3 х 3)
            {
                for (int i2 = 0; i2 < 3; i2++)
                    for (int j2 = 3; j2 < 6; j2++)
                        if (this.Point == this.Map[i2, j2])
                            return true;
            }
            else if (I < 3 && J >= 6 && J < 9)    // третя зона (3 х 3)
            {
                for (int i3 = 0; i3 < 3; i3++)
                    for (int j3 = 6; j3 < 9; j3++)
                        if (this.Point == this.Map[i3, j3])
                            return true;
            }
            else if (I >= 3 && I < 6 && J < 3)
            {                                       // четверта зона (3 х 3)
                for (int i4 = 3; i4 < 6; i4++)
                    for (int j4 = 0; j4 < 3; j4++)
                        if (this.Point == this.Map[i4, j4])
                            return true;
            }
            else if (I >= 3 && I < 6 && J >= 3 && J < 6)
            {                                       // пята зона (3 х 3)
                for (int i5 = 3; i5 < 6; i5++)
                    for (int j5 = 3; j5 < 6; j5++)
                        if (this.Point == this.Map[i5, j5])
                            return true;
            }
            else if (I >= 3 && I < 6 && J >= 6 && J < 9)
            {                                            // шоста зона (3 х 3)
                for (int i6 = 3; i6 < 6; i6++)
                    for (int j6 = 6; j6 < 9; j6++)
                        if (this.Point == this.Map[i6, j6])
                            return true;
            }
            else if (I >= 6 && I < 9 && J < 3)
            {                                           // сьома зона (3 х 3)
                for (int i7 = 6; i7 < 9; i7++)
                    for (int j7 = 0; j7 < 3; j7++)
                        if (this.Point == this.Map[i7, j7])
                            return true;
            }
            else if (I >= 6 && I < 9 && J >= 3 && J < 6)
            {                                           // восьма зона (3 х 3)
                for (int i8 = 6; i8 < 9; i8++)
                    for (int j8 = 3; j8 < 6; j8++)
                        if (this.Point == this.Map[i8, j8])
                            return true;
            }
            else if (I >= 6 && I < 9 && J >= 6 && J < 9)
            {                                           // девята зона (3 х 3)
                for (int i9 = 6; i9 < 9; i9++)
                    for (int j9 = 6; j9 < 9; j9++)
                        if (this.Point == this.Map[i9, j9])
                            return true;
            }
            return false;
        }

        private bool CheckRepeat()
        {
            for (int i = 0; i < Size; i++)
                if (Repeat[i] == false)
                    return true;
            return false;
        }

        private bool CheckWin(int[,] OuterMap)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (OuterMap[i, j] != this.Map[i, j])
                        return false;
            return true;
        }
    }
}