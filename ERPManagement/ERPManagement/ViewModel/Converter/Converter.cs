using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ERPManagement.ViewModel.Converter
{
    public enum ConvertInfomation : uint
    {
        Code = 0,
        Name = 1,
        Serial = 2,
        UnitMeasure = 3
    }

    public class MainConverter : IValueConverter
    {
        protected App app = (App)(Application.Current);

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Empty;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class CompanyNameConverter : MainConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int companyID = System.Convert.ToInt32(value);
            var companyvm = app.Companies.Items.SingleOrDefault(m => m.CompanyID == companyID);
            if (companyvm == null)
                return String.Empty;
            return companyvm.Name;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return base.ConvertBack(value, targetType, parameter, culture);
        }
    }

    public class DepartmentNameConverter : MainConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var departmentID = System.Convert.ToInt32(value);
            var departmentvn = app.Departments.Items.SingleOrDefault(m => m.DepartmentID == departmentID);
            if (departmentvn == null)
                return String.Empty;
            return departmentvn.Name;
        }
    }

    public class EquipmentTypeNameConverter : MainConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var typeID = System.Convert.ToInt32(value);
            var eqTypevm = app.EquipmentTypes.Items.SingleOrDefault(m => m.TypeID == typeID);
            if (eqTypevm == null)
                return String.Empty;
            return eqTypevm.Name;
        }
    }

    public class RegencyNameConverter : MainConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var regencyID = System.Convert.ToInt32(value);
            var regencyvm = app.Regencies.Items.SingleOrDefault(m => m.RegencyID == regencyID);
            if (regencyvm == null)
                return string.Empty;
            return regencyvm.Name;
        }
    }

    public class UnitMeasureNameConverter : MainConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var unitMeasurevm = app.UnitMeasures.Items.SingleOrDefault(m => m.UnitMeasureID == System.Convert.ToInt32(value));
            if (unitMeasurevm == null)
                return string.Empty;
            return unitMeasurevm.Name;
        }
    }

    public class EmployeeNameConverter : MainConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var empID = System.Convert.ToInt32(value);
            var employeevm = app.Employees.Items.SingleOrDefault(m => m.EmployeeID == empID);
            if (employeevm == null)
                return string.Empty;
            return employeevm.Name;
        }
    }

    public class EquipmentNameConverter : MainConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eqID = System.Convert.ToInt32(value);
            var cvInfo = (ConvertInfomation)parameter;
            var equipment = app.Equipments.Items.SingleOrDefault(m => m.EquipmentID == eqID);
            if (equipment == null)
                return null;
            if (cvInfo == ConvertInfomation.Code)
                return equipment.Code;
            else
                if (cvInfo == ConvertInfomation.Name)
                return equipment.Name;
            else
                if (cvInfo == ConvertInfomation.Serial)
                return equipment.Number;
            else
                return equipment.UnitMeasure;
        }
    }
}