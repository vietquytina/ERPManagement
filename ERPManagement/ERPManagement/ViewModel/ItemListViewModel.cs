using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel
{
    public class ItemListViewModel<T> : BaseNotify
    {
        private ICommand newCommand = null;
        private ICommand exportToXLSCommand = null;

        public ObservableCollection<T> Items { get; set; }
        public T SelectedItem { get; set; }

        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(() =>
                    {
                        OnNewCommandClick();
                    });
                }
                return newCommand;
            }
        }


        public ICommand ExportToXLSCommand
        {
            get
            {
                if (exportToXLSCommand == null)
                {
                    exportToXLSCommand = new RelayCommand<RadGridView>((gv) =>
                    {
                        SaveFileDialog saveDlg = new SaveFileDialog();
                        saveDlg.AddExtension = true;
                        saveDlg.CheckFileExists = true;
                        saveDlg.Filter = "Excel Worksheets(*.xls)|(*.xls)";
                        var result = saveDlg.ShowDialog();
                        if (result != null && result.Value)
                        {
                            FileStream fs = File.Open(saveDlg.FileName, FileMode.OpenOrCreate);
                            gv.Export(fs, new GridViewExportOptions() { Format = ExportFormat.ExcelML, Encoding = Encoding.UTF8 });
                            fs.Close();
                        }
                    });
                }
                return exportToXLSCommand;
            }
        }

        public ItemListViewModel()
        {
            Items = new ObservableCollection<T>();
        }

        protected virtual void OnNewCommandClick()
        {

        }
    }
}