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

namespace ERPManagement.View.Profession
{
    /// <summary>
    /// Interaction logic for EquipmentExportationListView.xaml
    /// </summary>
    public partial class EquipmentExportationListView : Telerik.Windows.Controls.RadWindow
    {
        public EquipmentExportationListView()
        {
            InitializeComponent();
            DataContext = (App.Current as App).EquipmentExports;
        }
    }
}