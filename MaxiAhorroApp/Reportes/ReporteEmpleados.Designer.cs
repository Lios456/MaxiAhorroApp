namespace MaxiAhorroApp.Reportes
{
    partial class ReporteEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteEmpleados));
            this.viewer = new Stimulsoft.Report.Viewer.StiRibbonViewerControl();
            this.empleadosreport = new Stimulsoft.Report.StiReport();
            this.SuspendLayout();
            // 
            // viewer
            // 
            this.viewer.AllowDrop = true;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.PageViewMode = Stimulsoft.Report.Viewer.StiPageViewMode.SinglePage;
            this.viewer.Report = null;
            this.viewer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.viewer.ShowZoom = true;
            this.viewer.Size = new System.Drawing.Size(1018, 503);
            this.viewer.TabIndex = 1;
            // 
            // empleadosreport
            // 
            this.empleadosreport.CookieContainer = null;
            this.empleadosreport.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.empleadosreport.HttpHeadersContainer = null;
            this.empleadosreport.Key = "912089d39dd44c67869234d8d1ea7cbf";
            this.empleadosreport.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.empleadosreport.ReportAlias = "Report";
            this.empleadosreport.ReportGuid = "dc018519dc664654b16dd969bdea6c7a";
            this.empleadosreport.ReportName = "Report";
            this.empleadosreport.ReportSource = resources.GetString("empleadosreport.ReportSource");
            this.empleadosreport.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.empleadosreport.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.empleadosreport.UseProgressInThread = false;
            // 
            // ReporteEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 503);
            this.Controls.Add(this.viewer);
            this.Name = "ReporteEmpleados";
            this.Text = "ReporteEmpleados";
            this.ResumeLayout(false);

        }

        #endregion

        private Stimulsoft.Report.Viewer.StiRibbonViewerControl viewer;
        private Stimulsoft.Report.StiReport empleadosreport;
    }
}