using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Журнал_V_Dip
{
    public partial class CreateAdmin : Form
    {
        private readonly SqlConnection connection;
        private SqlDataAdapter adapter= new SqlDataAdapter();
        DataSet dataSet = new DataSet();
        private string sql, table=string.Empty;

        public CreateAdmin(SqlConnection connection)
        {
            InitializeComponent();


            this.connection = connection;
            dataSet.Tables.Add("Object");
            dataSet.Tables.Add("Studen");
            dataSet.Tables.Add("Exist");
        }

        private void CreateAdmin_Load(object sender, EventArgs e)
        {
            dataSet.Clear();
            YearBox.Items.Clear();
            GroupBox.Items.Clear();
            ObjectBox.Items.Clear();

            YearBox.Items.Add("Год");
            YearBox.SelectedItem = "Год";
            GroupBox.Items.Add("Группа");
            GroupBox.SelectedItem = "Группа";
            GroupBox.Enabled = false;
            ObjectBox.Items.Add("Предмет");
            ObjectBox.SelectedItem = "Предмет";
            ObjectBox.Enabled = false;


            SqlCommand sqlCommand= new SqlCommand();
            sqlCommand.Connection = connection;


            sql = "select year([Дата поступления группы]) as [Год] from[Группы] WHERE [Номер группы] NOT LIKE N'Введите номер группы' ORDER BY [Год] ";
            adapter.SelectCommand = new SqlCommand(sql, connection);
            adapter.Fill(dataSet, "Groupe");

            for (int i = 0; i < dataSet.Tables["Groupe"].Rows.Count; i++)
            {
                YearBox.Items.Add(dataSet.Tables["Groupe"].Rows[i].ItemArray[0].ToString());
            }


            /*
                        for (int i = 0; i < dataSet.Tables["Groupe"].Rows.Count; i++)
                        {
                            sqlcreat = "SELECT * FROM [Студенты] WHERE [Код группы]=" + dataSet.Tables["Groupe"].Rows[i][0].ToString();
                            adapter.SelectCommand = new SqlCommand(sqlcreat, connection);
                            adapter.Fill(dataSet, "Studen");


                            sqlcreat = "SELECT * FROM [Предметы] WHERE [Id специальности]=" + dataSet.Tables["Groupe"].Rows[i][1].ToString() + " AND [Семестр обучения]=" + dataSet.Tables["Groupe"].Rows[i][4].ToString();
                            adapter.SelectCommand = new SqlCommand(sqlcreat, connection);
                            adapter.Fill(dataSet, "Object");

                            if (dataSet.Tables["Object"].Rows.Count > 0)
                            {
                                for (int c = 3; c < dataSet.Tables["Object"].Columns.Count; c++)
                                {
                                    TableCheack = dataSet.Tables["Groupe"].Rows[i][2].ToString() + "_" + dataSet.Tables["Object"].Rows[0][c].ToString() + "_" + dataSet.Tables["Groupe"].Rows[i][3].ToString();
                                    for (int cheack = 0; cheack < dataSet.Tables["Exist"].Rows.Count; cheack++)
                                    {
                                        if (dataSet.Tables["Exist"].Rows[cheack][0].ToString() == TableCheack)
                                        {
                                            TableCheack = string.Empty;
                                            break;
                                        }
                                    }
                                    if (TableCheack != string.Empty)
                                    {
                                        sqlCommand.CommandText = "CREATE TABLE [" + TableCheack + "] ([Id] int NOT NULL, [Предмет] nvarchar(200) NOT NULL, [Студент] nvarchar(200) NOT NULL, [Дата 1]  nvarchar(100), [Дата 2]  nvarchar(100), [Дата 3]  nvarchar(100), [Дата 4]  nvarchar(100),  PRIMARY KEY(Id)); ";
                                        sqlCommand.ExecuteNonQuery();


                                        sqlcreat = "INSERT INTO [" + TableCheack + "] VALUES (1, N'Дата', N'Дата', N'**//****', N'**//****',N'**//****',N'**//****');";
                                        for (int Stud = 0; Stud < dataSet.Tables["Studen"].Rows.Count; Stud++)
                                        {
                                            sqlcreat += "INSERT INTO [" + TableCheack + "] VALUES (" + dataSet.Tables["Studen"].Rows[Stud][0].ToString() + ", N'" + dataSet.Tables["Object"].Rows[0][c].ToString() + "', N'" + dataSet.Tables["Studen"].Rows[Stud][2].ToString() + "', NULL, NULL, NULL, NULL);";
                                        }
                                        sqlCommand.CommandText = sqlcreat;
                                        sqlCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                            dataSet.Tables["Studen"].Clear();
                            dataSet.Tables["Object"].Clear();
                        }

            */


        }



        private void ComboBox_DropDown(object sender, EventArgs e)
        {
            if (sender.Equals(YearBox))
            {
                YearBox.Items.Remove("Год");
            }
            else
            {
                if (sender.Equals(GroupBox))
                {
                    GroupBox.Items.Remove("Группа");
                }
                else
                {
                    if (sender.Equals(ObjectBox))
                    {
                        ObjectBox.Items.Remove("Предмет");
                    }
                }
            }
        }
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (sender.Equals(YearBox))
            {
                if (YearBox.SelectedIndex == -1)
                {
                    YearBox.Items.Add("Год");
                    YearBox.SelectedItem = "Год";
                }
            }
            else
            {
                if (sender.Equals(GroupBox))
                {
                    if (GroupBox.SelectedIndex == -1)
                    {
                        GroupBox.Items.Add("Группа");
                        GroupBox.SelectedItem = "Группа";
                    }
                }
                else
                {
                    if (sender.Equals(ObjectBox))
                    {
                        if (ObjectBox.SelectedIndex == -1)
                        {
                            ObjectBox.Items.Add("Предмет");
                            ObjectBox.SelectedItem = "Предмет";
                        }
                    }
                }
            }
        }



        private void YearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((YearBox.Items[YearBox.SelectedIndex].ToString() != "" && YearBox.Items[YearBox.SelectedIndex].ToString() != "Год") && YearBox.SelectedIndex != -1)
            {
                GroupBox.Items.Clear();
                ObjectBox.Items.Clear();
                dataSet.Tables["Groupe"].Clear();


                GroupBox.Items.Add("Группа");
                GroupBox.SelectedItem = "Группа";
                ObjectBox.Items.Add("Предмет");
                ObjectBox.SelectedItem = "Предмет";
                ObjectBox.Enabled = false;


                sql = "select [Номер группы] from [Группы] WHERE [Номер группы] NOT LIKE N'Введите номер группы' AND year([Дата поступления группы]) = year('" + YearBox.Items[YearBox.SelectedIndex].ToString() + "')  ORDER BY [Номер группы]";
                adapter.SelectCommand = new SqlCommand(sql, connection);
                adapter.Fill(dataSet, "Groupe");

                for (int i = 0; i < dataSet.Tables["Groupe"].Rows.Count; i++)
                {
                    GroupBox.Items.Add(dataSet.Tables["Groupe"].Rows[i].ItemArray[1].ToString());
                }
                GroupBox.Enabled = true;
            }
        }

        private void GroupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((GroupBox.Items[GroupBox.SelectedIndex].ToString() != "" && GroupBox.Items[GroupBox.SelectedIndex].ToString() != "Группа") && GroupBox.SelectedIndex != -1)
            {
                ObjectBox.Items.Clear();
                dataSet.Tables["Groupe"].Clear();
                dataSet.Tables["Object"].Clear();


                ObjectBox.Items.Add("Предмет");
                ObjectBox.SelectedItem = "Предмет";

                sql = "if (month(GETDATE()) BETWEEN 1 AND 7) " +
                        "select [Номер группы], year([Дата поступления группы]) as [Год], [Код группы], [Id специальности], (year(GEtdate()) - year([Дата поступления группы]))*2 as [Семестр] from [Группы] WHERE [Номер группы] = N'" + GroupBox.Items[GroupBox.SelectedIndex].ToString() + "' AND year ([Дата поступления группы]) = year('" + YearBox.Items[YearBox.SelectedIndex].ToString() + "')" +
                        "else select [Номер группы], year([Дата поступления группы]) as [Год], [Код группы], [Id специальности], (year(GEtdate()) - year([Дата поступления группы]))*2 + 1 as [Семестр] from [Группы] WHERE [Номер группы] = N'" + GroupBox.Items[GroupBox.SelectedIndex].ToString() + "' AND year ([Дата поступления группы]) = year('" + YearBox.Items[YearBox.SelectedIndex].ToString() + "')";
                // sql = "select [Номер группы] from [Группы] WHERE [Номер группы] = N'"+ GroupBox.Items[GroupBox.SelectedIndex].ToString() + "' AND year([Дата поступления группы]) = year('" + YearBox.Items[YearBox.SelectedIndex].ToString() + "')  ORDER BY [Год], [Номер группы]";
                // sql = "select [Номер группы] from [Группы] WHERE [Номер группы] NOT LIKE N'Введите номер группы' AND year([Дата поступления группы]) = year('" + YearBox.Items[YearBox.SelectedIndex].ToString() + "')  ORDER BY [Номер группы]";
                adapter.SelectCommand = new SqlCommand(sql, connection);
                adapter.Fill(dataSet, "Groupe");


                sql = "SELECT * FROM [Предметы] WHERE [Id специальности]=" + dataSet.Tables["Groupe"].Rows[0][3].ToString() + " AND [Семестр обучения]=" + dataSet.Tables["Groupe"].Rows[0][4].ToString();
                adapter.SelectCommand = new SqlCommand(sql, connection);
                adapter.Fill(dataSet, "Object");

                if (dataSet.Tables["Object"].Rows.Count > 0)
                {
                    for (int i = 3; i < dataSet.Tables["Object"].Columns.Count; i++)
                    {
                        if (dataSet.Tables["Object"].Rows[0].ItemArray[i].ToString() != "")
                        {
                            ObjectBox.Items.Add(dataSet.Tables["Object"].Rows[0].ItemArray[i].ToString());
                        }
                    }
                }
                ObjectBox.Enabled = true;
            }
        }

        private void CloseB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateB_Click(object sender, EventArgs e)
        {
            try
            {
                if (YearBox.Items[YearBox.SelectedIndex].ToString() == "" || YearBox.Items[YearBox.SelectedIndex].ToString() == "Год")
                {
                    MessageBox.Show("Вы не выбрали год.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    if (GroupBox.Items[GroupBox.SelectedIndex].ToString() == "" || GroupBox.Items[GroupBox.SelectedIndex].ToString() == "Группа")
                    {
                        MessageBox.Show("Вы не выбрали группу.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        if (ObjectBox.Items[ObjectBox.SelectedIndex].ToString() == "" || ObjectBox.Items[ObjectBox.SelectedIndex].ToString() == "Предмет")
                        {
                            MessageBox.Show("Вы не выбрали предмет.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string CreatTable= GroupBox.Items[GroupBox.SelectedIndex].ToString()+"_"+ObjectBox.Items[ObjectBox.SelectedIndex].ToString()+"_"+YearBox.Items[YearBox.SelectedIndex].ToString();


                            dataSet.Tables["Exist"].Clear();
                            sql = "SELECT [TABLE_NAME] FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME=N'" + CreatTable + "';";
                            adapter.SelectCommand = new SqlCommand(sql, connection);
                            adapter.Fill(dataSet, "Exist");
                            if (dataSet.Tables["Exist"].Rows.Count > 0)
                            {
                                MessageBox.Show("Данная таблица существует.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                dataSet.Tables["Studen"].Clear();
                                sql = "SELECT * FROM [Студенты] WHERE [Код группы]=" + dataSet.Tables["Groupe"].Rows[0][2].ToString();
                                adapter.SelectCommand = new SqlCommand(sql, connection);
                                adapter.Fill(dataSet, "Studen");


                                SqlCommand sqlCommand=new SqlCommand("", connection);
                                sqlCommand.CommandText = "CREATE TABLE [" + CreatTable + "] ([Id] int NOT NULL, [Предмет] nvarchar(200) NOT NULL, [Студент] nvarchar(200) NOT NULL, [Дата 1]  nvarchar(100), [Дата 2]  nvarchar(100), [Дата 3]  nvarchar(100), [Дата 4]  nvarchar(100),  PRIMARY KEY(Id)); ";
                                sqlCommand.ExecuteNonQuery();


                                sql = "INSERT INTO [" + CreatTable + "] VALUES (1, N'Дата', N'Дата', N'**/**/****', N'**/**/****',N'**/**/****',N'**/**/****');";
                                for (int Stud = 0; Stud < dataSet.Tables["Studen"].Rows.Count; Stud++)
                                {
                                    sql += "INSERT INTO [" + CreatTable + "] VALUES (" + dataSet.Tables["Studen"].Rows[Stud][0].ToString() + ", N'" + ObjectBox.Items[ObjectBox.SelectedIndex].ToString() + "', N'" + dataSet.Tables["Studen"].Rows[Stud][2].ToString() + "', NULL, NULL, NULL, NULL);";
                                }
                                sqlCommand.CommandText = sql;
                                sqlCommand.ExecuteNonQuery();
                                MessageBox.Show("Была создана таблица " + CreatTable);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
