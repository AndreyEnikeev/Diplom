using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Журнал_V_Dip
{
    public partial class Student : Form
    {
        private DataSet dataSet;
        private SqlDataAdapter adapter;
        private string sql;


        //Подключается БД внутри проекта, из-за отсутствия хоста для выкладывания БД.
        private readonly SqlConnection connection;//= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\ОсновнаяБД.mdf;Integrated Security=True");


        //Способы подключения БД, если она лежит на сервере
        //@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ОсновнаяБД; Integrated Security=True"
        //@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ОсновнаяБД;Integrated Security=False;User ID=TestUser;Password=Passwor";


        public Student(int Id, string Place)
        {
            InitializeComponent();

            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\Журналы" + Place + ".mdf; Integrated Security=True");
            connection.Open();

            sql = "SELECT [Код группы], [ФИО студента] FROM [Студенты] WHERE [Id]=" + Convert.ToString(Id);
            dataSet = new DataSet();
            adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(dataSet, "Group");


            sql = "IF (month(GETDATE()) BETWEEN 1 AND 7) " +
                "SELECT [Номер группы], year([Дата поступления группы]) AS [Год], [Id специальности], (year(GEtdate()) - year([Дата поступления группы]))*2 AS [Семестр] FROM[Группы] WHERE [Код группы]=" + dataSet.Tables["Group"].Rows[0][0].ToString() + " " +
                "ELSE SELECT [Номер группы], year([Дата поступления группы]) AS [Год], [Id специальности], (year(GEtdate()) - year([Дата поступления группы]))*2 + 1 AS [Семестр] FROM[Группы] WHERE [Код группы]=" + dataSet.Tables["Group"].Rows[0][0].ToString();
            adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(dataSet, "Semestr");


            sql = "SELECT * FROM [Предметы] WHERE [Id специальности]='" + dataSet.Tables["Semestr"].Rows[0][2].ToString() + "' AND [Семестр обучения]='" + dataSet.Tables["Semestr"].Rows[0][3].ToString() + "'";
            adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(dataSet, "Object");
            dataGridView1.DataSource = dataSet.Tables["Object"];


            for (int i = 3; i < dataSet.Tables["Object"].Columns.Count; i++)
            {
                if (dataSet.Tables["Object"].Rows[0][i].ToString() != "")
                {
                    sql = "SELECT * FROM [" + dataSet.Tables["Semestr"].Rows[0][0].ToString() + "_" + dataSet.Tables["Object"].Rows[0][i].ToString() + "_" + dataSet.Tables["Semestr"].Rows[0][1].ToString() + "] WHERE [Id]=1 OR [Id]=" + Convert.ToString(Id); adapter = new SqlDataAdapter(sql, connection);
                    adapter = new SqlDataAdapter(sql, connection);
                    adapter.Fill(dataSet, "View");
                }
            }
            dataGridView1.DataSource = dataSet.Tables["View"];
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Студент"].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            menuStrip1.Items[0].Text = "Вы зашли как "+dataSet.Tables["Group"].Rows[0][1].ToString();

            dataSet.Tables["Group"].Clear();
            dataSet.Tables["Semestr"].Clear();
            dataSet.Tables["Object"].Clear();
            connection.Close();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i += 2)
            {
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
            }
        }
    }
}
