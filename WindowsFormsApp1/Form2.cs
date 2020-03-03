using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=(LAPTOP-V9PGKOUS\SQLEXPRESS);Initial Catalog=neptuno;Integrated Security=True");

        public void ListaClientes()
        {
            using (SqlDataAdapter Df = new SqlDataAdapter("Select * from clientes", cn))
            {
                using (DataSet Da = new DataSet())
                {
                    // Llenar el DataSet mediante el método FILL del SqlAdapter
                    Df.Fill(Da, "clientes");
                    // Mostrar los datos en el control DataGridView
                    dgClientes.DataSource = Da.Tables["clientes"];
                    // Mostrar el número de clientes, pero en este ejemplo utilizar DataSet
                    lblTotal.Text = Da.Tables["clientes"].Rows.Count.ToString();
                }
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            // Colocar el nombre del metodo en el formulario, ya que contiene el evento Load(Cargar)
            ListaClientes();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
