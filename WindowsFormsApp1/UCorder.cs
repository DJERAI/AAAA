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
        string idMarka;
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
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];

                dataGridView1.CurrentRow.Selected = true;

                index_rows5 = dataGridView1.SelectedCells[0].RowIndex.ToString();
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
            string commandStr = $"SELECT t_Order.idOrder AS 'ID', t_Driver.fioDriver AS 'ФИО водителя', t_Disp.fioDisp AS 'ФИО диспетчера', t_Tarif.titleTarif AS 'Тариф', t_Order.dateOrder AS 'Дата заказа', t_Order.startAdr AS 'Начальный адрес', t_Order.endAdr AS 'Конечный адрес', t_Marka.titleMarks AS 'Марка автомобиля', t_Model.titleModel AS 'Модель автомобиля', t_Cars.NumberTS, t_Order.Price AS 'Цена поездки' FROM((((t_Order INNER JOIN((t_Marka INNER JOIN t_Model ON t_Marka.idMarka = t_Model.idMarka) INNER JOIN t_Cars ON t_Model.idModel = t_Cars.idModel) ON t_Order.idCar = t_Cars.idCar) INNER JOIN t_Driver ON t_Order.idDriver = t_Driver.idDriver) INNER JOIN t_Disp ON t_Order.idDisp = t_Disp.idDisp) INNER JOIN t_Client ON t_Order.idClient = t_Client.idClient) INNER JOIN t_Tarif ON t_Order.idTarif = t_Tarif.idTarif; ";
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
            dataGridView1.Columns[0].FillWeight = 50;
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
            dataGridView1.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.AllowUserToAddRows = false;
            GetComboBox1();
            comboBox1.Text = "";
            GetComboBox2();
            comboBox2.Text = "";
            GetComboBox3();
            comboBox3.Text = "";
            GetComboBox4();
            comboBox4.Text = "";
            GetComboBox6();
            comboBox6.Text = "";




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
        public void GetComboBox3()
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
            comboBox3.DataSource = list_marka_table;
            comboBox3.DisplayMember = "titleMarks";
            comboBox3.ValueMember = "idMarka";
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


        private void button1_Click(object sender, EventArgs e)
        {
            double coef = 0;
            double kmprice = 0;
            double price = 0;

            conn.Open();
            string query = $"SELECT idDisp FROM t_Disp WHERE fioDisp = '{comboBox6.Text}' ;";
            MySqlCommand command1 = new MySqlCommand(query, conn);
            string query1_resultDispID = command1.ExecuteScalar().ToString();

            string query2 = $"SELECT idDriver FROM t_Driver WHERE fioDriver = '{comboBox4.Text}' ;";
            MySqlCommand command2 = new MySqlCommand(query2, conn);
            string query2_resultDriverID = command2.ExecuteScalar().ToString();

            string query3 = $"SELECT idClient FROM t_Client WHERE fioClient = '{comboBox1.Text}' ;";
            MySqlCommand command3 = new MySqlCommand(query3, conn);
            string query3_resultClientID = command3.ExecuteScalar().ToString();

            string query4 = $"SELECT idTarif FROM t_Tarif WHERE titleTarif = '{comboBox2.Text}' ;";
            MySqlCommand command4 = new MySqlCommand(query4, conn);
            string query4_resultTarifID = command4.ExecuteScalar().ToString();



            string query6 = $"SELECT idMarka FROM t_Marka WHERE titleMarks = '{comboBox3.Text}';";
            MySqlCommand command6 = new MySqlCommand(query6, conn);
            string query6_resultMarkaID = command6.ExecuteScalar().ToString();

            string query7 = $"SELECT idModel FROM t_Model WHERE titleModel = '{comboBox5.Text}';";
            MySqlCommand command7 = new MySqlCommand(query7, conn);
            string query7_resultModelID = command7.ExecuteScalar().ToString();

            string query8 = $"SELECT idCar FROM t_Cars WHERE idModel = '{query7_resultModelID}' AND idMarka = '{query6_resultMarkaID}' ; ";
            MySqlCommand command8 = new MySqlCommand(query8, conn);
            string query8_resultCarID = command8.ExecuteScalar().ToString();

            string query9 = $"SELECT coefTarif,kmPrice FROM t_Tarif WHERE idTarif = '{query4_resultTarifID}';";
            MySqlCommand command9 = new MySqlCommand(query9, conn);
            string query9_resultTarifID = command9.ExecuteScalar().ToString();

            MySqlDataReader COEF_Date_reader = command9.ExecuteReader();
            while (COEF_Date_reader.Read())
            {
                coef = Convert.ToDouble(COEF_Date_reader[0]);
                kmprice = Convert.ToDouble(COEF_Date_reader[1]);

            }
            COEF_Date_reader.Close();
            DateTime datetime = dateTimePicker1.Value;
            string date = datetime.ToString("yyyy-MM-dd");
            price = Convert.ToDouble(textBox1.Text) * coef * kmprice;
            string queryINSERT = $"INSERT INTO t_Order (idDriver, idDisp, dateOrder, startAdr, endAdr, km, idClient, Price, idCar, idTarif) VALUES ('{query2_resultDriverID}','{query1_resultDispID}','{date}','{textBox2.Text}','{textBox3.Text}','{textBox1.Text}','{query3_resultClientID}','{price}','{query8_resultCarID}','{query4_resultTarifID}') ;";
            MySqlCommand commandINSERT = new MySqlCommand(queryINSERT, conn);
            commandINSERT.ExecuteNonQuery();
            conn.Close();
            reload_list();



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
            comboBox5.DataSource = list_model_table;
            comboBox5.DisplayMember = "titleModel";
            comboBox5.ValueMember = "idModel";
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
            comboBox5.Text = "";



            // остальные действия
        }
        public void GetComboBox6()
        {
            //Формирование списка статусов
            DataTable list_marka_table = new DataTable();
            MySqlCommand list_marka_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_marka_table.Columns.Add(new DataColumn("idDisp", System.Type.GetType("System.Int32")));
            list_marka_table.Columns.Add(new DataColumn("fioDisp", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox6.DataSource = list_marka_table;
            comboBox6.DisplayMember = "fioDisp";
            comboBox6.ValueMember = "idDisp";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_model = "SELECT idDisp, fioDisp FROM t_Disp";
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
                    rowToAdd["idDisp"] = Convert.ToInt32(list_model_reader[0]);
                    rowToAdd["fioDisp"] = list_model_reader[1].ToString();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public bool DeleteOrder()
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запрос удаления данных
            string query = $"DELETE FROM t_Order WHERE idOrder = '{id_selected_rows}'";

            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);

                // выполняем запрос
                InsertCount = command.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(Convert.ToInt32(index_rows5));

            }
            catch
            {
                InsertCount = 0;
            }
            finally
            {
                conn.Close();
                if (InsertCount != 0)
                {
                    result = true;
                    reload_list();
                }
            }
            return result;

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
            dataGridView1.Rows.RemoveAt(Convert.ToInt32(index_rows5));
            DeleteOrder();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];

                dataGridView1.CurrentRow.Selected = true;

                index_rows5 = dataGridView1.SelectedCells[0].RowIndex.ToString();
                GetSelectedIDString();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string vybor = toolStripTextBox1.Text;
            if (vybor != null)
            {
                
                reload_list();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
             reload_list();
            if (toolStripTextBox1.Text != "")
            {
                reload_list();
                for (int i = 0; i < dataGridView1.RowCount ; i++)
                { // если в таблице больше одной записи (первая - это наименования столбцов)
                    if (dataGridView1.RowCount > 1)
                    {

                        string QuanityValue = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        if (QuanityValue != toolStripTextBox1.Text)
                        {
                            dataGridView1.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                    
                }
            }
        }
    }
}





