using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class SubjectListViewModel : ItemListViewModel<SubjectViewModel>
    {
        public SubjectListViewModel() : base()
        {
            foreach (var subject in SubjectViewModel.GetSubjects())
            {
                Items.Add(subject);
                subject.Deleted += new System.Windows.RoutedEventHandler(Subject_Deleted);
            }
        }

        private void Subject_Deleted(object sender, System.Windows.RoutedEventArgs e)
        {
            Items.Remove((SubjectViewModel)sender);
        }
    }
}