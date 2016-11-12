namespace Sudoku
{
    partial class SudokuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SudokuForm));
            this.Map = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonCheck = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MessageStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.НоваГраStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ОчиститиtoolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.РівеньСкладностіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CountHideText = new System.Windows.Forms.ToolStripMenuItem();
            this.HideCountBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ВихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.допомогаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ВерсіяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Map
            // 
            this.Map.AllowUserToAddRows = false;
            this.Map.AllowUserToDeleteRows = false;
            this.Map.AllowUserToResizeColumns = false;
            this.Map.AllowUserToResizeRows = false;
            this.Map.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Map.ColumnHeadersVisible = false;
            this.Map.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Map.DefaultCellStyle = dataGridViewCellStyle1;
            this.Map.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Map.Enabled = false;
            this.Map.Location = new System.Drawing.Point(12, 36);
            this.Map.MultiSelect = false;
            this.Map.Name = "Map";
            this.Map.RowHeadersVisible = false;
            this.Map.RowTemplate.Height = 32;
            this.Map.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Map.Size = new System.Drawing.Size(291, 291);
            this.Map.TabIndex = 0;
            this.Map.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Map_CellEnter);
            this.Map.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Map_CellMouseClick);
            this.Map.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Map_KeyPress);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 32;
            this.Column1.Name = "Column1";
            this.Column1.Width = 32;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.MinimumWidth = 32;
            this.Column2.Name = "Column2";
            this.Column2.Width = 32;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.MinimumWidth = 32;
            this.Column3.Name = "Column3";
            this.Column3.Width = 32;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.MinimumWidth = 32;
            this.Column4.Name = "Column4";
            this.Column4.Width = 32;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.MinimumWidth = 32;
            this.Column5.Name = "Column5";
            this.Column5.Width = 32;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.MinimumWidth = 32;
            this.Column6.Name = "Column6";
            this.Column6.Width = 32;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.MinimumWidth = 32;
            this.Column7.Name = "Column7";
            this.Column7.Width = 32;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.MinimumWidth = 32;
            this.Column8.Name = "Column8";
            this.Column8.Width = 32;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Column9";
            this.Column9.MinimumWidth = 32;
            this.Column9.Name = "Column9";
            this.Column9.Width = 32;
            // 
            // ButtonCheck
            // 
            this.ButtonCheck.Enabled = false;
            this.ButtonCheck.Location = new System.Drawing.Point(12, 333);
            this.ButtonCheck.Name = "ButtonCheck";
            this.ButtonCheck.Size = new System.Drawing.Size(291, 23);
            this.ButtonCheck.TabIndex = 1;
            this.ButtonCheck.Text = "Перевірити";
            this.ButtonCheck.UseVisualStyleBackColor = true;
            this.ButtonCheck.Click += new System.EventHandler(this.ButtonCheck_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MessageStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 368);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(315, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MessageStrip
            // 
            this.MessageStrip.Name = "MessageStrip";
            this.MessageStrip.Size = new System.Drawing.Size(77, 17);
            this.MessageStrip.Text = "MessageStrip";
            this.MessageStrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.допомогаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(315, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.НоваГраStrip,
            this.ОчиститиtoolStrip,
            this.РівеньСкладностіToolStripMenuItem,
            this.toolStripSeparator1,
            this.ВихідToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(38, 20);
            this.toolStripMenuItem1.Text = "Гра";
            // 
            // НоваГраStrip
            // 
            this.НоваГраStrip.Name = "НоваГраStrip";
            this.НоваГраStrip.Size = new System.Drawing.Size(204, 22);
            this.НоваГраStrip.Text = "Нова гра...";
            this.НоваГраStrip.Click += new System.EventHandler(this.НоваГраStrip_Click);
            // 
            // ОчиститиtoolStrip
            // 
            this.ОчиститиtoolStrip.Enabled = false;
            this.ОчиститиtoolStrip.Name = "ОчиститиtoolStrip";
            this.ОчиститиtoolStrip.Size = new System.Drawing.Size(204, 22);
            this.ОчиститиtoolStrip.Text = "Очистити введені дані...";
            this.ОчиститиtoolStrip.Click += new System.EventHandler(this.ОчиститиtoolStrip_Click);
            // 
            // РівеньСкладностіToolStripMenuItem
            // 
            this.РівеньСкладностіToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CountHideText,
            this.HideCountBox});
            this.РівеньСкладностіToolStripMenuItem.Name = "РівеньСкладностіToolStripMenuItem";
            this.РівеньСкладностіToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.РівеньСкладностіToolStripMenuItem.Text = "Рівень складності...";
            this.РівеньСкладностіToolStripMenuItem.DropDownClosed += new System.EventHandler(this.РівеньСкладностіToolStripMenuItem_DropDownClosed);
            // 
            // CountHideText
            // 
            this.CountHideText.Enabled = false;
            this.CountHideText.Name = "CountHideText";
            this.CountHideText.Size = new System.Drawing.Size(210, 22);
            this.CountHideText.Text = "Кількість приховувань :";
            // 
            // HideCountBox
            // 
            this.HideCountBox.Name = "HideCountBox";
            this.HideCountBox.Size = new System.Drawing.Size(150, 23);
            this.HideCountBox.Text = "3";
            this.HideCountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HideCountBox_KeyPress);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // ВихідToolStripMenuItem
            // 
            this.ВихідToolStripMenuItem.Name = "ВихідToolStripMenuItem";
            this.ВихідToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.ВихідToolStripMenuItem.Text = "Вихід";
            this.ВихідToolStripMenuItem.Click += new System.EventHandler(this.ВихідToolStripMenuItem_Click);
            // 
            // допомогаToolStripMenuItem
            // 
            this.допомогаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ВерсіяToolStripMenuItem});
            this.допомогаToolStripMenuItem.Name = "допомогаToolStripMenuItem";
            this.допомогаToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.допомогаToolStripMenuItem.Text = "Допомога";
            // 
            // ВерсіяToolStripMenuItem
            // 
            this.ВерсіяToolStripMenuItem.Name = "ВерсіяToolStripMenuItem";
            this.ВерсіяToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.ВерсіяToolStripMenuItem.Text = "Версія...";
            this.ВерсіяToolStripMenuItem.Click += new System.EventHandler(this.ВерсіяToolStripMenuItem_Click_1);
            // 
            // SudokuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 390);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ButtonCheck);
            this.Controls.Add(this.Map);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SudokuForm";
            this.Text = "Судоку";
            ((System.ComponentModel.ISupportInitialize)(this.Map)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Map;
        private System.Windows.Forms.Button ButtonCheck;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem НоваГраStrip;
        private System.Windows.Forms.ToolStripMenuItem ВихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem допомогаToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel MessageStrip;
        private System.Windows.Forms.ToolStripMenuItem РівеньСкладностіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ВерсіяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CountHideText;
        private System.Windows.Forms.ToolStripTextBox HideCountBox;
        private System.Windows.Forms.ToolStripMenuItem ОчиститиtoolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

