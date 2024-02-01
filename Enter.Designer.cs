namespace Журнал_V_Dip
{
    partial class Enter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Enter));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LoginText = new System.Windows.Forms.TextBox();
            this.PassworText = new System.Windows.Forms.TextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.PlaceComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(83, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(83, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Пароль";
            // 
            // LoginText
            // 
            this.LoginText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginText.Location = new System.Drawing.Point(12, 146);
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(249, 29);
            this.LoginText.TabIndex = 2;
            this.LoginText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_KeyPress);
            // 
            // PassworText
            // 
            this.PassworText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassworText.Location = new System.Drawing.Point(12, 208);
            this.PassworText.Name = "PassworText";
            this.PassworText.Size = new System.Drawing.Size(249, 29);
            this.PassworText.TabIndex = 3;
            this.PassworText.UseSystemPasswordChar = true;
            this.PassworText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_KeyPress);
            this.PassworText.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PassworText_PreviewKeyDown);
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(88, 243);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(94, 29);
            this.EnterButton.TabIndex = 4;
            this.EnterButton.Text = "Войти";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            this.EnterButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_KeyPress);
            // 
            // PlaceComboBox
            // 
            this.PlaceComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.PlaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlaceComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlaceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlaceComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PlaceComboBox.FormattingEnabled = true;
            this.PlaceComboBox.Location = new System.Drawing.Point(12, 83);
            this.PlaceComboBox.Name = "PlaceComboBox";
            this.PlaceComboBox.Size = new System.Drawing.Size(249, 28);
            this.PlaceComboBox.TabIndex = 1;
            this.PlaceComboBox.DropDown += new System.EventHandler(this.PlaceComboBox_DropDown);
            this.PlaceComboBox.DropDownClosed += new System.EventHandler(this.PlaceComboBox_DropDownClosed);
            this.PlaceComboBox.Click += new System.EventHandler(this.PlaceComboBox_Click);
            this.PlaceComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Учебное заведение";
            // 
            // Enter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 279);
            this.Controls.Add(this.PlaceComboBox);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.PassworText);
            this.Controls.Add(this.LoginText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Enter";
            this.Text = "Вход в электронный журнал";
            this.Load += new System.EventHandler(this.Enter_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LoginText;
        private System.Windows.Forms.TextBox PassworText;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.ComboBox PlaceComboBox;
        private System.Windows.Forms.Label label4;
    }
}

