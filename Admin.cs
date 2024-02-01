using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Журнал_V_Dip
{
    public partial class Admin : Form
    {
        private Form form2;
        private readonly DataTable Table = new DataTable();
        private SqlDataAdapter adapter= new SqlDataAdapter();
        private string sql, table=string.Empty;
        private readonly string place;
        private readonly SqlConnection connection;


        //Способы подключения БД, если она лежит на сервере

        //@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ОсновнаяБД; Integrated Security=True"
        //@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ОсновнаяБД;Integrated Security=False;User ID=TestUser;Password=Passwor";
        /*
          SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder();
          sqlConnection.DataSource = "(localdb)\\MSSQLLocalDB";
          sqlConnection.InitialCatalog = "ОсновнаяБД";
          sqlConnection.IntegratedSecurity = false;
          sqlConnection.UserID = "TestUser";                    
          sqlConnection.Password = "Passwor";
          MessageBox.Show(sqlConnection.ConnectionString);
          connection = new SqlConnection(sqlConnection.ConnectionString);
        */


        public Admin(string place)
        {
            InitializeComponent();

            this.place = "Пароли" + place;
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\Журналы" + place + ".mdf; Integrated Security=True");
        }


        private void addRows(int rcount, bool pas, string table)
        {
            string sqladd=string.Empty;
            if (pas)
            {
                using (SqlConnection connectionForPassword = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\ОсновнаяБД.mdf; Integrated Security=True"))
                {
                    connectionForPassword.Open();


                    for (int ri = 1; ri <= rcount; ri++)
                    {
                        sqladd += "INSERT INTO [" + table + "] VALUES (";
                        sqladd += Convert.ToString(Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0].ToString()) + ri) + ", N'SLogin', N'SPasswor', 0);";
                    }

                    SqlCommand command= new SqlCommand(sqladd , connectionForPassword);
                    command.ExecuteNonQuery();

                    connectionForPassword.Close();
                }
            }
            else
            {
                for (int ri = 1; ri <= rcount; ri++)
                {
                    sqladd += "INSERT INTO [" + table + "] VALUES (";
                    if (table == "Студенты")
                    {
                        sqladd += Convert.ToString(Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0].ToString()) + ri) + ", 5, NULL);";
                    }
                    else
                    {
                        if (table == "Преподаватели")
                        {
                            sqladd += Convert.ToString(Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0].ToString()) + ri) + ", N'Введите ФИО'";
                            for (int i = 2; i < Table.Columns.Count; i++)
                            {
                                sqladd += ", NULL";
                            }
                            sqladd += ");";
                        }
                        else
                        {
                            if (table == "Группы")
                            {
                                sqladd += Convert.ToString(Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0].ToString()) + ri) + ", 1, N'Введите номер группы', GETDATE());";
                            }
                            else
                            {
                                if (table == "Предметы")
                                {
                                    sqladd += Convert.ToString(Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0].ToString()) + ri) + ", 1, 1";
                                    for (int i = 3; i < Table.Columns.Count; i++)
                                    {
                                        sqladd += ", NULL";
                                    }
                                    sqladd += ");";
                                }
                                else
                                {
                                    if (table == "Специальность")
                                    {
                                        sqladd += Convert.ToString(Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0].ToString()) + ri) + ", NULL, NULL, NULL);";
                                    }
                                    else
                                    {
                                        sqladd += Convert.ToString(Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0].ToString()) + ri) + ", N'" + table.Substring(table.IndexOf('_') + 1, table.LastIndexOf('_') - table.IndexOf('_') - 1) + "', N'Введите ФИО студента'";
                                        for (int i = 3; i < Table.Columns.Count; i++)
                                        {
                                            sqladd += ", NULL";
                                        }
                                        sqladd += ");";
                                    }
                                }
                            }
                        }
                    }
                }


                SqlCommand command= new SqlCommand(sqladd , connection);
                command.ExecuteNonQuery();
            }
        }


        private void SaveFunct()
        {
            dataGridView1.EndEdit();
            int y = dataGridView1.CurrentCellAddress.Y;
            int x = dataGridView1.CurrentCellAddress.X;
            if (y == 0)
            {
                dataGridView1.Rows[1].Cells[x].Selected = true;
                dataGridView1.Rows[1].Cells[x].Selected = false;
            }
            else
            {
                dataGridView1.Rows[0].Cells[x].Selected = true;
                dataGridView1.Rows[0].Cells[x].Selected = false;
            }


            if (table != place)
            {
                new SqlCommandBuilder(adapter);  // Билдер сам пишет команду для адаптера
                adapter.Update(Table);
            }
            else
            {
                using (SqlConnection connectionForPassword = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\ОсновнаяБД.mdf; Integrated Security=True"))
                {
                    connectionForPassword.Open();
                    adapter.SelectCommand = new SqlCommand(sql, connectionForPassword);
                    new SqlCommandBuilder(adapter);  // Билдер сам пишет команду для адаптера
                    adapter.Update(Table);
                    connectionForPassword.Close();
                }
            }
            dataGridView1.Rows[y].Cells[x].Selected = true;
        }


        private void LoadFunc(SqlConnection inconnection)
        {
            Table.Clear();
            Table.Rows.Clear();
            Table.Columns.Clear();
            dataGridView1.Columns.Clear();
            adapter.SelectCommand = new SqlCommand(sql, inconnection);
            adapter.Fill(Table);
            dataGridView1.DataSource = Table;
        }



        private void СтудентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuFunc.Enabled = true;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Visible = false;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Enabled = false;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Visible = false;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Enabled = false;
                sql = "SELECT * FROM [Студенты]";
                table = "Студенты";
                LoadFunc(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ПреподавателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuFunc.Enabled = true;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Visible = true;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Enabled = true;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Visible = true;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Enabled = true;
                sql = "SELECT * FROM [Преподаватели]";
                table = "Преподаватели";
                LoadFunc(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void группыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuFunc.Enabled = true;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Visible = false;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Enabled = false;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Visible = false;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Enabled = false;
                sql = "SELECT * FROM [Группы]";
                table = "Группы";
                LoadFunc(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void предметыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuFunc.Enabled = true;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Visible = true;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Enabled = true;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Visible = true;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Enabled = true;
                sql = "SELECT * FROM [Предметы]";
                table = "Предметы";
                LoadFunc(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void специальностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuFunc.Enabled = true;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Visible = false;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Enabled = false;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Visible = false;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Enabled = false;
                sql = "SELECT * FROM [Специальность]";
                table = "Специальность";
                LoadFunc(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void загрузитьПоНазваниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string time = Interaction.InputBox("Введите название таблицы для загрузки", "Загрузка в ручную", "");
                if (time != "")
                {
                    if (time.ToLower() == "студенты")
                    {
                        СтудентыToolStripMenuItem_Click(sender, e);
                    }
                    else
                    {
                        if (time.ToLower() == "преподаватели")
                        {
                            ПреподавателиToolStripMenuItem_Click(sender, e);
                        }
                        else
                        {
                            if (time.ToLower() == "группы")
                            {
                                группыToolStripMenuItem_Click(sender, e);
                            }
                            else
                            {
                                if (time.ToLower() == "предметы")
                                {
                                    предметыToolStripMenuItem_Click(sender, e);
                                }
                                else
                                {
                                    if (time.ToLower() == "специальность")
                                    {
                                        специальностиToolStripMenuItem_Click(sender, e);
                                    }
                                    else
                                    {
                                        if (time.ToLower() == place.ToLower())
                                        {
                                            паролиMenuItem_Click(sender, e);
                                        }
                                        else
                                        {
                                            MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Visible = true;
                                            MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Enabled = true;
                                            MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Visible = true;
                                            MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Enabled = true;
                                            MenuFunc.Enabled = true;
                                            sql = "SELECT * FROM [" + time + "]";
                                            table = time;
                                            LoadFunc(connection);
                                        }
                                    }
                                }
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


        private void Admin_Load(object sender, EventArgs e)
        {
            connection.Open();
        }
        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFunct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void паролиMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuFunc.Enabled = true;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Visible = false;
                MenuFunc.Items["удалитьСтолбецToolStripMenuItem"].Enabled = false;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Visible = false;
                MenuFunc.Items["добавитьСтолбецToolStripMenuItem"].Enabled = false;
                using (SqlConnection connectionForPassword = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\ОсновнаяБД.mdf; Integrated Security=True"))
                {
                    connectionForPassword.Open();
                    sql = "SELECT * FROM [" + place + "]";
                    table = place;
                    LoadFunc(connectionForPassword);
                    connectionForPassword.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void добавитьСтрочкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFunct();

                if (table == place)
                {
                    addRows(1, true, table);

                    using (SqlConnection connectionForPassword = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\ОсновнаяБД.mdf; Integrated Security=True"))
                    {
                        connectionForPassword.Open();
                        LoadFunc(connectionForPassword);
                        connectionForPassword.Close();
                    }
                }
                else
                {
                    addRows(1, false, table);
                    LoadFunc(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ДобавитьНесколькоСтрочекMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFunct();
                string time = Interaction.InputBox("Введите сколько нужно добавить строчек. Вводить только целове число", "Загрузка в ручную", "");
                if (time != "" && int.TryParse(time, out int i))
                {
                    if (i < 2)
                    {
                        MessageBox.Show("Введённые значение была меньше 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (table == place)
                        {
                            addRows(i, true, table);

                            using (SqlConnection connectionForPassword = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\ОсновнаяБД.mdf; Integrated Security=True"))
                            {
                                connectionForPassword.Open();
                                LoadFunc(connectionForPassword);
                                connectionForPassword.Close();
                            }
                        }
                        else
                        {
                            addRows(i, false, table);
                            LoadFunc(connection);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введённые данные не былы целочисленым значение", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void удалитьСтрочкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int i=dataGridView1.CurrentCellAddress.Y;
                SaveFunct();
                string sqldell=string.Empty;
                if (table == place)
                {
                    using (SqlConnection connectionForPassword = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\ОсновнаяБД.mdf; Integrated Security=True"))
                    {
                        connectionForPassword.Open();


                        sqldell = "DELETE FROM " + table + " WHERE " + Table.Columns[0].ColumnName.ToString() + "=" + Table.Rows[i][0].ToString();


                        SqlCommand command= new SqlCommand(sqldell , connectionForPassword);
                        command.ExecuteNonQuery();


                        LoadFunc(connectionForPassword);
                        connectionForPassword.Close();
                    }
                }
                else
                {
                    sqldell = "DELETE FROM [" + table + "] WHERE [" + Table.Columns[0].ColumnName.ToString() + "]=" + Table.Rows[i][0].ToString();


                    SqlCommand command= new SqlCommand(sqldell , connection);
                    command.ExecuteNonQuery();


                    LoadFunc(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void добавитьСтолбецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFunct();
                string sqlAddC=string.Empty;
                if (table == "Студенты" || table == place || table == "Группы" || table == "Специальность")
                {
                    MessageBox.Show("Я не знаю как вы это сделали, но в эту таблицу нельзя добавлять столбцы", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (table == "Преподаватели")
                    {
                        sqlAddC = "ALTER TABLE [" + table + "] ADD [Предмет " + Convert.ToString(dataGridView1.ColumnCount - 1) + "] NVARCHAR(100);";
                    }
                    else
                    {
                        if (table == "Предметы")
                        {
                            sqlAddC = "ALTER TABLE [" + table + "] ADD [Предмет " + Convert.ToString(dataGridView1.ColumnCount - 2) + "] NVARCHAR(100);";
                        }
                        else
                        {
                            sqlAddC = "ALTER TABLE [" + table + "] ADD [Дата " + Convert.ToString(dataGridView1.ColumnCount - 2) + "] NVARCHAR(100);";
                        }
                    }



                    SqlCommand command= new SqlCommand(sqlAddC , connection);
                    command.ExecuteNonQuery();


                    LoadFunc(connection);


                    dataGridView1.FirstDisplayedScrollingColumnIndex = dataGridView1.ColumnCount - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void удалитьСтолбецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int X=dataGridView1.CurrentCellAddress.X;
                string sqldellC=string.Empty;
                if (table == "Студенты" || table == place || table == "Группы" || table == "Специальность")
                {
                    MessageBox.Show("Я не знаю как вы это сделали, но в этой таблице нельзя удалять столбцы", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (table == "Преподаватели")
                    {
                        if (X == 0 || X == 1)
                        {
                            MessageBox.Show("Нельзя удалить этот столбец.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            for (int i = X; i < dataGridView1.ColumnCount - 1; i++)
                            {
                                for (int r = 0; r < dataGridView1.RowCount; r++)
                                {
                                    dataGridView1.Rows[r].Cells[i].Value = dataGridView1.Rows[r].Cells[i + 1].Value;
                                }
                            }
                            SaveFunct();
                            sqldellC = "ALTER TABLE [" + table + "] DROP COLUMN [" + dataGridView1.Columns[dataGridView1.ColumnCount - 1].Name.ToString() + "];";
                        }
                    }
                    else
                    {
                        if (table == "Предметы")
                        {
                            if (X == 0 || X == 1 || X == 2)
                            {
                                MessageBox.Show("Нельзя удалить этот столбец.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                for (int i = X; i < dataGridView1.ColumnCount - 1; i++)
                                {
                                    for (int r = 0; r < dataGridView1.RowCount; r++)
                                    {
                                        dataGridView1.Rows[r].Cells[i].Value = dataGridView1.Rows[r].Cells[i + 1].Value;
                                    }
                                }
                                SaveFunct();
                                sqldellC = "ALTER TABLE [" + table + "] DROP COLUMN [" + dataGridView1.Columns[dataGridView1.ColumnCount - 1].Name.ToString() + "];";
                            }
                        }
                        else
                        {
                            if (X == 0 || X == 1 || X == 2)
                            {
                                MessageBox.Show("Нельзя удалить этот столбец.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                for (int i = X; i < dataGridView1.ColumnCount - 1; i++)
                                {
                                    for (int r = 0; r < dataGridView1.RowCount; r++)
                                    {
                                        dataGridView1.Rows[r].Cells[i].Value = dataGridView1.Rows[r].Cells[i + 1].Value;
                                    }
                                }
                                SaveFunct();
                                sqldellC = "ALTER TABLE [" + table + "] DROP COLUMN [" + dataGridView1.Columns[dataGridView1.ColumnCount - 1].Name.ToString() + "];";
                            }
                        }
                    }
                    if (sqldellC != string.Empty)
                    {
                        SqlCommand command= new SqlCommand(sqldellC , connection);
                        command.ExecuteNonQuery();


                        LoadFunc(connection);
                        dataGridView1.FirstDisplayedScrollingColumnIndex = X;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void созданиеКластераТаблицToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Внимение, будут созданы все таблицы журналов, которых нету.\nЭто может потребовать много времени и ресурсов компьютера.\nВы уверены, что хотите это сделать?", "Внимение!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    if (table == "Группы" || table == "Предметы")
                    {
                        SaveFunct();
                    }
                    DataSet dataSet = new DataSet();
                    SqlCommand sqlCommand= new SqlCommand();
                    sqlCommand.Connection = connection;
                    string TableCheack=string.Empty;


                    string sqlcreat="SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME NOT LIKE 'sysdiagrams' OR TABLE_NAME NOT LIKE 'Студенты' OR TABLE_NAME NOT LIKE 'Предметы' OR TABLE_NAME NOT LIKE 'Специальность' OR TABLE_NAME NOT LIKE 'Группы' OR TABLE_NAME NOT LIKE 'Преподаватели'";
                    adapter.SelectCommand = new SqlCommand(sqlcreat, connection);
                    adapter.Fill(dataSet, "Exist");


                    sqlcreat = "if (month(GETDATE()) BETWEEN 1 AND 7) " +
                        "(select [Код группы], [Id специальности], [Номер группы], year([Дата поступления группы]) as [Год], (year(GEtdate()) - year([Дата поступления группы]))*2 as [Семестр] from[Группы] WHERE [Номер группы] NOT LIKE N'Введите номер группы') ORDER BY [Код группы] " +
                        "else (select [Код группы], [Id специальности], [Номер группы], year([Дата поступления группы]) as [Год], (year(GEtdate()) - year([Дата поступления группы]))*2 + 1 as [Семестр] from[Группы] WHERE [Номер группы] NOT LIKE N'Введите номер группы') ORDER BY [Код группы]";
                    adapter.SelectCommand = new SqlCommand(sqlcreat, connection);
                    adapter.Fill(dataSet, "Groupe");


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


                                    sqlcreat = "INSERT INTO [" + TableCheack + "] VALUES (1, N'Дата', N'Дата', N'**/**/****', N'**/**/****',N'**/**/****',N'**/**/****');";
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
                    MessageBox.Show("Операция была выполнена успешна.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("------", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void соданиеОпределёнойТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
             try
             {
                if (table == "Группы" || table == "Предметы")
                {
                    SaveFunct();
                }
                if (form2 != null)
                {
                    form2.ShowDialog();
                }
                else
                {
                    form2 = new CreateAdmin(connection);
                    form2.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void вывестиСписокВсехТаблицMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuFunc.Enabled = false;
                sql = "SELECT TABLE_NAME as [Название таблиц] FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME NOT LIKE 'sysdiagrams'";
                LoadFunc(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
