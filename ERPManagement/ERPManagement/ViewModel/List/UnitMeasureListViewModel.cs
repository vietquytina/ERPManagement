using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    [Authorize.Authorize(Method = "UnitMeasure")]
    public class UnitMeasureListViewModel : ItemListViewModel<UnitMeasureViewModel>
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

        protected override void OnNewCommandClick()
        {
            ERPManagement.View.List.UnitMeasureView frmUnitMeasure = new View.List.UnitMeasureView();
            UnitMeasureViewModel unitMeasurevm = new UnitMeasureViewModel();
            unitMeasurevm.ItemAction += new ActionEventHandler(UnitMeasurevm_ItemAction);
            frmUnitMeasure.DataContext = unitMeasurevm;
            frmUnitMeasure.ShowDialog();
        }

        private void UnitMeasurevm_ItemAction(object sender, ActionEventArgs e)
        {
            if (e.Action == ViewModelAction.Add)
            {
                Items.Add((UnitMeasureViewModel)sender);
            }
        }
    }
}