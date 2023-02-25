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
    public partial class frmArticulo : Form
    {
        private List<Articulo> listaArticulos;
        private int id;
        public frmArticulo()
        {
            InitializeComponent();
        }

        private void Articulo_Load(object sender, EventArgs e)
        {
            cargar();
        }

        public void cargar()
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            listaArticulos = articulo.Listar();
            cargarDgv(listaArticulos);
            cargarImagen(listaArticulos[0].ImagenUrl);
            cboOpciones.Items.Clear();
            cboOpciones.Items.Add("Marca");
            cboOpciones.Items.Add("Categoria");
            cboCampo.Items.Clear();
            cboCampo.Items.Add("Código");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");
            cboCampo.Items.Add("Precio");
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                Articulo articuloSelect = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(articuloSelect.ImagenUrl);
                id = articuloSelect.Id;
            }
        }

        public void cargarImagen (string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);

            }
            catch
            {
               pbxArticulo.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Estás seguro de eliminar?", "¿Eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    articulo.eliminarArticulo(id);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulos alta = new frmAltaArticulos();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAltaArticulos modificar = new frmAltaArticulos(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void cboOpciones_SelectedValueChanged(object sender, EventArgs e)
        {
            int seleccionado = cboOpciones.SelectedIndex;
            CategoriaNegocio categoria = new CategoriaNegocio();
            MarcaNegocio marca = new MarcaNegocio();
            switch (seleccionado)
            {
                case 0:
                    cboSubOpciones.DataSource = marca.Listar();
                    cboSubOpciones.ValueMember = "Id";
                    cboSubOpciones.DisplayMember = "Descripcion";
                    break;
                case 1:
                    cboSubOpciones.DataSource = categoria.Listar();
                    cboSubOpciones.ValueMember = "Id";
                    cboSubOpciones.DisplayMember = "Descripcion";
                    break;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            ArticuloNegocio articulo = new ArticuloNegocio();
            int indiceB = cboOpciones.SelectedIndex;
            int campo = cboCampo.SelectedIndex;
            string parametro = txtParametro.Text;
            int caracter = cboCaracter.SelectedIndex;

            try
            {
                if(campo == 3)
                {
                        if(caracter == 0)
                        {
                            listaFiltrada = listaArticulos.FindAll(x => x.Precio <= int.Parse(parametro));
                            cargarDgv(listaFiltrada);
                        }
                        else
                        {
                            listaFiltrada = listaArticulos.FindAll(x => x.Precio >= int.Parse(parametro));
                            cargarDgv(listaFiltrada);
                        }
                }
                else
                {
                    listaFiltrada = articulo.Filtrar(campo, caracter, parametro);
                    cargarDgv(listaFiltrada);
                }

                switch(indiceB)
                {
                    case 0:
                        Marca marca = (Marca)cboSubOpciones.SelectedItem;
                        listaFiltrada = listaArticulos.FindAll(x => x.Marca.Id == marca.Id);
                        cargarDgv(listaFiltrada);
                        break;
                    case 1:
                        Categoria categoria = (Categoria)cboSubOpciones.SelectedItem;
                        listaFiltrada = listaArticulos.FindAll(x => x.Categoria.Id == categoria.Id);
                        cargarDgv(listaFiltrada);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarDgv(List<Articulo> listaFiltrada)
        {
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
        }
        private void cboOpcion_SelectedValueChanged(object sender, EventArgs e)
        {
            int seleccionado = cboCampo.SelectedIndex;
            
            if(seleccionado == 3)
            {
                cboCaracter.Items.Clear();
                cboCaracter.Items.Add("Menor o igual a:");
                cboCaracter.Items.Add("Mayor o igual a");
            }
            else
            {
                cboCaracter.Items.Clear();
                cboCaracter.Items.Add("Empieza con");
                cboCaracter.Items.Add("Termina con");
                cboCaracter.Items.Add("Contiene");
            }
        }

        private void btnLimpias_Click(object sender, EventArgs e)
        {
            cboCampo.SelectedIndex = -1;
            cboCaracter.SelectedIndex = -1;
            cboOpciones.SelectedIndex = -1;
            cboSubOpciones.SelectedIndex = -1;
            txtParametro.Text = "";
            cargar();
        }
    }
}
