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
        #endregion

        #region Constructores
        public CRUD()
        {
            InitializeComponent();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
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
            string consulta;
            switch(((Button)sender).AccessibleName)
            {
                case "Agregar":
                    #region Agregar
                    #endregion
                break;
                case "Actualizar":
                    #region Actualizar
                    #endregion
                break;
                case "Buscar":
                    #region Buscar
                    #endregion
                break;
                case "Eliminar":
                    #region Eliminar
                    #endregion
                break;
            }
        }
        #endregion

        #endregion

        private void CRUD_Resize(object sender, EventArgs e)
        {
            Size size;
            Point point;
            size = new Size(this.Width - 41, this.Height - 210);
            this.dataGridView1.Size = size;
            point = new Point(this.Width - 245,this.label4.Location.Y);
            this.label4.Location = point;
            point = new Point(this.Width - 242, this.textBox1.Location.Y);
            this.textBox1.Location = point;
            point = new Point(this.textBox1.Location.X + 193, this.button4.Location.Y);
            this.button4.Location = point;
        }
    }
}
