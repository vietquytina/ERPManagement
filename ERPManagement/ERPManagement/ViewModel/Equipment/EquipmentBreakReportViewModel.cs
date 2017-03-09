using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;
using System.Data.Linq;

namespace ERPManagement.ViewModel.Equipment
{
    public class EquipmentBreakReportPersonViewModel: EquipmentHandoverPersonViewModel
    {
        public EquipmentBreakReportPersonViewModel() : base()
        {
        }
    }

    [Authorize.Authorize(Method = "EquipmentBreakReport")]
    public class EquipmentBreakReportViewModel : EquipmentViewModel
    {
        public static IEnumerable<EquipmentBreakReportViewModel> Gets()
        {
            List<EquipmentBreakReportViewModel> equipmentBreakRptvms = new List<EquipmentBreakReportViewModel>();
            var equipmentBreakRpts = from p in db.EquipmentBreakReports
                                     select p;
            foreach (var equipmentBreakRpt in equipmentBreakRpts)
            {
                EquipmentBreakReportViewModel equipmentBreakRptvm = new EquipmentBreakReportViewModel();
                equipmentBreakRptvm.ID = equipmentBreakRptvm.ID;
                equipmentBreakRptvm.Number = equipmentBreakRpt.Number;
                equipmentBreakRptvm.Date = equipmentBreakRpt.Date;
                equipmentBreakRptvm.DepartmentID = equipmentBreakRpt.DepartmentID;
                equipmentBreakRptvm.EquipmentID = equipmentBreakRpt.EquipmentID;
                equipmentBreakRptvm.EquipmentStatus = equipmentBreakRpt.EquipmentStatus;
                equipmentBreakRptvm.Cause = equipmentBreakRpt.Cause;
                equipmentBreakRptvm.HowToRepair = equipmentBreakRpt.HowToRepair;
                equipmentBreakRptvm.EmployeeAdvise = equipmentBreakRpt.EmployeeAdvise;
                equipmentBreakRptvm.ManagerAdvise = equipmentBreakRpt.ManagerAdvise;
                equipmentBreakRptvm.StatusID = equipmentBreakRpt.StatusID;
                foreach (var user in equipmentBreakRpt.EquipmentBreakReportUsers)
                {
                    EquipmentBreakReportPersonViewModel uservm = new EquipmentBreakReportPersonViewModel();
                    uservm.DetailID = user.DetailID;
                    uservm.Index = user.Index;
                    uservm.EmployeeID = user.EmployeeID;
                    equipmentBreakRptvm.Users.Add(uservm);
                }
                foreach (var manager in equipmentBreakRpt.EquipmentBreakReportManagers)
                {
                    EquipmentBreakReportPersonViewModel managervm = new EquipmentBreakReportPersonViewModel();
                    managervm.DetailID = manager.DetailID;
                    managervm.Index = manager.Index;
                    managervm.EmployeeID = manager.EmployeeID;
                    equipmentBreakRptvm.Managers.Add(managervm);
                }
                equipmentBreakRptvm.isInserted = false;
                equipmentBreakRptvms.Add(equipmentBreakRptvm);
            }
            return equipmentBreakRptvms;
        }

