using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.List
{
    public class StatusViewModel : ListViewModel
    {
        public static IEnumerable<StatusViewModel> GetStatuses()
        {
            List<StatusViewModel> statuses = new List<StatusViewModel>();
            statuses.Add(new StatusViewModel() { statusID = 1, Code = "", Name = "" });
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