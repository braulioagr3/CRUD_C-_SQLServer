using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_SQL_Server
{
    public partial class CRUD : Form
    {

        #region Variables de instancia
        //variable para poder realizar las operaciones con la base de datos
        Nexo nexo;
        bool band;
        int id;
        string consulta;
        #endregion

        #region Constructores
        public CRUD()
        {
            InitializeComponent();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            band = false;
            this.id = -1;
            //Creamos el nexo para conectarnos a la base de datos
            nexo = new Nexo();
            //Mandamos actualizar el data gridView
            nexo.actualizaGrid(this.dataGridView1,"select * from Alumno");

        }
        #endregion

        #region Eventos

        #region Botones
        private void buttons_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).AccessibleName)
            {
                case "Agregar":
                    #region Agregar
                    //Damos formato a la consulta SQL
                    consulta = "insert into Alumno(nombre, apellido, edad) values ('" + textBoxNombre.Text + "','" + textBoxApellido.Text + "'," + textBoxEdad.Text + ")";
                    //MAndamos limpiar los textbox
                    this.limpiaTextBox();
                    //Ejecutamos los comandosSQL
                    nexo.ejecutarSQL(consulta);
                    //Actualizamos el data grid
                    nexo.actualizaGrid(this.dataGridView1, "select * from Alumno");
                    #endregion
                    break;
                case "Actualizar":
                    #region Actualizar
                    //Si la bandera esta en falso  significa que debemos actualizar la fila seleccionada con el contenido de los textbox
                    if (band)
                    {
                        //Preparamos la consulta con los contenidos de los textbox y usamos el id capturado para poder usar el where
                        this.consulta = "update Alumno set Nombre = '" + textBoxNombre.Text +
                                        "', Apellido = '" + textBoxApellido.Text +
                                        "', Edad =" + textBoxEdad.Text +
                                        "where idAlumno =" + this.id.ToString();
                        //Ejecutamos el comando SQL
                        this.nexo.ejecutarSQL(consulta);
                        //Actualizamos el data grid
                        this.nexo.actualizaGrid(this.dataGridView1, "select * from Alumno");
                        //Habilitamos los botones para poder volver a operar
                        this.button1.Enabled = true;
                        this.button3.Enabled = true;
                        this.button4.Enabled = true;
                        //Limpiamos los textbox y bajamos la bandera
                        this.limpiaTextBox();
                        this.band = false;
                    }
                    //Si no significa que 
                    else
                    {
                        //Obtenemos el id de la fila seleccionada  y lo guaramos en la variable
                        this.id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        //Obtenemos los datos de la fila seleccionada y lo ponemos en los textbox
                        this.textBoxNombre.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        this.textBoxApellido.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        this.textBoxEdad.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        //Deshabilitamos los botones para que no se pueda hacer niguna operacion y levantamos la bandera
                        this.button1.Enabled = false;
                        this.button3.Enabled = false;
                        this.button4.Enabled = false;
                        this.band = true;
                    }
                    #endregion
                    break;
                case "Buscar":
                    #region Buscar
                    #endregion
                break;
                case "Eliminar":
                    #region Eliminar
                    //Obtenemos el id de la fila seleccionada  y lo guaramos en la variable
                    this.id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    //Preparamos la consulta con el delete y utilizamos el id con el here
                    this.consulta = "delete from Alumno where idAlumno = " + this.id.ToString();
                    //Ejecutamos el SQL
                    this.nexo.ejecutarSQL(this.consulta);
                    //Actualizamos el datagrid
                    this.nexo.actualizaGrid(this.dataGridView1, "select * from Alumno");
                    #endregion
                    break;
            }
        }
        #endregion

        #region Area Cliente

        private void CRUD_Resize(object sender, EventArgs e)
        {
            Size size;
            Point point;
            size = new Size(this.Width - 41, this.Height - 210);
            this.dataGridView1.Size = size;
            point = new Point(this.Width - 245, this.label4.Location.Y);
            this.label4.Location = point;
            point = new Point(this.Width - 242, this.textBox1.Location.Y);
            this.textBox1.Location = point;
            point = new Point(this.textBox1.Location.X + 193, this.button4.Location.Y);
            this.button4.Location = point;
        }

        #endregion

        #endregion

        private void limpiaTextBox()
        {
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxEdad.Text = "";
        }

    }
}
