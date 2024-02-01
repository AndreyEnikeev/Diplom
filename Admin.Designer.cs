namespace Журнал_V_Dip
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MenuFunc = new System.Windows.Forms.MenuStrip();
            this.работаСТаблицамиToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСтолбецToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСтрочкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ДобавитьНесколькоСтрочекMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСтолбецToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСтрочкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.созданиеТаблицToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.соданиеОпределёнойТаблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.созданиеКластераТаблицToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTable = new System.Windows.Forms.MenuStrip();
            this.стандартныеТаблицыToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.студентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преподавателиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предметыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.специальностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.паролиMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вывестиСписокВсехТаблицMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьПоНазваниюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.MenuFunc.SuspendLayout();
            this.MenuTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(196, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(510, 451);
            this.dataGridView1.TabIndex = 0;
            // 
            // MenuFunc
            // 
            this.MenuFunc.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuFunc.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MenuFunc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.работаСТаблицамиToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.добавитьСтолбецToolStripMenuItem,
            this.добавитьСтрочкуToolStripMenuItem,
            this.ДобавитьНесколькоСтрочекMenuItem,
            this.удалитьСтолбецToolStripMenuItem,
            this.удалитьСтрочкуToolStripMenuItem,
            this.созданиеТаблицToolStripMenuItem,
            this.информацияToolStripMenuItem,
            this.соданиеОпределёнойТаблицыToolStripMenuItem,
            this.созданиеКластераТаблицToolStripMenuItem});
            this.MenuFunc.Location = new System.Drawing.Point(0, 0);
            this.MenuFunc.Name = "MenuFunc";
            this.MenuFunc.Size = new System.Drawing.Size(196, 451);
            this.MenuFunc.TabIndex = 2;
            this.MenuFunc.Text = "menuStrip2";
            // 
            // работаСТаблицамиToolStripMenuItem
            // 
            this.работаСТаблицамиToolStripMenuItem.Enabled = false;
            this.работаСТаблицамиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.работаСТаблицамиToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.работаСТаблицамиToolStripMenuItem.Name = "работаСТаблицамиToolStripMenuItem";
            this.работаСТаблицамиToolStripMenuItem.ReadOnly = true;
            this.работаСТаблицамиToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.работаСТаблицамиToolStripMenuItem.Text = "Работа с таблицами";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(189, 19);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // добавитьСтолбецToolStripMenuItem
            // 
            this.добавитьСтолбецToolStripMenuItem.Name = "добавитьСтолбецToolStripMenuItem";
            this.добавитьСтолбецToolStripMenuItem.Size = new System.Drawing.Size(189, 19);
            this.добавитьСтолбецToolStripMenuItem.Text = "Добавить столбец";
            this.добавитьСтолбецToolStripMenuItem.Click += new System.EventHandler(this.добавитьСтолбецToolStripMenuItem_Click);
            // 
            // добавитьСтрочкуToolStripMenuItem
            // 
            this.добавитьСтрочкуToolStripMenuItem.Name = "добавитьСтрочкуToolStripMenuItem";
            this.добавитьСтрочкуToolStripMenuItem.Size = new System.Drawing.Size(189, 19);
            this.добавитьСтрочкуToolStripMenuItem.Text = "Добавить строчку";
            this.добавитьСтрочкуToolStripMenuItem.Click += new System.EventHandler(this.добавитьСтрочкуToolStripMenuItem_Click);
            // 
            // ДобавитьНесколькоСтрочекMenuItem
            // 
            this.ДобавитьНесколькоСтрочекMenuItem.Name = "ДобавитьНесколькоСтрочекMenuItem";
            this.ДобавитьНесколькоСтрочекMenuItem.Size = new System.Drawing.Size(189, 19);
            this.ДобавитьНесколькоСтрочекMenuItem.Text = "Добавить несколько строчек";
            this.ДобавитьНесколькоСтрочекMenuItem.Click += new System.EventHandler(this.ДобавитьНесколькоСтрочекMenuItem_Click);
            // 
            // удалитьСтолбецToolStripMenuItem
            // 
            this.удалитьСтолбецToolStripMenuItem.Name = "удалитьСтолбецToolStripMenuItem";
            this.удалитьСтолбецToolStripMenuItem.Size = new System.Drawing.Size(189, 19);
            this.удалитьСтолбецToolStripMenuItem.Text = "Удалить столбец";
            this.удалитьСтолбецToolStripMenuItem.Click += new System.EventHandler(this.удалитьСтолбецToolStripMenuItem_Click);
            // 
            // удалитьСтрочкуToolStripMenuItem
            // 
            this.удалитьСтрочкуToolStripMenuItem.Name = "удалитьСтрочкуToolStripMenuItem";
            this.удалитьСтрочкуToolStripMenuItem.Size = new System.Drawing.Size(189, 19);
            this.удалитьСтрочкуToolStripMenuItem.Text = "Удалить строчку";
            this.удалитьСтрочкуToolStripMenuItem.Click += new System.EventHandler(this.удалитьСтрочкуToolStripMenuItem_Click);
            // 
            // созданиеТаблицToolStripMenuItem
            // 
            this.созданиеТаблицToolStripMenuItem.Enabled = false;
            this.созданиеТаблицToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.созданиеТаблицToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.созданиеТаблицToolStripMenuItem.Name = "созданиеТаблицToolStripMenuItem";
            this.созданиеТаблицToolStripMenuItem.ReadOnly = true;
            this.созданиеТаблицToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.созданиеТаблицToolStripMenuItem.Text = "Управления таблицами";
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(189, 19);
            this.информацияToolStripMenuItem.Text = "Информация";
            this.информацияToolStripMenuItem.Click += new System.EventHandler(this.информацияToolStripMenuItem_Click);
            // 
            // соданиеОпределёнойТаблицыToolStripMenuItem
            // 
            this.соданиеОпределёнойТаблицыToolStripMenuItem.Name = "соданиеОпределёнойТаблицыToolStripMenuItem";
            this.соданиеОпределёнойТаблицыToolStripMenuItem.Size = new System.Drawing.Size(189, 19);
            this.соданиеОпределёнойТаблицыToolStripMenuItem.Text = "Содание определёной таблицы";
            this.соданиеОпределёнойТаблицыToolStripMenuItem.Click += new System.EventHandler(this.соданиеОпределёнойТаблицыToolStripMenuItem_Click);
            // 
            // созданиеКластераТаблицToolStripMenuItem
            // 
            this.созданиеКластераТаблицToolStripMenuItem.Name = "созданиеКластераТаблицToolStripMenuItem";
            this.созданиеКластераТаблицToolStripMenuItem.Size = new System.Drawing.Size(189, 19);
            this.созданиеКластераТаблицToolStripMenuItem.Text = "Создание кластера таблиц";
            this.созданиеКластераТаблицToolStripMenuItem.Click += new System.EventHandler(this.созданиеКластераТаблицToolStripMenuItem_Click);
            // 
            // MenuTable
            // 
            this.MenuTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.MenuTable.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MenuTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стандартныеТаблицыToolStripMenuItem,
            this.студентыToolStripMenuItem,
            this.преподавателиToolStripMenuItem,
            this.группыToolStripMenuItem,
            this.предметыToolStripMenuItem,
            this.специальностиToolStripMenuItem,
            this.toolStripMenuItem1,
            this.паролиMenuItem,
            this.вывестиСписокВсехТаблицMenuItem,
            this.загрузитьПоНазваниюToolStripMenuItem});
            this.MenuTable.Location = new System.Drawing.Point(706, 0);
            this.MenuTable.Name = "MenuTable";
            this.MenuTable.Size = new System.Drawing.Size(178, 451);
            this.MenuTable.TabIndex = 3;
            this.MenuTable.Text = "menuStrip1";
            // 
            // стандартныеТаблицыToolStripMenuItem
            // 
            this.стандартныеТаблицыToolStripMenuItem.Enabled = false;
            this.стандартныеТаблицыToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.стандартныеТаблицыToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.стандартныеТаблицыToolStripMenuItem.Name = "стандартныеТаблицыToolStripMenuItem";
            this.стандартныеТаблицыToolStripMenuItem.ReadOnly = true;
            this.стандартныеТаблицыToolStripMenuItem.Size = new System.Drawing.Size(169, 23);
            this.стандартныеТаблицыToolStripMenuItem.Text = "Стандартные таблицы";
            this.стандартныеТаблицыToolStripMenuItem.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // студентыToolStripMenuItem
            // 
            this.студентыToolStripMenuItem.Name = "студентыToolStripMenuItem";
            this.студентыToolStripMenuItem.Size = new System.Drawing.Size(171, 19);
            this.студентыToolStripMenuItem.Text = "Студенты";
            this.студентыToolStripMenuItem.Click += new System.EventHandler(this.СтудентыToolStripMenuItem_Click);
            // 
            // преподавателиToolStripMenuItem
            // 
            this.преподавателиToolStripMenuItem.Name = "преподавателиToolStripMenuItem";
            this.преподавателиToolStripMenuItem.Size = new System.Drawing.Size(171, 19);
            this.преподавателиToolStripMenuItem.Text = "Преподаватели";
            this.преподавателиToolStripMenuItem.Click += new System.EventHandler(this.ПреподавателиToolStripMenuItem_Click);
            // 
            // группыToolStripMenuItem
            // 
            this.группыToolStripMenuItem.Name = "группыToolStripMenuItem";
            this.группыToolStripMenuItem.Size = new System.Drawing.Size(171, 19);
            this.группыToolStripMenuItem.Text = "Группы";
            this.группыToolStripMenuItem.Click += new System.EventHandler(this.группыToolStripMenuItem_Click);
            // 
            // предметыToolStripMenuItem
            // 
            this.предметыToolStripMenuItem.Name = "предметыToolStripMenuItem";
            this.предметыToolStripMenuItem.Size = new System.Drawing.Size(171, 19);
            this.предметыToolStripMenuItem.Text = "Предметы";
            this.предметыToolStripMenuItem.Click += new System.EventHandler(this.предметыToolStripMenuItem_Click);
            // 
            // специальностиToolStripMenuItem
            // 
            this.специальностиToolStripMenuItem.Name = "специальностиToolStripMenuItem";
            this.специальностиToolStripMenuItem.Size = new System.Drawing.Size(171, 19);
            this.специальностиToolStripMenuItem.Text = "Специальности";
            this.специальностиToolStripMenuItem.Click += new System.EventHandler(this.специальностиToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ReadOnly = true;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 23);
            this.toolStripMenuItem1.Text = "Другие таблицы";
            this.toolStripMenuItem1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // паролиMenuItem
            // 
            this.паролиMenuItem.Name = "паролиMenuItem";
            this.паролиMenuItem.Size = new System.Drawing.Size(171, 19);
            this.паролиMenuItem.Text = "Пароли";
            this.паролиMenuItem.Click += new System.EventHandler(this.паролиMenuItem_Click);
            // 
            // вывестиСписокВсехТаблицMenuItem
            // 
            this.вывестиСписокВсехТаблицMenuItem.Name = "вывестиСписокВсехТаблицMenuItem";
            this.вывестиСписокВсехТаблицMenuItem.Size = new System.Drawing.Size(171, 19);
            this.вывестиСписокВсехТаблицMenuItem.Text = "Вывести список всех таблиц";
            this.вывестиСписокВсехТаблицMenuItem.Click += new System.EventHandler(this.вывестиСписокВсехТаблицMenuItem_Click);
            // 
            // загрузитьПоНазваниюToolStripMenuItem
            // 
            this.загрузитьПоНазваниюToolStripMenuItem.Name = "загрузитьПоНазваниюToolStripMenuItem";
            this.загрузитьПоНазваниюToolStripMenuItem.Size = new System.Drawing.Size(171, 19);
            this.загрузитьПоНазваниюToolStripMenuItem.Text = "Загрузить по названию";
            this.загрузитьПоНазваниюToolStripMenuItem.Click += new System.EventHandler(this.загрузитьПоНазваниюToolStripMenuItem_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 451);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.MenuFunc);
            this.Controls.Add(this.MenuTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.Text = "Администратор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_FormClosing);
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.MenuFunc.ResumeLayout(false);
            this.MenuFunc.PerformLayout();
            this.MenuTable.ResumeLayout(false);
            this.MenuTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip MenuFunc;
        private System.Windows.Forms.ToolStripTextBox стандартныеТаблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem студентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преподавателиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предметыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem специальностиToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MenuTable;
        private System.Windows.Forms.ToolStripTextBox работаСТаблицамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСтолбецToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСтрочкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСтолбецToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСтрочкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьПоНазваниюToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem паролиMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вывестиСписокВсехТаблицMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ДобавитьНесколькоСтрочекMenuItem;
        private System.Windows.Forms.ToolStripTextBox созданиеТаблицToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem соданиеОпределёнойТаблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem созданиеКластераТаблицToolStripMenuItem;
    }
}