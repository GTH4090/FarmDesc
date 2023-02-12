using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FarmDesc.Classes.Helper;
using FarmDesc.Models;

namespace FarmDesc.Pages
{
    /// <summary>
    /// Логика взаимодействия для WinControlPage.xaml
    /// </summary>
    public partial class PropertiesPage : Page
    {
        public PropertiesPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Db.Properties.FirstOrDefault(el => el.Id == 1).Value = Convert.ToDecimal(TempTbx.Text);
                Db.Properties.FirstOrDefault(el => el.Id == 2).Value = Convert.ToDecimal(AirHumTbx.Text);
                Db.Properties.FirstOrDefault(el => el.Id == 3).Value = Convert.ToDecimal(LandHumTbx.Text);
                Db.SaveChanges();
                MessageBox.Show("Настройки сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                TempTbx.Text = Db.Properties.FirstOrDefault(el => el.Id == 1).Value.ToString();
                AirHumTbx.Text = Db.Properties.FirstOrDefault(el => el.Id == 2).Value.ToString();
                LandHumTbx.Text = Db.Properties.FirstOrDefault(el => el.Id == 3).Value.ToString();
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
