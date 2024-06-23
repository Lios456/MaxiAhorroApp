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
            this.prov_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cat_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productostb)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productostb
            // 
            this.productostb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productostb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productostb.BackgroundColor = System.Drawing.Color.White;
            this.productostb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productostb.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.productostb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productostb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_cl,
            this.nombre_cl,
            this.descripcion_cl,
            this.prov_cl,
            this.cat_cl,
            this.price_cl});
            this.productostb.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.productostb.Location = new System.Drawing.Point(20, 164);
            this.productostb.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.productostb.Name = "productostb";
            this.productostb.ReadOnly = true;
            this.productostb.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.productostb.Size = new System.Drawing.Size(1293, 268);
            this.productostb.TabIndex = 0;
            this.productostb.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.productostb_CellFormatting);
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
            // prov_cl
            // 
            this.prov_cl.DataPropertyName = "Prov";
            this.prov_cl.HeaderText = "Proveedor";
            this.prov_cl.Name = "prov_cl";
            this.prov_cl.ReadOnly = true;
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1323, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Productos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.productostb, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0626F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.9374F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1333, 623);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 561);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1327, 59);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(265, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(396, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 30);
            this.button4.TabIndex = 3;
            this.button4.Text = "Refrescar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Ver_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 623);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn prov_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn cat_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_cl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}