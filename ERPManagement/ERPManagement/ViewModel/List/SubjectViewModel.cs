using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    class SubjectViewModel : ListViewModel
    {
        public static IEnumerable<SubjectViewModel> GetSubjects()
        {
            List<SubjectViewModel> subjects = new List<SubjectViewModel>();
            var _subjects = from p in db.Subjects
                            select p;
            foreach (var _subject in _subjects)
            {
                SubjectViewModel subject = new SubjectViewModel();
                subject.subjectID = _subject.SubjectID;
                subject.Name = _subject.Name;
                subject.Note = _subject.Note;
                subject.isInserted = false;
                subjects.Add(subject);
            }
            return subjects;
        }

        public static SubjectViewModel GetSubject(Int32 subjectID)
        {
            var _subject = db.Subjects.SingleOrDefault(m => m.SubjectID == subjectID);
            if (_subject == null)
                return null;
            SubjectViewModel subject = new SubjectViewModel();
            subject.subjectID = _subject.SubjectID;
            subject.Name = _subject.Name;
            subject.Note = _subject.Note;
            subject.isInserted = false;
            return subject;
        }

        #region Variables
        private Int32 subjectID = 0;
        #endregion

        #region Properties
        public Int32 SubjectID
        {
            get { return subjectID; }
        }
        #endregion

        protected override void Save(RadWindow window)
        {
            Subject subject = null;
            if (isInserted)
            {
                subject = new Subject();
                db.Subjects.InsertOnSubmit(subject);
            }
            else
            {
                subject = db.Subjects.SingleOrDefault(m => m.SubjectID == SubjectID);
            }
            if (subject != null)
            {
                subject.Name = Name;
                subject.Note = Note;
                db.SubmitChanges();
                subjectID = subject.SubjectID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            Subject subject = db.Subjects.SingleOrDefault(m => m.SubjectID == SubjectID);
            try
            {
                db.Subjects.DeleteOnSubmit(subject);
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