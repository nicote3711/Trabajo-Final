using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormSolicitarMantenimiento100Hs : Form
    {
        MantenimientoBLL MantenimientoBLO = new MantenimientoBLL();
        public FormSolicitarMantenimiento100Hs()
        {
            InitializeComponent();
        }

        private void FormSolicitarMantenimiento100Hs_Load(object sender, EventArgs e)
        {
            CargarDgv();
        }

        private void CargarDgv()
        {
            try
            {
                List<Mantenimiento> LMantenimientos = MantenimientoBLO.ObtenerTodos();
                dgv_Mantenimientos.DataSource = null;
                if(LMantenimientos.Count > 0 )
                {
                    dgv_Mantenimientos.DataSource =LMantenimientos;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
