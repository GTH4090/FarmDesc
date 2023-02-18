using FarmDesc.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using static FarmDesc.Classes.GetData;
using static FarmDesc.Classes.Helper;
using FarmDesc.Models;

namespace FarmDesc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        
        public FirstWindow()
        {
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += Timer_Tick;
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Db.AirSensorsLogs.AddRange(GetAirSensorsData());
            Db.LandSensorLogs.AddRange(GetLandSensorsData());
            Db.SaveChanges();
            AvargeAirLogs log = new AvargeAirLogs();
            log.Date = Db.AirSensorsLogs.Where(el => el.id == 1 && el.date >= DateNow).OrderByDescending(el => el.date).FirstOrDefault().date;
            var sens1 = Db.AirSensorsLogs.Where(el => el.id == 1).OrderByDescending(el => el.date).FirstOrDefault();
            var sens2 = Db.AirSensorsLogs.Where(el => el.id == 2).OrderByDescending(el => el.date).FirstOrDefault();
            var sens3 = Db.AirSensorsLogs.Where(el => el.id == 3).OrderByDescending(el => el.date).FirstOrDefault();
            var sens4 = Db.AirSensorsLogs.Where(el => el.id == 4).OrderByDescending(el => el.date).FirstOrDefault();

            log.humidity = (sens1.humidity + sens2.humidity + sens3.humidity + sens4.humidity) / 4;
            log.temperature = (sens1.temperature + sens2.temperature + sens3.temperature + sens4.temperature) / 4;

            Db.AvargeAirLogs.Add(log);
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if(MainFrame.CanGoBack == false)
            {
                BackBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                BackBtn.Visibility = Visibility.Visible; 
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
            DateNow = DateTime.Now;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
