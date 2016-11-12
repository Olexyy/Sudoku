using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using System.Linq;            // no framework 4.5
//using System.Threading.Tasks; // no framework 4.5

namespace Sudoku
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SudokuForm Interface = new SudokuForm();
            SudokuCore Game = new SudokuCore();
            Interface.RequestGenerateMap += Game.RequestGenerateMapHandler;
            Game.SendMap += Interface.AcceptMapHandler;
            Interface.RequestCheckResult += Game.RequestCheckResultHandler;
            Game.SendResult += Interface.ResultHandler;
            Interface.RequestMap += Game.RequestMapHandler;
            Application.Run(Interface);
        }
    }
}