        public static EquipmentBreakReportViewModel Get(int id)
        {
            var equipmentBreakRpt = db.EquipmentBreakReports.SingleOrDefault(m => m.ID == id);
            if (equipmentBreakRpt == null)
                return null;
            EquipmentBreakReportViewModel equipmentBreakRptvm = new EquipmentBreakReportViewModel();
            equipmentBreakRptvm.ID = equipmentBreakRptvm.ID;
            equipmentBreakRptvm.Number = equipmentBreakRpt.Number;
            equipmentBreakRptvm.Date = equipmentBreakRpt.Date;
            equipmentBreakRptvm.DepartmentID = equipmentBreakRpt.DepartmentID;
            equipmentBreakRptvm.EquipmentID = equipmentBreakRpt.EquipmentID;
            equipmentBreakRptvm.EquipmentStatus = equipmentBreakRpt.EquipmentStatus;
            equipmentBreakRptvm.Cause = equipmentBreakRpt.Cause;
            equipmentBreakRptvm.HowToRepair = equipmentBreakRpt.HowToRepair;
            equipmentBreakRptvm.EmployeeAdvise = equipmentBreakRpt.EmployeeAdvise;
            equipmentBreakRptvm.ManagerAdvise = equipmentBreakRpt.ManagerAdvise;
            equipmentBreakRptvm.StatusID = equipmentBreakRpt.StatusID;
            foreach (var user in equipmentBreakRpt.EquipmentBreakReportUsers)
            {
                EquipmentBreakReportPersonViewModel uservm = new EquipmentBreakReportPersonViewModel();
                uservm.DetailID = user.DetailID;
                uservm.Index = user.Index;
                uservm.EmployeeID = user.EmployeeID;
                equipmentBreakRptvm.Users.Add(uservm);
            }
            foreach (var manager in equipmentBreakRpt.EquipmentBreakReportManagers)
            {
                EquipmentBreakReportPersonViewModel managervm = new EquipmentBreakReportPersonViewModel();
                managervm.DetailID = manager.DetailID;
                managervm.Index = manager.Index;
                managervm.EmployeeID = manager.EmployeeID;
                equipmentBreakRptvm.Managers.Add(managervm);
            }
            equipmentBreakRptvm.isInserted = false;
            return equipmentBreakRptvm;
        }

        #region Variables
        private Int32 departmentID, equipmentID;
        private String equipmentStatus, cause, howToRepair, employeeAdvise, managerAdvise;
        #endregion

        #region Properties
        public Int32 ID { get; private set; }

        public Int32 DepartmentID
        {
            get { return departmentID; }
            set
            {
                if (departmentID != value)
                {
                    departmentID = value;
                    RaisePropertyChanged("DepartmentID");
                }
            }
        }

        public Int32 EquipmentID
        {
            get { return equipmentID; }
            set
            {
                if (equipmentID != value)
                {
                    equipmentID = value;
                    RaisePropertyChanged("EquipmentID");
                }
            }
        }

        public String EquipmentStatus
        {
            get { return equipmentStatus; }
            set
            {
                if (equipmentStatus != value)
                {
                    equipmentStatus = value;
                    RaisePropertyChanged("EquipmentStatus");
                }
            }
        }

        public String Cause
        {
            get { return cause; }
            set
            {
                if (cause != value)
                {
                    cause = value;
                    RaisePropertyChanged("Cause");
                }
            }
        }

        public String HowToRepair
        {
            get { return howToRepair; }
            set
            {
                if (howToRepair != value)
                {
                    howToRepair = value;
                    RaisePropertyChanged("HowToRepair");
                }
            }
        }

        public String EmployeeAdvise
        {
            get { return employeeAdvise; }
            set
            {
                if (employeeAdvise != value)
                {
                    employeeAdvise = value;
                    RaisePropertyChanged("EmployeeAdvise");
                }
            }
        }

        public String ManagerAdvise
        {
            get { return managerAdvise; }
            set
            {
                if (managerAdvise != value)
                {
                    managerAdvise = value;
                    RaisePropertyChanged("ManagerAdvise");
                }
            }
        }

        public ObservableCollection<EquipmentBreakReportPersonViewModel> Managers { get; set; }

        public ObservableCollection<EquipmentBreakReportPersonViewModel> Users { get; set; }
        #endregion

        public EquipmentBreakReportViewModel() : base()
        {
            Managers = new ObservableCollection<EquipmentBreakReportPersonViewModel>();
            Users = new ObservableCollection<EquipmentBreakReportPersonViewModel>();
        }

