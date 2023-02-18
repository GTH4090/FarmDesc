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
using System.Windows.Threading;

namespace FarmDesc.Pages
{
    /// <summary>
    /// Логика взаимодействия для AvargePage.xaml
    /// </summary>
    public partial class AvargePage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();

        public AvargePage()
        {
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += Timer_Tick; ;
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void DataLoad()
        {

            try
            {
                SensorsDatagrid.ItemsSource = Db.AvargeAirLogs.OrderByDescending(el => el.Date).Where(el => el.Date >= DateNow).ToList();
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataLoad();
            timer.Start();
        }
    }
}
