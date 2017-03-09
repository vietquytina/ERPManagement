using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ERPManagement
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public String ReportPath { get; set; }

        public ReportWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void AddReportSource(String dsName, Object dtSource)
        {
            ReportDataSource rptSource = new ReportDataSource();
            rptSource.Name = dsName;
            rptSource.Value = dtSource;
            rptViewer.LocalReport.DataSources.Add(rptSource);
        }

        public void RefreshReport()
        {
            rptViewer.LocalReport.ReportPath = ReportPath;
            rptViewer.RefreshReport();
        }
    }
}