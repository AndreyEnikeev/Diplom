using System;
using System.Data;
using System.Windows.Forms;

namespace Журнал_V_Dip
{
    public partial class UnderThecher : Form
    {
        public UnderThecher(DataTable set)
        {
            InitializeComponent();

            dataGridView1.DataSource = set;
        }

        private void загрузитьToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCellAddress.Y == -1 || dataGridView1.CurrentCellAddress.X == -1)
                {
                    MessageBox.Show("Вы не выбрали никакого журнала для загрузки.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Convert.ToString(dataGridView1.CurrentCell.Value) == "")
                    {
                        MessageBox.Show("Ячейка, которая была выбрана, ни содержит никакого журнала.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Data.Loading = true;
                        Data.Rows = dataGridView1.CurrentCellAddress.Y;
                        Data.Colum = dataGridView1.CurrentCellAddress.X;
                        this.Close();
                    }
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Отменить загрузку журнала?", "Отмена загрузки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Data.Loading = false;
                    this.Close();
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Дла загрузки журнала выберите номер группы в столбике соответствующего предмета и нажмите кнопку загрузить.\nЗагрузку также можно запустить двойным нажатием левой кнопки мыши по выбраной ячейки.", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                загрузитьToolStripMenuItem_Click(sender, e);
            }
        }
    }
}
