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

namespace CRUD_CELL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindData();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Documents\CRUD_1.mdf;Integrated Security=True;Connect Timeout=30");

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("INSERT INTO CRUD_Table1 values ('" + int.Parse(textBox1.Text) + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Success");
            con.Close();
            BindData();
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CRUD_Table1", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("UPDATE CRUD_Table1 SET Username = '" + textBox2.Text + "', Password = '" + textBox3.Text + "', Site = '" + textBox4.Text + "' WHERE Id='" + int.Parse(textBox1.Text) + "'", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Upadated");
            con.Close();

            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                con.Open();
                SqlCommand command = new SqlCommand("DELETE CRUD_Table1 WHERE Id= '" + int.Parse(textBox1.Text) + "' ", con);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted");
                BindData();
            }
            else
            {
                MessageBox.Show("Put ID");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Username"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Site"].Value.ToString();

        }
    }
}
