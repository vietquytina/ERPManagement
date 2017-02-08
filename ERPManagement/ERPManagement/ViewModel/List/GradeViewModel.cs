using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using ERPManagement.Model;

namespace ERPManagement.ViewModel.List
{
    class GradeViewModel : ListViewModel
    {
        public static IEnumerable<GradeViewModel> GetGrades()
        {
            List<GradeViewModel> grades = new List<GradeViewModel>();
            var gs = from p in db.Grades
                     select p;
            foreach (var g in gs)
            {
                GradeViewModel grade = new GradeViewModel();
                grade.Name = g.Name;
                grade.Note = g.Note;
                grade.isInserted = false;
                grades.Add(grade);
            }
            return grades;
        }

        public static GradeViewModel GetGrade(Int32 gradeID)
        {
            var g = db.Grades.SingleOrDefault(m => m.GradeID == gradeID);
            if (g == null)
                return null;
            GradeViewModel grade = new GradeViewModel();
            grade.Name = g.Name;
            grade.Note = g.Note;
            grade.isInserted = false;
            return grade;
        }

        #region Variables
        private Int32 gradeID = 0;
        #endregion

        protected override void Save(RadWindow window)
        {
            Grade grade = null;
            if (isInserted)
            {
                grade = new Grade();
                db.Grades.InsertOnSubmit(grade);
            }
            else
            {
                grade = db.Grades.SingleOrDefault(m => m.GradeID == gradeID);
            }
            if (grade != null)
            {
                grade.Name = Name;
                grade.Note = Note;
                db.SubmitChanges();
                gradeID = grade.GradeID;
                isInserted = false;
            }
        }

        protected override bool Delete()
        {
            Grade grade = db.Grades.SingleOrDefault(m => m.GradeID == gradeID);
            try
            {
                db.Grades.DeleteOnSubmit(grade);
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