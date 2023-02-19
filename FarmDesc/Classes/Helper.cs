using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmDesc.Models;
using System.Windows;

namespace FarmDesc.Classes
{
    public static class Helper
    {
        public static mainEntities Db = new mainEntities();

        public static DateTime DateNow;

        public static bool IsExtramod = false;
        
        public static void Error(string error ="Ошибка БД")
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
