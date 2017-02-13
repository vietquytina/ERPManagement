using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class ClassListViewModel : ItemListViewModel<ClassViewModel>
    {
        public ClassListViewModel() : base()
        {
            foreach (var _class in ClassViewModel.GetClasses())
            {
                Items.Add(_class);
                _class.Deleted += new System.Windows.RoutedEventHandler(_class_Deleted);
            }
        }

        private void _class_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((ClassViewModel)sender);
        }

        protected override void OnNewCommandClick()
        {

        }
    }
}