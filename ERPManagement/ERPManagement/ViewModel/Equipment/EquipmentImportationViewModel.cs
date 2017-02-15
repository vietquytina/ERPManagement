﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.Equipment
{
    class EquipmentImportationDetailViewModel : EquipmentDetailViewModel
    {
        #region Variables
        private Int32 number, fundingSourceID;
        private String fundingSoureName;
        private Decimal price, amount;
        #endregion

        #region Properties
        public Int32 EquipmentImportationID { get; set; }
        public Int32 Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    Amount = Number * Price;
                    RaisePropertyChanged("Number");
                }
            }
        }
        public Decimal Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Amount = Number * Price;
                    RaisePropertyChanged("Price");
                }
            }
        }
        public Decimal Amount
        {
            get { return amount; }
            set
            {
                if (amount != value)
                {
                    amount = value;
                    RaisePropertyChanged("Amount");
                }
            }
        }
        public Int32 FundingSourceID
        {
            get { return fundingSourceID; }
            set
            {
                if (fundingSourceID != value)
                {
                    fundingSourceID = value;
                    RaisePropertyChanged("FundingSourceID");
                }
            }
        }
        public String FundingSoureName
        {
            get { return fundingSoureName; }
            set
            {
                if (fundingSoureName != value)
                {
                    fundingSoureName = value;
                    RaisePropertyChanged("FundingSoureName");
                }
            }
        }
        #endregion

        public EquipmentImportationDetailViewModel() : base()
        {
        }
    }

    class EquipmentImportationViewModel : EquipmentViewModel
    {
        #region Variables
        private Int32 equipmentImportationID;
        #endregion

        #region Properties
        public Int32 EquipmentImportationID
        {
            get { return equipmentImportationID; }
        }
        public ObservableCollection<EquipmentImportationDetailViewModel> Details { get; set; }
        #endregion

        public EquipmentImportationViewModel()
        {
            Details = new ObservableCollection<EquipmentImportationDetailViewModel>();
        }

        protected override void Save(RadWindow window)
        {
            EquipmentImportation eqImp = null;
            if (isInserted)
            {
                eqImp = new EquipmentImportation();
                db.EquipmentImportations.InsertOnSubmit(eqImp);
            }
            else
            {
                eqImp = db.EquipmentImportations.SingleOrDefault(m => m.EquipmentImportationID == EquipmentImportationID);
            }
            if (eqImp != null)
            {
                eqImp.Number = Number;
                eqImp.Date = Date;
                eqImp.Note = Note;
                Sync(Details, eqImp.EquipmentImportationDetails);
                SyncIndex(Details);
                db.SubmitChanges();
                equipmentImportationID = eqImp.EquipmentImportationID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override bool Delete()
        {
            try
            {
                EquipmentImportation eqImp = db.EquipmentImportations.SingleOrDefault(m => m.EquipmentImportationID == EquipmentImportationID);
                db.EquipmentImportations.DeleteOnSubmit(eqImp);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        protected override void Edit()
        {

        }
    }
}