using BLL;
using DAL;
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
    public partial class FormRecargaCombustible : Form
    {
        ProveedorCombustibleBLL ProveedorCombustibleBLO = new ProveedorCombustibleBLL();
        DepositoCombustibleDAL DepositoCombustibleDAO = new DepositoCombustibleDAL();
        FacturaCombustibleBLL FacturaCombustibleBLO = new FacturaCombustibleBLL();  

        public FormRecargaCombustible()
        {
            InitializeComponent();
        }


        private void FormRecargaCombustible_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
        }


        #region Funciones Form



        private void CargarComboBoxes()
        {
            CargarComboBoxProveedorCombu();
            CargarComboBoxDeposito();
        }

        private void CargarComboBoxDeposito()
        {
            try
            {
                List<DepositoCombustible> LDepositosCombu = DepositoCombustibleDAO.ObtenerTodos();
                cmBox_DepositoCombu.DataSource = null;
                if(LDepositosCombu.Count>=0)
                {
                    cmBox_DepositoCombu.DataSource = LDepositosCombu;
                    cmBox_DepositoCombu.DisplayMember = "IdDepositoCombustible";
                    cmBox_DepositoCombu.ValueMember = "IdDepositoCombustible";
                    cmBox_DepositoCombu.SelectedIndex = -1;
                    cmBox_DepositoCombu.Text = "Seleccione un deposito";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboBoxProveedorCombu()
        {
            try
            {
                List<ProveedorCombustible> LproveedoresCombustible = ProveedorCombustibleBLO.ObtenerProveedores().Where(p => p.Activo).ToList();
                cmBox_ProveedorCombu.DataSource = null;
                if (LproveedoresCombustible.Count >= 0)
                {
                    cmBox_ProveedorCombu.DataSource = LproveedoresCombustible;
                    cmBox_ProveedorCombu.DisplayMember = "NombreEmpresa";
                    cmBox_ProveedorCombu.ValueMember = "IdProveedorCombustible";
                    cmBox_ProveedorCombu.SelectedIndex = -1;
                    cmBox_ProveedorCombu.Text = "Seleccione un proveedor";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion Fin Funciones Form




        #region Botones Form


        private void btn_RegistrarRecarga_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmBox_ProveedorCombu.SelectedIndex <= -1) throw new Exception("Debe seleccionar un Proveedor de combustible para registrar la regarga");
                ProveedorCombustible proveedorCombustible = cmBox_ProveedorCombu.SelectedItem as ProveedorCombustible;
                if (proveedorCombustible == null) throw new Exception("Error al obtener el proveedor de combustible del combo box");
                if (cmBox_DepositoCombu.SelectedIndex <= -1) throw new Exception("Debe seleccionar un deposito de combustible para la registrar la recarga");
                DepositoCombustible depositoCombustible = cmBox_DepositoCombu.SelectedItem as DepositoCombustible;
                if (depositoCombustible == null) throw new Exception("Error al obtener deposito de combustible del combo box");

                if(!decimal.TryParse(txt_CantidadLitros.Text, out decimal cantidadLitros)) throw new Exception("cantidad de litros invalida. Debe ser numerica");
                if(!decimal.TryParse(txt_PrecioLitro.Text,out decimal precioLitro)) throw new Exception("Precio de litro invalido, debe ser numerico");

                if (!int.TryParse(txt_NroFactura.Text,out int nroFactura)) throw new Exception("Nro de factura invalido, este debe ser numerico");
                if (!decimal.TryParse(txt_MontoFactura.Text, out decimal montoFactura)) throw new Exception("Monto Factura invalido, este debe ser numerico");

                RecargaCombustible recarga = new RecargaCombustible()
                {
                   ProveedorCombu = proveedorCombustible,
                   DepositoCombu = depositoCombustible,
                   PrecioLitros = precioLitro,
                   CantidadLitros = cantidadLitros,
                   Fecha = dtp_Fecha.Value,
                   
                };
                FacturaCombustible facturaCombustible = new FacturaCombustible()
                {
                    NroFactura = nroFactura,
                    MontoTotal = montoFactura,
                    RecargaCombu = recarga,
                };

                FacturaCombustibleBLO.RegistrarFacturaCombustible(facturaCombustible);

                MessageBox.Show("Recarga y Factura de combustible registradas correctamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_EliminarFactura_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        #endregion Fin Botones Form

 
    }
}
