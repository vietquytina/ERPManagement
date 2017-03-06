using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Equipment
{
    [Authorize.Authorize(Method = "EquipmentBreakReport")]
    public class EquipmentBreakReportListViewModel : ItemListViewModel<EquipmentBreakReportViewModel>
    {
        public EquipmentBreakReportListViewModel() : base()
        {
            foreach (var equipmentBreakRpt in EquipmentBreakReportViewModel.Gets())
            {
                Items.Add(equipmentBreakRpt);
                equipmentBreakRpt.Deleted += new System.Windows.RoutedEventHandler(EquipmentBreakRpt_Deleted);
            }
        }

        private void EquipmentBreakRpt_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((EquipmentBreakReportViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {

        }
    }
}