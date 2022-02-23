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
        string connStr = "server=caseum.ru;port=33333;user=st_1_22_19;database=st_1_22_19;password=97035229;";
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
            string commandStr = $"SELECT t_Order.idOrder, t_Driver.fioDriver, t_Disp.fioDisp, t_Tarif.titleTarif, t_Order.dateOrder, t_Order.startAdr, t_Order.endAdr, t_Marka.titleMarks, t_Model.titleModel, t_Cars.NumberTS, t_Order.Price FROM((((t_Order INNER JOIN((t_Marka INNER JOIN t_Model ON t_Marka.idMarka = t_Model.idMarka) INNER JOIN t_Cars ON t_Model.idModel = t_Cars.idModel) ON t_Order.idCar = t_Cars.idCar) INNER JOIN t_Driver ON t_Order.idDriver = t_Driver.idDriver) INNER JOIN t_Disp ON t_Order.idDisp = t_Disp.idDisp) INNER JOIN t_Client ON t_Order.idClient = t_Client.idClient) INNER JOIN t_Tarif ON t_Order.idTarif = t_Tarif.idTarif; ";
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
        public void GetComboBox1()
        {
            //Формирование списка статусов
            DataTable list_marka_table = new DataTable();
            MySqlCommand list_marka_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_marka_table.Columns.Add(new DataColumn("idMarka", System.Type.GetType("System.Int32")));
            list_marka_table.Columns.Add(new DataColumn("titleMarks", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox1.DataSource = list_marka_table;
            comboBox1.DisplayMember = "titleMarks";
            comboBox1.ValueMember = "idMarka";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_model = "SELECT idMarka, titleMarks FROM t_Marka;SELECT NumberTS FROM t_Cars";
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
                    rowToAdd["idMarka"] = Convert.ToInt32(list_model_reader[0]);
                    rowToAdd["titleMarks"] = list_model_reader[1].ToString();
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
        public bool InsertAdr(string nach, string konech, int km )
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запросы
            // запрос вставки данных
            string query = $"INSERT INTO t_Order (startAdr, endAdr, km, idDriver, idDisp ) VALUES ('{nach}', '{konech}', '{km}')";
            try
            {
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(query, conn);
                // выполняем запрос
                InsertCount = command.ExecuteNonQuery();
                // закрываем подключение к БД
            }
            catch
            {
                //Если возникла ошибка, то запрос не вставит ни одной строки
                InsertCount = 0;
            }
            finally
            {
                //Но в любом случае, нужно закрыть соединение
                conn.Close();
                //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
                if (InsertCount != 0)
                {
                    //то результат операции - истина
                    result = true;
                }
            }
            //Вернём результат операции, где его обработает алгоритм
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                //Открываем соединение
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO t_Order (dateOrder,startAdr,endAdr,idDriver,idDisp,idCar,km,idClient) " +
                   "VALUES (@date, @startAdr,@endAdr, @idDriver, @idCar, @idDisp, @idCar, @km, @idClient, @idTarif)", conn))
                {
                    //Использование параметров в запросах. Это повышает безопасность работы программы
                    cmd.Parameters.Add("@startAdr", MySqlDbType.VarChar).Value = textBox2.Text;
                    cmd.Parameters.Add("@endAdr", MySqlDbType.VarChar).Value = textBox3.Text;
                    cmd.Parameters.Add("@date", MySqlDbType.Timestamp).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@km", MySqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@idClient", MySqlDbType.VarChar).Value = comboBox1.Text;
                    cmd.Parameters.Add("@idTarif", MySqlDbType.VarChar).Value = comboBox2.Text;
                    cmd.Parameters.Add("@idDriver", MySqlDbType.VarChar).Value = comboBox4.Text;

                    int insertedRows = cmd.ExecuteNonQuery();
                    // закрываем подключение  БД
                    conn.Close();

                }
                reload_list();
            }
            
            //Объявляем переменные для вставки в БД
            string nach = textBox2.Text;
            string konech = textBox3.Text;
            int km = Convert.ToInt32(textBox1.Text);
            //Если метод вставки записи в БД вернёт истину, то просто обновим список и увидим вставленное значение
            if (InsertAdr(nach, konech, km))
            {
                GetListOrder();
                MessageBox.Show("Заказ успешно добавлен.");
            }
            //Иначе произошла какая то ошибка и покажем пользователю уведомление
            else
            {
                MessageBox.Show("Произошла ошибка.", "Ошибка");
            }

        }
        public void GetComboBox5(string idMarka)
        {
            //Формирование списка статусов
            DataTable list_model_table = new DataTable();
            MySqlCommand list_model_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_model_table.Columns.Add(new DataColumn("idModel", System.Type.GetType("System.Int32")));
            list_model_table.Columns.Add(new DataColumn("titleModel", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox2.DataSource = list_model_table;
            comboBox2.DisplayMember = "titleModel";
            comboBox2.ValueMember = "idModel";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = $"SELECT idModel, titleModel FROM t_Model WHERE idMarka = {idMarka}";
            list_model_command.CommandText = sql_list_users;
            list_model_command.Connection = conn;
            //Формирование списка ЦП для combobox'a
            MySqlDataReader list_model_reader;
            try
            {
                //Инициализируем ридер
                list_model_reader = list_model_command.ExecuteReader();
                while (list_model_reader.Read())
                {
                    DataRow rowToAdd = list_model_table.NewRow();
                    rowToAdd["idModel"] = Convert.ToInt32(list_model_reader[0]);
                    rowToAdd["titleModel"] = list_model_reader[1].ToString();
                    list_model_table.Rows.Add(rowToAdd);
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
            //Заполнение Combobox2 теми подкатегориями, которые относятся к выбранной категории
            GetComboBox5(comboBox3.SelectedValue.ToString());
            //Установка пустой строки по умолчанию в ComboBox2
            comboBox2.Text = "";


            string vybor = comboBox1.SelectedItem.ToString();
            if (vybor != null)
            {
                textBox1.Text = "";
            }
            else if (vybor == "2") ;
            // остальные действия
        }
    }

    }
    

