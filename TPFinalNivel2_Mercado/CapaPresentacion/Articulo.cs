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
    public partial class Articulo : Form
    {
        private List<ArticuloCAD> listaArticulos;
        private int id;
        public Articulo()
        {
            InitializeComponent();
        }

        private void Articulo_Load(object sender, EventArgs e)
        {
            cargar();
        }

        public void cargar()
        {
            ArticuloCLN articulo = new ArticuloCLN();
            listaArticulos = articulo.Listar();
            cargarDgv(listaArticulos);
            cargarImagen(listaArticulos[0].ImagenUrl);
            cboOpciones.Items.Clear();
            cboOpciones.Items.Add("Marca");
            cboOpciones.Items.Add("Categoria");
            cboOpcion.Items.Clear();
            cboOpcion.Items.Add("Código");
            cboOpcion.Items.Add("Nombre");
            cboOpcion.Items.Add("Descripción");
            cboOpcion.Items.Add("Precio");
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                ArticuloCAD articuloSelect = (ArticuloCAD)dgvArticulos.CurrentRow.DataBoundItem;
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
            ArticuloCLN articulo = new ArticuloCLN();
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
            AltaArticulos alta = new AltaArticulos();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ArticuloCAD seleccionado;
            seleccionado = (ArticuloCAD)dgvArticulos.CurrentRow.DataBoundItem;
            AltaArticulos modificar = new AltaArticulos(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void cboOpciones_SelectedValueChanged(object sender, EventArgs e)
        {
            int seleccionado = cboOpciones.SelectedIndex;
            CategoriaN categoria = new CategoriaN();
            MarcaN marca = new MarcaN();
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
            List<ArticuloCAD> listaFiltrada;
            ArticuloCLN articulo = new ArticuloCLN();
            int indiceB = cboOpciones.SelectedIndex;
            int indiceA = cboOpcion.SelectedIndex;
            string parametro = txtParametro.Text;
            int opcion = cboSubOpcion.SelectedIndex;

            if(indiceA == 3)
            {
                    if(opcion == 0)
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
                listaFiltrada = articulo.Filtrar(indiceA, opcion, parametro);
                cargarDgv(listaFiltrada);
            }

            switch(indiceB)
            {
                case 0:
                    MarcasCAD marca = (MarcasCAD)cboSubOpciones.SelectedItem;
                    listaFiltrada = listaArticulos.FindAll(x => x.Marca.Id == marca.Id);
                    cargarDgv(listaFiltrada);
                    break;
                case 1:
                    CategoriasCAD categoria = (CategoriasCAD)cboSubOpciones.SelectedItem;
                    listaFiltrada = listaArticulos.FindAll(x => x.Categoria.Id == categoria.Id);
                    cargarDgv(listaFiltrada);
                    break;
            }
        }

        private void cargarDgv(List<ArticuloCAD> listaFiltrada)
        {
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
        }
        private void cboOpcion_SelectedValueChanged(object sender, EventArgs e)
        {
            int seleccionado = cboOpcion.SelectedIndex;
            
            if(seleccionado == 3)
            {
                cboSubOpcion.Items.Clear();
                cboSubOpcion.Items.Add("Menor o igual a:");
                cboSubOpcion.Items.Add("Mayor o igual a");
            }
            else
            {
                cboSubOpcion.Items.Clear();
                cboSubOpcion.Items.Add("Empieza con");
                cboSubOpcion.Items.Add("Termina con");
                cboSubOpcion.Items.Add("Contiene");
            }
        }

        private void btnLimpias_Click(object sender, EventArgs e)
        {
            cboOpcion.SelectedIndex = -1;
            cboSubOpcion.SelectedIndex = -1;
            cboOpciones.SelectedIndex = -1;
            cboSubOpciones.SelectedIndex = -1;
            txtParametro.Text = "";
            cargar();
        }
    }
}
