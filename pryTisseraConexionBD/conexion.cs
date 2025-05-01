using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;




namespace pryTisseraConexionBD
{
    internal class conexion
    {
        public void Conectar(DataGridView dgv)
        {
            string connectionString = "Server=localhost;Database=Comercio;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("✅ Conexión exitosa a la base de datos.");

                    // CONSULTA SQL
                    string query = "SELECT * FROM Productos";

                    // CREA ADAPTADOR Y LLENA LA TABLA
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // MUESTRA LOS DATOS 
                    dgv.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error al conectar: " + ex.Message);
                }
            }
        }

    }


}
