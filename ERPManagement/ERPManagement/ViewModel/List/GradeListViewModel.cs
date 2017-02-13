using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class GradeListViewModel : ItemListViewModel<GradeViewModel>
    {
        public GradeListViewModel() : base()
        {
            foreach (var grade in GradeViewModel.GetGrades())
            {
                Items.Add(grade);
                grade.Deleted += new System.Windows.RoutedEventHandler(Grade_Deleted);
            }
        }

        private void Grade_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((GradeViewModel)sender);
        }
    }
}