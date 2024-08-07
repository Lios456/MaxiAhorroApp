namespace MaxiAhorroApp.Reportes
{
    partial class ReporteFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteFactura));
            this.stiViewerControl1 = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.stiReport1 = new Stimulsoft.Report.StiReport();
            this.SuspendLayout();
            // 
            // stiViewerControl1
            // 
            this.stiViewerControl1.AllowDrop = true;
            this.stiViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stiViewerControl1.Location = new System.Drawing.Point(0, 0);
            this.stiViewerControl1.Name = "stiViewerControl1";
            this.stiViewerControl1.PageViewMode = Stimulsoft.Report.Viewer.StiPageViewMode.SinglePage;
            this.stiViewerControl1.Report = null;
            this.stiViewerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiViewerControl1.ShowZoom = true;
            this.stiViewerControl1.Size = new System.Drawing.Size(640, 360);
            this.stiViewerControl1.TabIndex = 0;
            // 
            // stiReport1
            // 
            this.stiReport1.CookieContainer = null;
            this.stiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiReport1.HttpHeadersContainer = null;
            this.stiReport1.Key = "5217c08744124f67aa3e21b4917940d4";
            this.stiReport1.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiReport1.ReportAlias = "Report";
            this.stiReport1.ReportGuid = "2f2079ab87064f4d82100cf1d5623d20";
            this.stiReport1.ReportName = "Report";
            this.stiReport1.ReportSource = resources.GetString("stiReport1.ReportSource");
            this.stiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters;
            this.stiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiReport1.UseProgressInThread = false;
            // 
            // ReporteFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stiViewerControl1);
            this.Name = "ReporteFactura";
            this.Text = "ReporteFactura";
            this.ResumeLayout(false);

        }

        #endregion

        private Stimulsoft.Report.Viewer.StiViewerControl stiViewerControl1;
        private Stimulsoft.Report.StiReport stiReport1;
    }
}