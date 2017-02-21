using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class UnitMeasureListViewModel : ItemListViewModel<UnitMeasureViewModel>
    {
        public UnitMeasureListViewModel() : base()
        {
            foreach (var unitMeasure in UnitMeasureViewModel.GetUnitMeasures())
            {
                Items.Add(unitMeasure);
                unitMeasure.Deleted += new System.Windows.RoutedEventHandler(UnitMeasure_Deleted);
            }
        }

        private void UnitMeasure_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((UnitMeasureViewModel)sender);
        }
    }
}