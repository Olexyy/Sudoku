using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Linq;            // no framework 4.5
//using System.Threading.Tasks; // no framework 4.5

namespace Sudoku
{
    public partial class SudokuForm : Form
    {
        private const int MaxHideCount = 44;
        private const int MinHideCount = 3;
        private const int Length = 9;
        private int I;
        private int J;
        private int HideCount;
        private int[,] AnswerMap;
        public delegate void RequestGenerateMapDelegate(int HideCount);
        public event RequestGenerateMapDelegate RequestGenerateMap;
        public delegate void RequestMapDelegate();
        public event RequestMapDelegate RequestMap;
        public delegate void RequestCheckResultDelegate(int[,] AnswerMap);
        public event RequestCheckResultDelegate RequestCheckResult;

        public SudokuForm()
        {
            InitializeComponent();
            this.Map.RowCount = Length;
            this.I = this.J = 0;
            this.AnswerMap = new int[Length,Length];
            this.HideCount = MinHideCount;
            this.HideCountBox.Text = MinHideCount.ToString();
            this.CountHideText.Text = "Кількість приховувань (" + MinHideCount.ToString() + " - " + MaxHideCount.ToString() + ") :";
            this.EraseMap();
            this.MessageStrip.Text = "Нова гра/Обрати складність...";
        }

        private void EraseMap ()
        {
            for (int i = 0; i < Length; i++)
                for (int j = 0; j < Length; j++)
                {
                    this.Map[i, j].ReadOnly = true;
                    this.Map[i, j].Value = "";
                    if ((i <= 2 && j <= 2) || (i >= 6 && j <= 2) || ((i >= 3 && i <= 5) && (j >= 3 && j <= 5)) || (i <= 2 && j >= 6) || (i >= 6 && j >= 6))
                        this.Map[i, j].Style.BackColor = Color.LightBlue;
                    else
                        this.Map[i, j].Style.BackColor = Color.White;
                }
        }

        public void AcceptMapHandler (int[,] Map)
        {
            this.EraseMap();
            for (int i = 0; i < Length; i++)
                for (int j = 0; j < Length; j++)
                    if (Map[i, j] != 0)
                        this.Map[i, j].Value = Map[i, j];
                    else
                        this.Map[i, j].ReadOnly = false;  
        }

        public void ResultHandler(String Result)
        {
            if (Result == "Win")
            {
                this.MessageStrip.Text = "Розпочати гру...";
                this.Map.Enabled = false;
                this.ButtonCheck.Enabled = false;
                this.ОчиститиtoolStrip.Enabled = false;
                MessageBox.Show("Ви перемогли!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.MessageStrip.Text = "Продовжити...";
                MessageBox.Show("Відповіді неправильні, спробуйте ще раз!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Map_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Map[J, I].ReadOnly == false)
            {
                if (e.KeyChar >= '1' && e.KeyChar <= '9')
                    this.Map[J, I].Value = e.KeyChar.ToString();
                else if (e.KeyChar == Convert.ToChar(Keys.Back))
                    this.Map[J, I].Value = "";
            }
        }

        private void Map_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.I = e.RowIndex;
            this.J = e.ColumnIndex;
        }

        private void Map_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.I = e.RowIndex;
            this.J = e.ColumnIndex;
        }

        private void SetAnswerMap()
        {
            for (int i = 0; i < Length; i++)
                for (int j = 0; j < Length; j++)
                    int.TryParse (this.Map[i, j].Value.ToString(), out this.AnswerMap[i, j]);
        }

        private void ButtonCheck_Click(object sender, EventArgs e)
        {
            this.SetAnswerMap();
            this.RequestCheckResult(this.AnswerMap);
        }

        private void НоваГраStrip_Click(object sender, EventArgs e)
        {
            this.Map.Enabled = true;
            this.ButtonCheck.Enabled = true;
            this.RequestGenerateMap(this.HideCount);
            this.ОчиститиtoolStrip.Enabled = true;
            this.MessageStrip.Text = "Гру розпочато...";
        }

        private void ВихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HideCountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == Convert.ToChar(Keys.Back))
                return;
            else 
                e.Handled = true;
        }

        private void РівеньСкладностіToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            int TempHideCount;
            if (int.TryParse(this.HideCountBox.Text, out TempHideCount) == true)
            {
                if (TempHideCount < MinHideCount)
                {
                    this.HideCount = MinHideCount;
                    this.HideCountBox.Text = this.HideCount.ToString();
                }
                else if (TempHideCount > MaxHideCount)
                {
                    this.HideCount = MaxHideCount;
                    this.HideCountBox.Text = this.HideCount.ToString();
                }
                else
                    this.HideCount = TempHideCount;
            }
            else
                this.HideCountBox.Text = this.HideCount.ToString();
        }

        private void ВерсіяToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Версія: 0.9а", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ОчиститиtoolStrip_Click(object sender, EventArgs e)
        {
            this.RequestMap();
        }

    }
}
