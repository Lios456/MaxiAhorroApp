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
            this.panel1 = new System.Windows.Forms.Panel();
            this.vista = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.stiReportDataSource1 = new Stimulsoft.Report.Design.StiReportDataSource("facturavista", this);
            this.panel1.SuspendLayout();
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
            this.factura_Ttal.ReportGuid = "151688fa11434c50ab3cdde351eb2dd6";
            this.factura_Ttal.ReportName = "Report";
            this.factura_Ttal.ReportSource = resources.GetString("factura_Ttal.ReportSource");
            this.factura_Ttal.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.factura_Ttal.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.factura_Ttal.UseProgressInThread = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vista);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 588);
            this.panel1.TabIndex = 0;
            // 
            // vista
            // 
            this.vista.AllowDrop = true;
            this.vista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vista.Location = new System.Drawing.Point(0, 0);
            this.vista.Name = "vista";
            this.vista.PageViewMode = Stimulsoft.Report.Viewer.StiPageViewMode.SinglePage;
            this.vista.Report = null;
            this.vista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.vista.ShowZoom = true;
            this.vista.Size = new System.Drawing.Size(628, 588);
            this.vista.TabIndex = 1;
            // 
            // stiReportDataSource1
            // 
            this.stiReportDataSource1.Item = this;
            this.stiReportDataSource1.Name = "facturavista";
            // 
            // facturavista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 588);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "facturavista";
            this.Text = "facturavista";
            this.Load += new System.EventHandler(this.facturavista_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Stimulsoft.Report.StiReport factura_Ttal;
        private System.Windows.Forms.Panel panel1;
        private Stimulsoft.Report.Viewer.StiViewerControl vista;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource1;
    }
}