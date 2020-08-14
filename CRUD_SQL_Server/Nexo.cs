using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace CRUD_SQL_Server
{
    class Nexo
    {
        #region variables de instancia
        SqlConnection sqlConnection;
        #endregion

        #region Metodos

        /**
         * Este metodo se encarga de conectarse a la base de datos seleccionada mediante
         * un objeto SqlConnection utilizando la cadena de conexion y mediante el metodo
         * Open poder abrir un nexo entre el programa y la base de datos
         */
        public void conexion()
        {
            //Creamos el enlace con el objeto mediante la cadena de conexion
            sqlConnection = new SqlConnection("Data Source=DESKTOP-CM20RJA;Initial Catalog=Persona;User ID=sa;Password=1123581321xD$");
            //Abrimos el nexo entre el programa y la base datos
            sqlConnection.Open();
        }


        /**
         * Ete metodo es el encargado de cerrar el nexo entre la base de datos y el 
         * programa mediante un objeto SqlConnection y el metodo Close
         */
        public void desConexion()
        {
            sqlConnection.Close();
        }

        /**
         * Este metodo es el encargado de ejecutar los comando SQL que deseamos para las operaciónes en nuestra base de datos
         * @Param String cadena que contiene la consulta que deseamos ejecutar
         */
        public void ejecutarSQL(string consulta)
        {
            SqlCommand sqlCommand;
            int cambios;

            //Nos conectamos a la base de datos
            this.conexion();

            //Instanciamos el objeto para realizar comandos SQL con la cadena de la consulta SQL y la conexion a la BD
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            //Ejecutamos la consutla SQL y guardamos el numero de filas afectadas
            cambios = sqlCommand.ExecuteNonQuery();

            //Verificamos los cambios en la base de
            if (cambios != 0)
            {
                MessageBox.Show("Operacion realizada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo realizar la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.desConexion();
        }

        /**
         * @Param DataGridView Es el data grid que queremos rellenar
         * @Param String Consulta que deseamos inicializar
         * Este metodo se encarga de llenar el datagrid 
         * 
         */
        public void actualizaGrid(DataGridView dataGridView, string consutla)
        {
            //Cache de datos en memoria
            DataSet dataSet;
            //Adaptador de resultados de datosSQL para la variable DataSet
            SqlDataAdapter sqlDataAdapter;

            //Nos conectamos a la base de datos
            this.conexion();
            dataSet = new DataSet();


            //Inicializamos el adaptador con el comando SQL que deseamos realizar y con el objeto que tiene nuestro enlace
            sqlDataAdapter = new SqlDataAdapter(consutla, this.sqlConnection);

            //Utilizamos el metodo Fill para ejecutar el comando SQL y se ordenene en la variable dataSet
            sqlDataAdapter.Fill(dataSet, "Alumno");
            //Rellenamos los datos del dataGrid con el contenido del dataSet
            dataGridView.DataSource = dataSet;
            //Establecemos el nombre de la tabla de origen de los datos
            dataGridView.DataMember = "Alumno";

            //Nos desconectamos de la base de datos
            this.desConexion();

        }
        #endregion
    }
}
