using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using ERPManagement.ViewModel.Converter;

namespace ERPManagement
{
    public class ConvertCollection
    {
        public static IValueConverter CompanyConverter { get; set; }

        public static IValueConverter DepartmentConverter { get; set; }

        public static IValueConverter EquipmentTypeConverter { get; set; }

        public static IValueConverter RegencyConverter { get; set; }

        public static IValueConverter UnitMeasurConverter { get; set; }

        public static IValueConverter EmployeeConverter { get; set; }

        public static IValueConverter EquipmentConverter { get; set; }

        static ConvertCollection()
        {
            CompanyConverter = new CompanyNameConverter();
            DepartmentConverter = new DepartmentNameConverter();
            EquipmentTypeConverter = new EquipmentTypeNameConverter();
            RegencyConverter = new RegencyNameConverter();
            UnitMeasurConverter = new UnitMeasureNameConverter();
            EmployeeConverter = new EmployeeNameConverter();
            EquipmentConverter = new EquipmentNameConverter();
        }
    }
}