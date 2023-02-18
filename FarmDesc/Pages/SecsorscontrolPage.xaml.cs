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
using System.Windows.Forms.DataVisualization.Charting;

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
        private void GraphGen()
        {

            try
            {
                SensorsGraph.ChartAreas.Add(new ChartArea("Сенсоры"));
                SensorsGraph.ChartAreas["Сенсоры"].AxisY.Interval = 5;


                Series ser = new Series("Сенсор1Темп");
                ser.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;
                

                Series ser1Hum = new Series("Сенсор1Влаж");
                ser1Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser1Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                Series ser2 = new Series("Сенсор2Темп");
                ser2.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser2);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;


                Series ser2Hum = new Series("Сенсор2Влаж");
                ser2Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser2Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                Series ser3 = new Series("Сенсор3Темп");
                ser3.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser3);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;


                Series ser3Hum = new Series("Сенсор3Влаж");
                ser3Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser3Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                Series ser4 = new Series("Сенсор4Темп");
                ser4.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser4);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;


                Series ser4Hum = new Series("Сенсор4Влаж");
                ser4Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser4Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                SensorsGraph.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd hh:mm:ss";

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
        private void GraphData()
        {

            try
            {
                var ox1 = Db.AirSensorsLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy1 = Db.AirSensorsLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.temperature);
                SensorsGraph.Series["Сенсор1Темп"].Points.DataBindXY(ox1, oy1);

                var ox11 = Db.AirSensorsLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy11 = Db.AirSensorsLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор1Влаж"].Points.DataBindXY(ox11, oy11);

                var ox2 = Db.AirSensorsLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy2 = Db.AirSensorsLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.temperature);
                SensorsGraph.Series["Сенсор2Темп"].Points.DataBindXY(ox2, oy2);

                var ox21 = Db.AirSensorsLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy21 = Db.AirSensorsLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор2Влаж"].Points.DataBindXY(ox21, oy21);

                var ox3 = Db.AirSensorsLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy3 = Db.AirSensorsLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.temperature);
                SensorsGraph.Series["Сенсор3Темп"].Points.DataBindXY(ox3, oy3);

                var ox31 = Db.AirSensorsLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy31 = Db.AirSensorsLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор3Влаж"].Points.DataBindXY(ox31, oy31);

                var ox4 = Db.AirSensorsLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy4 = Db.AirSensorsLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.temperature);
                SensorsGraph.Series["Сенсор3Темп"].Points.DataBindXY(ox4, oy4);

                var ox41 = Db.AirSensorsLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy41 = Db.AirSensorsLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор4Влаж"].Points.DataBindXY(ox41, oy41);

                
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
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
            GraphData();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            DataLoad();
            GraphGen();
            
            timer.Start();
        }
    }
}
