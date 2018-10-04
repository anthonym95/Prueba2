using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinInventarioHogar.Usuarios
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }


        private void frmReportes_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
        }

        private void btnGenerar1_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == 0)
            {
                this.rvReportes.Reset();
                this.rvReportes.LocalReport.DataSources.Add(new ReportDataSource("dsReporteEntradasPorFecha", this.sPProductInputReportBindingSource));
                this.rvReportes.LocalReport.ReportEmbeddedResource = "WinInventarioHogar.Reportes.ReporteEntradasPorFecha.rdlc";
                this.sP_ProductInputReportTableAdapter.Fill(this.inventariohogardbDataSet.SP_ProductInputReport, dtpDesde.Value.ToString("yyyy-MM-dd"), dtpHasta.Value.ToString("yyyy-MM-dd"));

            }
            else if (cmbTipo.SelectedIndex == 1)
            {
                this.rvReportes.Reset();
                this.rvReportes.LocalReport.DataSources.Add(new ReportDataSource("dsReporteSalidasPorFecha", this.sPProductOutputReportBindingSource));
                this.rvReportes.LocalReport.ReportEmbeddedResource = "WinInventarioHogar.Reportes.ReporteSalidasPorFecha.rdlc";
                this.sP_ProductOutputReportTableAdapter.Fill(this.inventariohogardbDataSet.SP_ProductOutputReport, dtpDesde.Value.ToString("yyyy-MM-dd"), dtpHasta.Value.ToString("yyyy-MM-dd"));

            }

            this.rvReportes.RefreshReport();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.rvReportes.PrintDialog();
        }
    }
}
