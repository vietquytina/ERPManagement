using ERPManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace ERPManagement.ViewModel.List
{
    class ClassViewModel : ListViewModel
    {
        public static IEnumerable<ClassViewModel> GetClasses()
        {
            List<ClassViewModel> studentClasses = new List<ClassViewModel>();
            var classes = from p in db.Classes
                          select p;
            foreach (var _class in classes)
            {
                ClassViewModel studentClass = new ClassViewModel();
                studentClass.classID = _class.ClassID;
                studentClass.Name = _class.Name;
                studentClass.Note = _class.Note;
                studentClass.GradeID = _class.GradeID;
                studentClass.isInserted = false;
                studentClasses.Add(studentClass);
            }
            return studentClasses;
        }

        public static ClassViewModel GetClass(Int32 classID)
        {
            var _class = db.Classes.SingleOrDefault(m => m.ClassID == classID);
            if (_class == null)
                return null;
            ClassViewModel studentClass = new ClassViewModel();
            studentClass.Name = _class.Name;
            studentClass.Note = _class.Note;
            studentClass.GradeID = _class.GradeID;
            studentClass.isInserted = false;
            return studentClass;
        }

        public ClassViewModel() : base()
        {

        }

        #region Variables
        private Int32 classID = 0;
        private Int32 gradeID = 0;
        #endregion

        #region Properties
        public Int32 GradeID
        {
            get { return gradeID; }
            set
            {
                if (gradeID != value)
                {
                    gradeID = value;
                    RaisePropertyChanged("GradeID");
                }
            }
        }
        #endregion

        protected override void Save(RadWindow window)
        {
            Class studentClass = null;
            if(isInserted)
            {
                studentClass = new Class();
                db.Classes.InsertOnSubmit(studentClass);
            }
            else
            {
                studentClass = db.Classes.SingleOrDefault(m => m.ClassID == classID);
            }
            if (studentClass != null)
            {
                studentClass.Name = Name;
                studentClass.Note = Note;
                studentClass.Grade = db.Grades.Single(m => m.GradeID == GradeID);
                db.SubmitChanges();
                classID = studentClass.ClassID;
                RaiseAction(isInserted ? ViewModelAction.Add : ViewModelAction.Edit);
                isInserted = false;
            }
        }

        protected override Boolean Delete()
        {
            var studentClass = db.Classes.SingleOrDefault(m => m.ClassID == classID);
            try
            {
                db.Classes.DeleteOnSubmit(studentClass);
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