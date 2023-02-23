
namespace CapaPresentacion
{
    partial class Articulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Articulo));
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cboOpciones = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cboSubOpciones = new System.Windows.Forms.ComboBox();
            this.gboBusqueda = new System.Windows.Forms.GroupBox();
            this.lblFiltrar1 = new System.Windows.Forms.Label();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.cboSubOpcion = new System.Windows.Forms.ComboBox();
            this.cboOpcion = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnLimpias = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.gboBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulos.Location = new System.Drawing.Point(12, 137);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(630, 173);
            this.dgvArticulos.TabIndex = 0;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(354, 316);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 32);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.BackColor = System.Drawing.Color.Transparent;
            this.pbxArticulo.Location = new System.Drawing.Point(688, 37);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(150, 229);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArticulo.TabIndex = 17;
            this.pbxArticulo.TabStop = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(461, 316);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(84, 32);
            this.btnModificar.TabIndex = 18;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(561, 316);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(84, 32);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltro.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFiltro.Location = new System.Drawing.Point(6, 78);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(124, 18);
            this.lblFiltro.TabIndex = 20;
            this.lblFiltro.Text = "Filtrado por grupo:";
            // 
            // cboOpciones
            // 
            this.cboOpciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOpciones.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOpciones.FormattingEnabled = true;
            this.cboOpciones.Location = new System.Drawing.Point(145, 74);
            this.cboOpciones.Name = "cboOpciones";
            this.cboOpciones.Size = new System.Drawing.Size(121, 26);
            this.cboOpciones.TabIndex = 21;
            this.cboOpciones.SelectedValueChanged += new System.EventHandler(this.cboOpciones_SelectedValueChanged);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFiltrar.Location = new System.Drawing.Point(423, 75);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(79, 29);
            this.btnFiltrar.TabIndex = 22;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cboSubOpciones
            // 
            this.cboSubOpciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubOpciones.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSubOpciones.FormattingEnabled = true;
            this.cboSubOpciones.Location = new System.Drawing.Point(285, 75);
            this.cboSubOpciones.Name = "cboSubOpciones";
            this.cboSubOpciones.Size = new System.Drawing.Size(121, 26);
            this.cboSubOpciones.TabIndex = 23;
            // 
            // gboBusqueda
            // 
            this.gboBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.gboBusqueda.Controls.Add(this.btnLimpias);
            this.gboBusqueda.Controls.Add(this.lblFiltrar1);
            this.gboBusqueda.Controls.Add(this.txtParametro);
            this.gboBusqueda.Controls.Add(this.cboSubOpcion);
            this.gboBusqueda.Controls.Add(this.cboOpcion);
            this.gboBusqueda.Controls.Add(this.lblFiltro);
            this.gboBusqueda.Controls.Add(this.btnFiltrar);
            this.gboBusqueda.Controls.Add(this.cboSubOpciones);
            this.gboBusqueda.Controls.Add(this.cboOpciones);
            this.gboBusqueda.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboBusqueda.ForeColor = System.Drawing.SystemColors.Control;
            this.gboBusqueda.Location = new System.Drawing.Point(12, 13);
            this.gboBusqueda.Name = "gboBusqueda";
            this.gboBusqueda.Size = new System.Drawing.Size(630, 118);
            this.gboBusqueda.TabIndex = 24;
            this.gboBusqueda.TabStop = false;
            this.gboBusqueda.Text = "Busqueda";
            // 
            // lblFiltrar1
            // 
            this.lblFiltrar1.AutoSize = true;
            this.lblFiltrar1.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltrar1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrar1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFiltrar1.Location = new System.Drawing.Point(6, 39);
            this.lblFiltrar1.Name = "lblFiltrar1";
            this.lblFiltrar1.Size = new System.Drawing.Size(133, 18);
            this.lblFiltrar1.TabIndex = 27;
            this.lblFiltrar1.Text = "Filtrado general por:";
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(423, 35);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(120, 25);
            this.txtParametro.TabIndex = 26;
            // 
            // cboSubOpcion
            // 
            this.cboSubOpcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubOpcion.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSubOpcion.FormattingEnabled = true;
            this.cboSubOpcion.Location = new System.Drawing.Point(285, 36);
            this.cboSubOpcion.Name = "cboSubOpcion";
            this.cboSubOpcion.Size = new System.Drawing.Size(121, 26);
            this.cboSubOpcion.TabIndex = 25;
            // 
            // cboOpcion
            // 
            this.cboOpcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOpcion.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOpcion.FormattingEnabled = true;
            this.cboOpcion.Location = new System.Drawing.Point(145, 35);
            this.cboOpcion.Name = "cboOpcion";
            this.cboOpcion.Size = new System.Drawing.Size(121, 26);
            this.cboOpcion.TabIndex = 24;
            this.cboOpcion.SelectedValueChanged += new System.EventHandler(this.cboOpcion_SelectedValueChanged);
            // 
            // btnLimpias
            // 
            this.btnLimpias.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpias.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpias.Location = new System.Drawing.Point(520, 75);
            this.btnLimpias.Name = "btnLimpias";
            this.btnLimpias.Size = new System.Drawing.Size(79, 29);
            this.btnLimpias.TabIndex = 28;
            this.btnLimpias.Text = "Limpiar";
            this.btnLimpias.UseVisualStyleBackColor = true;
            this.btnLimpias.Click += new System.EventHandler(this.btnLimpias_Click);
            // 
            // Articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(882, 357);
            this.Controls.Add(this.gboBusqueda);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvArticulos);
            this.Name = "Articulo";
            this.Text = "Articulos";
            this.Load += new System.EventHandler(this.Articulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.gboBusqueda.ResumeLayout(false);
            this.gboBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cboOpciones;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cboSubOpciones;
        private System.Windows.Forms.GroupBox gboBusqueda;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblFiltrar1;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.ComboBox cboSubOpcion;
        private System.Windows.Forms.ComboBox cboOpcion;
        private System.Windows.Forms.Button btnLimpias;
    }
}