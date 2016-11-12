using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    enum Defs {all, with_hide, erase, set};
    class SudokuCore
    {
        private const int Size = 9;
        private int[,] Map;
        private int[,] Buffer;
        private bool[] Repeat;
        private int[,] Answers;
        private int Point;
        private int I;
        private int J;
        private int HideCount;
        private Random Rand;
        public delegate void SendMapDelegate(int[,] Map);
        public event SendMapDelegate SendMap;
        public delegate void SendResultDelegate(String Result, int[,] Map);
        public event SendResultDelegate SendResult;

        public SudokuCore()
        {
            this.Rand = new Random();
            this.Map = new int[Size, Size];
            this.Buffer = new int[Size, Size];
            this.Repeat = new bool[Size];
            this.Answers = new int[Size / 3, Size * 3]; // визначається максимальна кількість приховувань;
            this.Point = this.I = this.J = 0;
            this.HideCount = 9;
        }

        public void RequestGenerateMapHandler()
        {
            this.SetMap(0);
            this.SetAnswers(Defs.erase, 0);
            while (!this.MovePoint());
            this.SetAnswers(Defs.set, this.HideCount);
            this.MapToBuffer();
            this.SendMap(this.Buffer);
        }

        public void RequestResultHandler(int[,] OuterMap)
        {
            if (this.CheckWin(Map))
                this.SendResult("Win", this.Map);
            else
                this.SendResult("Loose", this.Buffer);
        }

        public void GetMapConsole(Defs mode) // TEST
        {
            Console.Write("\n\n  ");
            for (int i = 0; i < Size; i++)
            {
                this.I = i;
                for (int j = 0; j < Size; j++)
                {
                    this.J = j;
                    if (mode == Defs.with_hide)
                        if (this.CheckAnswers())
                            Console.Write("    ");
                        else
                            Console.Write(Map[i, j] + "   ");
                    else
                        Console.Write(Map[i, j] + "   ");
                }
                Console.Write("\n\n  ");
            }
        }

        private bool CheckWin(int[,] OuterMap)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (OuterMap[i, j] != this.Map[i, j])
                        return false;
            return true;
        }

        private void MapToBuffer()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (this.CheckAnswers())
                        this.Buffer[i, j] = 0;
                    else
                        this.Buffer[i, j] = this.Map[i, j];
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

        private void SetAnswers(Defs Mode, int Num)
        {
            if (Mode == Defs.erase)                      // звичайний режим заповнення встановленим числом;
            {
                for (int i = 0; i < Size / 3; i++)
                    for (int j = 0; j < Size; j++)
                        this.Answers[i, j] = Num;
            }
            else
            { //Defs.set                               // спеціальний режим заповнення - визначення полей для відгадування;
                for (int i = 0; i < Num; i++)
                {                                        // Увага!!! тут num виконує функцію кількості елементів, що приховуються від гравця;
                    this.Answers[0, i] = Rand.Next(0, 9);   // тут без +1, бо визначаються індекси в матриці; [ 0 - i ]
                    this.Answers[1, i] = Rand.Next(0, 9);   // тут без +1, бо визначаються індекси в матриці; [ 1 - j ]
                    for (int j = i - 1; j >= 0; j--)
                    {                                     // цикл уникнення можливості повторення елментів, що приховуються;
                        if (this.Answers[0, i] == this.Answers[0, j] && this.Answers[1, i] == this.Answers[1, j])
                            i--;
                    }
                }
            }
        }

        private bool CheckAnswers()
        {
            for (int i = 0; i < this.HideCount; i++)
                if ((this.Answers[0, i] == this.I) && (this.Answers[1, i] == this.J))
                    return true;
            return false;
        }

        private bool MovePoint()
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

        public bool ProcedStart() // TEST
        {
            String num;
            do
            {
                Console.Write("=========================");
                this.SetMap(0);                                 // обнулення карти;
                this.SetAnswers(Defs.erase, 0);                  // обнулення масиву елементів, що приховуються від гравця;
                while (!this.MovePoint());             // заповнення карти згідно правил СУДОКУ;
                this.SetAnswers(Defs.set, this.HideCount); // заповнення масиву елементів, що приховуються від гравця;
                this.GetMapConsole(Defs.all);
                Console.Write("=========================");
                this.GetMapConsole(Defs.with_hide);                 // відображення карти з прихованими елементами;
                Console.Write("=========================");
                //cout << "   ПОЧАТОК ГРИ [1]   ВИХIД [0]   СКЛАДНIСТЬ- [2]   СКЛАДНIСТЬ+ [3]   ДIЮЧА : " << HideCount << "\n";
                //for (int i = 0; i < 78; i ++) cout << "=";
                //while (!(cin >> num) || num < 0 || num > 3){
                //    cin.clear();
                //    while (cin.get()!='\n');
                //    system ("cls");
                //    header();
                //    getMap(true);
                //    for (int i = 0; i < 80; i ++) cout << "=";
                //cout << "   ПОЧАТОК ГРИ [1]   ВИХIД [0]   СКЛАДНIСТЬ- [2]   СКЛАДНIСТЬ+ [3]   ДIЮЧА : " << HideCount << "\n";
                //for (int i = 0; i < 78; i ++) cout << "=";
                //}
                //if (num == 2 && HideCount > 1)       // контроль зміни рівня складності гри (від 1 до 27);
                //    Hide--;                     // за замовчуванням - значення (3);
                //else if (num == 3 && Hide < 27) // 27 тільки тому, що створюється масив відповідей такого розміру;
                //    Hide++;                     // може бути збільшено/зменшено;
                //else if (num == 1)
                //    return 1;
                //else if (num == 0)
                //    return 0;
                num = Console.ReadLine();
            } while (true);
        }

        //public void SetUserAnswers(int Num)
        //{
        //    for (int j = 0; j < this.HideCount; j++)
        //        Answers[2, j] = Num;
        //}

        //void sudoku::procedGame() 
        //{                                       // ПРОЦЕДУРА ГРИ; (детально описана)
        //    while (ProcedStart())
        //    {                                   // функція попереднього вибору складності гри;
        //         do {                           // цикл повторення введення відповідей;
        //            system ("cls");             // очищення фрейму;
        //            header();                   // вивід хедера;
        //            getMap(true);               // показ карти на екран "з приховуванням елементів";
        //            procedInput();              // введення гравцем відповідей;
        //        } while (!procedWin ());        // поки відповіді не будуть правильними;
        //    }
        //}
        //
        //void sudoku::procedInput() {
        //    int count = 0;                      // лічильник елементів, що вводить гравець;
        //    int* currAns = new int [Hide];      // тимчасовий блок відповідей гравця;
        //    int* currPass = currAns;            // вказівник, що "проходить" по тимчасовому блоку відповідей гравця;
        //    for (int i = 0; i < Hide; i ++)     // обнулення тимчасового блоку відповідей гравця;;
        //        currAns[i] = 0;
        //    for (int i = 0; i < 80; i ++) cout << "=";
        //    cout << "  Введiть послiдовно зверху донизу злiва направо " << Hide << " пропущених елементiв : \n";
        //    for (int i = 0; i < 78; i ++) cout << "=";
        //    for (int i = 0; i < size; i ++) {
        //            I = i;
        //        for (int j = 0; j < size; j ++) {
        //            J = j;
        //            if (getAns()) {
        //
        //                if (++count > 1) {
        //                    for (int i = 0; i < 80; i ++) cout << "=";
        //                    cout << "  Введено : ";
        //                    for (int i = 0; i < Hide; i ++)
        //                        if (currAns[i] != 0)
        //                            cout << currAns[i] << "  ";
        //                    cout << endl;
        //                    for (int i = 0; i < 78; i ++) cout << "=";
        //                }
        //                while (!(cin >> Ans[2][getAns(true)]) || ( Ans[2][getAns(true)] < 1 ) || ( Ans[2][getAns(true)] > 9 )) {
        //                    cin.clear();
        //                    while (cin.get()!='\n');
        //                    system ("cls");
        //                    header();
        //                    getMap(true);
        //                    I = i;  // приведення I J у відповідність до значень поточної функції;
        //                    J = j;  // I J використовуються також у інших функціях;
        //                    for (int i = 0; i < 80; i ++) cout << "=";
        //                    cout << " Помилка вводу, спробуйте ще раз : " << endl;
        //                    for (int i = 0; i < 78; i ++) cout << "=";
        //                }
        //                *(currPass++) = Ans[2][getAns(true)];
        //                system ("cls");
        //                header();
        //                getMap(true);
        //                I = i;      // приведення I J у відповідність до значень поточної функції;
        //                J = j;      // I J використовуються також у інших функціях;
        //            }
        //        }
        //    }
        //    delete [] currAns;
        //}
        //
        //bool sudoku::procedWin () {
        //    for (int i = 0; i < Hide; i ++) {
        //        if (Ans [2][i] != Map[Ans[0][i]][Ans[1][i]]) {
        //            for (int i = 0; i < 80; i ++) cout << "=";
        //            cout << "\t\t  Вiдповiдь не є вiрною. Спробуйте ще раз." << endl;
        //            for (int i = 0; i < 78; i ++) cout << "=";
        //            clearUserAns();
        //            _getch();
        //            return 0;
        //        }
        //    }
        //    system ("cls");
        //    header();
        //    getMap();                           // відображення переможцю повної карти;
        //    for (int i = 0; i < 80; i ++) cout << "=";
        //    cout << "\t\t  Ви перемогли." << endl;
        //    for (int i = 0; i < 78; i ++) cout << "=";
        //    _getch();
        //    return 1;
        //}
        //private int GetAnswers(Defs Mode)
        //{
        //    if (Mode == Defs.exist)
        //    {				                        // функція вертає "логічне" значення, якщо знайдено співпадіння;
        //        for (int i = 0; i < this.HideCount; i++)
        //            if ((this.Answers[0, i] == I) && (this.Answers[1, i] == J))
        //                return 1;
        //        return 0;
        //    }
        //    else
        //    {								         // функція вертає індекс елементу, що співпав, якщо знайдено співпадіння;
        //        for (int i = 0; i < this.HideCount; i++) // по цьому індексу буде здійснено запис в 3тій рядок масиву;
        //            if ((this.Answers[0, i] == I) && (this.Answers[1, i] == J))
        //                return i;
        //        return 0;
        //    }
        //}
    }
}