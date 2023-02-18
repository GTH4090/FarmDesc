using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
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
    /// Логика взаимодействия для LandSensorsControlPage.xaml
    /// </summary>
    public partial class LandSensorsControlPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public LandSensorsControlPage()
        {
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += Timer_Tick; ;
            InitializeComponent();
        }

        private void GraphGen()
        {

            try
            {
                SensorsGraph.ChartAreas.Add(new ChartArea("Сенсоры"));
                SensorsGraph.ChartAreas["Сенсоры"].AxisY.Interval = 5;


                


                Series ser1Hum = new Series("Сенсор1Влаж");
                ser1Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser1Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                


                Series ser2Hum = new Series("Сенсор2Влаж");
                ser2Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser2Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                


                Series ser3Hum = new Series("Сенсор3Влаж");
                ser3Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser3Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                


                Series ser4Hum = new Series("Сенсор4Влаж");
                ser4Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser4Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;

                Series ser5Hum = new Series("Сенсор5Влаж");
                ser5Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser5Hum);
                SensorsGraph.Series[0].XValueType = ChartValueType.DateTime;




                Series ser6Hum = new Series("Сенсор6Влаж");
                ser6Hum.ChartType = SeriesChartType.Line;
                SensorsGraph.Series.Add(ser6Hum);
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
                

                var ox11 = Db.LandSensorLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy11 = Db.LandSensorLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор1Влаж"].Points.DataBindXY(ox11, oy11);

                
                var ox21 = Db.LandSensorLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy21 = Db.LandSensorLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор2Влаж"].Points.DataBindXY(ox21, oy21);

                
                var ox31 = Db.LandSensorLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy31 = Db.LandSensorLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор3Влаж"].Points.DataBindXY(ox31, oy31);


                var ox41 = Db.LandSensorLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy41 = Db.LandSensorLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор4Влаж"].Points.DataBindXY(ox41, oy41);

                var ox51 = Db.LandSensorLogs.Where(el => el.id == 5 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy51 = Db.LandSensorLogs.Where(el => el.id == 5 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор5Влаж"].Points.DataBindXY(ox51, oy51);


                var ox61 = Db.LandSensorLogs.Where(el => el.id == 6 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.date);
                var oy61 = Db.LandSensorLogs.Where(el => el.id == 6 && el.date > DateNow).OrderByDescending(el => el.date).Select(el => el.humidity);
                SensorsGraph.Series["Сенсор4Влаж"].Points.DataBindXY(ox61, oy61);


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
                Sensor1Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 1 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor2Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 2 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor3Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 3 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor4Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 4 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor5Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 5 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
                Sensor6Datagrid.ItemsSource = Db.LandSensorLogs.Where(el => el.id == 6 && el.date > DateNow).OrderByDescending(el => el.date).ToList();
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
            GraphData();

            timer.Start();
        }
    }
}
