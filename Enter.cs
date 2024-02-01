using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Журнал_V_Dip
{
    public partial class Enter : Form
    {

        private int IdForm;
        private readonly DataSet dataSet = new DataSet();
        private SqlDataAdapter adapter;
        private string sql;


        //Подключается БД внутри проекта, из-за отсутствия хоста для выкладывания БД.
        private readonly SqlConnection connection= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zver\Desktop\Проэкт\Журнал\Журнал V Dip\ОсновнаяБД.mdf;Integrated Security=True");


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


        public Enter()
        {
            InitializeComponent();


            PlaceComboBox.Items.Add("Выберите учебное заведение");
            PlaceComboBox.SelectedItem = "Выберите учебное заведение";
        }

        private void Enter_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            PlaceAdd();

            Cursor.Current = Cursors.Default;
        }



        private void Enter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EnterButton_Click(sender, e);//Запускает обработку кливиши "Входа" при нажатие Enter
            }
        }

        private void PassworText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            PassworText.BackColor = System.Drawing.Color.White;//Возврат белого цвета для поля пароля
        }

        private void PlaceAdd()
        {
            try
            {
                sql = "SELECT * FROM [Учебные заведения]";
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dataSet, "Place");
                for (int i = 0; i < dataSet.Tables["Place"].Rows.Count; i++)
                {
                    PlaceComboBox.Items.Add(dataSet.Tables["Place"].Rows[i].ItemArray[1].ToString());
                }
                connection.Close();
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                connection.Close();
            }
        }

        private void PlaceComboBox_Click(object sender, EventArgs e)
        {
            if (PlaceComboBox.Items.Count == 0)
            {
                PlaceAdd();
            }
        }
        private void PlaceComboBox_DropDown(object sender, EventArgs e)
        {
            PlaceComboBox.Items.Remove("Выберите учебное заведение");
            PlaceComboBox.BackColor = System.Drawing.Color.White;
        }
        private void PlaceComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (PlaceComboBox.SelectedIndex == -1)
            {
                PlaceComboBox.Items.Add("Выберите учебное заведение");
                PlaceComboBox.SelectedItem = "Выберите учебное заведение";
                PlaceComboBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            try
            {
                string LoginForm = LoginText.Text, PassworForm = PassworText.Text;
                if (PlaceComboBox.SelectedIndex != dataSet.Tables["Place"].Rows.Count)
                {
                    sql = "SELECT Id, Преподователь FROM [Пароли" + Convert.ToString(dataSet.Tables["Place"].Rows[PlaceComboBox.SelectedIndex].ItemArray[0]) + "] WHERE Логин='" + LoginForm + "' COLLATE SQL_Latin1_General_CP1_CS_AS AND Пароль ='" + PassworForm + "' COLLATE SQL_Latin1_General_CP1_CS_AS";
                    connection.Open();
                    adapter = new SqlDataAdapter(sql, connection);
                    adapter.Fill(dataSet, "User");
                    if (dataSet.Tables["User"].Rows.Count > 0)
                    {
                        IdForm = Convert.ToInt32(dataSet.Tables["User"].Rows[0][0]);
                        if (IdForm == 1)
                        {
                            Admin Form2 = new Admin(Convert.ToString(dataSet.Tables["Place"].Rows[PlaceComboBox.SelectedIndex].ItemArray[0]));
                            this.Hide();
                            dataSet.Clear();
                            connection.Close();
                            Form2.ShowDialog();
                            this.Close();
                        }
                        else if (Convert.ToBoolean(dataSet.Tables["User"].Rows[0][1]) == true)
                        {
                            Thecher Form2 = new Thecher(Convert.ToInt32(dataSet.Tables["User"].Rows[0][0]), Convert.ToString(dataSet.Tables["Place"].Rows[PlaceComboBox.SelectedIndex].ItemArray[0]));
                            this.Hide();
                            dataSet.Clear();
                            connection.Close();
                            Form2.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            Student Form2 = new Student(Convert.ToInt32(dataSet.Tables["User"].Rows[0][0]), Convert.ToString(dataSet.Tables["Place"].Rows[PlaceComboBox.SelectedIndex].ItemArray[0]));
                            this.Hide();
                            dataSet.Clear();
                            connection.Close();
                            Form2.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль или логин.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PassworText.Text = string.Empty;
                        PassworText.BackColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали учебное заведение", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PlaceComboBox.BackColor = System.Drawing.Color.Red;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
