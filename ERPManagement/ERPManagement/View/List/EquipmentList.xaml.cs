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
    /// Interaction logic for EquipmentList.xaml
    /// </summary>
    public partial class EquipmentList : Telerik.Windows.Controls.RadWindow
    {
        public EquipmentList()
        {
            InitializeComponent();
            DataContext = (App.Current as App).Equipments;
        }
    }
}