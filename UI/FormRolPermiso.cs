using BLL;
using BLL.Composite;
using ENTITY;
using ENTITY.Composite;
using Seguridad;
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
    public partial class FormRolPermiso : Form
    {
        private UsuarioBLL UsuarioBLO = new UsuarioBLL();
        private RolBLL RolBLO = new RolBLL();
        private PermisoBLL PermisoBLO = new PermisoBLL();
        private TreeNode nodoUsuarioSeleccionado;
        private TreeNode nodoRolSeleccionado;
        public FormRolPermiso()
        {
            InitializeComponent();
            CargarUsuarios();
            CargarRoles();
            CargarPermisos();

        }

        private void FormRolPermiso_Load(object sender, EventArgs e)
        {

        }

        private void CargarUsuarios()
        {
            try
            {
                List<Usuario> usuarios = UsuarioBLO.ObtenerTodos();
                tv_Usuarios.Nodes.Clear();

                foreach (Usuario usuario in usuarios)
                {
                    TreeNode nodoUsuario = new TreeNode($"{usuario.IdUsuario} - {usuario.NombreUsuario}") { Tag = usuario };

                    foreach (Rol rol in usuario.Roles)
                    {
                        TreeNode nodoRol = new TreeNode($"Rol: {rol.NombreComponente}") { Tag = rol };

                        foreach (Componente permiso in rol.ObtenerHijos())
                        {
                            nodoRol.Nodes.Add(CrearNodoPermiso(permiso));
                        }

                        nodoUsuario.Nodes.Add(nodoRol);
                    }

                    tv_Usuarios.Nodes.Add(nodoUsuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}");
            }
        }
        private void CargarRoles()
        {
            try
            {
                List<Rol> roles = RolBLO.ObtenerTodos();
                tv_Roles.Nodes.Clear();

                foreach (Rol rol in roles)
                {
                    var nodo = new TreeNode(rol.NombreComponente) { Tag = rol };
                    tv_Roles.Nodes.Add(nodo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}");
            }
        }
        private void CargarPermisos()
        {
            try
            {
                List<Componente> listaRaices = PermisoBLO.ObtenerArbol();
                tv_Permisos.Nodes.Clear();

                foreach (Componente comp in listaRaices)
                {
                    tv_Permisos.Nodes.Add(CrearNodoPermiso(comp));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar permisos: {ex.Message}");
            }
        }
        private TreeNode CrearNodoPermiso(Componente comp)
        {
            TreeNode nodo = new TreeNode(comp.NombreComponente) { Tag = comp };

            foreach (var hijo in comp.ObtenerHijos())
            {
                nodo.Nodes.Add(CrearNodoPermiso(hijo));
            }

            return nodo;
        }

        private void btn_AltaRol_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txt_NombreRolAlta.Text.Trim();
                if (string.IsNullOrEmpty(nombre)) throw new ArgumentException("El nombre del rol no puede estar vacío.");


                Rol nuevoRol = new Rol();
                nuevoRol.NombreComponente = nombre;


                RolBLO.Alta(nuevoRol);
                CargarRoles();
                txt_NombreRolAlta.Clear();
                MessageBox.Show("Rol creado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear rol: {ex.Message}");
            }
        }

        private void btn_BajaRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (tv_Roles.Nodes.Count <= 0) throw new InvalidOperationException("No hay roles para eliminar.");
                if (tv_Roles.SelectedNode == null) throw new InvalidOperationException("Debe seleccionar un rol para eliminar.");


                Rol rolSeleccionado = tv_Roles.SelectedNode.Tag as Rol;
                if (rolSeleccionado == null) throw new InvalidOperationException("El nodo seleccionado no es un rol válido.");

                DialogResult confirm = MessageBox.Show($"¿Está seguro que desea eliminar el rol '{rolSeleccionado.NombreComponente}' y todas sus asociaciones?", "Confirmar baja", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    RolBLO.Baja(rolSeleccionado.IdComponente);
                    CargarRoles();
                    CargarUsuarios();
                    MessageBox.Show("Rol eliminado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar rol: {ex.Message}");
            }
        }

        private void btn_AsignarRolSeleccionado_Click(object sender, EventArgs e)
        {
            try
            {
                if (tv_Usuarios.SelectedNode == null || tv_Roles.SelectedNode == null) throw new InvalidOperationException("Debe seleccionar un usuario y un rol.");
                if (tv_Usuarios.SelectedNode?.Tag is not Usuario Unusuario) throw new Exception("El nodo seleccionado no es un usuario válido.");
                if (tv_Roles.SelectedNode?.Tag is not Rol Unrol) throw new Exception("El nodo seleccionado no es un rol válido.");

                Usuario usuario = (Usuario)tv_Usuarios.SelectedNode.Tag;
                Rol rol = (Rol)tv_Roles.SelectedNode.Tag;

                UsuarioBLO.AsociarRolAUsuario(usuario.IdUsuario, rol.IdComponente);


                CargarUsuarios(); // Actualiza visualización
                MessageBox.Show($"Rol '{rol.NombreComponente}' asignado a '{usuario.NombreUsuario}'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar rol: {ex.Message}");
            }
        }

        private void btn_QuitarRolSeleccionado_Click(object sender, EventArgs e)
        {
            try
            {
                if (tv_Usuarios.SelectedNode == null || tv_Roles.SelectedNode == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario y un rol.");
                    return;
                }
                if (tv_Usuarios.SelectedNode?.Tag is not Usuario Unusuario) throw new Exception("El nodo seleccionado no es un usuario válido.");
                if (tv_Roles.SelectedNode?.Tag is not Rol Unrol) throw new Exception("El nodo seleccionado no es un rol válido.");
                Usuario usuario = (Usuario)tv_Usuarios.SelectedNode.Tag;
                Rol rol = (Rol)tv_Roles.SelectedNode.Tag;

                UsuarioBLO.DesasociarRolDeUsuario(usuario.IdUsuario, rol.IdComponente);
                MessageBox.Show($"Rol '{rol.NombreComponente}' quitado a '{usuario.NombreUsuario}'.");

                CargarUsuarios(); // Actualiza visualización
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al quitar rol: {ex.Message}");
            }
        }

        private void tv_Usuarios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (nodoUsuarioSeleccionado != null)
                    nodoUsuarioSeleccionado.BackColor = Color.White;

                nodoUsuarioSeleccionado = e.Node;
                nodoUsuarioSeleccionado.BackColor = Color.LightBlue;

                if (e.Node?.Tag is Usuario usuario)
                {
                    txt_IdUsuario.Text = usuario.IdUsuario.ToString();
                    txt_Nombre.Text = usuario.NombreUsuario;
                    txt_Password.Text = usuario.Contrasena;

                    CargarPermisosUsuario(usuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tv_Roles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (nodoRolSeleccionado != null)
                    nodoRolSeleccionado.BackColor = Color.White;

                nodoRolSeleccionado = e.Node;
                nodoRolSeleccionado.BackColor = Color.LightGreen;

                if (e.Node?.Tag is Rol rol)
                {
                    txt_IdRol.Text = rol.IdComponente.ToString();
                    txt_NombreRol.Text = rol.NombreComponente;

                    CargarPermisosRol(rol);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarPermisosUsuario(Usuario usuario)
        {
            try
            {
                Dictionary<int, Componente> DicPermisosUnicos = new Dictionary<int, Componente>();

                foreach (Rol rol in usuario.Roles)
                {
                    foreach (Componente permiso in rol.ObtenerHijos())
                    {
                        AgregarPermisosRecursivos(permiso, DicPermisosUnicos);
                    }
                }

                tv_PermisoUsuario.Nodes.Clear();

                foreach (Componente permiso in DicPermisosUnicos.Values.Where(p => !TienePadre(p, DicPermisosUnicos)))
                {
                    tv_PermisoUsuario.Nodes.Add(CrearNodoPermiso(permiso));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarPermisosRol(Rol rol)
        {
            try
            {
                tv_PermisosRol.Nodes.Clear();
                foreach (Componente permiso in rol.ObtenerHijos())
                {
                    tv_PermisosRol.Nodes.Add(CrearNodoPermiso(permiso));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool TienePadre(Componente comp, Dictionary<int, Componente> DicPermisosUnicos)
        {
            return DicPermisosUnicos.Values.Any(c => c.ObtenerHijos().Any(h => h.IdComponente == comp.IdComponente));
        }

        private void AgregarPermisosRecursivos(Componente Permiso, Dictionary<int, Componente> DicPermisosUnicos)
        {
            try
            {
                if (!DicPermisosUnicos.ContainsKey(Permiso.IdComponente))
                {
                    DicPermisosUnicos.Add(Permiso.IdComponente, Permiso);
                }

                foreach (var hijo in Permiso.ObtenerHijos())
                {
                    AgregarPermisosRecursivos(hijo, DicPermisosUnicos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AsignarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (tv_Roles.SelectedNode == null || tv_Permisos.SelectedNode == null)
                    throw new InvalidOperationException("Debe seleccionar un rol y un permiso.");

                Rol rol = tv_Roles.SelectedNode.Tag as Rol;
                Componente permiso = tv_Permisos.SelectedNode.Tag as Componente;

                if (rol == null || permiso == null)
                    throw new InvalidOperationException("Selección inválida.");

                RolBLO.AgregarPermisoARol(rol.IdComponente, permiso.IdComponente);

                CargarRoles();  // Para reflejar cambios si se desea
                CargarPermisosRol(rol);  // Actualiza árbol de permisos del rol
                MessageBox.Show($"Permiso '{permiso.NombreComponente}' asignado al rol '{rol.NombreComponente}'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar permiso: {ex.Message}");
            }
        }

        private void btn_QuitarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (tv_Roles.SelectedNode == null || tv_PermisosRol.SelectedNode == null)
                    throw new InvalidOperationException("Debe seleccionar un rol y un permiso del árbol de Rol Permisos.");

                Rol rol = tv_Roles.SelectedNode.Tag as Rol;
                Componente permiso = tv_PermisosRol.SelectedNode.Tag as Componente;

                if (rol == null || permiso == null)
                    throw new InvalidOperationException("Selección inválida.");

                RolBLO.QuitarPermisoARol(rol.IdComponente, permiso.IdComponente);

                CargarPermisosRol(rol); // Recargar permisos del rol
                MessageBox.Show($"Permiso '{permiso.NombreComponente}' quitado del rol '{rol.NombreComponente}'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al quitar permiso: {ex.Message}");
            }
        }

        private void tv_Permisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node?.Tag is Componente permiso)
                {
                    txt_IdPermiso.Text = permiso.IdComponente.ToString();
                    txt_NombrePermiso.Text = permiso.NombreComponente;
                    checkBox_EsHoja.Checked = permiso is PermisoItem;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar datos del permiso: {ex.Message}");
            }
        }

        private void tv_PermisosRol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void checkBox_Desencriptar_CheckedChanged(object sender, EventArgs e)
        {
            if (tv_Usuarios.SelectedNode?.Tag is Usuario usuario)
            {
                if (checkBox_Desencriptar.Checked)
                {
                    txt_Password.Text = Encriptador.Desencriptar(usuario.Contrasena);
                }
                else
                {
                    txt_Password.Text = usuario.Contrasena; // Mostrar encriptada
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario para desencriptar la contraseña.");
            }
        }
    }
}

