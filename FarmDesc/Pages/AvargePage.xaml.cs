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
using static FarmDesc.Classes.GetData;
using FarmDesc.Models;
using System.Windows.Threading;
using System.Windows.Forms.DataVisualization.Charting;

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
        private void GraphGen()
        {

            try
            {
                MainChart.ChartAreas.Add(new ChartArea("Среднее значение"));
                Series ser = new Series("СредТемп");
                ser.ChartType = SeriesChartType.Line;
                MainChart.Series.Add(ser);
                MainChart.Series[0].XValueType = ChartValueType.DateTime;

                Series ser2 = new Series("СредВлаж");
                ser2.ChartType = SeriesChartType.Line;
                MainChart.Series.Add(ser2);
                MainChart.Series[1].XValueType = ChartValueType.DateTime;

                MainChart.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd hh:mm:ss";

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DataLoad();
            BtnsStat();
        }

        private void DataLoad()
        {

            try
            {
                SensorsDatagrid.ItemsSource = Db.AvargeAirLogs.OrderByDescending(el => el.Date).Where(el => el.Date >= DateNow).ToList();

                var ox = Db.AvargeAirLogs.OrderByDescending(el => el.Date).Where(el => el.Date >= DateNow).Select(el => el.Date);
                var oy = Db.AvargeAirLogs.OrderByDescending(el => el.Date).Where(el => el.Date >= DateNow).Select(el => el.temperature);

                MainChart.Series["СредТемп"].Points.DataBindXY(ox, oy);

                var ox1 = Db.AvargeAirLogs.OrderByDescending(el => el.Date).Where(el => el.Date >= DateNow).Select(el => el.Date);
                var oy1 = Db.AvargeAirLogs.OrderByDescending(el => el.Date).Where(el => el.Date >= DateNow).Select(el => el.humidity);

                MainChart.Series["СредВлаж"].Points.DataBindXY(ox1, oy1);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
        private void BtnsStat()
        {

            try
            {
                if(Db.Devices.FirstOrDefault(el => el.Id == 8).State == false)
                {
                    WinStatBtn.Content = "Открыть форточку";
                    if(Db.AvargeAirLogs.OrderByDescending(el => el.Date).FirstOrDefault().temperature > Db.Properties.FirstOrDefault(el => el.Id == 1).Value || IsExtramod == true)
                    {
                        WinStatBtn.IsEnabled = true;
                    }
                    else
                    {
                        WinStatBtn.IsEnabled = false;
                    }
                }
                else
                {
                    WinStatBtn.Content = "Закрыть форточку";
                    WinStatBtn.IsEnabled = true;
                }

                if (Db.Devices.FirstOrDefault(el => el.Id == 1).State == false)
                {
                    HumStatBtn.Content = "Открыть систему увлажнения";
                    if (Db.AvargeAirLogs.OrderByDescending(el => el.Date).FirstOrDefault().humidity < Db.Properties.FirstOrDefault(el => el.Id == 2).Value || IsExtramod == true)
                    {
                        HumStatBtn.IsEnabled = true;
                    }
                    else
                    {
                        HumStatBtn.IsEnabled = false;
                    }
                }
                else
                {
                    HumStatBtn.Content = "Закрыть систему увлажнения";
                    HumStatBtn.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GraphGen();
            DataLoad();
            BtnsStat();
            timer.Start();
        }

        private void WinStatBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if(WinStatBtn.Content == "Открыть форточку")
                {
                    if(WindowState(1) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 8).State = true;
                        Db.SaveChanges();
                        BtnsStat();
                        MessageBox.Show("Форточка открыта");
                    }
                    else
                    {
                        Error("Ошибка открытия форточки");
                    }
                    
                }
                else
                {
                    if (WindowState(0) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 8).State = false;
                        Db.SaveChanges();
                        BtnsStat();
                        MessageBox.Show("Форточка закрыта");
                    }
                    else
                    {
                        Error("Ошибка закрытия форточки");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void HumStatBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HumStatBtn.Content == "Открыть систему увлажнения")
                {
                    if (HumState(1) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 1).State = true;
                        Db.SaveChanges();
                        BtnsStat();
                        MessageBox.Show("Система увлажнения открыта");
                    }
                    else
                    {
                        Error("Ошибка системы увлажнения");
                    }

                }
                else
                {
                    if (HumState(0) == true)
                    {
                        Db.Devices.FirstOrDefault(el => el.Id == 1).State = false;
                        Db.SaveChanges();
                        BtnsStat();
                        MessageBox.Show("Система увлажнения закрыта");
                    }
                    else
                    {
                        Error("Ошибка системы увлажнения");
                    }

                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
