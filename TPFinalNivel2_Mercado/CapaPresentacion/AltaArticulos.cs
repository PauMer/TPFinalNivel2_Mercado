using CapaDominio;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class AltaArticulos : Form
    {
        private List<CategoriasCAD> listaC = new List<CategoriasCAD>();
        private ArticuloCAD articulo = null;

        public AltaArticulos()
        {
            InitializeComponent();
        }
        public AltaArticulos(ArticuloCAD articulo)
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
                if(articulo != null)
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
            CategoriaN categoria = new CategoriaN();
            MarcaN marca = new MarcaN();
            cboCategoria.DataSource = categoria.Listar();
            cboCategoria.ValueMember = "Id";
            cboCategoria.DisplayMember = "Descripcion";
            cboMarca.DataSource = marca.Listar();
            cboMarca.ValueMember = "Id";
            cboMarca.DisplayMember = "Descripcion";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloCLN nuevo = new ArticuloCLN();
            try
            {
                if (articulo == null)
                    articulo = new ArticuloCAD();
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (MarcasCAD)cboMarca.SelectedItem;
                articulo.Categoria = (CategoriasCAD)cboCategoria.SelectedItem;
                articulo.ImagenUrl = txtImagen.Text;
                articulo.Precio = int.Parse(txtPrecio.Text);

                if(articulo.Id != 0)
                {
                    nuevo.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    nuevo.Agregar(articulo);
                    MessageBox.Show("Agregado exitosamente");
                }
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
    }
}
