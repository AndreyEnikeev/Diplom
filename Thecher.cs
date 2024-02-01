using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Журнал_V_Dip
{
    public partial class Thecher : Form
    {
        private readonly UnderThecher UnThec; // Форма для выбара загружаемого журнала
        private readonly DataSet dataSet = new DataSet();
        private readonly SqlDataAdapter adapter;private string sql, table="";
        private bool saving=true;


        //Подключается БД внутри проекта, из-за отсутствия хоста для выкладывания БД.
        private readonly SqlConnection connection;//= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\ОсновнаяБД.mdf;Integrated Security=True");


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


        public Thecher(int Id, string place)
        {
            InitializeComponent();


            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\Журналы" + place + ".mdf; Integrated Security=True");
            connection.Open();

            int rowsadd, rowshave=-1;

            sql = "SELECT * FROM [Преподаватели] WHERE Id=" + Convert.ToString(Id) + "";
            adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(dataSet, "Thecher");

            sql = "SELECT * FROM [Предметы] ORDER BY [Семестр обучения]";
            adapter.SelectCommand = new SqlCommand(sql, connection);
            adapter.Fill(dataSet, "Object");

            sql = "if (month(GETDATE()) BETWEEN 1 AND 7) " +
                "(select [Номер группы], year([Дата поступления группы]) as [Год], [Id специальности], (year(GEtdate()) - year([Дата поступления группы]))*2 as [Семестр] from[Группы]) ORDER BY [Номер группы] " +
                "else (select [Номер группы], year([Дата поступления группы]) as [Год], [Id специальности], (year(GEtdate()) - year([Дата поступления группы]))*2 + 1 as [Семестр] from[Группы]) ORDER BY [Номер группы]";
            adapter.SelectCommand = new SqlCommand(sql, connection);
            adapter.Fill(dataSet, "Group");

            dataSet.Tables.Add("VisibalGroup");
            dataSet.Tables.Add("RealGroup");

            for (int i = 2; i < dataSet.Tables["Thecher"].Columns.Count; i++)
            {
                if (dataSet.Tables["Thecher"].Rows[0][i].ToString() != "")
                {
                    dataSet.Tables["VisibalGroup"].Columns.Add(Convert.ToString(dataSet.Tables["Thecher"].Rows[0][i]));
                    dataSet.Tables["RealGroup"].Columns.Add(Convert.ToString(dataSet.Tables["Thecher"].Rows[0][i]));

                    rowsadd = -1;

                    for (int r = 0; r < dataSet.Tables["Object"].Rows.Count; r++)
                    {
                        for (int c = 3; c < dataSet.Tables["Object"].Columns.Count; c++)
                        {
                            if (dataSet.Tables["Object"].Rows[r][c].ToString() == dataSet.Tables["Thecher"].Rows[0][i].ToString())
                            {
                                for (int rr = 0; rr < dataSet.Tables["Group"].Rows.Count; rr++)
                                {
                                    if (Convert.ToInt32(dataSet.Tables["Object"].Rows[r][1]) == Convert.ToInt32(dataSet.Tables["Group"].Rows[rr][2]) && Convert.ToInt32(dataSet.Tables["Object"].Rows[r][2]) == Convert.ToInt32(dataSet.Tables["Group"].Rows[rr][3]))
                                    {
                                        rowsadd++;
                                        if (rowsadd > rowshave)
                                        {
                                            rowshave++;
                                            dataSet.Tables["VisibalGroup"].Rows.Add();
                                            dataSet.Tables["RealGroup"].Rows.Add();
                                            dataSet.Tables["VisibalGroup"].Rows[rowsadd][i - 2] = dataSet.Tables["Group"].Rows[rr][0].ToString();
                                            dataSet.Tables["RealGroup"].Rows[rowsadd][i - 2] = (dataSet.Tables["Group"].Rows[rr][0].ToString() + "_" + dataSet.Tables["Thecher"].Rows[0][i].ToString() + "_" + dataSet.Tables["Group"].Rows[rr][1].ToString());
                                        }
                                        else
                                        {
                                            dataSet.Tables["VisibalGroup"].Rows[rowsadd][i - 2] = dataSet.Tables["Group"].Rows[rr][0].ToString();
                                            dataSet.Tables["RealGroup"].Rows[rowsadd][i - 2] = (dataSet.Tables["Group"].Rows[rr][0].ToString() + "_" + dataSet.Tables["Thecher"].Rows[0][i].ToString() + "_" + dataSet.Tables["Group"].Rows[rr][1].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            dataSet.Tables["Thecher"].Clear();
            dataSet.Tables["Group"].Clear();
            dataSet.Tables["Object"].Clear();
            dataSet.Tables.Add("Table");

            UnThec = new UnderThecher(dataSet.Tables["VisibalGroup"]);

        }


        private void FunctionLoad()
        {
            table = dataSet.Tables["RealGroup"].Rows[Data.Rows][Data.Colum].ToString();
            sql = "SELECT * FROM [" + table + "]";


            adapter.SelectCommand = new SqlCommand(sql, connection);
            dataSet.Tables["Table"].Clear();
            dataSet.Tables["Table"].Rows.Clear();
            dataSet.Tables["Table"].Columns.Clear();
            adapter.Fill(dataSet, "Table");


            dataGridView1.DataSource = dataSet.Tables["Table"];


            dataGridView1.Columns["Id"].ReadOnly = true;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Предмет"].ReadOnly = true;
            dataGridView1.Columns["Предмет"].Visible = false;
            dataGridView1.Columns["Студент"].ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Gray;

            Data.Loading = false;
        }



        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();
                if (dataGridView1.CurrentCellAddress.Y == 0)
                {
                    dataGridView1.Rows[1].Cells[2].Selected = true;
                    dataGridView1.Rows[1].Cells[2].Selected = false;
                }
                else
                {
                    dataGridView1.Rows[0].Cells[2].Selected = true;
                    dataGridView1.Rows[0].Cells[2].Selected = false;
                }


                new SqlCommandBuilder(adapter);  // Билдер сам пишет команду для адаптера
                adapter.Update(dataSet, "Table");


                saving = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            saving = false;
            if (dataGridView1.CurrentCellAddress.Y == 0 && Convert.ToString(dataGridView1.CurrentCell.Value) == "")
            {
                dataGridView1.EditingControl.Text = DateTime.Today.ToString("d");
            }
        }

        private void добавитьДатуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (table == "")
                {
                    MessageBox.Show("Вы не загрузили никакого журнала для добавления даты.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    сохранитьToolStripMenuItem_Click(sender, e);


                    sql = "ALTER TABLE [" + table + "] ADD [Дата " + Convert.ToString(dataGridView1.ColumnCount - 2) + "] NVARCHAR(100);";
                    SqlCommand sqlCommand= new SqlCommand(sql, connection);
                    sqlCommand.ExecuteNonQuery();
                    FunctionLoad();


                    dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 1].Value = DateTime.Today.ToString("d");


                    сохранитьToolStripMenuItem_Click(sender, e);
                    dataGridView1.FirstDisplayedScrollingColumnIndex = dataGridView1.ColumnCount - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void УдалитьВыбраннуюДатуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (table == "")
                {
                    MessageBox.Show("Вы не загрузили никакого журнала для удаления даты даты.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (dataGridView1.CurrentCellAddress.X == 2 || dataGridView1.CurrentCellAddress.X == 1 || dataGridView1.CurrentCellAddress.X == 0)
                    {
                        MessageBox.Show("Вы не можите удалить данный столбец.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        for (int i = dataGridView1.CurrentCellAddress.X; i < dataGridView1.ColumnCount - 1; i++)
                        {
                            for (int r = 0; r < dataGridView1.RowCount; r++)
                            {
                                dataGridView1.Rows[r].Cells[i].Value = dataGridView1.Rows[r].Cells[i + 1].Value;
                            }
                        }

                        сохранитьToolStripMenuItem_Click(sender, e);


                        sql = "ALTER TABLE [" + table + "] DROP COLUMN [" + dataGridView1.Columns[dataGridView1.ColumnCount - 1].HeaderText + "];";
                        SqlCommand sqlCommand= new SqlCommand(sql, connection);
                        sqlCommand.ExecuteNonQuery();


                        FunctionLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saving)
                {
                    UnThec.ShowDialog();
                    if (Data.Loading)
                    {
                        FunctionLoad();
                    }
                }
                else
                {
                    if (MessageBox.Show("Вы не сохранили журнал, сохранить?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        сохранитьToolStripMenuItem_Click(sender, e);
                        загрузитьToolStripMenuItem_Click(sender, e);
                    }
                    else
                    {
                        if (MessageBox.Show("Вы уверены? Все не сохраненные данные будут утерены.", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            saving = true;
                            загрузитьToolStripMenuItem_Click(sender, e);
                        }
                        else
                        {
                            сохранитьToolStripMenuItem_Click(sender, e);
                            загрузитьToolStripMenuItem_Click(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCellAddress.Y == 0 && dataGridView1.CurrentCellAddress.X != 0 && dataGridView1.CurrentCellAddress.X != 2)
            {
                monthCalendar1.SelectionStart = DateTime.Today;
                monthCalendar1.Visible = true;
            }
            else
            {
                monthCalendar1.SelectionStart = DateTime.Today;
                monthCalendar1.Visible = false;
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            dataGridView1.CurrentCell.Value = monthCalendar1.SelectionStart.ToShortDateString().ToString();
        }

        private void Thecher_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
        }
    }
}
