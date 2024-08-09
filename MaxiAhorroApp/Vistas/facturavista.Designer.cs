namespace MaxiAhorroApp.Vistas
{
    partial class facturavista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(facturavista));
            this.factura_Ttal = new Stimulsoft.Report.StiReport();
            this.stiReportDataSource1 = new Stimulsoft.Report.Design.StiReportDataSource("facturavista", this);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.vista = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // factura_Ttal
            // 
            this.factura_Ttal.CalculationMode = Stimulsoft.Report.StiCalculationMode.Interpretation;
            this.factura_Ttal.CookieContainer = null;
            this.factura_Ttal.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.factura_Ttal.HttpHeadersContainer = null;
            this.factura_Ttal.Key = "53463c3382854b698239184ae5cb483a";
            this.factura_Ttal.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.factura_Ttal.ReportAlias = "Report";
            this.factura_Ttal.ReportAuthor = "Henrry Barrionuevo";
            this.factura_Ttal.ReportDataSources.Add(this.stiReportDataSource1);
            this.factura_Ttal.ReportGuid = "9b2e9ef644da4f73b551dc6eeb3436a3";
            this.factura_Ttal.ReportName = "Report";
            this.factura_Ttal.ReportSource = resources.GetString("factura_Ttal.ReportSource");
            this.factura_Ttal.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.factura_Ttal.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.factura_Ttal.UseProgressInThread = false;
            // 
            // stiReportDataSource1
            // 
            this.stiReportDataSource1.Item = this;
            this.stiReportDataSource1.Name = "facturavista";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 588);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.vista, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(628, 588);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // vista
            // 
            this.vista.AllowDrop = true;
            this.vista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vista.Location = new System.Drawing.Point(3, 3);
            this.vista.Name = "vista";
            this.vista.PageViewMode = Stimulsoft.Report.Viewer.StiPageViewMode.SinglePage;
            this.vista.Report = null;
            this.vista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.vista.ShowZoom = true;
            this.vista.Size = new System.Drawing.Size(622, 523);
            this.vista.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 532);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(622, 53);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Registrar venta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(314, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(305, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // facturavista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 588);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "facturavista";
            this.Text = "facturavista";
            this.Load += new System.EventHandler(this.facturavista_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Stimulsoft.Report.StiReport factura_Ttal;
        private System.Windows.Forms.Panel panel1;
        private Stimulsoft.Report.Viewer.StiViewerControl vista;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}