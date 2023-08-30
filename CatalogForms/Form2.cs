using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CatalogForms
{
    public partial class Form2 : Form
    {
        int id_student = 0;
        SqlCommand cmd;
        SqlConnection cn = new SqlConnection(@"Data Source = DESKTOP-6V1C8KS\SQLEXPRESS; Initial Catalog = CatalogForms; Integrated Security = True");
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'catalogFormsDataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.catalogFormsDataSet.student);

        }

        private void DisplayData()
        {
            cn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from student", cn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }

        private void ClearData()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                cmd = new SqlCommand("insert into student(nume,clasa,numar_telefon_tutore,varsta,medie_anuala) values(@nume,@clasa,@nr_telefon,@varsta,@medie_anuala)", cn);
                cn.Open();
                cmd.Parameters.AddWithValue("@nume", textBox2.Text);
                cmd.Parameters.AddWithValue("@clasa", textBox3.Text);
                cmd.Parameters.AddWithValue("@nr_telefon", textBox4.Text);
                cmd.Parameters.AddWithValue("@varsta", textBox5.Text);
                cmd.Parameters.AddWithValue("@medie_anuala", textBox6.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                DisplayData();
                MessageBox.Show("Student adaugat cu succes!");
                ClearData();
                chart1.Refresh();
            }
            else
            {
                MessageBox.Show("Trebuie introduse toate datele necesare");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "" || textBox6.Text != "")
            {
                cmd = new SqlCommand("update student set nume=@nume,clasa=@clasa,numar_telefon_tutore=@nr_telefon,varsta=@varsta,medie_anuala=@medie_anuala where id_student=@id_student", cn);
                cn.Open();
                cmd.Parameters.AddWithValue("@id_student", id_student);
                cmd.Parameters.AddWithValue("@nume", textBox2.Text);
                cmd.Parameters.AddWithValue("@clasa", textBox3.Text);
                cmd.Parameters.AddWithValue("@nr_telefon", textBox4.Text);
                cmd.Parameters.AddWithValue("@varsta", textBox5.Text);
                cmd.Parameters.AddWithValue("@medie_anuala", textBox6.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Informatii student actualizate cu succes!");
                cn.Close();
                DisplayData();
                ClearData();
                chart1.Refresh();
            }
            else
            {
                MessageBox.Show("Selecteaza studentul a carui informatii doriti actualizate!");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (id_student != 0)
            {
                SqlCommand cmd = new SqlCommand("delete student where id_student=@id_student", cn);
                cn.Open();
                cmd.Parameters.AddWithValue("@id_student", id_student);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Informatii student sterse cu succes!");
                DisplayData();
                ClearData();
                chart1.Refresh();
            }
            else
            {
                MessageBox.Show("Selecteaza studentul a carui informatii doriti sa le stergeti!");
            }
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            id_student = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cn.Open();
            chart1.ResetAutoValues();
            chart1.Update();
            chart1.Refresh();
            cn.Close();

        }
    }
    }








