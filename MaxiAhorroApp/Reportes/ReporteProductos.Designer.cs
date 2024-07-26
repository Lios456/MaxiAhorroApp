namespace MaxiAhorroApp.Reportes
{
    partial class ReporteProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteProductos));
            this.productosreport = new Stimulsoft.Report.StiReport();
            this.stiReportDataSource5 = new Stimulsoft.Report.Design.StiReportDataSource("ReporteProductos", this);
            this.stiReportDataSource1 = new Stimulsoft.Report.Design.StiReportDataSource("ReporteProductos", this);
            this.viewer = new Stimulsoft.Report.Viewer.StiRibbonViewerControl();
            this.stiReportDataSource3 = new Stimulsoft.Report.Design.StiReportDataSource("ReporteProductos", this);
            this.stiReportDataSource4 = new Stimulsoft.Report.Design.StiReportDataSource("ReporteProductos", this);
            this.SuspendLayout();
            // 
            // productosreport
            // 
            this.productosreport.CookieContainer = null;
            this.productosreport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.productosreport.HttpHeadersContainer = null;
            this.productosreport.Key = "912089d39dd44c67869234d8d1ea7cbf";
            this.productosreport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.productosreport.ReportAlias = "Report";
            this.productosreport.ReportDataSources.Add(this.stiReportDataSource5);
            this.productosreport.ReportGuid = "9f70c77bcdb74b43a3afc77474349a27";
            this.productosreport.ReportName = "Report";
            this.productosreport.ReportSource = resources.GetString("productosreport.ReportSource");
            this.productosreport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.productosreport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.productosreport.UseProgressInThread = false;
            // 
            // stiReportDataSource5
            // 
            this.stiReportDataSource5.Item = this;
            this.stiReportDataSource5.Name = "ReporteProductos";
            // 
            // stiReportDataSource1
            // 
            this.stiReportDataSource1.Item = this;
            this.stiReportDataSource1.Name = "ReporteProductos";
            // 
            // viewer
            // 
            this.viewer.AllowDrop = true;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.Report = null;
            this.viewer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.viewer.ShowZoom = true;
            this.viewer.Size = new System.Drawing.Size(1102, 597);
            this.viewer.TabIndex = 0;
            // 
            // stiReportDataSource3
            // 
            this.stiReportDataSource3.Item = this;
            this.stiReportDataSource3.Name = "ReporteProductos";
            // 
            // stiReportDataSource4
            // 
            this.stiReportDataSource4.Item = this;
            this.stiReportDataSource4.Name = "ReporteProductos";
            // 
            // ReporteProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 597);
            this.Controls.Add(this.viewer);
            this.Name = "ReporteProductos";
            this.Text = "ReporteProductos";
            this.ResumeLayout(false);

        }

        #endregion

        private Stimulsoft.Report.StiReport productosreport;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource1;
        private Stimulsoft.Report.Viewer.StiRibbonViewerControl viewer;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource2;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource5;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource3;
        private Stimulsoft.Report.Design.StiReportDataSource stiReportDataSource4;
    }
}