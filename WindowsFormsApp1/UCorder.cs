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
    public partial class UCorder : UserControl
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
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        string id_selected_rows = "0";
        string index_rows5;
        public UCorder()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            GetListOrder();
        }
        public void GetListOrder()
        {
            //Запрос для вывода строк в БД
            string commandStr = $"SELECT t_Order.idDriver, t_Order.idDisp, t_Order.dateOrder FROM(t_Order INNER JOIN t_Driver ON t_Order.idDriver = t_Driver.idDriver) INNER JOIN t_Disp ON t_Order.idDisp = t_Disp.idDisp;";
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

        private void UCorder_Load(object sender, EventArgs e)
        {
            string connStr = "server=caseum.ru;port=33333;user=st_1_22_19;database=st_1_22_19;password=97035229;";
            conn = new MySqlConnection(connStr);
            GetListOrder();
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
            GetComboBox1();
            comboBox1.Text = "";
            GetComboBox2();
            comboBox2.Text = "";
            //GetComboBox3();
            //comboBox3.Text = "";
            GetComboBox4();
            comboBox4.Text = "";


        }
        public void GetComboBox1()
        {
            //Формирование списка статусов
            DataTable list_marka_table = new DataTable();
            MySqlCommand list_marka_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_marka_table.Columns.Add(new DataColumn("idClient", System.Type.GetType("System.Int32")));
            list_marka_table.Columns.Add(new DataColumn("fioClient", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox1.DataSource = list_marka_table;
            comboBox1.DisplayMember = "fioClient";
            comboBox1.ValueMember = "idClient";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_model = "SELECT idClient, fioClient FROM t_Client";
            list_marka_command.CommandText = sql_list_model;
            list_marka_command.Connection = conn;
            //Формирование списка ЦП для combobox'a
            MySqlDataReader list_model_reader;
            try
            {
                //Инициализируем ридер
                list_model_reader = list_marka_command.ExecuteReader();
                while (list_model_reader.Read())
                {
                    DataRow rowToAdd = list_marka_table.NewRow();
                    rowToAdd["idClient"] = Convert.ToInt32(list_model_reader[0]);
                    rowToAdd["fioClient"] = list_model_reader[1].ToString();
                    list_marka_table.Rows.Add(rowToAdd);
                }
                list_model_reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            finally
            {
                conn.Close();
            }

        }
        public void GetComboBox2()
        {
            //Формирование списка статусов
            DataTable list_marka_table = new DataTable();
            MySqlCommand list_marka_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_marka_table.Columns.Add(new DataColumn("idTarif", System.Type.GetType("System.Int32")));
            list_marka_table.Columns.Add(new DataColumn("titleTarif", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox2.DataSource = list_marka_table;
            comboBox2.DisplayMember = "titleTarif";
            comboBox2.ValueMember = "idTarif";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_model = "SELECT idTarif, titleTarif FROM t_Tarif";
            list_marka_command.CommandText = sql_list_model;
            list_marka_command.Connection = conn;
            //Формирование списка ЦП для combobox'a
            MySqlDataReader list_model_reader;
            try
            {
                //Инициализируем ридер
                list_model_reader = list_marka_command.ExecuteReader();
                while (list_model_reader.Read())
                {
                    DataRow rowToAdd = list_marka_table.NewRow();
                    rowToAdd["idTarif"] = Convert.ToInt32(list_model_reader[0]);
                    rowToAdd["titleTarif"] = list_model_reader[1].ToString();
                    list_marka_table.Rows.Add(rowToAdd);
                }
                list_model_reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            finally
            {
                conn.Close();
            }

        }
        //public void GetComboBox3()
        //{
        //    //Формирование списка статусов
        //    DataTable list_marka_table = new DataTable();
        //    MySqlCommand list_marka_command = new MySqlCommand();
        //    //Открываем соединение
        //    conn.Open();
        //    //Формируем столбцы для комбобокса списка ЦП
        //    list_marka_table.Columns.Add(new DataColumn("idModel", System.Type.GetType("System.Int32")));
        //    list_marka_table.Columns.Add(new DataColumn("idMarka", System.Type.GetType("System.String")));
        //    list_marka_table.Columns.Add(new DataColumn("titleModel", System.Type.GetType("System.String")));
        //    list_marka_table.Columns.Add(new DataColumn("titleMarks", System.Type.GetType("System.String")));
        //    //Настройка видимости полей комбобокса
        //    comboBox3.DataSource = list_marka_table;
        //    comboBox3.DisplayMember = "titleModel";
        //    comboBox3.DisplayMember = "titleMarks";
        //    comboBox3.ValueMember = "idModel,idMarka";
        //    //Формируем строку запроса на отображение списка статусов прав пользователя
        //    string sql_list_model = "SELECT idModel, titleModel FROM t_Model; SELECT idMarka, titleMarks FROM t_Marka";
        //    list_marka_command.CommandText = sql_list_model;
        //    list_marka_command.Connection = conn;
        //    //Формирование списка ЦП для combobox'a
        //    MySqlDataReader list_model_reader;
        //    try
        //    {
        //        //Инициализируем ридер
        //        list_model_reader = list_marka_command.ExecuteReader();
        //        while (list_model_reader.Read())
        //        {
        //            DataRow rowToAdd = list_marka_table.NewRow();
        //            rowToAdd["idModel"] = Convert.ToInt32(list_model_reader[0]);
        //            rowToAdd["titleModel"] = list_model_reader[1].ToString();
        //            rowToAdd["idMarka"] = Convert.ToInt32(list_model_reader[2]);
        //            rowToAdd["titleMarks"] = list_model_reader[3].ToString();
        //            list_marka_table.Rows.Add(rowToAdd);
        //        }
        //        list_model_reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Application.Exit();
        //    }

        //    finally
        //    {
        //        conn.Close();
        //    }
        public void GetComboBox4()
        {
            //Формирование списка статусов
            DataTable list_marka_table = new DataTable();
            MySqlCommand list_marka_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_marka_table.Columns.Add(new DataColumn("idDriver", System.Type.GetType("System.Int32")));
            list_marka_table.Columns.Add(new DataColumn("fioDriver", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox4.DataSource = list_marka_table;
            comboBox4.DisplayMember = "fioDriver";
            comboBox4.ValueMember = "idDriver";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_model = "SELECT idDriver, fioDriver FROM t_Driver";
            list_marka_command.CommandText = sql_list_model;
            list_marka_command.Connection = conn;
            //Формирование списка ЦП для combobox'a
            MySqlDataReader list_model_reader;
            try
            {
                //Инициализируем ридер
                list_model_reader = list_marka_command.ExecuteReader();
                while (list_model_reader.Read())
                {
                    DataRow rowToAdd = list_marka_table.NewRow();
                    rowToAdd["idDriver"] = Convert.ToInt32(list_model_reader[0]);
                    rowToAdd["fioDriver"] = list_model_reader[1].ToString();
                    list_marka_table.Rows.Add(rowToAdd);
                }
                list_model_reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            finally
            {
                conn.Close();
            }

        }

    }

    }
    

