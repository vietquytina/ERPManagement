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

namespace ERPManagement.View.List
{
    /// <summary>
    /// Interaction logic for EquipmentTypeList.xaml
    /// </summary>
    public partial class EquipmentTypeList : Telerik.Windows.Controls.RadWindow
    {
        public EquipmentTypeList()
        {
            InitializeComponent();
            DataContext = (App.Current as App).EquipmentTypes;
        }
    }
}