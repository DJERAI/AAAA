using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class UC_Drivers : UserControl
    {
        MySqlConnection conn;
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();
        // строка подключения к БД
        string connStr = "server=caseum.ru;port=33333;user=st_1_22_19;database=st_1_22_19;password=97035229;";
        string id_selected_rows = "0";

        public UC_Drivers()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload_list();            
        }

        private void UC_Drivers_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            GetListDriver();
            //Видимость полей в гриде
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;


            //Ширина полей
            dataGridView1.Columns[0].FillWeight = 150;
            dataGridView1.Columns[1].FillWeight = 150;
            dataGridView1.Columns[2].FillWeight = 150;

            //Режим для полей "Только для чтения"
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

            //Растягивание полей грида
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Убираем заголовки строк
            dataGridView1.RowHeadersVisible = true;
            //Показываем заголовки столбцов
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.AllowUserToAddRows = false;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                //Открываем соединение
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO t_Driver (fioDriver,dateOfbirthDriver,phoneDriver) " +
                   "VALUES (@name, @date,@number)", conn))
                {
                    //Использование параметров в запросах. Это повышает безопасность работы программы
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@date", MySqlDbType.Timestamp).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@number", MySqlDbType.VarChar).Value = textBox2.Text;

                    int insertedRows = cmd.ExecuteNonQuery();
                    // закрываем подключение  БД
                    conn.Close();

                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                //dataGridView1.CurrentRow.Selected = true;
                dataGridView1.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
        }
        public void reload_list()
        {
            //Чистим виртуальную таблицу
            table.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            GetListDriver();
        }
        public void GetListDriver()
        {
            //Запрос для вывода строк в БД
            string commandStr = $"SELECT t_Driver.idDriver AS 'ID', t_Driver.fioDriver AS 'ФИО', t_Driver.phoneDriver AS 'Номер телефона', t_Driver.dateOfbirthDriver AS 'Дата рождения' FROM t_Driver;";
                       ;
            //Открываем соединение
            conn.Open();
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            dataGridView1.DataSource = bSource;
            //Закрываем соединение
            conn.Close();


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            bSource.Filter = "ФИО LIKE'" + textBox5.Text + "%'";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
