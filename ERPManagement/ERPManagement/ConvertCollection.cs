﻿using System;
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

        public static IValueConverter StatusConverter { get; set; }

        static ConvertCollection()
        {
            CompanyConverter = new CompanyNameConverter();
            DepartmentConverter = new DepartmentNameConverter();
            EquipmentTypeConverter = new EquipmentTypeNameConverter();
            RegencyConverter = new RegencyNameConverter();
            UnitMeasurConverter = new UnitMeasureNameConverter();
            EmployeeConverter = new EmployeeNameConverter();
            EquipmentConverter = new EquipmentNameConverter();
            StatusConverter = new StatusConverter();
        }

        public static String ConvertEmployee(int empID, EmployeeConvertation empConvert = EmployeeConvertation.Name)
        {
            Object result = EmployeeConverter.Convert(empID, typeof(String), empConvert, System.Globalization.CultureInfo.CurrentCulture);
            if (empConvert != EmployeeConvertation.Regency)
                return result.ToString();
            else
            {
                return ConvertRegency(System.Convert.ToInt32(result));
            }
        }

        public static String ConvertEquipment(int equipmentID, ConvertInfomation cvInfo)
        {
            return EquipmentConverter.Convert(equipmentID, typeof(String), cvInfo, System.Globalization.CultureInfo.CurrentCulture).ToString();
        }

        public static String ConvertStatus(int statusID)
        {
            return StatusConverter.Convert(statusID, typeof(String), null, System.Globalization.CultureInfo.CurrentCulture).ToString();
        }

        public static String ConvertRegency(int regencyID)
        {
            return RegencyConverter.Convert(regencyID, typeof(String), null, System.Globalization.CultureInfo.CurrentCulture).ToString();
        }
    }
}