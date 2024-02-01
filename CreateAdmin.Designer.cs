namespace Журнал_V_Dip
{
    partial class CreateAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAdmin));
            this.YearBox = new System.Windows.Forms.ComboBox();
            this.GroupBox = new System.Windows.Forms.ComboBox();
            this.ObjectBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateB = new System.Windows.Forms.Button();
            this.CloseB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // YearBox
            // 
            this.YearBox.BackColor = System.Drawing.SystemColors.Window;
            this.YearBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.YearBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.YearBox.FormattingEnabled = true;
            this.YearBox.Location = new System.Drawing.Point(12, 31);
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(139, 21);
            this.YearBox.TabIndex = 0;
            this.YearBox.DropDown += new System.EventHandler(this.ComboBox_DropDown);
            this.YearBox.SelectedIndexChanged += new System.EventHandler(this.YearBox_SelectedIndexChanged);
            this.YearBox.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            // 
            // GroupBox
            // 
            this.GroupBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.GroupBox.FormattingEnabled = true;
            this.GroupBox.Location = new System.Drawing.Point(157, 31);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(139, 21);
            this.GroupBox.TabIndex = 0;
            this.GroupBox.DropDown += new System.EventHandler(this.ComboBox_DropDown);
            this.GroupBox.SelectedIndexChanged += new System.EventHandler(this.GroupBox_SelectedIndexChanged);
            this.GroupBox.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            // 
            // ObjectBox
            // 
            this.ObjectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObjectBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ObjectBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ObjectBox.FormattingEnabled = true;
            this.ObjectBox.Location = new System.Drawing.Point(302, 31);
            this.ObjectBox.Name = "ObjectBox";
            this.ObjectBox.Size = new System.Drawing.Size(139, 21);
            this.ObjectBox.TabIndex = 0;
            this.ObjectBox.DropDown += new System.EventHandler(this.ComboBox_DropDown);
            this.ObjectBox.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Год поступления";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(157, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Номер группы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(298, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Предмет";
            // 
            // CreateB
            // 
            this.CreateB.Location = new System.Drawing.Point(12, 67);
            this.CreateB.Name = "CreateB";
            this.CreateB.Size = new System.Drawing.Size(139, 21);
            this.CreateB.TabIndex = 2;
            this.CreateB.Text = "Создать таблицу";
            this.CreateB.UseVisualStyleBackColor = true;
            this.CreateB.Click += new System.EventHandler(this.CreateB_Click);
            // 
            // CloseB
            // 
            this.CloseB.Location = new System.Drawing.Point(302, 67);
            this.CloseB.Name = "CloseB";
            this.CloseB.Size = new System.Drawing.Size(139, 21);
            this.CloseB.TabIndex = 2;
            this.CloseB.Text = "Отмена";
            this.CloseB.UseVisualStyleBackColor = true;
            this.CloseB.Click += new System.EventHandler(this.CloseB_Click);
            // 
            // CreateAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 100);
            this.Controls.Add(this.CloseB);
            this.Controls.Add(this.CreateB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ObjectBox);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.YearBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateAdmin";
            this.Text = "Создание таблицы";
            this.Load += new System.EventHandler(this.CreateAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox YearBox;
        private System.Windows.Forms.ComboBox GroupBox;
        private System.Windows.Forms.ComboBox ObjectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreateB;
        private System.Windows.Forms.Button CloseB;
    }
}