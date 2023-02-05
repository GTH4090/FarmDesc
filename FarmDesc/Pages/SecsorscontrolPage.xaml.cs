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
using System.Windows.Threading;
using static FarmDesc.Classes.Helper;
using FarmDesc.Models;

namespace FarmDesc.Pages
{
    /// <summary>
    /// Логика взаимодействия для SecsorscontrolPage.xaml
    /// </summary>
    public partial class SecsorscontrolPage : Page
    {
        
        DispatcherTimer timer = new DispatcherTimer();
        public SecsorscontrolPage()
        {
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += Timer_Tick;
            InitializeComponent();
        }
        private void DataLoad()
        {

            try
            {
                Sensor1Datagrid.ItemsSource = Db.AirSensorsLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor2Datagrid.ItemsSource = Db.AirSensorsLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor3Datagrid.ItemsSource = Db.AirSensorsLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor4Datagrid.ItemsSource = Db.AirSensorsLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DataLoad();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            DataLoad();
            timer.Start();
        }
    }
}
