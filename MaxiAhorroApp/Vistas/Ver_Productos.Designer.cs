namespace MaxiAhorroApp.Vistas
{
    partial class Ver_Productos
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
            this.productostb = new System.Windows.Forms.DataGridView();
            this.id_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cat_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuan_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datein_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prov_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateex_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sign_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tx_buscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.productostb)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productostb
            // 
            this.productostb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productostb.BackgroundColor = System.Drawing.Color.White;
            this.productostb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productostb.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.productostb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productostb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_cl,
            this.nombre_cl,
            this.descripcion_cl,
            this.cat_cl,
            this.price_cl,
            this.cuan_cl,
            this.datein_cl,
            this.prov_cl,
            this.barcode_cl,
            this.dateex_cl,
            this.sign_cl,
            this.location_cl});
            this.productostb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productostb.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.productostb.Location = new System.Drawing.Point(5, 94);
            this.productostb.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.productostb.Name = "productostb";
            this.productostb.ReadOnly = true;
            this.productostb.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.productostb.Size = new System.Drawing.Size(971, 309);
            this.productostb.TabIndex = 0;
            this.productostb.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.productostb_CellFormatting);
            this.productostb.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.productostb_CellMouseClick);
            // 
            // id_cl
            // 
            this.id_cl.DataPropertyName = "Id";
            this.id_cl.HeaderText = "ID";
            this.id_cl.Name = "id_cl";
            this.id_cl.ReadOnly = true;
            // 
            // nombre_cl
            // 
            this.nombre_cl.DataPropertyName = "Name";
            this.nombre_cl.HeaderText = "Nombre";
            this.nombre_cl.Name = "nombre_cl";
            this.nombre_cl.ReadOnly = true;
            // 
            // descripcion_cl
            // 
            this.descripcion_cl.DataPropertyName = "Description";
            this.descripcion_cl.HeaderText = "Descripción";
            this.descripcion_cl.Name = "descripcion_cl";
            this.descripcion_cl.ReadOnly = true;
            // 
            // cat_cl
            // 
            this.cat_cl.DataPropertyName = "Cat.Name";
            this.cat_cl.HeaderText = "Categoría";
            this.cat_cl.Name = "cat_cl";
            this.cat_cl.ReadOnly = true;
            // 
            // price_cl
            // 
            this.price_cl.DataPropertyName = "Price";
            this.price_cl.HeaderText = "Precio";
            this.price_cl.Name = "price_cl";
            this.price_cl.ReadOnly = true;
            // 
            // cuan_cl
            // 
            this.cuan_cl.DataPropertyName = "Cuantity";
            this.cuan_cl.HeaderText = "Cantidad";
            this.cuan_cl.Name = "cuan_cl";
            this.cuan_cl.ReadOnly = true;
            // 
            // datein_cl
            // 
            this.datein_cl.HeaderText = "Fecha de Ingreso";
            this.datein_cl.Name = "datein_cl";
            this.datein_cl.ReadOnly = true;
            // 
            // prov_cl
            // 
            this.prov_cl.DataPropertyName = "Prov";
            this.prov_cl.HeaderText = "Proveedor";
            this.prov_cl.Name = "prov_cl";
            this.prov_cl.ReadOnly = true;
            // 
            // barcode_cl
            // 
            this.barcode_cl.DataPropertyName = "Barcode";
            this.barcode_cl.HeaderText = "Código de Barras";
            this.barcode_cl.Name = "barcode_cl";
            this.barcode_cl.ReadOnly = true;
            // 
            // dateex_cl
            // 
            this.dateex_cl.DataPropertyName = "Dateex";
            this.dateex_cl.HeaderText = "Fecha de expiración";
            this.dateex_cl.Name = "dateex_cl";
            this.dateex_cl.ReadOnly = true;
            // 
            // sign_cl
            // 
            this.sign_cl.DataPropertyName = "Sign";
            this.sign_cl.HeaderText = "Marca";
            this.sign_cl.Name = "sign_cl";
            this.sign_cl.ReadOnly = true;
            // 
            // location_cl
            // 
            this.location_cl.DataPropertyName = "Location";
            this.location_cl.HeaderText = "Ubicación";
            this.location_cl.Name = "location_cl";
            this.location_cl.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(971, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Productos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.productostb, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tx_buscar, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(981, 453);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 410);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(975, 40);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(134, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(265, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(396, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 30);
            this.button4.TabIndex = 3;
            this.button4.Text = "Refrescar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tx_buscar
            // 
            this.tx_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_buscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tx_buscar.Location = new System.Drawing.Point(3, 54);
            this.tx_buscar.Name = "tx_buscar";
            this.tx_buscar.Size = new System.Drawing.Size(975, 27);
            this.tx_buscar.TabIndex = 3;
            this.tx_buscar.TextChanged += new System.EventHandler(this.tx_buscar_TextChanged);
            // 
            // Ver_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(981, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Ver_Productos";
            this.Text = "Ver_Productos";
            ((System.ComponentModel.ISupportInitialize)(this.productostb)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView productostb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn cat_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuan_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn datein_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn prov_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateex_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn sign_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn location_cl;
        private System.Windows.Forms.TextBox tx_buscar;
    }
}