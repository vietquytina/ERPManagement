using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    class StatusViewModel : ListViewModel
    {
        public static IEnumerable<StatusViewModel> GetStatuses()
        {
            List<StatusViewModel> statuses = new List<StatusViewModel>();
            var _statuses = from p in db.Status
                    select p;
            foreach (var _status in _statuses)
            {
                StatusViewModel status = new StatusViewModel();
                status.statusID = _status.StatusID;
                status.Name = _status.Name;
                status.Note = _status.Note;
                statuses.Add(status);
            }
            return statuses;
        }

        #region Variables
        private Int32 statusID = 0;
        #endregion

        #region Properties
        public Int32 StatusID
        {
            get { return statusID; }
        }
        #endregion
    }
}