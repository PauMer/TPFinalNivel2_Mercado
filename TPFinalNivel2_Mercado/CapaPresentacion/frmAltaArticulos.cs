using CapaDominio;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace CapaPresentacion
{
    public partial class frmAltaArticulos : Form
    {
        private List<Categoria> listaC = new List<Categoria>();
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;

        public frmAltaArticulos()
        {
            InitializeComponent();
        }
        public frmAltaArticulos(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void AltaArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                cargarCbx();
                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagen.Text = articulo.ImagenUrl;
                    txtPrecio.Text = articulo.Precio.ToString();
                    cargarImagen(articulo.ImagenUrl);
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void cargarCbx()
        {
            CategoriaNegocio categoria = new CategoriaNegocio();
            MarcaNegocio marca = new MarcaNegocio();
            cboCategoria.DataSource = categoria.Listar();
            cboCategoria.ValueMember = "Id";
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.SelectedIndex = -1;
            cboMarca.DataSource = marca.Listar();
            cboMarca.ValueMember = "Id";
            cboMarca.DisplayMember = "Descripcion";
            cboMarca.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCasilleros())
            {
                ArticuloNegocio nuevo = new ArticuloNegocio();
                try
                {
                    if (articulo == null)
                        articulo = new Articulo();
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Marca = (Marca)cboMarca.SelectedItem;
                    articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                    articulo.ImagenUrl = txtImagen.Text;
                    articulo.Precio = int.Parse(txtPrecio.Text);

                    if (articulo.Id != 0)
                    {
                        nuevo.modificar(articulo);
                        MessageBox.Show("Modificado exitosamente");
                    }
                    else
                    {
                        nuevo.Agregar(articulo);
                        MessageBox.Show("Agregado exitosamente");
                    }
                    if(archivo != null && !(txtImagen.Text.ToUpper().Contains("HTTP")))
                        File.Copy(archivo.FileName, ConfigurationManager.AppSettings["Archivos"] + archivo.SafeFileName);
              
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    Close();
                }
            }
        }

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagen.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxAlta.Load(imagen);

            }
            catch
            {
                pbxAlta.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validarCasilleros()
        {
            bool bandera = true;

            if (txtCodigo.Text == "")
            {
                bandera = false;
                errCodigo.SetError(txtCodigo, "Debe ingresar un nombre");
            }
            if (txtNombre.Text == "")
            {
                bandera = false;
                errNombre.SetError(txtNombre, "Debe ingresar un Código");
            }
            if (txtDescripcion.Text == "")
            {
                bandera = false;
                errDescripcion.SetError(txtDescripcion, "Debe ingresar una descripcion");
            }
            if (cboMarca.Text == "")
            {
                bandera = false;
                errMarca.SetError(cboMarca, "Debe ingresar una marca");
            }
            if (cboCategoria.Text == "")
            {
                bandera = false;
                errCategoria.SetError(cboCategoria, "Debe ingresar una Categoria");
            }
            if (!validarSoloNumeros(txtPrecio.Text))
            {
                bandera = false;
                MessageBox.Show("Debes ingresar sólo números en el campo 'Precio'");
            }
            if (txtPrecio.Text == "")
            {
                bandera = false;
                errPrecio.SetError(txtPrecio, "Debe ingresar un precio");
            }

            return bandera;
        }
        
        private bool validarSoloNumeros(string precio)
        {
            foreach (char caracter in precio)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text = archivo.FileName;
                cargarImagen(txtImagen.Text);
            }
        }
    }
}