        protected override void Save(RadWindow window)
        {
            EquipmentBreakReport equipmentBreakRpt = null;
            if (isInserted)
            {
                equipmentBreakRpt = new EquipmentBreakReport();
                db.EquipmentBreakReports.InsertOnSubmit(equipmentBreakRpt);
            }
            else
            {
                equipmentBreakRpt = db.EquipmentBreakReports.SingleOrDefault(m => m.ID == ID);
            }
            if (equipmentBreakRpt != null)
            {
                equipmentBreakRpt.Number = Number;
                equipmentBreakRpt.Date = Date;
                equipmentBreakRpt.DepartmentID = DepartmentID;
                equipmentBreakRpt.EquipmentID = EquipmentID;
                equipmentBreakRpt.EquipmentStatus = EquipmentStatus;
                equipmentBreakRpt.Cause = Cause;
                equipmentBreakRpt.HowToRepair = HowToRepair;
                equipmentBreakRpt.EmployeeAdvise = EmployeeAdvise;
                equipmentBreakRpt.ManagerAdvise = ManagerAdvise;
                equipmentBreakRpt.StatusID = StatusID;
                Sync(Users, equipmentBreakRpt.EquipmentBreakReportUsers);
                Sync(Managers, equipmentBreakRpt.EquipmentBreakReportManagers);
                SyncIndex(equipmentBreakRpt.EquipmentBreakReportUsers);
                SyncIndex(equipmentBreakRpt.EquipmentBreakReportManagers);
                SyncIndex(Users);
                SyncIndex(Managers);
                db.SubmitChanges();
                ID = equipmentBreakRpt.ID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        #region Sync
        private void Sync(IList<EquipmentBreakReportPersonViewModel> srcDetails, EntitySet<EquipmentBreakReportUser> destDetails)
        {
            int i = 0;
            int j = 0;
            if (srcDetails.Count == 0 || (srcDetails.Count > 0 && srcDetails[0].Index == -1))
            {
                destDetails.Clear();
            }
            while (i < srcDetails.Count && j < destDetails.Count)
            {
                if (srcDetails[i].Index == destDetails[j].Index)
                {
                    destDetails[j].EmployeeID = srcDetails[i].EmployeeID;
                    i++;
                    j++;
                }
                {
                    if (srcDetails[i].Index == -1 || srcDetails[i].Index > destDetails[j].Index)
                    {
                        destDetails.RemoveAt(j);
                    }
                }
            }
            while (j < destDetails.Count)
            {
                destDetails.RemoveAt(j);
            }
            while (i < srcDetails.Count)
            {
                EquipmentBreakReportUser user = new EquipmentBreakReportUser();
                user.EmployeeID = srcDetails[i].EmployeeID;
                destDetails.Add(user);
                i++;
            }
        }

        private void Sync(IList<EquipmentBreakReportPersonViewModel> srcDetails, EntitySet<EquipmentBreakReportManager> destDetails)
        {
            int i = 0;
            int j = 0;
            if (srcDetails.Count == 0 || (srcDetails.Count > 0 && srcDetails[0].Index == -1))
            {
                destDetails.Clear();
            }
            while (i < srcDetails.Count && j < destDetails.Count)
            {
                if (srcDetails[i].Index == destDetails[j].Index)
                {
                    destDetails[j].EmployeeID = srcDetails[i].EmployeeID;
                    i++;
                    j++;
                }
                {
                    if (srcDetails[i].Index == -1 || srcDetails[i].Index > destDetails[j].Index)
                    {
                        destDetails.RemoveAt(j);
                    }
                }
            }
            while (j < destDetails.Count)
            {
                destDetails.RemoveAt(j);
            }
            while (i < srcDetails.Count)
            {
                EquipmentBreakReportManager manager = new EquipmentBreakReportManager();
                manager.EmployeeID = srcDetails[i].EmployeeID;
                destDetails.Add(manager);
                i++;
            }
        }
        #endregion

        protected override bool Delete()
        {
            try
            {
                EquipmentBreakReport equipmentBreakRpt = db.EquipmentBreakReports.SingleOrDefault(m => m.ID == ID);
                db.EquipmentBreakReports.DeleteOnSubmit(equipmentBreakRpt);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {

        }

        protected override void ExportToReport()
        {
            Data.EquipmentExport eqExportDS = new Data.EquipmentExport();
            ReportWindow rptWnd = new ReportWindow();
            rptWnd.ReportPath = "Report/EquipmentBreakReport.rdlc";
            rptWnd.AddReportSource("EquipmentExport", eqExportDS.EquipmentImportation);
            rptWnd.AddReportSource("EquipmentExportDetail", eqExportDS.EquipmentImportationDetail);
            rptWnd.RefreshReport();
            rptWnd.ShowDialog();
        }
    }
}