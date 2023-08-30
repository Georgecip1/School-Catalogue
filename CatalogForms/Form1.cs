using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CatalogForms
{
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlConnection cn = new SqlConnection(@"Data Source = DESKTOP-6V1C8KS\SQLEXPRESS; Initial Catalog = CatalogForms; Integrated Security = True");
        SqlDataReader dr;
        private void Form1_Load(object sender, EventArgs e)
        {
            cn.Open();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {
                SqlConnection cn = new SqlConnection(@"Data Source = DESKTOP-6V1C8KS\SQLEXPRESS; Initial Catalog = CatalogForms; Integrated Security = True");
                cn.Open();
                cmd = new SqlCommand("select * from profesor where id_profesor='" + textBox1.Text + "' and parola_catalog_online='" + textBox2.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    Form2 obj1 = new Form2();
                    obj1.Show();
                    this.Hide();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("ID sau parola gresita!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Trebuie introduse toate datele necesare", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
