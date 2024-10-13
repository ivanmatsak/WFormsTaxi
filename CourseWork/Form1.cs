using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        DataSet dsTable;
        SqlCommand sCommand;
        SqlDataAdapter sAdapter;
        SqlCommandBuilder sBuilder;
        DataSet sDs;
        DataTable sTable;
        string connectionString = "Data Source=WIN-B9PG27IQF4T;Initial Catalog=CourseWorkDB;Integrated Security=True";
        private void readButton_Click(object sender, EventArgs e)
        {
            string Table = "Automobiles";
            // Организация подключения
            
            SqlConnection con = new SqlConnection(connectionString);

            string sql = "SELECT * FROM " + Table;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            sCommand = new SqlCommand(sql, connection);
            sAdapter = new SqlDataAdapter(sCommand);
            sBuilder = new SqlCommandBuilder(sAdapter);
            sDs = new DataSet();
            sAdapter.Fill(sDs, Table);
            sTable = sDs.Tables[Table];
            connection.Close();
            dataGridView1.DataSource = sDs.Tables[Table];
            dataGridView1.ReadOnly = true;
          
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите удалить этот ряд?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                sAdapter.Update(sTable);
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            save_btn.Enabled = true;
            new_btn.Enabled = false;
            
            

            SqlConnection con = new SqlConnection(connectionString);

            // Создать команду для вызова хранимой процедуры InsPerson
            SqlCommand cmd = new SqlCommand("insert into Automobiles values(@Name, @SerialNumber, @Color,@Mark,@State,@Class)", con);
            

            // Указать параметры
            cmd.Parameters.AddWithValue("@Name", carName.Text);
            cmd.Parameters.AddWithValue("@SerialNumber", serialNumber.Text);
            cmd.Parameters.AddWithValue("@Color", color.Text);
            cmd.Parameters.AddWithValue("@Mark", mark.Text);
            cmd.Parameters.AddWithValue("@State", state.Text);
            cmd.Parameters.AddWithValue("@Class", comboBox1.Text);
       
          
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                // Получить вновь сгенерированный идентификатор
                
                readButton_Click(sender,e);
            }
            finally
            {
                con.Close();
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            sAdapter.Update(sTable);
            dataGridView1.ReadOnly = true;
            save_btn.Enabled = false;
            new_btn.Enabled = true;
            delete_btn.Enabled = true;
        }

        private void readButton2_Click(object sender, EventArgs e)
        {
            string Table = "Clients";
            // Организация подключения

            SqlConnection con = new SqlConnection(connectionString);

            string sql = "SELECT * FROM " + Table;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            sCommand = new SqlCommand(sql, connection);
            sAdapter = new SqlDataAdapter(sCommand);
            sBuilder = new SqlCommandBuilder(sAdapter);
            sDs = new DataSet();
            sAdapter.Fill(sDs, Table);
            sTable = sDs.Tables[Table];
            connection.Close();
            dataGridView2.DataSource = sDs.Tables[Table];
            dataGridView2.ReadOnly = true;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void readButton3_Click(object sender, EventArgs e)
        {
            string Table = "VehicleClass";
            // Организация подключения

            SqlConnection con = new SqlConnection(connectionString);

            string sql = "SELECT * FROM " + Table;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            sCommand = new SqlCommand(sql, connection);
            sAdapter = new SqlDataAdapter(sCommand);
            sBuilder = new SqlCommandBuilder(sAdapter);
            sDs = new DataSet();
            sAdapter.Fill(sDs, Table);
            sTable = sDs.Tables[Table];
            connection.Close();
            dataGridView3.DataSource = sDs.Tables[Table];
            dataGridView3.ReadOnly = true;

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void readButton4_Click(object sender, EventArgs e)
        {
            string Table = "CarOrder";
            // Организация подключения

            SqlConnection con = new SqlConnection(connectionString);

            string sql = "SELECT * FROM " + Table;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            sCommand = new SqlCommand(sql, connection);
            sAdapter = new SqlDataAdapter(sCommand);
            sBuilder = new SqlCommandBuilder(sAdapter);
            sDs = new DataSet();
            sAdapter.Fill(sDs, Table);
            sTable = sDs.Tables[Table];
            connection.Close();
            dataGridView4.DataSource = sDs.Tables[Table];
            dataGridView4.ReadOnly = true;

            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void cleanButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить этот ряд?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                sAdapter.Update(sTable);
            }
        }
        private void cleanButton3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите удалить этот ряд?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridView3.Rows.RemoveAt(dataGridView3.SelectedRows[0].Index);
                sAdapter.Update(sTable);
            }
        }
        private void cleanButton4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите удалить этот ряд?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridView4.Rows.RemoveAt(dataGridView4.SelectedRows[0].Index);
                sAdapter.Update(sTable);
            }
        }
        private void save_btn2_Click(object sender, EventArgs e)
        {
            sAdapter.Update(sTable);
            dataGridView2.ReadOnly = true;
            save_btn.Enabled = false;
            new_btn.Enabled = true;
            delete_btn.Enabled = true;
        }
        private void save_btn3_Click(object sender, EventArgs e)
        {
            sAdapter.Update(sTable);
            dataGridView3.ReadOnly = true;
            save_btn.Enabled = false;
            new_btn.Enabled = true;
            delete_btn.Enabled = true;
        }
        private void save_btn4_Click(object sender, EventArgs e)
        {
            sAdapter.Update(sTable);
            dataGridView4.ReadOnly = true;
            save_btn.Enabled = false;
            new_btn.Enabled = true;
            delete_btn.Enabled = true;
        }
        private void Refresh_Click2(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            save_btn.Enabled = true;
            new_btn.Enabled = false;



            SqlConnection con = new SqlConnection(connectionString);

            // Создать команду для вызова хранимой процедуры InsPerson
            SqlCommand cmd = new SqlCommand("insert into Clients values(@FirstName, @Surname, @Patronymic,@Age,@DriverLicense,@Address)", con);


            // Указать параметры
            cmd.Parameters.AddWithValue("@FirstName", firstname.Text);
            cmd.Parameters.AddWithValue("@Surname", surname.Text);
            cmd.Parameters.AddWithValue("@Patronymic", patronymic.Text);
            cmd.Parameters.AddWithValue("@Age", Int32.Parse(age.Text));
            cmd.Parameters.AddWithValue("@DriverLicense", license.Text);
            cmd.Parameters.AddWithValue("@Address", address.Text);


            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                // Получить вновь сгенерированный идентификатор

                readButton2_Click(sender, e);
            }
            finally
            {
                con.Close();
            }
        }
        private void Refresh_Click3(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            save_btn.Enabled = true;
            new_btn.Enabled = false;



            SqlConnection con = new SqlConnection(connectionString);

            // Создать команду для вызова хранимой процедуры InsPerson
            SqlCommand cmd = new SqlCommand("insert into VehicleClass values(@Name, @LoadCapacity, @Sits,@EnginePower,@Speed)", con);


            // Указать параметры
            cmd.Parameters.AddWithValue("@Name", carTypeName.Text);
            cmd.Parameters.AddWithValue("@LoadCapacity", Int32.Parse(cap.Text));
            cmd.Parameters.AddWithValue("@Sits", sits.Text);
            cmd.Parameters.AddWithValue("@EnginePower", power.Text);
            cmd.Parameters.AddWithValue("@Speed", speed.Text);
           


            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                // Получить вновь сгенерированный идентификатор

                readButton3_Click(sender, e);
            }
            finally
            {
                con.Close();
            }
        }
        private void Refresh_Click4(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            save_btn.Enabled = true;
            new_btn.Enabled = false;



            SqlConnection con = new SqlConnection(connectionString);

            // Создать команду для вызова хранимой процедуры InsPerson
            SqlCommand cmd = new SqlCommand("insert into CarOrder values(@CarId, @DateOfApproval, @Validity,@Cost,@Client)", con);


            // Указать параметры
            cmd.Parameters.AddWithValue("@CarId", Int32.Parse(comboBox2.Text));
            cmd.Parameters.AddWithValue("@DateOfApproval", approvalDate.Text);
            cmd.Parameters.AddWithValue("@Validity", validity.Text);
            cmd.Parameters.AddWithValue("@Cost", cost.Text);
            cmd.Parameters.AddWithValue("@Client", Int32.Parse(comboBox3.Text));



            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                // Получить вновь сгенерированный идентификатор

                readButton4_Click(sender, e);
            }
            finally
            {
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "CourseWorkDBDataSet.Clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.CourseWorkDBDataSet.Clients);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "CourseWorkDBDataSet.VehicleClass". При необходимости она может быть перемещена или удалена.
            this.vehicleClassTableAdapter.Fill(this.CourseWorkDBDataSet.VehicleClass);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "CourseWorkDBDataSet.Automobiles". При необходимости она может быть перемещена или удалена.
            this.AutomobilesTableAdapter.Fill(this.CourseWorkDBDataSet.Automobiles);

            this.reportViewer1.RefreshReport();
        }
    }
}
